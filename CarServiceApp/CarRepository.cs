using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp
{
    public class CarRepository : IRepository<Cars>
    {
        private CarServiceDBEntities db;

        public CarRepository(CarServiceDBEntities context)
        {
            this.db = context;
        }

        public IEnumerable<Cars> GetAll()
        {
            return db.Cars;
        }

        public Cars Get(int id)
        {
            return db.Cars.Find(id);
        }

        public void Create(Cars car)
        {
            db.Cars.Add(car);
        }

        public void Update(Cars car)
        {
            db.Entry(car).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Cars car = db.Cars.Find(id);
            if (car != null)
            {
                db.Cars.Remove(car);
            }
        }
    }
}
