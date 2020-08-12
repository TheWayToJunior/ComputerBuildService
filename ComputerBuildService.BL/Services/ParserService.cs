using ComputerBuildService.BL.IServices;
using ComputerBuildService.BL.Models.Requests;
using ComputerBuildService.BL.Parser;
using ComputerBuildService.BL.Parser.CitilinkParser;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ComputerBuildService.BL.Services
{
    public class ParserService : IParserService
    {
        private readonly ILogger<ParserService> logger;

        public ParserService(ILogger<ParserService> logger)
        {
            this.logger = logger;
        }

        public async Task<HardwareItemRequest> ParseItem(IParserSettings settings, string type)
        {
            HardwareItemRequest item = null;

            try
            {
                item = await ParseProductItem(settings.BaseUrl);
                item.HardwareType = type;
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.Message} at the {settings.BaseUrl}");
            }

            return item;
        }

        public async Task<IEnumerable<HardwareItemRequest>> ParseItems(IParserSettings settings, string type)
        {
            var items = new List<HardwareItemRequest>();

            var productsId = await ParseProductId(settings);


            foreach (var id in productsId)
            {
                await Task.Delay(10000); /// lazy way to avoid captcha 

                try
                {
                    var item = await ParseProductItem($"{settings.BaseUrl}/{id}");
                    item.HardwareType = type;

                    items.Add(item);
                }
                catch (HttpRequestException ex)
                {
                    logger.LogError($"{ex.Message}: {items.Count}");
                    break;
                }
                catch (Exception ex)
                {
                    logger.LogError($"{ex.Message} at the {settings.BaseUrl}/{id}");
                    continue;
                }
            }

            return items;
        }

        private async Task<IEnumerable<string>> ParseProductId(IParserSettings settings)
        {
            var productsId = new List<string>();

            var parser = new ParserWorker<string[]>(new CitilinkParserId());

            parser.OnCompleted += (s, e) => { productsId.AddRange(e); };

            for (int i = settings.StartPoint; i <= settings.EndPoint; i++)
            {
                parser.Uri = $"{settings.BaseUrl}/?{settings.Prefix}={i}";

                await parser.Start();
            }

            return productsId;
        }

        private async Task<HardwareItemRequest> ParseProductItem(string uri)
        {
            var item = new HardwareItemRequest();

            var parser = new ParserWorker<HardwareItemRequest>(new CitilinkParserItem());

            parser.OnCompleted += (s, e) =>
            {
                logger.LogInformation($"{e.Name} - successfully paired");
                item = e;
            };

            parser.Uri = uri;

            await parser.Start();

            return item;
        }
    }
}
