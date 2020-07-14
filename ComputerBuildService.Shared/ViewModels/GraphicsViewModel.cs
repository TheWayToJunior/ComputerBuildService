using ComputerBuildService;

namespace ComputerBuildService.Shared.ViewModels
{
    public class GraphicsViewModel : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Частота графического процессора
        /// </summary>
        public int FrequencyGraphicsProcessor { get; set; }

        public string VideoMemoryType { get; set; }

        /// <summary>
        /// Частота видеопамяти
        /// </summary>
        public int FrequencyVideoMemory { get; set; }

        /// <summary>
        /// Объем видео памяти
        /// </summary>
        public int VideoMemoryAmount { get; set; }
    }
}
