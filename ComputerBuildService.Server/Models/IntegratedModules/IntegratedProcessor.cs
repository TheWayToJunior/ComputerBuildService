using ComputerBuildService.Server.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerBuildService.Shared.Models.IntegratedModule
{
    public class IntegratedProcessor : ProcessorBase
    {
        public virtual ICollection<Motherboard> Motherboards { get; set; }
    }
}
