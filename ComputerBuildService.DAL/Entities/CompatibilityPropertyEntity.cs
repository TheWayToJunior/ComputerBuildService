using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerBuildService.DAL.Entities
{
    public class CompatibilityPropertyEntity : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [StringLength(32)]
        public string PropertyType { get; set; }

        [StringLength(64)]
        public string PropertyName { get; set; }

        public ICollection<CompatibilityPropertyHardwareItem> PropertysItems { get; set; }
    }
}
