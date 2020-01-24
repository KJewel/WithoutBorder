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
    /// Логика взаимодействия для wAddUpdateBonus.xaml
    /// </summary>
    public partial class wAddUpdateBonus : Window
    {
        bool f = true;
        dbWithoutBorderContext context;
        TBonus bonus = new TBonus();

        public wAddUpdateBonus(dbWithoutBorderContext context , bool f )
        {
            InitializeComponent();
            this.context = context;
            this.f = f;
        }
        
        void Save()
        {
            if (f)
            {
                TBonus bonus = new TBonus() { Name = txtName.Text, Description = txtDescription.Text, PercentBonus =float.Parse(txtPercent.Text) };
                context.TBonus.Add(bonus);
                context.SaveChanges();
                DialogResult = true;
            }
            else
            {
                bonus = (TBonus)DataContext;
                context.Update(bonus);
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
