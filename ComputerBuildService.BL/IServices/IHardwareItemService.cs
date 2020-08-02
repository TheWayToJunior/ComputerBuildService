using ComputerBuildService.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuildService.BL.IServices
{
    public interface IHardwareItemService
    {
        Task<ResultObject<IEnumerable<HardwareItemResponse>>> GetHardwareItem(
            Pagination pagination,
            SelectingHardware selecting);
    }
}
