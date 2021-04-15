using RedBadgeProj.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProj.Models.EventModels
{
    public class EventDetail
    {
        public int EventId { get; set; }
        public string Note { get; set; }
        public EventType EventType { get; set; }
        [Display(Name = "Time of Event")]
        public DateTimeOffset CreatedUtc { get; set; }
        public int DogId { get; set; }
    }
}
