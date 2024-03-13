using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderItemList : List<OrderItem>
    {
      
        public int Total
        {
            get
            {
                int sum = 0;

                if (this.Count == 0) return 0;


                for (int i = 0; i < this.Count; i++)
                {
                    sum += this[i].Item.ItemPrice * this[i].Amount;
                }

                return sum;
            }
        }

        public int amount
        {
            get { return this.Count; }
        }
        public OrderItemList()
        {

        }

        public OrderItemList(IEnumerable<OrderItem> lst) : base(lst)
        {

        }

        public OrderItemList(IEnumerable<BaseEntity> lst) : base(lst.Cast<OrderItem>().ToList())
        {

        }

        public void AddToCart(Item item, int amount,Order o) 
        { 

            //if exists - add to quantity
            if(this.Exists(x=>x.Item.ItemID == item.ItemID))
            {
                this.Find(x=>x.Item.ItemID==item.ItemID).Amount+=amount;
            }
            else //else - add to list
            {
                this.Add(new OrderItem(o, item,amount,item.ItemPrice));
            }
            
            
        }
    }
}
