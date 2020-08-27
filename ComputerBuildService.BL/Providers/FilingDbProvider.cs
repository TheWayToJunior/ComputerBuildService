using ComputerBuildService.BL.IServices;
using ComputerBuildService.BL.Models;
using ComputerBuildService.BL.Parser.CitilinkParsers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.BL.Services
{
    public class FilingDbProvider : IFilingDbProvider
    {
        private readonly IHardwareItemService service;
        private readonly IParserService parser;

        public FilingDbProvider(IHardwareItemService service, IParserService parser)
        {
            this.service = service;
            this.parser = parser;
        }

        public async Task<ResultObject<HardwareItemResponse>> FillHardwareItem(string type, string id)
        {
            var result = ResultObject<HardwareItemResponse>.Create();

            HardwareItemResponse response = null;

            try
            {
                var item = await parser.ParseItem(new CitilinkParserSettings($"{type}/{id}"), type);

                var serviceResult = await service.AddHardwareItem(item);

                if (!serviceResult.IsSuccess)
                    return result.AddErrors(serviceResult.Errors);

                response = serviceResult.Value;
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result.SetValue(response);
        }

        public async Task<ResultObject<IEnumerable<HardwareItemResponse>>> FillHardwareItems(string type, int start, int end)
        {
            var result = ResultObject<IEnumerable<HardwareItemResponse>>.Create();

            var list = new List<HardwareItemResponse>();

            try
            {
                var items = await parser.ParseItems(new CitilinkParserSettings(type, start, end), type);

                foreach (var item in items)
                {
                    var serviceResult = await service.AddHardwareItem(item);

                    if (!serviceResult.IsSuccess)
                    {
                        result.AddErrors(serviceResult.Errors);
                        continue;
                    }

                    list.Add(serviceResult.Value);
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result.SetValue(list);
        }
    }
}
