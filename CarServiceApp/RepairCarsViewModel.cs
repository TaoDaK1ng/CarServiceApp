using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarServiceApp
{
    public class RepairCarsViewModel
    {
        UnitOfWork unitOfWork;

        private RepairCars _selectedRepairCar;

        public List<RepairCars> RepairCars { get; set; }

        private RelayCommand _addCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _deleteCommand;

        public RepairCarsViewModel()
        {
            unitOfWork = new UnitOfWork();
            RepairCars = unitOfWork.RepairCars.GetAll().ToList();     
        }

        public RepairCars SelectedRepairCar
        {
            get { return _selectedRepairCar; }
            set { _selectedRepairCar = value; }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        RepairCarView repairCarView = new RepairCarView(new RepairCars());
                        repairCarView.UpdateButton.Visibility = Visibility.Hidden;
                        repairCarView.Show();
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
                        RepairCars repairCar = obj as RepairCars;
                        if (repairCar != null)
                        {
                            RepairCarView repairCarView = new RepairCarView(repairCar);
                            repairCarView.AddButton.Visibility = Visibility.Hidden;
                            repairCarView.Show();
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
                        RepairCars repairCar = obj as RepairCars;
                        if (repairCar != null)
                        {
                            unitOfWork.RepairCars.Delete(repairCar.Id);
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
