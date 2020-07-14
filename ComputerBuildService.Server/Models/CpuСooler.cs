using ComputerBuildService.Server.IServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace ComputerBuildService.Shared.Models
{
    public class CpuСooler : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(12)]
        public string SizeBlower { get; set; }

        [Required]
        [Range(1, 5)]
        public int NumberBlower { get; set; }

        public string RotationSpeed { get; set; }

        /// <summary>
        /// Уровень шума
        /// </summary>
        public string NoiseLevel { get; set; }

        /// <summary>
        /// Совместимые сокеты
        /// </summary>
        [Required]
        public string Sockets { get; set; }
    }
}
