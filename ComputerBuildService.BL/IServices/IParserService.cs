using ComputerBuildService.BL.Models.Requests;
using ComputerBuildService.BL.Parser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.BL.IServices
{
    public interface IParserService
    {
        Task<IEnumerable<HardwareItemRequest>> ParseItems(IParserSettings settings, string type);

        Task<HardwareItemRequest> ParseItem(IParserSettings settings, string type);
    }
}
