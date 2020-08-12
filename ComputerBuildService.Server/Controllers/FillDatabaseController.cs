using ComputerBuildService.BL.IServices;
using ComputerBuildService.BL.Models;
using ComputerBuildService.BL.Parser.CitilinkParsers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class FillDatabaseController : ControllerBase
    {
        private readonly IFilingDbService service;

        public FillDatabaseController(IFilingDbService service)
        {
            this.service = service;
        }

        [HttpPost("{type}")]
        public async Task<ActionResult<ResultObject<IEnumerable<HardwareItemResponse>>>> FillHardwareItems(
            string type, int start, int end)
        {
            var result = await service.FillHardwareItems(new CitilinkParserSettings(type, start, end), type);

            return result;
        }

        [HttpPost("{type}/{id}")]
        public async Task<ActionResult<ResultObject<HardwareItemResponse>>> FillHardwareItem(string type, string id)
        {
            var result = await service.FillHardwareItem(new CitilinkParserSettings($"{type}/{id}"), type);

            return result;
        }
    }
}
