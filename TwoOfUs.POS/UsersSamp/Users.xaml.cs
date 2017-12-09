using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TwoOfUs.Domain.BLL;
using TwoOfUs.Domain.Models;

namespace TwoOfUs.POS.UsersSamp
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Window
    {

        public Users()
        {
            List<User> users = UsersBLL.GetAll();
            InitializeComponent();

            grUsers.ItemsSource = users;
        }
    }
}
