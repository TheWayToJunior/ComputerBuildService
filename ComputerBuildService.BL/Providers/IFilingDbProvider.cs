using ComputerBuildService.BL.Models;
using ComputerBuildService.BL.Parser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.BL.IServices
{
    public interface IFilingDbProvider
    {
        Task<ResultObject<IEnumerable<HardwareItemResponse>>> FillHardwareItems(IParserSettings settings, string parseItemType);

        Task<ResultObject<HardwareItemResponse>> FillHardwareItem(IParserSettings settings, string parseItemType);
    }
}
