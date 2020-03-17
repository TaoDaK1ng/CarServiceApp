using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp
{
    public class MasterRepository : IRepository<Masters>
    {
        private CarServiceDBEntities db;

        public MasterRepository(CarServiceDBEntities context)
        {
            this.db = context;
        }

        public IEnumerable<Masters> GetAll()
        {
            return db.Masters;
        }

        public Masters Get(int id)
        {
            return db.Masters.Find(id);
        }

        public void Create(Masters master)
        {
            db.Masters.Add(master);
        }

        public void Update(Masters master)
        {
            db.Entry(master).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Masters master = db.Masters.Find(id);
            if (master != null)
            {
                db.Masters.Remove(master);
            }
        }
    }
}
