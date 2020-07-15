using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Models.Base
{
    public class ProcessorBase : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Maker { get; set; }

        /// <summary>
        /// Линейка процессоров
        /// </summary>
        [Required]
        public string RangeOf { get; set; }

        [Required]
        [MaxLength(32)]
        public string Model { get; set; }

        [Required]
        [MaxLength(16)]
        public string Socket { get; set; }

        /// <summary>
        /// Тактовая частота процессора
        /// </summary>
        [Required]
        public int FrequencyCore { get; set; }

        [Required]
        public int NumberOfCores { get; set; }
    }
}
