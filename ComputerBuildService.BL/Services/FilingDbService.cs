using ComputerBuildService.BL.IServices;
using ComputerBuildService.BL.Models;
using ComputerBuildService.BL.Parser;
using System;
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

        public async Task<ResultObject<HardwareItemResponse>> Fill(IParserSettings settings, string parseItemType)
        {
            var result = ResultObject<HardwareItemResponse>.Create();

            try
            {
                var items = await parser.Parse(settings, parseItemType);

                foreach (var item in items)
                {
                    var serviceResult = await service.AddHardwareItem(item);

                    if (!serviceResult.IsSuccess)
                        result.AddErrors(serviceResult.Errors);
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }
    }
}
