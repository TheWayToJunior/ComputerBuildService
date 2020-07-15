using ComputerBuildService.Server.IServices;
using ComputerBuildService.Server.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerBuildService.Shared.Models
{
    public class GraphicsCard : GraphicsBase
    {
        [Required]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
    }
}
