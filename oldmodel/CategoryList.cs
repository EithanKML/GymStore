using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CategoryList : List<Category>
    {

        public CategoryList()
        {

        }

        public CategoryList(IEnumerable<Category> lst) :base(lst)
        {

        }

        public CategoryList(IEnumerable<BaseEntity> lst) :base(lst.Cast<Category>().ToList())
        {

        }



    }
}
