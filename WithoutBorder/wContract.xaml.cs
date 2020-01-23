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
    public partial class wContract : Window
    {
        dbWithoutBorderContext context;
        public wContract()
        {
            InitializeComponent();
        }

        private void FilterClear()
        {
            Filter();
        }

        private void Update()
        {
            var item = (TContract)dgdContract.SelectedItem as TContract;
            
            if (item == null)
            {
                MessageBox.Show("Сперва выберите элемент из списка");
                return;
            }

            wAddContract update = new wAddContract(false , ref context);
                update.contract = item;
            if(update.ShowDialog() == true)
            {
                context.SaveChanges();
                Filter();
            }
        }

        private void Add()
        {
            wAddContract add = new wAddContract(ref context);
            if(add.ShowDialog() == true)
            {
                TContract contract;
                contract = add.contract;

                context.TContract.Add(contract);
                context.SaveChanges();

                MessageBox.Show("Новый 'договор' добавлен");

                Filter();
                MessageBox.Show("Обьект добавлен");
            }

        }

        private void Delete()
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить данные ? ", "Удалить", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Cancel) return;

            var item = (TContract)dgdContract.SelectedItem as TContract;

            if (item == null)
            {
                MessageBox.Show("Сперва выберите элемент из списка");
                return;
            }

            context.Remove(item);
            context.SaveChanges();

            Filter();
        }
        private void Filter()
        {
        }
        private void Load()
        {
            context = new dbWithoutBorderContext();
            context.TContract.Include(b => b.IdUserNavigation).Include(x => x.IdTarifNavigation).Include(x => x.IdOperatorNavigation).Include(x => x.IdDeviceNavigation).Include(x => x.IdBonusNavigation).Load();
            dgdContract.ItemsSource = context.TContract.Local.ToBindingList();
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void cmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btnFilterClear_Click(object sender, RoutedEventArgs e)
        {
            FilterClear();
        }

        private void ckbRole_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter();
        }
        private void dgdUsers_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                Delete();
            }
        }

    }
}
