using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CustomerItemList : List<CustomerItem>
    {

        public CustomerItemList()
        {

        }

        public CustomerItemList(IEnumerable<CustomerItem> lst) : base(lst)
        {

        }

        public CustomerItemList(IEnumerable<BaseEntity> lst) : base(lst.Cast<CustomerItem>().ToList())
        {

        }

    }
}
