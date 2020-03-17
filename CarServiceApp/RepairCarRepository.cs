using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp
{
    public class RepairCarRepository : IRepository<RepairCars>
    {
        private CarServiceDBEntities db;

        public RepairCarRepository(CarServiceDBEntities context)
        {
            this.db = context;
        }

        public IEnumerable<RepairCars> GetAll()
        {
            return db.RepairCars;
        }

        public RepairCars Get(int id)
        {
            return db.RepairCars.Find(id);
        }

        public void Create(RepairCars repairCar)
        {
            db.RepairCars.Add(repairCar);
        }

        public void Update(RepairCars repairCar)
        {
            db.Entry(repairCar).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            RepairCars repairCar = db.RepairCars.Find(id);
            if (repairCar != null)
            {
                db.RepairCars.Remove(repairCar);
            }
        }
    }
}
