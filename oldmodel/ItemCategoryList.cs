using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ItemCategoryList : List<ItemCategory>
    {

        public ItemCategoryList()
        {

        }

        public ItemCategoryList(IEnumerable<ItemCategory> lst) : base(lst)
        {

        }

        public ItemCategoryList(IEnumerable<BaseEntity> lst) : base(lst.Cast<ItemCategory>().ToList())
        {

        }

    }
}
