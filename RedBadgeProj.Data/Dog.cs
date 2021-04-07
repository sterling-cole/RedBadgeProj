﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProj.Data
{
    public class Dog
    {
        [Key]
        public int DogId { get; set; }
        [Required]
        public string DogName { get; set; }
        public int Weight { get; set; }
        public string Breed { get; set; }
        public int OwnerId { get; set; }
    }
}
