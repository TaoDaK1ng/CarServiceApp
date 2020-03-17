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
using System.Windows.Shapes;

namespace CarServiceApp
{
    /// <summary>
    /// Логика взаимодействия для MastersView.xaml
    /// </summary>
    public partial class MastersView : Window
    {
        public MastersView()
        {
            InitializeComponent();
            DataContext = new MastersViewModel();
            this.Activated += (sender, e) =>
            {
                DataContext = new MastersViewModel();
            };
        }
    }
}
