using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerBuildService.BL.Models.Requests
{
    public class CompatibilityPropertyRequest
    {
        public string PropertyType { get; set; }

        public string PropertyName { get; set; }
    }
}
