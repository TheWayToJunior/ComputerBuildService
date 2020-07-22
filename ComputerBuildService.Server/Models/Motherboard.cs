using ComputerBuildService.Shared.Models.IntegratedModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerBuildService.Shared.Models
{
    public class Motherboard : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(32)]
        public string Chipset { get; set; }

        [Required]
        [MaxLength(16)]
        public string Socket { get; set; }

        [MaxLength(32)]
        public string FormFactor { get; set; }

        [Required]
        [MaxLength(12)]
        public string MemoryType { get; set; }

        [Required]
        [Range(1, 6)]
        public int MemorySlots { get; set; }

        [Required]
        [Range(16, 256)]
        public int MaximumMemory { get; set; }

        public string SoundCard { get; set; }

        public string NetworkInterface { get; set; }

        /// <summary>
        /// Разъёмы на задней панели
        /// </summary>
        [Required]
        public string Connectors { get; set; }

        [Required]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        public int? IntegratedProcessorId { get; set; }

        public int? IntegratedGraphicsId { get; set; }

        [ForeignKey(nameof(IntegratedProcessorId))]
        public virtual IntegratedProcessor IntegratedProcessor { get; set; }

        [ForeignKey(nameof(IntegratedGraphicsId))]
        public virtual IntegratedGraphics IntegratedGraphics { get; set; }
    }
}
