using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerBuildService.DAL.Entities
{
    public class HardwareItemEntity : IUniqueEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [StringLength(64)]
        public string Name { get; set; }

        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int ManufacturerId { get; set; }

        public ManufacturerEntity Manufacturer { get; set; }

        public int HardwareTypeId { get; set; }

        public HardwareTypeEntity HardwareType { get; set; }

        public ICollection<CompatibilityPropertyHardwareItem> PropertysItems { get; set; }
    }
}
