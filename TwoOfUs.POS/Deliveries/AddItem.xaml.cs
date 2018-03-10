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
using TwoOfUs.Domain.CustomModels;
using TwoOfUs.Domain.Models;

namespace TwoOfUs.POS.Deliveries
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        private List<Material> materials = MaterialBLL.GetAll();
        private Deliveries.Add _sender;

        public AddItem(Deliveries.Add sender)
        {
            InitializeComponent();
            this._sender = sender;
        }


        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            bool found = false;
            var border = (resultStack.Parent as ScrollViewer).Parent as Border;
            var data = materials.Select(a => a.Name).ToList();

            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                // Clear   
                resultStack.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list   
            resultStack.Children.Clear();

            // Add the result   
            foreach (var obj in data)
            {
                if (obj.ToLower().StartsWith(query.ToLower()))
                {
                    // The word starts with this... Autocomplete must work   
                    addItem(obj);
                    found = true;
                }
            }

            if (!found)
            {
                resultStack.Children.Add(new TextBlock() { Text = "No results found." });
            }
        }

        private void addItem(string text)
        {
            TextBlock block = new TextBlock();

            // Add the text   
            block.Text = text;

            // A little style...   
            block.Margin = new Thickness(2, 3, 2, 3);
            block.Cursor = Cursors.Hand;

            // Mouse events   
            block.MouseLeftButtonUp += (sender, e) =>
            {
                textBox.Text = (sender as TextBlock).Text;

                Material material = MaterialBLL.SearchByName((sender as TextBlock).Text);

                lblMaterialId.Content = material.Id.ToString();
            };

            block.MouseEnter += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.PeachPuff;
            };

            block.MouseLeave += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.Transparent;
            };

            // Add to the panel   
            resultStack.Children.Add(block);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(Validate() == false)
            {
                MessageBox.Show("Please specify a correct quantity and make sure that the material has not been added yet.");
                return;
            }

            decimal val = 0;
            decimal.TryParse(txtQty.Text, out val);

            CustomDeliveryItem item = new CustomDeliveryItem()
            {
                MaterialId = Guid.Parse(lblMaterialId.Content.ToString()),
                MaterialName = textBox.Text,
                Quantity = val
            };

            if(this._sender.delivery.Items == null)
            {
                this._sender.delivery.Items = new List<CustomDeliveryItem>();
            }

            this._sender.delivery.Items.Add(item);
            this._sender.ShowList();
            this.Close();
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtQty.Text))
            {
                return false;
            }

            decimal val = 0;
            decimal.TryParse(txtQty.Text, out val);
            if(val < 1)
            {
                return false;
            }

            var list = this._sender.delivery.Items;
            if(list != null) { 
                var duplicate = list.FirstOrDefault(m => m.MaterialId == Guid.Parse(lblMaterialId.Content.ToString()));
                if(duplicate != null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
