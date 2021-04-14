﻿using RedBadgeProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProj.Models.EventModels
{
    public class EventCreate
    { 
        public string Note { get; set; }
        public EventType EventType { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public int DogId { get; set; }
    }
}
