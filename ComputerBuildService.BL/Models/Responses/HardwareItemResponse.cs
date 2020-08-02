using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerBuildService.BL.Models
{
    public class HardwareItemResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        public string HardwareType { get; set; }

        public IEnumerable<CompatibilityPropertyResponse> PropertysItems { get; set; }
    }
}
