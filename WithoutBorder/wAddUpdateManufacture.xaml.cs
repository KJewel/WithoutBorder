using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для wAddUpdateManufacture.xaml
    /// </summary>
    public partial class wAddUpdateManufacture : Window
    {
        dbWithoutBorderContext context = new dbWithoutBorderContext();
        TManufacture manufacture = new TManufacture();
        bool f = true;

        public wAddUpdateManufacture(dbWithoutBorderContext context , bool f)
        {
            InitializeComponent();
            this.context = context;
            this.f = f;
        }

        private void Load()
        {
            if(f == false)
            {

            }
        }

        private void Save()
        {
            if (f)
            {
                TManufacture manufacture = new TManufacture() { Name = txtName.Text, Description = txtDescription.Text };
                context.TManufacture.Add(manufacture);
                context.SaveChanges();
            }
            else
            {
                manufacture = (TManufacture)DataContext;
                context.TManufacture.Update(manufacture);
                context.SaveChanges();
            }

            this.DialogResult = true;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}
