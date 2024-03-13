using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Category : BaseEntity
    {

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public ItemCategoryList CategoryItems { get; set; }

        public Category()
        {

        }

        public Category(Category copy)
        {
            CategoryID = copy.CategoryID;
            CategoryName = copy.CategoryName;
        }

        public Category(int CategoryID, string CategoryName)
        {
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;
        }
    }
}
