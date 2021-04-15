using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProj.Models
{
   public  class DogCreate
    {
        [Required]
        public string DogName { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public string Breed { get; set; }
        [Display(Name = "Owner's Id")]
        public int OwnerId { get; set; }
    }
}
