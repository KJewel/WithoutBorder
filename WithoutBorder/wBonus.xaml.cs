using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для wBonus.xaml
    /// </summary>
    public partial class wBonus : Window
    {
        dbWithoutBorderContext context;

        private void Filter()
        {
            if (ckbFilter.IsChecked == false) 
            {
                dgdBonus.ItemsSource = null;
                dgdBonus.ItemsSource = context.TBonus.Local.ToBindingList();
                dgdBonus.CanUserAddRows = true;
                dgdBonus.CanUserDeleteRows = true;
                return;
            }

            var item = context.TBonus.Local.Where(b => b.Name == txtName.Text).ToList();
            dgdBonus.CanUserAddRows = false;
            dgdBonus.CanUserDeleteRows = true;
            dgdBonus.ItemsSource = item;
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
            context.TBonus.Load();

            dgdBonus.ItemsSource = context.TBonus.Local.ToBindingList();
        }
        void Add()
        {
            TBonus typeDevice = new TBonus() { Name = txtName.Text, Description = txtDescription.Text };
            context.TBonus.Add(typeDevice);
        }
        void Delete()
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить ?", "Удалить ? ", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Cancel) return;

            var item = (TBonus)dgdBonus.SelectedItem as TBonus;
            context.Remove(item);
        }

        public wBonus()
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

        private void dgdBonus_Error(object sender, ValidationErrorEventArgs e)
        {
            var item = (TextBox)sender;
            item.Text = "0";
        }
    }
}
