using ExamPm.FolderClass;
using ExamPm.Pattern;
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

namespace ExamPm.Pages
{
    /// <summary>
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Page
    {
       // ViewModel viewModel = new ViewModel();
        public Basket(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            CommandBindings.Add(viewModel.EndOrderBinding);
        }

        private void ReturnShop(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.GoBack();
        }
    }
}
