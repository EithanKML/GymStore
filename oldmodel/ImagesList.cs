using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ImagesList : List<Images>
    {

        public ImagesList()
        {

        }

        public ImagesList(IEnumerable<Images> lst) : base(lst)
        {

        }

        public ImagesList(IEnumerable<BaseEntity> lst) : base(lst.Cast<Images>().ToList())
        {

        }

    }
}
