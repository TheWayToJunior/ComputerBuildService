using ComputerBuildService.Shared.EntitysBase;
using System.Collections.Generic;

namespace ComputerBuildService.Shared.ViewModels
{
    public class IntegratedGraphicsResponse : GraphicsBase
    {
        public int Id { get; set; }

        public IEnumerable<ProcessorInfo> Processors { get; set; }
    }

    public class IntegratedGraphicsRequest : GraphicsBase
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// Объект предназначенный для отображения сонвной информации модели
    /// </summary>
    public class IntegratedGraphicsInfo : GraphicsBase
    {
    }
}
