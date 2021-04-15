using RedBadgeProj.Models.OwnerModels;
using RedBadgeProj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeProj.WebMVC.Controllers
{
    public class OwnerController : Controller
    {
        // GET: Owner
        public ActionResult Index()
        {
            return View(new OwnerService().GetOwnerList());
        }
        public ActionResult Create()
        {
            ViewBag.Title = "New Owner";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OwnerCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            if (new OwnerService().CreateOwner(model))
            {
                TempData["SaveResult"] = "Owner added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error adding an owner");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var owner = new OwnerService().GetOwnerDetailsById(id);
            return View(owner);
        }
        public ActionResult Edit(int id)
        {
            var owner = new OwnerService().GetOwnerDetailsById(id);
            return View(new OwnerEdit
            {
                OwnerName = owner.OwnerName
            });

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OwnerEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.OwnerId != id)
            {
                ModelState.AddModelError("", "Id incorrect");
                return View(model);
            }

            if (new OwnerService().UpdateOwner(model))
            {
                TempData["SaveResult"] = "Owner has been updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Error updating this owner");
            return View(model);
        }

    }
}