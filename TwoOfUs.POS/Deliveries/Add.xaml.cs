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

namespace TwoOfUs.POS.Deliveries
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public CustomDelivery delivery = new CustomDelivery();
        private Deliveries.List _sender;

        public Add(Deliveries.List sender)
        {
            InitializeComponent();
            lblDate.Content = DateTime.Now.ToString("ddd dd MMMM yyyy");
            delivery.Date = DateTime.Now;
            this._sender = sender;
        }

        public void ShowList()
        {
            grDeliveryItemList.ItemsSource = null;
            grDeliveryItemList.ItemsSource = this.delivery.Items;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Deliveries.AddItem addItemWindow = new Deliveries.AddItem(this);
            addItemWindow.Show();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var saved = DeliveryBLL.Create(delivery);
            this._sender.showList();
            this.Close();
        }
    }
}
