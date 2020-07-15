using AutoMapper;
using ComputerBuildService.Server.IServices;
using ComputerBuildService.Shared.Models;
using ComputerBuildService.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComputerBuildService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphicsCardController : GenericController<GraphicsCard, GraphicsViewModel, int>
    {
        public GraphicsCardController(IApplicationDbService<GraphicsCard, int> servise,
           IMapper mapper, ILogger<GraphicsCardController> logger) : base(servise, mapper, logger)
        {
        }
    }
}
