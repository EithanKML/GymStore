using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CustomerDB : BaseDB
    {

        protected override BaseEntity NewEntity()
        {
            return new Customer();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Customer customer = entity as Customer;
            customer.CustomerAddress = reader["CustomerAddress"].ToString();
            customer.CustomerID = int.Parse(reader["CustomerID"].ToString());
            customer.CustomerEmail = reader["CustomerEmail"].ToString();
            customer.CustomerPFP = reader["CustomerPFP"].ToString();
            customer.CustomerPhone = reader["CustomerPhone"].ToString();
            customer.CustomerName = reader["CustomerName"].ToString();
            customer.CustomerPassword = reader["CustomerPassword"].ToString();
            customer.IsAdmin = bool.Parse(reader["IsAdmin"].ToString());
            return customer;
        }

        public Customer SelectByEmail(string email, string password)
        {
            command.Parameters.Clear();

            command.CommandText = "SELECT * From Customer WHERE CustomerEmail=@Email AND CustomerPassword=@Password";

            command.Parameters.Add(new OleDbParameter("@Email", email));
            command.Parameters.Add(new OleDbParameter("@Password", password));

            List<BaseEntity> lst = base.Select();

            if (lst.Count == 1) return lst[0] as Customer;
            return null;
        }

        public Customer SelectByEmail(string email)
        {
            command.Parameters.Clear();

            command.CommandText = "SELECT * From Customer WHERE CustomerEmail=@Email";

            command.Parameters.Add(new OleDbParameter("@Email", email));
            

            List<BaseEntity> lst = base.Select();

            if (lst.Count == 1) return lst[0] as Customer;
            return null;
        }

        public Customer SelectByID(int id)
        {
            command.Parameters.Clear();

            command.CommandText = "SELECT * From Customer WHERE CustomerID=@id";

            command.Parameters.Add(new OleDbParameter("@id", id));
            

            List<BaseEntity> lst = base.Select();

            if (lst.Count == 1) return lst[0] as Customer;
            return null;
        }

        public int Insert(Customer customer)
        {
            string sql = $"INSERT INTO Customer(CustomerName, CustomerPhone, CustomerEmail, CustomerAddress, CustomerPassword, CustomerPFP, IsAdmin)" + 
                $" VALUES('{customer.CustomerName}','{customer.CustomerPhone}','{customer.CustomerEmail}','{customer.CustomerAddress}','{customer.CustomerPassword}','{customer.CustomerPFP}',{customer.IsAdmin})";

            int records = base.SaveChanges(sql);

            customer.CustomerID = base.lastID;
            return records;
        }

        public int Update(Customer customer)
        {
            string sql = $"Update Customer SET CustomerName='{customer.CustomerName}', CustomerPhone='{customer.CustomerPhone}', CustomerEmail='{customer.CustomerEmail}'," +
                $" CustomerAddress='{customer.CustomerAddress}', CustomerPassword='{customer.CustomerPassword}', CustomerPFP='{customer.CustomerPFP}', IsAdmin={customer.IsAdmin} WHERE CustomerID={customer.CustomerID}";

            return base.SaveChanges(sql);
        }

    }
}
