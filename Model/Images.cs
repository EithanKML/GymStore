using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Images:BaseEntity
    {

        public int ImageID { get; set; }
        public Item Item { get; set; }
        public string ImageURL { get; set; }

        public Images()
        {

        }

        public Images(Images copy)
        {
            ImageID = copy.ImageID;
            Item = new Item(copy.Item);
            ImageURL = copy.ImageURL;
        }

        public Images(int imageid, Item item, string imageurl)
        {
            this.ImageID = imageid;
            this.Item = new Item(item);
            this.ImageURL = imageurl;
        }

    }
}
