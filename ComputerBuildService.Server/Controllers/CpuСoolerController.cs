using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ComputerBuildService.Server.IServices;
using ComputerBuildService.Shared.Models;
using ComputerBuildService.Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComputerBuildService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuСoolerController : GenericController<CpuСooler, CpuСoolerViewModel, int>
    {
        public CpuСoolerController(IApplicationDbService<CpuСooler, int> servise,
            IMapper mapper, ILogger<CpuСoolerController> logger) : base(servise, mapper, logger)
        {
        }
    }
}
