using ComputerBuildService.Shared.ModelBase;

namespace ComputerBuildService.Shared.ViewModels
{
    public class GraphicsResponse : GraphicsBase
    {
        public int Id { get; set; }

        public decimal Price { get; set; }
    }

    public class GraphicsRequest : GraphicsBase
    {
        public int Id { get; set; }

        public decimal Price { get; set; }
    }
}
