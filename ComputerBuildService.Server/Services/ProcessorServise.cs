using ComputerBuildService.Server.Data;
using ComputerBuildService.Server.Helpers;
using ComputerBuildService.Server.IServices;
using ComputerBuildService.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Services
{
    public class ProcessorServise : ApplicationDbService<CentralProcessorUnit>, IProcessorServise
    {
        public ProcessorServise(ApplicationDbContext context) 
            : base(context)
        {
        }

        public new IQueryable<CentralProcessorUnit> GerRange(int index, int size = 5)
        {
            return base.GerRange(index, size)
                .Include(cpu => cpu.IntegratedGraphics);
        }
    }
}
