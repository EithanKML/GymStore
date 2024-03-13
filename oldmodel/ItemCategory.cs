using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ItemCategory:BaseEntity
    {

        public Category Category { get; set; }
        public Item Item { get; set; }

        public ItemCategory()
        {

        }

        public ItemCategory(ItemCategory copy)
        {
            this.Category = new Category(copy.Category);
            this.Item = new Item(copy.Item);
        }

        public ItemCategory(Category category, Item item)
        {
            Category = new Category(category);
            Item = new Item(item);
        }
    }
}
