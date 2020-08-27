using ComputerBuildService.BL.IProviders;
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
        private readonly IFilingDbProvider provider;

        public FillDatabaseController(IFilingDbProvider provider)
        {
            this.provider = provider;
        }

        [HttpPost("{type}/{id}")]
        public async Task<ActionResult<ResultObject<HardwareItemResponse>>> FillHardwareItem(string type, string id)
        {
            var result = await provider.FillHardwareItem(type, id);

            return result;
        }

        [HttpPost("{type}")]
        public async Task<ActionResult<ResultObject<IEnumerable<HardwareItemResponse>>>> FillHardwareItems(
            string type, int start, int end)
        {
            var result = await provider.FillHardwareItems(type, start, end);

            return result;
        }
    }
}
