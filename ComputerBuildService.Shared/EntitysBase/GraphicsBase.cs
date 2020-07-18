using System.ComponentModel.DataAnnotations;

namespace ComputerBuildService.Shared.EntitysBase
{
    public abstract class GraphicsBase
    {
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Частота графического процессора
        /// </summary>
        [Required]
        public int FrequencyGraphicsProcessor { get; set; }

        [Required]
        [MaxLength(12)]
        public string VideoMemoryType { get; set; }

        /// <summary>
        /// Частота видеопамяти
        /// </summary>
        [Required]
        public int FrequencyVideoMemory { get; set; }

        /// <summary>
        /// Объем видео памяти
        /// </summary>
        [Required]
        public int VideoMemoryAmount { get; set; }
    }
}
