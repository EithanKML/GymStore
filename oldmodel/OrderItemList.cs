using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderItemList : List<OrderItem>
    {

        public OrderItemList()
        {

        }

        public OrderItemList(IEnumerable<OrderItem> lst) : base(lst)
        {

        }

        public OrderItemList(IEnumerable<BaseEntity> lst) : base(lst.Cast<OrderItem>().ToList())
        {

        }

    }
}
