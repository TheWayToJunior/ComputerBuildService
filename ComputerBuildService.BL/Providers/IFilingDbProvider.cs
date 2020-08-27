using ComputerBuildService.BL.Models;
using ComputerBuildService.BL.Parser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.BL.IServices
{
    public interface IFilingDbProvider
    {
        Task<ResultObject<HardwareItemResponse>> FillHardwareItem(string type, string id);

        Task<ResultObject<IEnumerable<HardwareItemResponse>>> FillHardwareItems(string type, int start, int end);
    }
}
