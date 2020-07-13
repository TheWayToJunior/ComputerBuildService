using System.ComponentModel.DataAnnotations;

namespace ComputerBuildService.Shared.Models
{
    public class RandomAccessMemory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(12)]
        public string Type { get; set; }

        /// <summary>
        /// Частота памяти
        /// </summary>
        [Required]
        public int Frequency { get; set; }

        /// <summary>
        /// Объем памяти
        /// </summary>
        [Required]
        public int Amount { get; set; }

        /// <summary>
        /// Совместимые сокеты
        /// </summary>
        [Required]
        public string Sockets { get; set; }
    }
}
