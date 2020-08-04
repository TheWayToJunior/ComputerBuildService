using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerBuildService.BL.Models.Requests
{
    public class HardwareItemRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        public string HardwareType { get; set; }

        public IEnumerable<CompatibilityPropertyRequest> PropertysItems { get; set; }
    }
}
