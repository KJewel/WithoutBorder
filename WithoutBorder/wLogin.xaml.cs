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

    public partial class wLogin : Window
    {
        dbWithoutBorderContext context;
        dbWithoutBorderContext log;

        TUsers user = new TUsers();
        bool f = true;
        int p = 3;

        public wLogin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if(f == true)
            {
                string item = "admin";

                switch (item.ToLower())
                {
                    case "admin":
                        {
                            wLogList admin = new wLogList();
                            if(admin.ShowDialog() == true)
                            {

                            }

                            break;
                        }
                    case "manager":
                        {
                            break;
                        }
                }
            }
            else
            {
                DateTime time = new DateTime();
                MessageBox.Show($"Вы не имеете доступа, осталось времени : {time}");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
