using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CustomerItem:BaseEntity
    {

        public Customer Customer { get; set; }
        public Item Item { get; set; }

        public CustomerItem()
        {

        }

        public CustomerItem(CustomerItem copy)
        {
            Customer = new Customer(copy.Customer);
            Item = new Item(copy.Item);
        }

        public CustomerItem(Customer customer, Item item)
        {
            this.Customer = new Customer(customer); //????
            this.Item = new Item(item);

        }
    }
}
