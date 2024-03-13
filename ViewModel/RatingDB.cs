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
    public class RatingDB : BaseDB
    {

        protected override BaseEntity NewEntity()
        {
            return new Rating();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
           
            Rating rating = new Rating();

            rating.Customer = new CustomerDB().SelectByID(int.Parse(reader["CustomerID"].ToString()));

            int itemid = int.Parse(reader["ItemID"].ToString());
            ItemDB db = new ItemDB();
            rating.Item = new Item(db.SelectByID(itemid));

            rating.Rate = int.Parse(reader["Rate"].ToString());
            rating.Notes = reader["Rate"].ToString();
            rating.RateDate = (DateTime)reader["RateDate"];

            return rating;
        }

        public RatingList SelectAll()
        {
            command.CommandText = "SELECT * From Rating";
            RatingList lst = new RatingList(base.Select());
            return lst;
        }

        public RatingList SelectByItemID(int id)
        {
            command.Parameters.Clear();

            command.CommandText = "SELECT * From Rating WHERE ItemID=@id";

            command.Parameters.Add(new OleDbParameter("@id", id));


            RatingList lst = new RatingList(base.Select());

            return lst;

        }

        public int Insert(Rating rating)
        {
            string sql = $"INSERT INTO Rating(CustomerID, ItemID, RateDate, Notes, Rate)" +
                $" VALUES('{rating.Customer.CustomerID}','{rating.Item.ItemID}',#{rating.RateDate}#,'{rating.Notes}','{rating.Rate}')";

            int records = base.SaveChanges(sql);

            return records;
        }

        public int Update(Rating rating)
        {
            string sql = $"Update Rating SET Rate='{rating.Rate}', Notes='{rating.Notes}' WHERE CustomerID={rating.Customer.CustomerID} AND ItemID={rating.Item.ItemID}";

            return base.SaveChanges(sql);
        }

    }
}
