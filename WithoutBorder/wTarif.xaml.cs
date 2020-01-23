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
    /// Логика взаимодействия для wTarif.xaml
    /// </summary>
    public partial class wTarif : Window
    {
        dbWithoutBorderContext context;

        private void Filter()
        {
            if (ckbFilter.IsChecked == false)
            {
                dgdTarif.ItemsSource = null;
                dgdTarif.ItemsSource = context.TTarif.Local.ToBindingList();
                dgdTarif.CanUserAddRows = true;
                dgdTarif.CanUserDeleteRows = true;
                return;
            }

            var item = context.TTarif.Local.Where(b => b.Name == txtName.Text).ToList();
            dgdTarif.CanUserAddRows = false;
            dgdTarif.CanUserDeleteRows = true;
            dgdTarif.ItemsSource = item;
        }

        void Save()
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите сохранить данные ? ", "Сохранить", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Cancel) return;

            context.SaveChanges();
        }

        void Add()
        {
            TTarif typeDevice = new TTarif() { Name = txtName.Text, Description = txtDescription.Text };
            context.TTarif.Add(typeDevice);
        }

        void Delete()
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить ?", "Удалить ? ", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Cancel) return;

            var item = (TTarif)dgdTarif.SelectedItem as TTarif;
            context.Remove(item);
        }

        private void Load()
        {
            context = new dbWithoutBorderContext();
            context.TTarif.Load();

            dgdTarif.ItemsSource = context.TTarif.Local.ToBindingList();
        }

        public wTarif()
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
