using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ItemList : List<Item>
    {

        public ItemList()
        {

        }

        public ItemList(IEnumerable<Item> lst) : base(lst)
        {

        }

        public ItemList(IEnumerable<BaseEntity> lst) : base(lst.Cast<Item>().ToList())
        {

        }

    }
}
