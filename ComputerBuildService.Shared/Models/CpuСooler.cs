using ComputerBuildService.Shared.ModelBase;

namespace ComputerBuildService.Shared.ViewModels
{
    public class CpuСoolerResponse : CpuСoolerBase
    {
        public int Id { get; set; }

        public decimal Proce { get; set; }
    }

    public class CpuСoolerRequest : CpuСoolerBase
    {
        public int Id { get; set; }

        public decimal Proce { get; set; }
    }
}
