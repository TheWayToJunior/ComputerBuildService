using System;
using System.ComponentModel.DataAnnotations;

namespace ComputerBuildService.Shared.ModelBase
{
    public abstract class CpuСoolerBase
    {
        public string Name { get; set; }

        public string SizeBlower { get; set; }

        public int NumberBlower { get; set; }

        public string RotationSpeed { get; set; }

        public string NoiseLevel { get; set; }

        public string Sockets { get; set; }
    }
}
