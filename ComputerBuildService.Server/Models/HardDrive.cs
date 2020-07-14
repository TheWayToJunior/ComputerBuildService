using ComputerBuildService.Server.IServices;
using System.ComponentModel.DataAnnotations;

namespace ComputerBuildService.Shared.Models
{
    public class HardDrive : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Объем памяти
        /// </summary>
        [Required]
        public int Amount { get; set; }

        [Required]
        public string ConnectionInterface { get; set; }

        public string RotationSpeed { get; set; }
    }
}
