using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.OleDb;

namespace ViewModel
{
    public abstract class BaseDB
    {

        protected string connString;
        protected OleDbConnection conn;
        protected OleDbCommand command;
        protected OleDbDataReader reader;
        protected int lastID;

        protected abstract BaseEntity NewEntity();

        protected abstract BaseEntity CreateModel(BaseEntity entity);

        public BaseDB()
        {
            connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\11thGrade\GymStore\GymStore\ViewModel\App_Data\Project.accdb";
            conn = new OleDbConnection(connString);
            command = new OleDbCommand();
            command.Connection = conn;
        }

        protected List<BaseEntity> Select()
        {

            List<BaseEntity> lst = new List<BaseEntity>();

            try
            {
                conn.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BaseEntity entity = NewEntity();

                    lst.Add(CreateModel(entity));
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL: " + command.CommandText);
            }

            finally
            {
                if (reader != null) reader.Close();
                if (conn.State == ConnectionState.Open) conn.Close();
            }

            return lst;
            
        }

        protected int SaveChanges(string sql)
        {
            int records = 0;

            try
            {
                command.CommandText = sql;
                conn.Open();
                records = command.ExecuteNonQuery();

                command.CommandText = "select @@Identity";
                var id = command.ExecuteScalar();
                lastID = int.Parse(id.ToString());
            }

            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL: " + command.CommandText);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }

            return records;

        }
    }
}

