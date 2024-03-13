using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public OrderList Orders { get; set; }

        public RatingList Ratings { get; set; }

        public CustomerItemList Wishlist { get; set; }

        public Customer()
        {

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
        }

        public Customer(int id, string name, string phone, string email, string address, string password, string pfp)
        {
            CustomerID = id;
            CustomerName = name;
            CustomerPhone = phone;
            CustomerEmail = email;
            CustomerAddress = address;
            CustomerPassword = password;
            CustomerPFP = pfp;
        }

    }
}
