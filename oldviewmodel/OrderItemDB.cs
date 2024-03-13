using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class OrderItemDB : BaseDB
    {

        protected override BaseEntity NewEntity()
        {
            return new OrderItem();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            OrderItem orderitem = entity as OrderItem;

            int orderid = int.Parse(reader["OrderID"].ToString());
            OrderDB db = new OrderDB();
            orderitem.Order = new Order(db.SelectByID(orderid));

            int itemid = int.Parse(reader["ItemID"].ToString());
            ItemDB db1 = new ItemDB();
            orderitem.Item = new Item(db1.SelectByID(itemid));

            orderitem.Amount = int.Parse(reader["OrderID"].ToString());
            orderitem.CurrentPrice = int.Parse(reader["CurrentPrice"].ToString());

            return orderitem;
        }




        public OrderItemList SelectByOrderID(int id)
        {
            command.Parameters.Clear();

            command.CommandText = "SELECT * From OrderItem WHERE OrderID=@id";

            command.Parameters.Add(new OleDbParameter("@id", id));


            OrderItemList lst = new OrderItemList(base.Select());

            return lst;
            
        }

        public int Insert(OrderItem oi)
        {
            string sql = $"INSERT INTO OrderItem(OrderID, ItemID, Amount, CurrentPrice)" + $"VALUES('{oi.Order.OrderID}','{oi.Item.ItemID}','{oi.Amount}','{oi.CurrentPrice}')";
            int records = base.SaveChanges(sql);
            return records;
        }

    }
}
