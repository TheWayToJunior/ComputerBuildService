using ComputerBuildService.BL.IServices;
using ComputerBuildService.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardwareItemController : ControllerBase
    {
        private readonly IHardwareItemService service;

        public HardwareItemController(IHardwareItemService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ResultObject<HardwareItemResponse>>> GetAll(
            [FromQuery] Pagination pagination,
            [FromBody] SelectingHardware selecting)
        {
            var result = await service.GetHardwareItem(pagination, selecting);

            return Ok(result);
        }
    }
}
