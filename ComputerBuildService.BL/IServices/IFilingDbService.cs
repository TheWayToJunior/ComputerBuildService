using ComputerBuildService.BL.Models;
using ComputerBuildService.BL.Parser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.BL.IServices
{
    public interface IFilingDbService
    {
        Task<ResultObject<IEnumerable<HardwareItemResponse>>> Fill(IParserSettings settings, string parseItemType);
    }
}
