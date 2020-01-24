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
                dgdBonus.ItemsSource = context.TBonus.ToList();
                return;
            }

            dgdBonus.ItemsSource = context.TBonus.Where(b => b.Name == txtNameFilter.Text).ToList();
        }

        private void Load()
        {
            context = new dbWithoutBorderContext();
            context.TBonus.Load();

            dgdBonus.ItemsSource = context.TBonus.Local.ToBindingList();
        }
        private void Add()
        {
            wAddUpdateBonus add = new wAddUpdateBonus(context, true);
            if(add.ShowDialog() == true)
            {
                MessageBox.Show("Объект добавлен");
            }
        }
        private void Update()
        {
            var item = (TBonus)dgdBonus.SelectedItem as TBonus;

            wAddUpdateBonus update = new wAddUpdateBonus(context, false);
            update.DataContext = item;
            if(update.ShowDialog() == true)
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

                var item = (TBonus)dgdBonus.SelectedItem as TBonus;
                context.Remove(item);
                context.SaveChanges();
                MessageBox.Show("Объект удалён");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Load();
            }
        }

        public wBonus()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }

        #region//Filter
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
        #endregion
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
