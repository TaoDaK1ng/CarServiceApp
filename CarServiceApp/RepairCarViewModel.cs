using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarServiceApp
{
    public class RepairCarViewModel
    {
        UnitOfWork unitOfWork;
        private RepairCars _repairCar;
        private Cars _selectedCar;
        private Masters _selectedMaster;
        public List<Cars> Cars { get; set; }
        public List<Masters> Masters { get; set; }
        private Window _window;

        private RelayCommand _addCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _cancelCommand;

        public RepairCarViewModel(RepairCars repairCar, Window window)
        {
            unitOfWork = new UnitOfWork();
            Cars = unitOfWork.Cars.GetAll().ToList();
            Masters = unitOfWork.Masters.GetAll().ToList();
            _repairCar = repairCar;
            _window = window;
            SelectedCar = unitOfWork.Cars.GetAll().ToList().Where(car => car.Id == repairCar.Car_Id).FirstOrDefault();
            SelectedMaster = unitOfWork.Masters.GetAll().ToList().Where(master => master.Id == repairCar.Master_Id).FirstOrDefault();
        }

        public Cars SelectedCar
        {
            get { return _selectedCar; }
            set { _selectedCar = value; }
        }

        public Masters SelectedMaster
        {
            get { return _selectedMaster; }
            set { _selectedMaster = value; }
        }

        public int Id
        {
            get { return _repairCar.Id; }
            set { _repairCar.Id = value; }
        }

        public int Master_Id
        {
            get { return _repairCar.Master_Id; }
            set { _repairCar.Master_Id = value; }
        }
        public int Car_Id
        {
            get { return _repairCar.Car_Id; }
            set { _repairCar.Car_Id = value; }
        }
        public string Malfunction
        {
            get { return _repairCar.Malfunction; }
            set { _repairCar.Malfunction = value; }
        }
        public System.DateTime Production_Date
        {
            get { return _repairCar.Production_Date; }
            set { _repairCar.Production_Date = value; }
        }
        public Nullable<System.DateTime> Expiration_Date
        {
            get { return _repairCar.Expiration_Date; }
            set { _repairCar.Expiration_Date = value; }
        }
        public int Cost
        {
            get { return _repairCar.Cost; }
            set { _repairCar.Cost = value; }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        unitOfWork.RepairCars.Create(_repairCar);
                        MessageBox.Show("Машина добавлена");
                        unitOfWork.Save();
                        _window.Close();
                    }));
            }
        }

        public RelayCommand UpdateCommand
        {
            get
            {
                return _updateCommand ??
                    (_updateCommand = new RelayCommand(obj =>
                    {
                        unitOfWork.RepairCars.Update(_repairCar);
                        MessageBox.Show("Машина изменена");
                        unitOfWork.Save();
                        _window.Close();
                    }));
            }
        }

        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelCommand ??
                    (_cancelCommand = new RelayCommand(obj =>
                    {
                        _window.Close();
                    }));
            }
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
