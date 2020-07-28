using ComputerBuildService.Server.ViewModel.Models.Base;

namespace ComputerBuildService.Shared.ViewModels
{
    public class MemoryResponse : MemoryBase
    {
        public int Id { get; set; }

        public decimal Price { get; set; }
    }

    public class MemoryRequest : MemoryBase
    {
        public int Id { get; set; }

        public decimal Price { get; set; }
    }
}
