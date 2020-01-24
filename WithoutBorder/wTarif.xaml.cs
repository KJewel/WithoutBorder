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
            if (ckbFilter.IsChecked == true)
            {
                if(ckbPrice.IsChecked == true)
                {
                    if (txtPriceFilter.Text == "")
                    {
                        txtPriceFilter.Text = "0";
                    }

                    dgdTarif.ItemsSource = context.TTarif.Local.Where(n => n.Name == txtNameFilter.Text).Where(p => p.Price == float.Parse(txtPriceFilter.Text)).ToList();
                }
                else
                {
                    dgdTarif.ItemsSource = context.TTarif.Local.Where(n => n.Name == txtNameFilter.Text).ToList();
                }
            }
            else if(ckbPrice.IsChecked == true)
            {   
                if(txtPriceFilter.Text == "")
                {
                    txtPriceFilter.Text = "0";
                }

                dgdTarif.ItemsSource = context.TTarif.Local.Where(p => p.Price == float.Parse(txtPriceFilter.Text)).ToList();
            }
            else
            {
                dgdTarif.ItemsSource = context.TTarif.Local.ToList();
            }
        }
        private void Add()
        {
            wAddUpdateTarif add = new wAddUpdateTarif(context, true);
            if (add.ShowDialog() == true)
            {
                MessageBox.Show("Объект добавлен");
            }
        }
        private void Update()
        {
            var item = (TTarif)dgdTarif.SelectedItem as TTarif;

            wAddUpdateTarif update = new wAddUpdateTarif(context, false);
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

                var item = (TTarif)dgdTarif.SelectedItem as TTarif;
                context.Remove(item);
                context.SaveChanges();
                Load();
                MessageBox.Show("Объект удалён");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Load();
            }
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
