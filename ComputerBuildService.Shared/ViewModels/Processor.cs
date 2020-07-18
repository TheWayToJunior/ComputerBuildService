using ComputerBuildService.Shared.EntitysBase;

namespace ComputerBuildService.Shared.ViewModels
{
    public class ProcessorResponse : ProcessorBase
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public IntegratedGraphicsInfo IntegratedGraphics { get; set; }
    }

    public class ProcessorRequest : ProcessorBase
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int IntegratedGraphicsId { get; set; }
    }

    /// <summary>
    /// Объект предназначенный для отображения сонвной информации модели
    /// </summary>
    public class ProcessorInfo : ProcessorBase
    {
    }
}
