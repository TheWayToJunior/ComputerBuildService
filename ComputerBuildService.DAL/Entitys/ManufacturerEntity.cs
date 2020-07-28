using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerBuildService.DAL.Entitys
{
    public class ManufacturerEntity : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<HardwareItemEntity> HardwareItems { get; set; }
    }
}
