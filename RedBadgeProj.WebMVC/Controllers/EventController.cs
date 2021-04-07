using RedBadgeProj.Models.EventModels;
using RedBadgeProj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeProj.WebMVC.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.Title = "New Event";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            if (new EventService().CreateEvent(model))
            {
                TempData["SaveResult"] = "Event created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error creating an Event");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var Event = new EventService().GetEventDetailsById(id);
            return View(Event);
        }

        public ActionResult Edit(int id)
        {
            var Event = new EventService().GetEventDetailsById(id);
            return View(new EventEdit
            {
                EventId = Event.EventId,
                Note =  Event.Note,
                EventType = Event.EventType,
                CreatedUtc = Event.CreatedUtc

            });

        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.EventId != id)
            {
                ModelState.AddModelError("", "Id incorrect");
                return View(model);
            }

            if (new EventService().UpdateEvent(model))
            {
                TempData["SaveResult"] = "Event has been updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Error updating this event");
            return View(model);
        }
    }
}