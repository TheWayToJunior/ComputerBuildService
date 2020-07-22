using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputerBuildService.Shared.ModelBase
{
    public abstract class MotherboardBase
    {
        public string Name { get; set; }

        public string Chipset { get; set; }

        public string Socket { get; set; }

        public string FormFactor { get; set; }

        public string MemoryType { get; set; }

        public int MemorySlots { get; set; }

        public int MaximumMemory { get; set; }

        public string SoundCard { get; set; }

        public string NetworkInterface { get; set; }

        public string Connectors { get; set; }
    }
}
