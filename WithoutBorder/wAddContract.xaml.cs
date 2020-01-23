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
    /// Логика взаимодействия для wAddContract.xaml
    /// </summary>
    public partial class wAddContract : Window
    {
        dbWithoutBorderContext context;
        bool f = true;
        public TContract contract = new TContract();

        public wAddContract()
        {
            InitializeComponent();
        }
        public wAddContract(ref dbWithoutBorderContext context)
        {
            InitializeComponent();
            this.context = context;
            f = true;
        }
        public wAddContract(bool f , ref dbWithoutBorderContext context)
        {
            InitializeComponent();
            this.context = context;
            this.f = f;
        }

        private void Load()
        {
            rb1.IsChecked = true;

            cmbBonus.ItemsSource = context.TBonus.ToList();
            cmbDevice.ItemsSource = context.TDevice.ToList();
            cmbOperator.ItemsSource = context.TUsers.Where(b => b.IdRole == 1).ToList();
            cmbTarif.ItemsSource = context.TTarif.ToList();
            cmbUser.ItemsSource = context.TUsers.Where(b => b.IdRole == 2).ToList();

            if (f == false)
            {
                if (contract.IdDeviceNavigation != null)
                {
                    if (contract.IdTarifNavigation != null)
                    {
                        rb3.IsChecked = true;
                    }
                    else
                    {
                        rb1.IsChecked = true;
                    }
                }
                else
                {
                    rb2.IsChecked = true;
                }

                DataContext = contract;
            }
        }

        private void Checked(RadioButton rb)
        {
            if (rb.Tag.ToString() == "1")
            {
                cmbDevice.IsEnabled = true;
                cmbDevice.SelectedIndex = 0;

                cmbTarif.IsEnabled = false;
                cmbTarif.SelectedIndex = -1;
            }
            else if (rb.Tag.ToString() == "2")
            {
                cmbDevice.IsEnabled = false;
                cmbDevice.SelectedIndex = -1;

                cmbTarif.IsEnabled = true;
                cmbTarif.SelectedIndex = 0;
            }
            else if (rb.Tag.ToString() == "3")
            {
                cmbDevice.IsEnabled = true;
                cmbDevice.SelectedIndex = 0;

                cmbTarif.IsEnabled = true;
                cmbTarif.SelectedIndex = 0;
            }
        }

        private void Add()
        {
            var itemBonus = (TBonus)cmbBonus.SelectedItem as TBonus;
            var itemDevice = (TDevice)cmbDevice.SelectedItem as TDevice;
            var itemOperator = (TUsers)cmbOperator.SelectedItem as TUsers;
            var itemTarif = (TTarif)cmbTarif.SelectedItem as TTarif;
            var itemUser = (TUsers)cmbUser.SelectedItem as TUsers;
            
            DateTime dt = dtp.SelectedDate.Value;

            if (f == true)
            {
                if (rb1.IsChecked == true)
                {
                    TContract c1 = new TContract() { IdOperator = itemOperator.IdUser, IdUser = itemUser.IdUser, Price = float.Parse(txtPrice.Text), IdDevice = itemDevice.Id, ConlusionDate = dt};
                    if (itemBonus != null)
                    {
                        c1.IdBonus = itemBonus.Id;
                    }
                    this.contract = c1;
                }
                else if (rb2.IsChecked == true)
                {
                    TContract c1 = new TContract() { IdTarif = itemTarif.Id, IdOperator = itemOperator.IdUser, IdUser = itemUser.IdUser, Price = float.Parse(txtPrice.Text), ConlusionDate = dt };
                    if (itemBonus != null)
                    {
                        c1.IdBonus = itemBonus.Id;
                    }
                    this.contract = c1;
                }
                else if (rb3.IsChecked == true)
                {
                    TContract c1 = new TContract() {IdDevice = itemDevice.Id, IdTarif = itemTarif.Id, IdOperator = itemOperator.IdUser, IdUser = itemUser.IdUser, Price = float.Parse(txtPrice.Text), ConlusionDate = dt };
                    if (itemBonus != null)
                    {
                        c1.IdBonus = itemBonus.Id;
                    }
                    this.contract = c1;
                }
            }
            else
            {
                if (rb1.IsChecked == true)
                {
                    TContract c1 = new TContract() {Id = contract.Id, IdOperator = itemOperator.IdUser, IdUser = itemUser.IdUser, Price = float.Parse(txtPrice.Text), IdDevice = itemDevice.Id, ConlusionDate = dt};
                    if (itemBonus != null)
                    {
                        c1.IdBonus = itemBonus.Id;
                    }
                    context.TContract.Remove(contract);
                    context.TContract.Update(c1);
                }
                else if (rb2.IsChecked == true)
                {
                    int index = contract.Id;
                    context.TContract.Remove(contract);
                    TContract c1 = new TContract() { Id = index, IdTarif = itemTarif.Id, IdOperator = itemOperator.IdUser, IdUser = itemUser.IdUser, Price = float.Parse(txtPrice.Text), ConlusionDate = dt, IdBonus = itemBonus.Id };
                    if(itemBonus != null)
                    {
                        c1.IdBonus = itemBonus.Id;
                    }
                    context.TContract.Update(c1);
                }
                else if (rb3.IsChecked == true)
                {
                    TContract c1 = new TContract() { Id = contract.Id, IdDevice = itemDevice.Id, IdTarif = itemTarif.Id, IdOperator = itemOperator.IdUser, IdUser = itemUser.IdUser, Price = float.Parse(txtPrice.Text), ConlusionDate = dt };
                    if (itemBonus != null)
                    {
                        c1.IdBonus = itemBonus.Id;
                    }
                    context.TContract.Remove(contract);
                    context.TContract.Update(c1);
                }
            }

            this.DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var rb = (RadioButton)sender;
            Checked(rb);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            popup1.IsOpen = true;
        }
    }
}
