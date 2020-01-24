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
    /// Логика взаимодействия для wLogList.xaml
    /// </summary>
    public partial class wLogList : Window
    {
        TUsers user = new TUsers();

        public wLogList()
        {
            InitializeComponent();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnContract_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Load()
        {
            using(dbWithoutBorderContext context = new dbWithoutBorderContext())
            {

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}
