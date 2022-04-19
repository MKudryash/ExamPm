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
    /// Логика взаимодействия для MainBook.xaml
    /// </summary>
    /// 

   
    public partial class MainBook : Page
    {
        ViewModel viewModel = new ViewModel();
        public MainBook()
        {
            InitializeComponent();
            DataContext = viewModel;
            CommandBindings.Add(viewModel.AddBookBasketBinding);
        }

        private void OpenBasket(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.Navigate(new Basket(viewModel));
        }
    }
}
