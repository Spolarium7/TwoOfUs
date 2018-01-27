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
using TwoOfUs.Domain.Models.Enums;

namespace TwoOfUs.POS.Users
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        private User _user;

        public Update(User user)
        {
            InitializeComponent();
            this.txtFirstName.Text = user.FirstName;
            this.txtLastName.Text = user.LastName;
            this.txtUserName.Text = user.UserName;
            this._user = user;

            cboRole.ItemsSource = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
            cboRole.SelectedValue = user.Role;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (Validate() == false)
            {
                return;
            }

            if (UsersBLL.GetDuplicateUserName(txtUserName.Text, this._user.Id) != null)
            {
                MessageBox.Show("Username is already used");
            }
            else
            {
                User user = new User();
                user.Id = Guid.NewGuid();
                user.UserName = txtUserName.Text;
                user.LastName = txtLastName.Text;
                user.FirstName = txtFirstName.Text;

                Role role = new Role();
                if (cboRole.SelectedValue.ToString() == Role.Admin.ToString())
                {
                    role = Role.Admin;
                }
                else if (cboRole.SelectedValue.ToString() == Role.Cashier.ToString())
                {
                    role = Role.Cashier;
                }
                else if (cboRole.SelectedValue.ToString() == Role.Chef.ToString())
                {
                    role = Role.Chef;
                }
                else if (cboRole.SelectedValue.ToString() == Role.InventoryController.ToString())
                {
                    role = Role.InventoryController;
                }
                else if (cboRole.SelectedValue.ToString() == Role.Waiter.ToString())
                {
                    role = Role.Waiter;
                }

                user.Role = role;
                user.Id = this._user.Id;
                UsersBLL.Update(user);
                MessageBox.Show("User successfully updated.");
                this.Close();
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtUserName.Text) ||
               string.IsNullOrEmpty(txtFirstName.Text) ||
               string.IsNullOrEmpty(txtLastName.Text) ||
               cboRole.SelectedValue == null)
            {
                MessageBox.Show("Please input correct values");
                return false;
            };

            return true;
        }
    }
}
