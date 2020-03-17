using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarServiceApp
{
    public class MasterViewModel
    {
        UnitOfWork unitOfWork;
        private Masters _master;
        private Window _window;

        private RelayCommand _addCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _cancelCommand;

        public MasterViewModel(Masters master, Window window)
        {
            unitOfWork = new UnitOfWork();
            _master = master;
            _window = window;
        }

        public int Id
        {
            get { return _master.Id; }
            set { _master.Id = value; }
        }
        public string First_Name
        {
            get { return _master.First_Name; }
            set { _master.First_Name = value; }
        }
        public string Second_Name
        {
            get { return _master.Second_Name; }
            set { _master.Second_Name = value; }
        }
        public string Middle_Name
        {
            get { return _master.Middle_Name; }
            set { _master.Middle_Name = value; }
        }
        public string Phone_Number
        {
            get { return _master.Phone_Number; }
            set { _master.Phone_Number = value; }
        }
        public int Work_Experience
        {
            get { return _master.Work_Experience; }
            set { _master.Work_Experience = value; }
        }
        

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        unitOfWork.Masters.Create(_master);
                        MessageBox.Show("Мастер добавлен");
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
                        unitOfWork.Masters.Update(_master);
                        MessageBox.Show("Мастер изменен");
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
