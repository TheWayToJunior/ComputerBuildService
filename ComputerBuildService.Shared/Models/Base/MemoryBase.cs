using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerBuildService.Server.ViewModel.Models.Base
{
    public class MemoryBase
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Frequency { get; set; }

        public int Amount { get; set; }

        public string Sockets { get; set; }
    }
}
