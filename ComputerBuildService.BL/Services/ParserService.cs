using ComputerBuildService.BL.IServices;
using ComputerBuildService.BL.Models.Requests;
using ComputerBuildService.BL.Parser;
using ComputerBuildService.BL.Parser.CitilinkParser;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<HardwareItemRequest>> Parse(IParserSettings settings, string type)
        {
            var productsId = await ParseProductId(settings);

            var items = (await ParseItem(productsId, settings.BaseUrl))
                .Select(i => { i.HardwareType = type; return i; }).ToList();

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

        private async Task<IEnumerable<HardwareItemRequest>> ParseItem(IEnumerable<string> productsId, string url)
        {
            var productsItem = new List<HardwareItemRequest>();

            var parser = new ParserWorker<HardwareItemRequest>(new CitilinkParserItem());

            parser.OnCompleted += (s, e) =>
            {
                logger.LogInformation($"{e.Name} - successfully paired");
                productsItem.Add(e);
            };

            foreach (var id in productsId)
            {
                parser.Uri = $"{url}/{id}";

                try
                {
                    await Task.Delay(10000); /// lazy way to avoid captcha 
                    await parser.Start();
                }
                catch (HttpRequestException ex)
                {
                    logger.LogError($"{ex.Message}: {productsItem.Count}");
                    parser.Abort();
                    break;
                }
                catch (Exception ex)
                {
                    logger.LogError($"{ex.Message} at the {url}/{id}");
                    parser.Abort();
                    continue;
                }
            }

            return productsItem;
        }
    }
}
