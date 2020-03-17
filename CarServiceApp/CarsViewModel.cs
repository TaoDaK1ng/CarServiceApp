using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarServiceApp
{
    public class CarsViewModel
    {
        UnitOfWork unitOfWork;

        private Cars _selectedCar;

        public List<Cars> Cars { get; set; }

        private RelayCommand _addCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _deleteCommand;

        public CarsViewModel()
        {
            unitOfWork = new UnitOfWork();
            Cars = unitOfWork.Cars.GetAll().ToList();
        }

        public Cars SelectedCar
        {
            get { return _selectedCar; }
            set { _selectedCar = value; }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        CarView carView = new CarView(new Cars());
                        carView.UpdateButton.Visibility = Visibility.Hidden;
                        carView.Show();
                        unitOfWork.Dispose();
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
                        Cars car = obj as Cars;
                        if(car != null)
                        {
                            CarView carView = new CarView(car);
                            carView.AddButton.Visibility = Visibility.Hidden;
                            carView.Show();
                            unitOfWork.Dispose();
                        }            
                    }));
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ??
                    (_deleteCommand = new RelayCommand(obj =>
                    {
                        Cars car = obj as Cars;
                        if (car != null)
                        {
                            unitOfWork.Cars.Delete(car.Id);
                            MessageBox.Show("Удалено");
                            unitOfWork.Save();
                        }
                    }));
            }
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
