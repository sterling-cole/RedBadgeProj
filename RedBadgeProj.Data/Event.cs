using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProj.Data
{
    public enum EventType { Walked, Fed, Injury}
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Note { get; set; }
        public EventType EventType { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
