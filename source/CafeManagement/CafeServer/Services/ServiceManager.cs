using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CafeServer.Services
{
    public class ServiceManager
    {
        public static UserService User = new UserService();

        public static RevenueService Revenue = new RevenueService();

        public static DiscountService Discount = new DiscountService();

        public static MenuService Menu = new MenuService();

        public static TableService Table = new TableService();

        public static BillService Bill = new BillService();

        public static OrderService Order = new OrderService();

        public static CustomerService Customer = new CustomerService();

        public static KitchenService Kitchen = new KitchenService();

        // public static FoodService Food = new FoodService();

        // public static TableService Table = new TableService();
    }
}
