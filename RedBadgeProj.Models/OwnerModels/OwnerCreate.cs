using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProj.Models.OwnerModels
{
    public class OwnerCreate
    {
        [Display(Name = "Owner") ]
        public string OwnerName { get; set; }
    }
}
