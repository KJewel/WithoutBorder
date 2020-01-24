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
    /// Логика взаимодействия для wManufacture.xaml
    /// </summary>
    public partial class wManufacture : Window
    {
        dbWithoutBorderContext context;
        private void Filter()
        {
            if (ckbFilter.IsChecked == false)
            {
                dgdManufacture.ItemsSource = context.TManufacture.ToList();
                return;
            }

            dgdManufacture.ItemsSource = context.TManufacture.Where(b => b.Name == txtNameFilter.Text).ToList();
        }

        void Add()
        {
            wAddUpdateManufacture add = new wAddUpdateManufacture(context,true);
            if(add.ShowDialog() == true)
            {
                MessageBox.Show("Объект добавлен");
            }        
        }

        private void Update()
        {
            var item = (TManufacture)dgdManufacture.SelectedItem as TManufacture;

            wAddUpdateManufacture update = new wAddUpdateManufacture(context, false);
            update.DataContext = item;
            if (update.ShowDialog() == true)
            {
                MessageBox.Show("Объект изменён");
            }
        }

        void Delete()
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить ?", "Удалить ? ", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Cancel) return;

            var item = (TManufacture)dgdManufacture.SelectedItem as TManufacture;
            context.Remove(item);
            context.SaveChanges();
            MessageBox.Show("Объект удалён");
        }

        private void Load()
        {
            context = new dbWithoutBorderContext();
            context.TManufacture.Load();

            dgdManufacture.ItemsSource = context.TManufacture.Local.ToBindingList();
        }

        public wManufacture()
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
