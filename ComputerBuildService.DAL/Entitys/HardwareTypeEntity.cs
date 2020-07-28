using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerBuildService.DAL.Entitys
{
    public class HardwareTypeEntity : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        public string TypeName { get; set; }

        public ICollection<HardwareItemEntity> HardwareItems { get; set; }
    }
}
