using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarServiceApp
{
    public class MastersViewModel
    {
        UnitOfWork unitOfWork;

        private Masters _selectedMaster;

        public List<Masters> Masters { get; set; }

        private RelayCommand _addCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _deleteCommand;

        public MastersViewModel()
        {
            unitOfWork = new UnitOfWork();
            Masters = unitOfWork.Masters.GetAll().ToList();
        }

        public Masters SelectedMaster
        {
            get { return _selectedMaster; }
            set { _selectedMaster = value; }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        MasterView masterView = new MasterView(new Masters());
                        masterView.UpdateButton.Visibility = Visibility.Hidden;
                        masterView.Show();
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
                        Masters master = obj as Masters;
                        if (master != null)
                        {
                            MasterView masterView = new MasterView(master);
                            masterView.AddButton.Visibility = Visibility.Hidden;
                            masterView.Show();
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
                        Masters master = obj as Masters;
                        if (master != null)
                        {
                            unitOfWork.Masters.Delete(master.Id);
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
