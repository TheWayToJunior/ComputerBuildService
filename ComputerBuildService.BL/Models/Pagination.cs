using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerBuildService.BL.Models
{
    public class Pagination
    {
        public int Index { get; set; } = 1;

        public int Size { get; set; } = 5;
    }
}
