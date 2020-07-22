using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.Shared.ModelBase
{
    public abstract class ProcessorBase
    {
        public string Maker { get; set; }

        public string RangeOf { get; set; }

        public string Model { get; set; }

        public string Socket { get; set; }

        public int FrequencyCore { get; set; }

        public int NumberOfCores { get; set; }
    }
}
