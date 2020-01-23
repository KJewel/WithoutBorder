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
    /// Логика взаимодействия для wUsers.xaml
    /// </summary>
    public partial class wUsers : Window
    {
        dbWithoutBorderContext context;
        ObservableCollection<TUsers> ocUsers;

        public wUsers()
        {
            InitializeComponent();
        }

        private void FilterClear()
        {
            cmbRole.SelectedIndex = -1;
            ckbRole.IsChecked = false;
            Filter();
        }

        private void Update()
        {
            var item = (TUsers)dgdUsers.SelectedItem as TUsers;

            if (item == null)
            {
                MessageBox.Show("Сперва выберите элемент из списка");
                return;
            }

            int index = ocUsers.IndexOf(item);

            wAddUser update = new wAddUser(ref context, ref ocUsers, index);
            update.ShowDialog();

            Filter();
        }
        private void Add()
        {
            wAddUser add = new wAddUser(ref context, ref ocUsers);
            add.ShowDialog();

            Filter();
        }

        private void Delete()
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить данные ? ", "Удалить", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Cancel) return;

            var item = (TUsers)dgdUsers.SelectedItem as TUsers;

            if (item == null)
            {
                MessageBox.Show("Сперва выберите элемент из списка");
                return;
            }

            ocUsers.Remove(item);
            context.Remove(item);
            Filter();
        }
        void Save()
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите сохранить данные ? ", "Сохранить", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Cancel) return;

            context.SaveChanges();
        }
        private void Filter()
        {
            if (ckbRole.IsChecked == true)
            {
                var role = (TRole)cmbRole.SelectedItem as TRole;

                if (role == null) return;

                var item = from t in ocUsers
                           where t.IdRole == role.Id
                           select t;

                btnFilterClear.Visibility = Visibility.Visible;
                dgdUsers.ItemsSource = item;
            }
            else
            {
                btnFilterClear.Visibility = Visibility.Hidden;
                dgdUsers.ItemsSource = null;
                dgdUsers.ItemsSource = ocUsers;
            }
        }
        private void Load()
        {
            context = new dbWithoutBorderContext();
            ocUsers = new ObservableCollection<TUsers>();

            var items = context?.TUsers.Include(u => u.IdRoleNavigation).Include(u => u.TSpec).ToList();

            var itemsRole = context.TRole.ToList();
            cmbRole.ItemsSource = itemsRole;

            if (items != null)
            {
                foreach (var item in items)
                {
                    ocUsers.Add(item);
                }
            }

            dgdUsers.ItemsSource = ocUsers;
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
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

        private void btnInfoWorker_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
