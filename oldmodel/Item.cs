using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Item:BaseEntity
    {

        public int ItemID { get; set; }
        public string ItemImage { get; set; }
        public int ItemPrice { get; set; }
        public string ItemName { get; set; }

        public string ItemDescription { get; set; }
        public int ItemStock { get; set; }

        public RatingList Ratings { get; set; }

        public ImagesList Images { get; set; }

        public CategoryList Categories { get; set; }

       public Item()
        {

        }

        public Item(Item copy)
        {
            ItemID = copy.ItemID;
            ItemImage = copy.ItemImage;
            ItemPrice = copy.ItemPrice;
            ItemName = copy.ItemName;
            ItemDescription = copy.ItemDescription;
            ItemStock = copy.ItemStock;
        }

        public Item(int itemID, string itemImage, int itemPrice, string itemName, string itemDescription, int itemStock)
        {
            ItemID = itemID;
            ItemImage = itemImage;
            ItemPrice = itemPrice;
            ItemName = itemName;
            ItemDescription = itemDescription;
            ItemStock = itemStock;
        }
    }
}
