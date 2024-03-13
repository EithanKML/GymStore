using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CustomerList : List<Customer>
    {

        public CustomerList()
        {

        }

        public CustomerList(IEnumerable<Customer> lst) : base(lst)
        {

        }

        public CustomerList(IEnumerable<BaseEntity> lst) : base(lst.Cast<Customer>().ToList())
        {

        }

    }
}
