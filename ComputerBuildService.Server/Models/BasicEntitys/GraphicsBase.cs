﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Models.Base
{
    public class GraphicsBase : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Частота графического процессора
        /// </summary>
        [Required]
        public int FrequencyGraphicsProcessor { get; set; }

        [Required]
        [MaxLength(12)]
        public string VideoMemoryType { get; set; }

        /// <summary>
        /// Частота видеопамяти
        /// </summary>
        [Required]
        public int FrequencyVideoMemory { get; set; }

        /// <summary>
        /// Объем видео памяти
        /// </summary>
        [Required]
        public int VideoMemoryAmount { get; set; }
    }
}