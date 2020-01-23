using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.ComponentModel.DataAnnotations;

namespace WithoutBorder
{
    /// <summary>
    /// Логика взаимодействия для wAddUser.xaml
    /// </summary>
    public partial class wAddUser : Window
    {
        byte[] bs;
        string path = "";
        dbWithoutBorderContext context;
        ObservableCollection<TUsers> ocUsers;
        int index = -1;
        public wAddUser()
        {
            InitializeComponent();
        }

        public wAddUser(ref dbWithoutBorderContext context, ref ObservableCollection<TUsers> ocUsers)
        {
            InitializeComponent();
            this.context = context;
            this.ocUsers = ocUsers;
        }

        public wAddUser(ref dbWithoutBorderContext context, ref ObservableCollection<TUsers> ocUsers, int index)
        {
            InitializeComponent();
            this.context = context;
            this.ocUsers = ocUsers;
            this.index = index;
        }
        void Add()
        {
            var item = (TRole)cmbRole.SelectedItem as TRole;
            
            if (Test() == false)
            {
                return;
            }

            TUsers users = new TUsers() { Name = txtName.Text, Surname = txtSurname.Text, Middlename = txtMiddleName.Text, PassportNumber = int.Parse(txtNumber.Text), PassportSeria = int.Parse(txtSeria.Text), Photo = bs, IdRoleNavigationLog = item, IdRole = item.IdRole , TSpec = new TSpec { Title = "sdsdsd"} };

            context.TUsers.Add(users);
            ocUsers.Add(users);
        }

        void Update()
        {
            var item = (TRole)cmbRole.SelectedItem as TRole;

            if (Test() == false)
            {
                return;
            }

            ocUsers[index].Name = txtName.Text;
            ocUsers[index].Surname = txtSurname.Text;
            ocUsers[index].Middlename = txtMiddleName.Text;
            ocUsers[index].PassportNumber = int.Parse(txtNumber.Text);
            ocUsers[index].PassportSeria = int.Parse(txtSeria.Text);
            ocUsers[index].Photo = bs;
            ocUsers[index].IdRole = item.IdRole;
            ocUsers[index].IdRoleNavigationLog = item;

            if (ocUsers[index].IdRole != 0)
            {
                context.TUsers.Remove(ocUsers[index]);
                context.TUsers.Update(ocUsers[index]);
            }
            else
            {
            }
        }
        private bool Test()
        {
            var item = (TRole)cmbRole.SelectedItem as TRole;

            TUsers user = new TUsers()
            {
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Middlename = txtMiddleName.Text,
                PassportNumber = int.Parse(txtNumber.Text),
                PassportSeria = int.Parse(txtSeria.Text),
                Photo = bs,
                IdRole = item.IdRole,
                IdRoleNavigationLog = item,
            };

            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var error in results)
                {
                    MessageBox.Show(error.ErrorMessage);
                    return false;
                }
            }

            return true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (index == -1)
            {
                Add();
            }
            else
            {
                Update();
            }

            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public BitmapImage GetImage()
        {
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(path);
            img.CacheOption = BitmapCacheOption.OnLoad;
            img.EndInit();

            return img;
        }

        private void iProfile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == true)
            {
                path = open.FileName;
                bs = File.ReadAllBytes(path);
                iProfile.Source = GetImage();
            }
        }

        void Load()
        {
            cmbRole.ItemsSource = context.TRole.ToList();

            if (index != -1)
            {
                bs = ocUsers[index].Photo;
                this.DataContext = ocUsers[index];
            }

            cmbRole.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ComboBox)sender as ComboBox;

            var role = (TRole)item.SelectedItem as TRole;
            
            if (role == null) return;

            if(role.Title.ToLower() == "user")
            {
                btnAddInformation.IsEnabled = false;
            }
            else
            {
                btnAddInformation.IsEnabled = true;
            }
        }

        private void btnAddInformation_Click(object sender, RoutedEventArgs e)
        {
            wAddInfoWorker addInfoWorker = new wAddInfoWorker();
            addInfoWorker.ShowDialog();
        }
    }
}
