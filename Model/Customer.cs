using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Model
{
    public class Customer:BaseEntity
    {

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerPFP { get; set; }
        
        public string defCustomerPFP
        {
            get
            {
                if (CustomerPFP == "")
                    return "photos/defaultpfp.png";
                else return CustomerPFP;
            }
        }


        public bool IsAdmin { get; set; }

        public OrderList Orders { get; set; }

        public RatingList Ratings { get; set; }

        public ItemList Wishlist { get; set; }

        public Customer()
        {
            Orders = new OrderList();
            Wishlist = new ItemList();
            Ratings = new RatingList();
        }
        
        public Customer(Customer copy)
        {
            CustomerID = copy.CustomerID;
            CustomerName = copy.CustomerName;
            CustomerPhone = copy.CustomerPhone;
            CustomerEmail = copy.CustomerEmail;
            CustomerAddress = copy.CustomerAddress;
            CustomerPassword = copy.CustomerPassword;
            CustomerPFP = copy.CustomerPFP;
            IsAdmin = copy.IsAdmin;
            Orders = copy.Orders;
            Wishlist = new ItemList();
            Ratings = new RatingList();

        }

        public Customer(int id, string name, string phone, string email, string address, string password, string pfp, bool isadmin)
        {
            CustomerID = id;
            CustomerName = name;
            CustomerPhone = phone;
            CustomerEmail = email;
            CustomerAddress = address;
            CustomerPassword = password;
            CustomerPFP = pfp;
            IsAdmin = isadmin;
            Orders = new OrderList();
            Wishlist = new ItemList();
            Ratings = new RatingList();

        }

        public bool Update(string name, string phone, string email, string address, string password, string pfp, bool isadmin)
        {
            CustomerDB db = new CustomerDB();

            this.CustomerName = name;
            this.CustomerPhone = phone;
            this.CustomerEmail = email;
            this.CustomerAddress = address;
            this.CustomerPassword = password;
            this.CustomerPFP = pfp;
            this.IsAdmin = isadmin;

            if (db.Update(this) > 0)
                return true;
            else return false;

        }

        public Order AddOrder(string address, string notes)
        {
            Order o = new Order(0, this, address, notes, DateTime.Now, false);
            OrderDB db = new OrderDB();

            if (db.Insert(o) > 0)
            {
                Orders.Add(o);
                return o;
            }
            return null;

        }

        public void LoadOrders()
        {
            OrderDB db = new OrderDB();

            this.Orders = db.SelectByCustomer(this.CustomerID);
        }

        public void AddToWishList(Item item)
        {

            CustomerItemDB db = new CustomerItemDB();
            CustomerItem c = new CustomerItem(this, item);
            db.Insert(c);

            Wishlist.Add(item);
        }

        public void LoadWishList()
        {
            ItemDB db = new ItemDB();

            this.Wishlist = db.SelectByCustomerID(this.CustomerID);
        }

        public void DeleteFromWishList(Item item)
        {

            CustomerItemDB db = new CustomerItemDB();
            CustomerItem c = new CustomerItem(this, item);
            db.Delete(c);

            Wishlist.Remove(item);
        }

        public void AddRating(int rate, Item item, string text)
        {

            RatingDB ratingDB = new RatingDB();
            Rating rating = new Rating(this, item, DateTime.Now, text, rate);

            ratingDB.Insert(rating);

            Ratings.Add(rating);

        }
    }
}
