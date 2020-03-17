using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarServiceApp
{
    public class OwnerViewModel
    {
        UnitOfWork unitOfWork;
        private Owners _owner;
        private Window _window;

        private RelayCommand _addCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _cancelCommand;

        public OwnerViewModel(Owners owner, Window window)
        {
            unitOfWork = new UnitOfWork();
            _owner = owner;
            _window = window;
        }

        public int Id
        {
            get { return _owner.Id; }
            set { _owner.Id = value; }
        }
        public string First_Name
        {
            get { return _owner.First_Name; }
            set { _owner.First_Name = value; }
        }
        public string Second_Name
        {
            get { return _owner.Second_Name; }
            set { _owner.Second_Name = value; }
        }
        public string Middle_Name
        {
            get { return _owner.Middle_Name; }
            set { _owner.Middle_Name = value; }
        }
        public string Phone_Number
        {
            get { return _owner.Phone_Number; }
            set { _owner.Phone_Number = value; }
        }
        public string Address_Of_Residence
        {
            get { return _owner.Address_Of_Residence; }
            set { _owner.Address_Of_Residence = value; }
        }
        public string Passport_Data
        {
            get { return _owner.Passport_Data; }
            set { _owner.Passport_Data = value; }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        unitOfWork.Owners.Create(_owner);
                        MessageBox.Show("Владелец добавлен");
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
                        unitOfWork.Owners.Update(_owner);
                        MessageBox.Show("Владелец изменен");
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
