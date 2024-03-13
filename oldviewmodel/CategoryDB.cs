using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CategoryDB : BaseDB
    {

        protected override BaseEntity NewEntity()
        {
            return new Category();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Category category = entity as Category;
            category.CategoryID = int.Parse(reader["CategoryID"].ToString());
            category.CategoryName = reader["CategoryName"].ToString();
            return category;
        }



        public Category SelectCategoryName(string name)
        {
            command.Parameters.Clear();

            command.CommandText = "SELECT * From Category WHERE CategoryName=@name";

            command.Parameters.Add(new OleDbParameter("@name", name));


            List<BaseEntity> lst = base.Select();

            if (lst.Count == 1) return lst[0] as Category;
            return null;
        }

        public Category SelectCategoryID(int id)
        {
            command.Parameters.Clear();

            command.CommandText = "SELECT * From Category WHERE CategoryID=@id";

            command.Parameters.Add(new OleDbParameter("@id", id));


            List<BaseEntity> lst = base.Select();

            if (lst.Count == 1) return lst[0] as Category;
            return null;
        }

        public CategoryList SelectAll()
        {
            command.CommandText = "SELECT * From Category";
            CategoryList lst = new CategoryList(base.Select());
            return lst;
        }

        public int Insert(Category category)
        {
            string sql = $"INSERT INTO Category(CategoryName)" + $" VALUES('{category.CategoryName}')";

            int records = base.SaveChanges(sql);

            category.CategoryID = base.lastID;
            return records;
        }

        public int Update(Category category)
        {
            string sql = $"Update Category SET CategoryName='{category.CategoryName}' WHERE CategoryID={category.CategoryID}";
            return base.SaveChanges(sql);
        }

    }
}
