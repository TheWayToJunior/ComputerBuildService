using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerBuildService.DAL.Entities
{
    public class CompatibilityPropertyEntity : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [StringLength(128)]
        public string PropertyType { get; set; }

        public string PropertyName { get; set; }

        public ICollection<CompatibilityPropertyHardwareItem> PropertysItems { get; set; }
    }
}
