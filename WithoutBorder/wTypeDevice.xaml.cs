using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WithoutBorder
{
    /// <summary>
    /// Логика взаимодействия для wTypeDevice.xaml
    /// </summary>
    public partial class wTypeDevice : Window
    {
        dbWithoutBorderContext context;
        private void Filter()
        {
            if (ckbFilter.IsChecked == false)
            {
                dgdTypeDevice.ItemsSource = context.TTypeDevice.Local.ToBindingList();
                return;
            }

            dgdTypeDevice.ItemsSource = context.TTypeDevice.Local.Where(b => b.Name.ToUpper() == txtNameFilter.Text.ToUpper()).ToList();
        }

        private void Load()
        {
            context = new dbWithoutBorderContext();
            context.TTypeDevice.Load();

            dgdTypeDevice.ItemsSource = context.TTypeDevice.Local.ToBindingList();
        }

        private void Add()
        {
            wAddUpdateTypeDevice add = new wAddUpdateTypeDevice(context, true);
            if (add.ShowDialog() == true)
            {
                MessageBox.Show("Объект добавлен");
            }
        }
        private void Update()
        {
            var item = (TTypeDevice)dgdTypeDevice.SelectedItem as TTypeDevice;

            wAddUpdateTypeDevice update = new wAddUpdateTypeDevice(context, false);
            update.DataContext = item;
            if (update.ShowDialog() == true)
            {
                MessageBox.Show("Объект изменён");
            }
        }
        private void Delete()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить ?", "Удалить ? ", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Cancel) return;

                var item = (TTypeDevice)dgdTypeDevice.SelectedItem as TTypeDevice;
                context.Remove(item);
                context.SaveChanges();
                MessageBox.Show("Объект удалён");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Load();
            }
        }

        public wTypeDevice()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }


        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void ckbFilter_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void ckbFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
