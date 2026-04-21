using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeServer.Services
{
    public class ServiceManager
    {
        public static UserService User = new UserService();

        public static RevenueService Revenue = new RevenueService();

        public static DiscountService Discount = new DiscountService();
       
        // public static FoodService Food = new FoodService();

        // public static TableService Table = new TableService();
    }
}
