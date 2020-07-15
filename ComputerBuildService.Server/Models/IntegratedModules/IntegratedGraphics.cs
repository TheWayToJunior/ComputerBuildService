using ComputerBuildService.Server.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerBuildService.Shared.Models.IntegratedModule
{
    public class IntegratedGraphics : GraphicsBase
    {
        public virtual ICollection<Processor> Processors { get; set; }

        public virtual ICollection<Motherboard> Motherboards { get; set; }
    }
}
