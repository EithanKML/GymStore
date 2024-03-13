using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Model
{
    public class Helper
    {
        public static Customer Login(string email, string password)
        {
            CustomerDB db = new CustomerDB();
            return db.SelectByEmail(email, password);
        }
    }
}
