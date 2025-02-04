using InventoryLibrary.ViewModels;
using System.Windows;

namespace InventoryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel = new();
        public MainWindow()
        {
            InitializeComponent();
            _viewModel.ShowMessageBox = (message, title) =>
            {
                MessageBox.Show(message, title, MessageBoxButton.OK);
            };
            DataContext = _viewModel;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddItem();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.EditItem();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteItem();
        }
    }
}