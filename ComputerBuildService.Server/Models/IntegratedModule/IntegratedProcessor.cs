using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerBuildService.Shared.Models.IntegratedModule
{
    public class IntegratedProcessor : CentralProcessorUnit
    {
        public virtual ICollection<Motherboard> Motherboards { get; set; }
    }
}
