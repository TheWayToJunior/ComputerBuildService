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
            #region Processor entity Mapping

            /// Response
            CreateMap<Processor, ProcessorResponse>();
            CreateMap<ProcessorResponse, Processor>();

            CreateMap<Processor, ProcessorInfo>();

            /// Request
            CreateMap<Processor, ProcessorRequest>();
            CreateMap<ProcessorRequest, Processor>();

            #endregion

            #region GraphicsCard entity Mapping

            /// Response
            CreateMap<GraphicsCard, GraphicsResponse>();
            CreateMap<GraphicsResponse, GraphicsCard>();

            /// Request
            CreateMap<GraphicsCard, GraphicsRequest>();
            CreateMap<GraphicsRequest, GraphicsCard>();

            #endregion

            #region IntegratedGraphics entity Mapping

            /// Response
            CreateMap<IntegratedGraphics, IntegratedGraphicsResponse>();
            CreateMap<IntegratedGraphicsResponse, IntegratedGraphics>();

            CreateMap<IntegratedGraphics, IntegratedGraphicsInfo>();

            /// Request
            CreateMap<IntegratedGraphics, IntegratedGraphicsRequest>();
            CreateMap<IntegratedGraphicsRequest, IntegratedGraphics>();

            #endregion

            #region CpuСooler entity Mapping

            /// Response
            CreateMap<CpuСooler, CpuСoolerResponse>();
            CreateMap<CpuСoolerResponse, CpuСooler>();

            /// Request
            CreateMap<CpuСooler, CpuСoolerRequest>();
            CreateMap<CpuСoolerRequest, CpuСooler>();

            #endregion

            #region Motherboar entity Mapping

            /// Response
            CreateMap<Motherboard, MotherboardResponse>();
            CreateMap<MotherboardResponse, Motherboard>();

            CreateMap<Motherboard, MotherboardInfo>();

            /// Request
            CreateMap<Motherboard, MotherboardRequest>();
            CreateMap<MotherboardRequest, Motherboard>();

            #endregion

            #region RandomAccessMemory entity Mapping

            /// Response
            CreateMap<RandomAccessMemory, MemoryResponse>();
            CreateMap<MemoryResponse, RandomAccessMemory>();

            /// Request
            CreateMap<RandomAccessMemory, MemoryRequest>();
            CreateMap<MemoryRequest, RandomAccessMemory>();

            #endregion
        }
    }
}
