using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp
{
    public class OwnerRepository : IRepository<Owners>
    {
        private CarServiceDBEntities db;

        public OwnerRepository(CarServiceDBEntities context)
        {
            this.db = context;
        }

        public IEnumerable<Owners> GetAll()
        {
            return db.Owners;
        }

        public Owners Get(int id)
        {
            return db.Owners.Find(id);
        }

        public void Create(Owners owner)
        {
            db.Owners.Add(owner);
        }

        public void Update(Owners owner)
        {
            db.Entry(owner).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Owners owner = db.Owners.Find(id);
            if (owner != null)
            {
                db.Owners.Remove(owner);
            }
        }
    }
}
