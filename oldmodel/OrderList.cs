using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderList : List<Order>
    {

        public OrderList()
        {

        }

        public OrderList(IEnumerable<Order> lst) : base(lst)
        {

        }

        public OrderList(IEnumerable<BaseEntity> lst) : base(lst.Cast<Order>().ToList())
        {

        }

    }
}
