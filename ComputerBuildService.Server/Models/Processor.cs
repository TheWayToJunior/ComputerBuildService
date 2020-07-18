using ComputerBuildService.Shared.EntitysBase;
using ComputerBuildService.Shared.Models.IntegratedModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerBuildService.Shared.Models
{
    public class Processor : ProcessorBase, IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        public int? IntegratedGraphicsId { get; set; }

        [ForeignKey(nameof(IntegratedGraphicsId))]
        public virtual IntegratedGraphics IntegratedGraphics { get; set; }
    }
}
