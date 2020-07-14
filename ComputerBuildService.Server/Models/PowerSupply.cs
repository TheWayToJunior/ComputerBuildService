using ComputerBuildService.Server.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputerBuildService.Shared.Models
{
    public class PowerSupply : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Power { get; set; }
    }
}
