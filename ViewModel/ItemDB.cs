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
    public class ItemDB : BaseDB
    {

        protected override BaseEntity NewEntity()
        {
            return new Item();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Item item = entity as Item;
            

            item.ItemID = int.Parse(reader["ItemID"].ToString());
            item.ItemName = reader["ItemName"].ToString();
            item.ItemImage = reader["ItemImage"].ToString();
            item.ItemPrice = int.Parse(reader["ItemPrice"].ToString());
            item.ItemDescription = reader["ItemDescription"].ToString();
            item.ItemStock = int.Parse(reader["ItemStock"].ToString());

            return item;
        }

        public ItemList SelectAll()
        {
            command.CommandText = "SELECT * From Item";
            ItemList lst = new ItemList(base.Select());
            return lst;
        }

        public Item SelectByID(int id)
        {
            command.Parameters.Clear();

            command.CommandText = "SELECT * From Item WHERE ItemID=@id";

            command.Parameters.Add(new OleDbParameter("@id", id));


            List<BaseEntity> lst = base.Select();

            if (lst.Count == 1) return lst[0] as Item;
            return null;
        }

        public ItemList SelectByCustomerID(int customerID)
        {
            command.Parameters.Clear();

            command.CommandText = "SELECT Item.* FROM Item INNER JOIN CustomerItem ON Item.ItemID = CustomerItem.ItemID WHERE CustomerItem.CustomerID=@customerID";
            command.Parameters.Add(new OleDbParameter("@customerID", customerID));
            ItemList lst = new ItemList(base.Select());
            return lst;
        }

        public int Insert(Item item)
        {
            string sql = $"INSERT INTO Item(ItemName, ItemPrice, ItemDescription, ItemImage, ItemStock)" +
                $" VALUES('{item.ItemName}','{item.ItemPrice}','{item.ItemDescription}','{item.ItemImage}','{item.ItemStock}')";

            int records = base.SaveChanges(sql);

            item.ItemID = base.lastID;
            return records;
        }

        public int Update(Item item)
        {
            string sql = $"Update Item SET ItemName='{item.ItemName}', ItemPrice={item.ItemPrice}, ItemDescription='{item.ItemDescription}'," +
                $" ItemImage='{item.ItemImage}', ItemStock={item.ItemStock} WHERE ItemID={item.ItemID}";

            return base.SaveChanges(sql);
        }

    }
}
