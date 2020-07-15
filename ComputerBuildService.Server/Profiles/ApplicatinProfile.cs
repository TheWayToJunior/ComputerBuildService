using AutoMapper;
using ComputerBuildService.Shared.Models;
using ComputerBuildService.Shared.Models.IntegratedModule;
using ComputerBuildService.Shared.ViewModels;

namespace ComputerBuildService.Server.Profiles
{
    public class ApplicatinProfile : Profile
    {
        public ApplicatinProfile()
        {
            CreateMap<Processor, ProcessorViewModel>();
            CreateMap<ProcessorViewModel, Processor>()
                .ForMember(viewModel => viewModel.IntegratedGraphics, memberOptins => memberOptins.Ignore());

            CreateMap<GraphicsCard, GraphicsViewModel>();
            CreateMap<GraphicsViewModel, GraphicsCard>();

            CreateMap<IntegratedGraphics, GraphicsViewModel>();
            CreateMap<GraphicsViewModel, IntegratedGraphics>();
        }
    }
}
