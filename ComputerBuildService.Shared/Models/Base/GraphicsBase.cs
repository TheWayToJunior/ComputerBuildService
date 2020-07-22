using System.ComponentModel.DataAnnotations;

namespace ComputerBuildService.Shared.ModelBase
{
    public abstract class GraphicsBase
    {
        public string Name { get; set; }

        public int FrequencyGraphicsProcessor { get; set; }

        public string VideoMemoryType { get; set; }

        public int FrequencyVideoMemory { get; set; }

        public int VideoMemoryAmount { get; set; }
    }
}
