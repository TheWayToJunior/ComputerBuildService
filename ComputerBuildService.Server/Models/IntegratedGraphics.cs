using ComputerBuildService.Server.Contract.EntitysBase;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerBuildService.Shared.Models.IntegratedModule
{
    public class IntegratedGraphics : GraphicsBase, IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Processor> Processors { get; set; }

        public virtual ICollection<Motherboard> Motherboards { get; set; }
    }
}
