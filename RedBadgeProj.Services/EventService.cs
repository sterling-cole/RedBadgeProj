using RedBadgeProj.Data;
using RedBadgeProj.Models.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProj.Services
{
    
    public  class EventService
    {
        public bool CreateEvent(EventCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newEvent = new Event()
                {
                    Note = model.Note,
                    EventType = model.EventType,
                    CreatedUtc = DateTimeOffset.Now,
                    DogId = model.DogId
                };
                ctx.Events.Add(newEvent);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool UpdateEvent(EventEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var Event = ctx.Events.Single(e => e.EventId == model.EventId);
                Event.Note = model.Note;
                Event.EventType = model.EventType;
                Event.ModifiedUtc = DateTimeOffset.UtcNow;
                Event.DogId = model.DogId;
                return ctx.SaveChanges() == 1;

            }
        }
        public EventDetail GetEventDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var Event = ctx.Events.Single(e => e.EventId == id);
                return new EventDetail
                {
                    EventId = Event.EventId,
                    Note = Event.Note,
                    EventType = Event.EventType,
                    CreatedUtc = Event.CreatedUtc,
                    DogId = Event.DogId
                };
            }
        }
        public IEnumerable<EventListItem> GetEventList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Events.Select(e => new EventListItem
                {
                    EventId = e.EventId,
                    Note = e.Note,
                    EventType = e.EventType,
                    CreatedUtc = e.CreatedUtc,
                    DogId = e.DogId
                });
                return query.ToArray();
            }
        }
        public IEnumerable<Event> GetEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Events.ToList();
            }
        }

    }
}
