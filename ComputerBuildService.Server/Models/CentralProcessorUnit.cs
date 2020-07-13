using ComputerBuildService.Shared.Models.IntegratedModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerBuildService.Shared.Models
{
    public class CentralProcessorUnit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Maker { get; set; }

        /// <summary>
        /// Линейка процессоров
        /// </summary>
        [Required]
        public string RangeOf { get; set; }

        [Required]
        [MaxLength(32)]
        public string Model { get; set; }

        [Required]
        [MaxLength(16)]
        public string Socket { get; set; }

        /// <summary>
        /// Тактовая частота процессора
        /// </summary>
        [Required]
        public int FrequencyCore { get; set; }

        [Required]
        public int NumberOfCores { get; set; }

        public int? IntegratedGraphicsId { get; set; }

        [ForeignKey(nameof(IntegratedGraphicsId))]
        public virtual IntegratedGraphics IntegratedGraphics { get; set; }
    }
}
