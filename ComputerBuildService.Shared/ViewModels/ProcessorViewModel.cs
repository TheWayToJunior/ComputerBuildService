using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerBuildService.Shared.ViewModels
{
    public class ProcessorViewModel : IEntity<int>
    {
        public int Id { get; set; }

        public string Maker { get; set; }

        /// <summary>
        /// Линейка процессоров
        /// </summary>
        public string RangeOf { get; set; }

        public string Model { get; set; }

        public string Socket { get; set; }

        /// <summary>
        /// Тактовая частота процессора
        /// </summary>
        public int FrequencyCore { get; set; }

        public int NumberOfCores { get; set; }

        public int IntegratedGraphicsId { get; set; }

        public GraphicsViewModel IntegratedGraphics { get; set; }
    }
}
