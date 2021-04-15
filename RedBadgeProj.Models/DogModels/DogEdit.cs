using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProj.Models
{
    public class DogEdit
    {
        public int DogId { get; set; }
        public string DogName { get; set; }
        public int Weight { get; set; }
        public string Breed { get; set; }
        [Display(Name = "Owner's Id")]
        public int OwnerId { get; set; }
    }
}
