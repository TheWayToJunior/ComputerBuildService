using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerBuildService.BL.Models;
using ComputerBuildService.BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerBuildService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardwareItemController : ControllerBase
    {
        private readonly HardwareItemService service;

        public HardwareItemController(HardwareItemService service)
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
