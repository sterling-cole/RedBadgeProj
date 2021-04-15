using Microsoft.AspNet.Identity;
using RedBadgeProj.Data;
using RedBadgeProj.Models;
using RedBadgeProj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeProj.WebMVC.Controllers
{
    public class DogController : Controller
    {
        // GET: Dog
        public ActionResult Index()
        {
            return View(CreateDogService().GetDogList());
        }
        public ActionResult Create()
        {
            ViewBag.Title = "New Dog";
            List<Owner> Owners = (new OwnerService()).GetOwners().ToList();
            var query = from o in Owners
                        select new SelectListItem()
                        {
                            Value = o.OwnerId.ToString(),
                            Text = o.OwnerName
                        };
            ViewBag.OwnerId = query.ToList(); 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DogCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            if (CreateDogService().CreateDog(model))
            {
                TempData["SaveResult"] = "Dog created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error creating a Dog");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var dog = CreateDogService().GetDogDetailsById(id);
            return View(dog);
        }
        public ActionResult Edit(int id)
        {
            var dog = CreateDogService().GetDogDetailsById(id);
            ViewBag.Title = "New Dog";
            List<Owner> Owners = (new OwnerService()).GetOwners().ToList();
            var query = from o in Owners
                        select new SelectListItem()
                        {
                            Value = o.OwnerId.ToString(),
                            Text = o.OwnerName,
                            Selected = dog.OwnerId == o.OwnerId
                        };
            ViewBag.OwnerId = query.ToList();


            return View(new DogEdit
            {
                DogId = dog.DogId,
                DogName = dog.DogName,
                Weight = dog.Weight,
                Breed =  dog.Breed,
            });
                
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DogEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.DogId != id)
            {
                ModelState.AddModelError("", "Id incorrect");
                return View(model);
            }

            if (CreateDogService().UpdateDog(model))
            {
                TempData["SaveResult"] = "Dog has been updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Error creating a Dog");
            return View(model);
        }

        private DogService CreateDogService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DogService(userId);
            return service;
        }
        public ActionResult Delete(int id)
        {
            var dog = CreateDogService().GetDogDetailsById(id);
            return View(dog);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDog(int id)
        {
            var service = CreateDogService();
            service.DeleteDog(id);
            TempData["SaveResult"] = "This dog was removed";
            return RedirectToAction("Index");
        }
    }
}