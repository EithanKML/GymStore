using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

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

        public string CategoriesNames { 
           get {
                string str = "";
            foreach (Category category in Categories)
                {
                    str += category.CategoryName + ", ";
                }
                if (str != "")
                {
                    str = str.Substring(0, str.Length - 2);
                }
            return str;
            }  
        }

       public Item()
        {
            Categories = new CategoryList();
        }

        public Item(Item copy)
        {
            ItemID = copy.ItemID;
            ItemImage = copy.ItemImage;
            ItemPrice = copy.ItemPrice;
            ItemName = copy.ItemName;
            ItemDescription = copy.ItemDescription;
            ItemStock = copy.ItemStock;
            Categories = new CategoryList(copy.Categories);
        }

        public Item(int itemID, string itemImage, int itemPrice, string itemName, string itemDescription, int itemStock)
        {
            ItemID = itemID;
            ItemImage = itemImage;
            ItemPrice = itemPrice;
            ItemName = itemName;
            ItemDescription = itemDescription;
            ItemStock = itemStock;
            Categories = new CategoryList();
        }

        public bool Update(string name, int price, int stock, string image, string description)
        {
            ItemDB db = new ItemDB();

            this.ItemName = name;
            this.ItemPrice = price;
            this.ItemStock = stock;
            this.ItemImage = image;
            this.ItemDescription = description;

            if (db.Update(this) > 0)
                return true;
            else return false;

        }

        public void LoadCategories()
        {
            CategoryDB categoryDB = new CategoryDB();
            this.Categories = categoryDB.SelectByItemID(this.ItemID);
        }

        public void AddCategory(Category category)
        {
            ItemCategoryDB db = new ItemCategoryDB();
            ItemCategory ic = new ItemCategory(category, this);

            if (db.Insert(ic) > 0)
            {
                Categories.Add(category);
            }

        }

        public void RemoveCategory(Category category)
        {
            ItemCategoryDB db = new ItemCategoryDB();
            ItemCategory ic = new ItemCategory(category, this);

            if (db.Delete(ic) > 0)
            {
                Categories.RemoveAt(Categories.FindIndex(x => x.CategoryID == category.CategoryID));
            }
        }
    }
}
