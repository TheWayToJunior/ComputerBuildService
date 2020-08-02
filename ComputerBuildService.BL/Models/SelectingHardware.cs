using ComputerBuildService.BL.Models.Requests;
using System.Collections.Generic;

namespace ComputerBuildService.BL.Models
{
    public class SelectingHardware
    {
        public string Type { get; set; }

        public IEnumerable<CompatibilityPropertyRequest> СompatibilityProperties { get; set; }
    }
}
