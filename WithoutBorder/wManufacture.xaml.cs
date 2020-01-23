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
                dgdManufacture.ItemsSource = null;
                dgdManufacture.ItemsSource = context.TManufacture.Local.ToBindingList();
                dgdManufacture.CanUserAddRows = true;
                dgdManufacture.CanUserDeleteRows = true;
                return;
            }

            var item = context.TManufacture.Local.Where(b => b.Name == txtNameFilter.Text).ToList();
            dgdManufacture.CanUserAddRows = false;
            dgdManufacture.CanUserDeleteRows = true;
            dgdManufacture.ItemsSource = item;
        }

        void Add()
        {
            TManufacture manufacture = new TManufacture() { Name = txtName.Text, Description = txtDescription.Text };
            context.TManufacture.Add(manufacture);
        }

        void Delete()
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить ?", "Удалить ? ", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Cancel) return;

            var item = (TManufacture)dgdManufacture.SelectedItem as TManufacture;
            context.Remove(item);
        }

        void Save()
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите сохранить данные ? ", "Сохранить", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Cancel) return;

            context.SaveChanges();
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите обновить данные ? ", "Обновить", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Cancel) return;

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
    }
}
