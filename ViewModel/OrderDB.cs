using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class OrderDB : BaseDB
    {

        protected override BaseEntity NewEntity()
        {
            return new Order();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Order order = entity as Order;
            
            

            order.OrderID = int.Parse(reader["OrderID"].ToString());
            order.OrderAddress = reader["OrderAddress"].ToString();
            order.Customer = new CustomerDB().SelectByID(int.Parse(reader["CustomerID"].ToString()));
            order.OrderNotes = reader["OrderNotes"].ToString();
            order.OrderDate = (DateTime)reader["OrderDate"];
            order.OrderStatus = bool.Parse(reader["OrderStatus"].ToString());

            return order;
        }

        public OrderList SelectAll()
        {
            command.CommandText = "SELECT * From [Order]";
            OrderList lst = new OrderList(base.Select());
            return lst;
        }

        

        public Order SelectByID(int id)
        {
            command.Parameters.Clear();

            command.CommandText = "SELECT * From [Order] WHERE OrderID=@id";

            command.Parameters.Add(new OleDbParameter("@id", id));


            List<BaseEntity> lst = base.Select();

            if (lst.Count == 1) return lst[0] as Order;
            return null;
        }

        public OrderList SelectByCustomer(int id)
        {
            command.Parameters.Clear();

            command.CommandText = "SELECT * From [Order] WHERE CustomerID=@id";

            command.Parameters.Add(new OleDbParameter("@id", id));


            OrderList lst = new OrderList(base.Select());

            return lst;
        }

        public int Insert(Order order)
        {
            string sql = $"INSERT INTO [Order](CustomerID, OrderAddress, OrderNotes, OrderDate, OrderStatus)" +
                $" VALUES({order.Customer.CustomerID},'{order.OrderAddress}','{order.OrderNotes}',#{order.OrderDate}#,{order.OrderStatus})";

            int records = base.SaveChanges(sql);

            order.OrderID = base.lastID;
            return records;
        }

        public int Update(Order order)
        {
            string sql = $"Update [Order] SET OrderStatus='{order.OrderStatus}' WHERE OrderID={order.OrderID}";
            return base.SaveChanges(sql);
        }

    }
}
