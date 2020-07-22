using ComputerBuildService.Shared.ModelBase;

namespace ComputerBuildService.Shared.ViewModels
{
    public class MotherboardResponse : MotherboardBase
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        //public IntegratedProcessorInfo IntegratedProcessor { get; set; }

        public IntegratedGraphicsInfo IntegratedGraphics { get; set; }
    }

    public class MotherboardRequest : MotherboardBase
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int? IntegratedProcessorId { get; set; }

        public int? IntegratedGraphicsId { get; set; }
    }

    /// <summary>
    /// Объект предназначенный для отображения сонвной информации модели
    /// </summary>
    public class MotherboardInfo : MotherboardBase
    {
    }
}
