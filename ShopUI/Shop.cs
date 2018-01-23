using ShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopUI
{
    public partial class Shop : Form
    {
        private Store store = new Store();
        //list of everything in the shopping cart
        private List<Item> shoppingCartData = new List<Item>();
        //connects this to ui
        BindingSource itemsBinding = new BindingSource();
        BindingSource cartBinding = new BindingSource();

        //constructor. once its called it will initialize component then it will call setupdata which has dummy data
        public Shop()
        {
            InitializeComponent();
            SetupData();

            //links our items to this binding source
            itemsBinding.DataSource = store.Items;
            itemsListBox.DataSource = itemsBinding;

            itemsListBox.DisplayMember = "Display";
            itemsListBox.ValueMember = "Display";

            cartBinding.DataSource = shoppingCartData;
            shoppingCartListBox.DataSource = cartBinding;

            shoppingCartListBox.DisplayMember = "Display";
            shoppingCartListBox.ValueMember = "Display";
        }

        private void SetupData()
        {
         

            store.Vendors.Add(new Vendor { FirstName = "Bill", LastName = "Smith"});
            store.Vendors.Add(new Vendor { FirstName = "Sue", LastName = "Jones"});

            store.Items.Add(new Item
            {
                Title = "Moby Dick",
                Description = "A book about a whale",
                Price = 4.50M,
                Owner = store.Vendors[0]
            });

            store.Items.Add(new Item
            {
                Title = "A Tale of Two Citties",
                Description = "A book about a revolutoin",
                Price = 3.80M,
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                Title = "Harry Potter Book 1",
                Description = "A book about a boy",
                Price = 5.20M,
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                Title = "Jane Eyre",
                Description = "A book about a girl",
                Price = 1.50M,
                Owner = store.Vendors[1]
            });

            store.Name = "Seconds are Better";
        }

        private void Shop_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // button for adding to cart.

            //the selected item
            Item selectedItem = (Item)itemsListBox.SelectedItem;

            //add selected item to shopping cart
            shoppingCartData.Add(selectedItem);

            //reset to show new items in cart
            cartBinding.ResetBindings(false);
        }

        private void makePurchase_Click(object sender, EventArgs e)
        {
            //mark each iem in the cart as sold
            //clear cart

            //loops thorugh every item in cart and mark as sold
            foreach (Item item in shoppingCartData)
            {
                item.Sold = true;
            }

            shoppingCartData.Clear();

            cartBinding.ResetBindings(false);
        }
    }
}
