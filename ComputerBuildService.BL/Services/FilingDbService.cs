using ComputerBuildService.BL.IServices;
using ComputerBuildService.BL.Models;
using ComputerBuildService.BL.Parser;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.BL.Services
{
    public class FilingDbService : IFilingDbService
    {
        private readonly IHardwareItemService service;
        private readonly IParserService parser;

        public FilingDbService(IHardwareItemService service, IParserService parser)
        {
            this.service = service;
            this.parser = parser;
        }

        public async Task<ResultObject<HardwareItemResponse>> FillHardwareItem(IParserSettings settings, string parseItemType)
        {
            var result = ResultObject<HardwareItemResponse>.Create();

            HardwareItemResponse response = null;

            try
            {
                var item = await parser.ParseItem(settings, parseItemType);

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

        public async Task<ResultObject<IEnumerable<HardwareItemResponse>>> FillHardwareItems(IParserSettings settings, string parseItemType)
        {
            var result = ResultObject<IEnumerable<HardwareItemResponse>>.Create();

            var list = new List<HardwareItemResponse>();

            try
            {
                var items = await parser.ParseItems(settings, parseItemType);

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
