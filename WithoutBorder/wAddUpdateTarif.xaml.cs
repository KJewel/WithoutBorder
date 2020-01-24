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
    /// Логика взаимодействия для wAddUpdateTarif.xaml
    /// </summary>
    public partial class wAddUpdateTarif : Window
    {
        bool f = true;
        dbWithoutBorderContext context;
        TTarif tarif = new TTarif();

        public wAddUpdateTarif(dbWithoutBorderContext context, bool f)
        {
            InitializeComponent();
            this.context = context;
            this.f = f;
        }

        void Save()
        {
            if (f)
            {
                TTarif tarif = new TTarif() { Name = txtName.Text, Description = txtDescription.Text, Price = float.Parse(txtPrice.Text) };
                context.TTarif.Add(tarif);
                context.SaveChanges();
                DialogResult = true;
            }
            else
            {
                tarif = (TTarif)DataContext;
                context.Update(tarif);
                context.SaveChanges();
                DialogResult = true;
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
