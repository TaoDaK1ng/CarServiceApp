using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarServiceApp
{
    public class OwnersViewModel
    {
        UnitOfWork unitOfWork;

        private Owners _selectedOwner;

        public List<Owners> Owners { get; set; }

        private RelayCommand _addCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _deleteCommand;

        public OwnersViewModel()
        {
            unitOfWork = new UnitOfWork();
            Owners = unitOfWork.Owners.GetAll().ToList();
        }

        public Owners SelectedOwner
        {
            get { return _selectedOwner; }
            set { _selectedOwner = value; }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        OwnerView ownerView = new OwnerView(new Owners());
                        ownerView.UpdateButton.Visibility = Visibility.Hidden;
                        ownerView.Show();
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
                        Owners owner = obj as Owners;
                        if (owner != null)
                        {
                            OwnerView ownerView = new OwnerView(owner);
                            ownerView.AddButton.Visibility = Visibility.Hidden;
                            ownerView.Show();
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
                        Owners owner = obj as Owners;
                        if (owner != null)
                        {
                            unitOfWork.Owners.Delete(owner.Id);
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
