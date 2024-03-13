using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Model
{
    public class Helper
    {
        public static Customer Login(string email, string password)
        {
            CustomerDB db = new CustomerDB();
            return db.SelectByEmail(email, password);
        }

        public static Customer Register(string name, string email, string password)
        {
            CustomerDB db = new CustomerDB();
            //check if email exists
            if (db.SelectByEmail(email) != null) return null;


            Customer customer = new Customer(0, name, "", email, "", password, "", false);
            if (db.Insert(customer) > 0)
                return customer;
            else return null;

        }

        public static Item AddItem(string name, int price, string description, string image, int stock)
        {
            ItemDB db = new ItemDB();

            Item item = new Item(0, image, price, name, description, stock);
            if (db.Insert(item) > 0)
                return item;
            else return null;

        }

        public static ItemList AllItems()
        {
            ItemDB db = new ItemDB();
            ItemList lst = db.SelectAll();
            foreach (Item item in lst)
            {
                item.LoadCategories();
            }
            return lst;
        }

        public static CategoryList AllCategories()
        {

            CategoryDB categoryDB = new CategoryDB();

            return categoryDB.SelectAll();
        }
    }
}
