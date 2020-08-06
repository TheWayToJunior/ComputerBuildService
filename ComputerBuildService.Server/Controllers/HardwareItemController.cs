using ComputerBuildService.BL.IServices;
using ComputerBuildService.BL.Models;
using ComputerBuildService.BL.Models.Requests;
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

        [HttpPost]
        public async Task<ActionResult<ResultObject<HardwareItemResponse>>> Add([FromBody] HardwareItemRequest request)
        {
            var result = await service.AddHardwareItem(request);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ResultObject<HardwareItemResponse>>> Update([FromBody] HardwareItemRequest request)
        {
            var result = await service.UpdateHardwareItem(request);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultObject<HardwareItemResponse>>> Delete(int id)
        {
            var result = await service.DeleteHardwareItem(id);

            return Ok(result);
        }
    }
}
