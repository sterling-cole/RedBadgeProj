using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProj.Models
{
    public class DogListItem
    {
        public int DogId { get; set; }
        
        public string DogName { get; set; }
        [Display(Name = "Owner's Id")]
        public int OwnerId { get; set; }

    }
}
