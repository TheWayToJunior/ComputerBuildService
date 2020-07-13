using AutoMapper;
using ComputerBuildService.Shared.Models;
using ComputerBuildService.Shared.Models.IntegratedModule;
using ComputerBuildService.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Profiles
{
    public class ApplicatinProfile : Profile
    {
        public ApplicatinProfile()
        {
            CreateMap<CentralProcessorUnit, ProcessorViewModel>();
            CreateMap<ProcessorViewModel, CentralProcessorUnit>();

            CreateMap<IntegratedGraphics, GraphicsViewModel>();
            CreateMap<GraphicsViewModel, IntegratedGraphics>();
        }
    }
}
