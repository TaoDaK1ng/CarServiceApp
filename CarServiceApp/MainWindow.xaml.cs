using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarServiceApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CarsButton.Click += (sender, e) =>
            {
                CarsView carsView = new CarsView();
                carsView.Show();
            };
            OwnersButton.Click += (sender, e) =>
            {
                OwnersView ownersView = new OwnersView();
                ownersView.Show();
            };
            MastersButton.Click += (sender, e) =>
            {
                MastersView mastersView = new MastersView();
                mastersView.Show();
            };
            RepairCarsButton.Click += (sender, e) =>
            {
                RepairCarsView repairCarsView = new RepairCarsView();
                repairCarsView.Show();
            };
        }
    }
}
