using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Book> books;

        public MainWindow()
        {
            InitializeComponent();
            using (var context = new HwContext())
            {
                books = new ObservableCollection<Book>(context.Books.ToList());
            }
            dataGrid.ItemsSource = books;
        }

        private void UpdateBtnClick(object sender, RoutedEventArgs e)
        {
            using (var context = new HwContext())
            {
                books.ToList().ForEach(x => context.Update(x));
                context.SaveChanges();
            }
        }

        private void AddBtnClick(object sender, RoutedEventArgs e)
        {
            using (var context = new HwContext())
            {
                int.TryParse(priceTB.Text, out var price);
                context.Add(new Book
                {
                    Author = authorTB.Text,
                    Price = price,
                    TitleName = titleNameTB.Text
                });
                priceTB.Text = "";
                authorTB.Text = "";
                titleNameTB.Text = "";
                context.SaveChanges();
                books = new ObservableCollection<Book>(context.Books.ToList());
                dataGrid.ItemsSource = books;
            }
        }
    }
}
