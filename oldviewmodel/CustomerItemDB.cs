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
    public class CustomerItemDB : BaseDB
    {

        protected override BaseEntity NewEntity()
        {
            return new CustomerItem();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            CustomerItem customeritem = entity as CustomerItem;

            customeritem.Item = new ItemDB().SelectByID(int.Parse(reader["ItemID"].ToString()));
            customeritem.Customer = new CustomerDB().SelectByID(int.Parse(reader["CustomerID"].ToString()));

            return customeritem;
        }

        public CustomerItemList SelectAll()
        {
            command.CommandText = "SELECT * From CustomerItem";
            CustomerItemList lst = new CustomerItemList(base.Select());
            return lst;
        }

        public int Insert(CustomerItem ci)
        {
            string sql = $"INSERT INTO CustomerItem(CustomerID, ItemID)" + $" VALUES('{ci.Customer.CustomerID}','{ci.Item.ItemID}')";

            int records = base.SaveChanges(sql);

            return records;
        }

        public int Delete(CustomerItem ci)
        {
            string sql = $"DELETE From CustomerItem WHERE ItemID={ci.Item.ItemID} AND CustomerID={ci.Customer.CustomerID}";
            return base.SaveChanges(sql);
        }
    }
}
