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

        TUsers worker = new TUsers();

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
            
        }

        private void Add()
        {
           
        }

        private void Delete()
        {

        }

        private void Filter()
        {
            
        }

        private void Load()
        {
            context = new dbWithoutBorderContext();

            switch (worker.IdRole)
            {
                //admin
                case 1:
                    {

                        var itemsRole = context.TRole.Where(r => r.Id !=1).ToList();
                        cmbRole.ItemsSource = itemsRole;
                        
                        dgdUsers.ItemsSource = context?.TUsers.Include(u => u.IdRoleNavigation).Include(u => u.TSpec).Where(w => w.IdRole != 1).ToList();

                        break;
                    }
                //manager
                case 2:
                    {
                        cmbRole.Visibility = Visibility.Hidden;
                        ckbRole.Visibility = Visibility.Hidden;

                        lRole.Visibility = Visibility.Hidden;

                        dgdUsers.ItemsSource = context?.TUsers.Include(u => u.IdRoleNavigation).Include(u => u.TSpec).Where(w => w.IdRole != 2).Where(w=>w.IdRole !=1).ToList();
                        break;
                    }
            }
            


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

    }
}
