using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RatingList : List<Rating>
    {

        public RatingList()
        {

        }

        public RatingList(IEnumerable<Rating> lst) : base(lst)
        {

        }

        public RatingList(IEnumerable<BaseEntity> lst) : base(lst.Cast<Rating>().ToList())
        {

        }

    }
}
