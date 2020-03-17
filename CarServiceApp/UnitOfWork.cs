using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp
{
    public class UnitOfWork : IDisposable
    {
        private CarServiceDBEntities db = new CarServiceDBEntities();
        private CarRepository carRepository;
        private MasterRepository masterRepository;
        private OwnerRepository ownerRepository;
        private RepairCarRepository repairCarRepository;

        public CarRepository Cars
        {
            get
            {
                if (carRepository == null)
                    carRepository = new CarRepository(db);
                return carRepository;
            }
        }

        public MasterRepository Masters
        {
            get
            {
                if (masterRepository == null)
                    masterRepository = new MasterRepository(db);
                return masterRepository;
            }
        }

        public OwnerRepository Owners
        {
            get
            {
                if (ownerRepository == null)
                    ownerRepository = new OwnerRepository(db);
                return ownerRepository;
            }
        }

        public RepairCarRepository RepairCars
        {
            get
            {
                if (repairCarRepository == null)
                    repairCarRepository = new RepairCarRepository(db);
                return repairCarRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
