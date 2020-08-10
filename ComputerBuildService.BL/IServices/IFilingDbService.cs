using ComputerBuildService.BL.Models;
using ComputerBuildService.BL.Parser;
using System.Threading.Tasks;

namespace ComputerBuildService.BL.IServices
{
    public interface IFilingDbService
    {
        Task<ResultObject<HardwareItemResponse>> Fill(IParserSettings settings, string parseItemType);
    }
}
