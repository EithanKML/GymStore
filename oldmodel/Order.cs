using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order:BaseEntity
    {

        public int OrderID { get; set; }
        public Customer Customer { get; set; }
        public string OrderAddress { get; set; }
        public string OrderNotes { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderStatus { get; set; }

        public Order()
        {

        }

        public Order(Order copy)
        {
            this.OrderID = copy.OrderID;
            this.Customer = new Customer(copy.Customer);
            this.OrderAddress = copy.OrderAddress;
            this.OrderNotes = copy.OrderNotes;
            this.OrderDate = copy.OrderDate;
            this.OrderStatus = copy.OrderStatus;
        }
        public Order(int orderID, Customer customer, string orderAddress, string orderNotes, DateTime orderDate, bool orderStatus)
        {
            OrderID = orderID;
            Customer = customer;
            OrderAddress = orderAddress;
            OrderNotes = orderNotes;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
        }
    }
}
