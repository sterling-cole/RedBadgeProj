using RedBadgeProj.Data;
using RedBadgeProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProj.Services
{
    public class DogService
    {
        private readonly Guid _userId;
        public DogService(Guid userId)
        {
            _userId = userId;
        }
        public DogDetail GetDogDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dog = ctx.Dogs.Single(d => d.DogId == id);
                return new DogDetail
                {
                    DogId = dog.DogId,
                    DogName = dog.DogName,
                    Weight = dog.Weight,
                    Breed = dog.Breed,
                    EventId = dog.EventId
                };
            }
        }

        public bool CreateDog(DogCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newDog = new Dog()
                {
                    DogName = model.DogName,
                    Weight = model.Weight,
                    Breed = model.Breed,
                    EventId = model.EventId
                };
                ctx.Dogs.Add(newDog);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DogListItem> GetDogList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Dogs.Select(d => new DogListItem
                {
                    DogId = d.DogId,
                    DogName = d.DogName,
                    EventId = d.EventId
                });
                return query.ToArray();
            }
        }


        public bool UpdateDog(DogEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dog = ctx.Dogs.Single(d => d.DogId == model.DogId);
                dog.DogName = model.DogName;
                dog.Weight = model.Weight;
               dog.Breed = model.Breed;
                dog.EventId = model.EventId;
                return ctx.SaveChanges() == 1;

            }
        }


        public bool DeleteDog(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dog = ctx.Dogs.Single(d => d.DogId == id);
                ctx.Dogs.Remove(dog);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
