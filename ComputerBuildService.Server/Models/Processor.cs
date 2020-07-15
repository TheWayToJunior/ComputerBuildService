using ComputerBuildService.Server.IServices;
using ComputerBuildService.Server.Models.Base;
using ComputerBuildService.Shared.Models.IntegratedModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerBuildService.Shared.Models
{
    public class Processor : ProcessorBase
    {
        [Required]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        public int? IntegratedGraphicsId { get; set; }

        [ForeignKey(nameof(IntegratedGraphicsId))]
        public virtual IntegratedGraphics IntegratedGraphics { get; set; }
    }
}
