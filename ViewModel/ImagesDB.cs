using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
//using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ImagesDB : BaseDB
    {

        protected override BaseEntity NewEntity()
        {
            return new Images();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Images images = entity as Images;

            images.ImageID = int.Parse(reader["ImageID"].ToString());
            images.ImageURL = reader["ImageURL"].ToString();
            images.Item = new ItemDB().SelectByID(int.Parse(reader["ItemID"].ToString()));


            return images;
        }

        public ImagesList SelectAll()
        {
            command.CommandText = "SELECT * From Images";
            ImagesList lst = new ImagesList(base.Select());
            return lst;
        }

        public Images SelectByID(int id)
        {
            command.Parameters.Clear();

            command.CommandText = "SELECT * From Images WHERE ImageID=@id";

            command.Parameters.Add(new OleDbParameter("@id", id));


            List<BaseEntity> lst = base.Select();

            if (lst.Count == 1) return lst[0] as Images;
            return null;
        }

        public int Insert(Images image)
        {
            string sql = $"INSERT INTO Images(ItemID, ImageURL)" +
                $" VALUES('{image.Item.ItemID}','{image.ImageURL}')";

            int records = base.SaveChanges(sql);

            return records;
        }

        public int Update(Images image)
        {
            string sql = $"Update Images SET ImageURL='{image.ImageURL}', ItemID='{image.Item.ItemID}' WHERE ImageID={image.ImageID}";

            return base.SaveChanges(sql);
        }
    }
}
