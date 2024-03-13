using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderItem:BaseEntity
    {

        public Order Order { get; set; }
        public Item Item { get; set; }
        public int Amount { get; set; }
        public int CurrentPrice { get; set; }
        public string ItemName { get { return Item.ItemName; } }

        public string ItemImage { get { return Item.ItemImage; } }

        public int TotalPrice { get {  return Amount * CurrentPrice; } }
        public OrderItem()
        {

        }

        public OrderItem(OrderItem copy)
        {
            this.Order = new Order(copy.Order);
            this.Item = new Item(copy.Item);
            this.Amount = copy.Amount;
            this.CurrentPrice = copy.CurrentPrice;
        }

        public OrderItem(Order order, Item item, int amount, int currentPrice)
        {
            Order = order;
            Item = item;
            Amount = amount;
            CurrentPrice = currentPrice;
        }



    }
}
