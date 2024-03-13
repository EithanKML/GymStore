using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace ViewModel
{
    public class ItemCategoryDB : BaseDB
    {

        protected override BaseEntity NewEntity()
        {
            return new ItemCategory();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            ItemCategory itemcategory = entity as ItemCategory;
            int itemid = int.Parse(reader["ItemID"].ToString());
            ItemDB db = new ItemDB();
            itemcategory.Item = new Item(db.SelectByID(itemid));


            int categoryid = int.Parse(reader["ItemID"].ToString());
            CategoryDB dbc = new CategoryDB();
            itemcategory.Category = new Category(dbc.SelectCategoryID(categoryid));

            return itemcategory;
        }

        public ItemCategoryList SelectAll(int id)
        {
            command.Parameters.Clear();

            command.CommandText = "SELECT * From ItemCategory WHERE CategoryID=@id";

            command.Parameters.Add(new OleDbParameter("@id", id));


            ItemCategoryList lst = new ItemCategoryList(base.Select());

            return lst;
        }

        public int Insert(ItemCategory ic)
        {
            string sql = $"INSERT INTO ItemCategory(ItemID, CategoryID)" + $"VALUES('{ic.Item.ItemID}','{ic.Category.CategoryID}')";
            int records = base.SaveChanges(sql);
            return records;
        }

        public int Delete(ItemCategory ic)
        {
            string sql = $"DELETE From ItemCategory WHERE ItemID={ic.Item.ItemID} AND CategoryID={ic.Category.CategoryID}";
            return base.SaveChanges(sql);
        }
    }
}
