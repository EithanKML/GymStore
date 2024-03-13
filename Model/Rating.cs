using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rating:BaseEntity
    {

        public Customer Customer { get; set; }
        public Item Item { get; set; }
        public DateTime RateDate { get; set; }
        public string Notes { get; set; }
        public int Rate { get; set; }

        public Rating()
        {

        }

        public Rating(Customer customer, Item item, DateTime rateDate, string notes, int rate)
        {
            Customer = customer;
            Item = item;
            RateDate = rateDate;
            Notes = notes;
            Rate = rate;
        }

        public Rating(Rating copy)
        {
            this.Customer = new Customer(copy.Customer);
            this.Item = new Item(copy.Item);
            this.RateDate = copy.RateDate;
            this.Notes = copy.Notes;
            this.Rate = copy.Rate;
        }
        

    }
}
