using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarServiceApp
{
    public class CarViewModel
    {
        UnitOfWork unitOfWork;
        private Cars _car;
        private Window _window;

        private RelayCommand _addCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _cancelCommand;

        public CarViewModel(Cars car, Window window)
        {
            unitOfWork = new UnitOfWork();
            _car = car;
            _window = window;
        }

        public int Id
        {
            get { return _car.Id; }
            set { _car.Id = value; }
        }

        public string Brand
        {
            get { return _car.Brand; }
            set { _car.Brand = value; }
        }

        public string Model
        {
            get { return _car.Model; }
            set { _car.Model = value; }
        }

        public string Government_Number
        {
            get { return _car.Government_Number; }
            set { _car.Government_Number = value; }
        }

        public int Mileage
        {
            get { return _car.Mileage; }
            set { _car.Mileage = value; }
        }

        public int Engine_Capacity
        {
            get { return _car.Engine_Capacity; }
            set { _car.Engine_Capacity = value; }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        unitOfWork.Cars.Create(_car);
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
                        unitOfWork.Cars.Update(_car);
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
