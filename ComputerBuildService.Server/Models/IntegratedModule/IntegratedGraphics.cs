using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerBuildService.Shared.Models.IntegratedModule
{
    public class IntegratedGraphics : GraphicsCard
    {
        public virtual ICollection<Processor> Processors { get; set; }

        public virtual ICollection<Motherboard> Motherboards { get; set; }
    }
}
