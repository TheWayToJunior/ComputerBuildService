using ComputerBuildService.Shared.EntitysBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerBuildService.Shared.Models
{
    public class CpuСooler : CpuСoolerBase, IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
    }
}
