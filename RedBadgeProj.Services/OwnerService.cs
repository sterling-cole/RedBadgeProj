using RedBadgeProj.Data;
using RedBadgeProj.Models.OwnerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProj.Services
{
   public class OwnerService
    {
        public OwnerDetail GetOwnerDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var owner = ctx.Owners.Single(o => o.OwnerId == id);
                return new OwnerDetail
                {
                    OwnerId = owner.OwnerId,
                    OwnerName = owner.OwnerName
                };
            }
        }

        public bool CreateOwner(OwnerCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newOwner = new Owner()
                {
                    OwnerName = model.OwnerName
                };
                ctx.Owners.Add(newOwner);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<OwnerListItem> GetOwnerList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Owners.Select(o => new OwnerListItem
                {
                    OwnerName = o.OwnerName,
                });
                return query.ToArray();
            }
        }

        public IEnumerable<Owner> GetOwners()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Owners.ToList();

            }
        }


        public bool UpdateOwner(OwnerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var owner = ctx.Owners.Single(o => o.OwnerId == model.OwnerId);
                owner.OwnerName = model.OwnerName;
                return ctx.SaveChanges() == 1;

            }
        }


        public bool DeleteOwner(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var owner = ctx.Owners.Single(o => o.OwnerId == id);
                ctx.Owners.Remove(owner);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
