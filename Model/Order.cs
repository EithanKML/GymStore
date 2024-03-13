using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

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

        public OrderItemList ItemList { get; set; }

        public Order()
        {
            ItemList=new OrderItemList();
        }

        public Order(Order copy)
        {
            this.OrderID = copy.OrderID;
            this.Customer = new Customer(copy.Customer);
            this.OrderAddress = copy.OrderAddress;
            this.OrderNotes = copy.OrderNotes;
            this.OrderDate = copy.OrderDate;
            this.OrderStatus = copy.OrderStatus;
            this.ItemList = copy.ItemList;
        }
        public Order(int orderID, Customer customer, string orderAddress, string orderNotes, DateTime orderDate, bool orderStatus)
        {
            OrderID = orderID;
            Customer = customer;
            OrderAddress = orderAddress;
            OrderNotes = orderNotes;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
            ItemList = new OrderItemList();

        }

        public void SaveItemsToDB()
        {
            OrderItemDB db = new OrderItemDB();
            foreach (OrderItem item in ItemList)
            {
                item.Order = new Order(this);
                item.Item.Update(item.Item.ItemName, item.Item.ItemPrice, item.Item.ItemStock - item.Amount, item.Item.ItemImage, item.Item.ItemDescription);
                db.Insert(item);
            }
        }

        public void LoadOrderItems()
        {
            int id = this.OrderID;
            OrderItemDB itemDB = new OrderItemDB();

            ItemList = itemDB.SelectByOrderID(id);
        }
    }
}
