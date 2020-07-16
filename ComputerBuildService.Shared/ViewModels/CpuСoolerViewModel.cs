using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerBuildService.Shared.ViewModels
{
    public class CpuСoolerViewModel : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SizeBlower { get; set; }

        public int NumberBlower { get; set; }

        public string RotationSpeed { get; set; }

        /// <summary>
        /// Уровень шума
        /// </summary>
        public string NoiseLevel { get; set; }

        /// <summary>
        /// Совместимые сокеты
        /// </summary>
        public string Sockets { get; set; }
    }
}
