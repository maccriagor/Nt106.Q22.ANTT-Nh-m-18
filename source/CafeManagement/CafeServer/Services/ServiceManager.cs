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

        // Sau này có thêm Food, bạn chỉ cần thêm 1 dòng:
        // public static FoodService Food = new FoodService();

        // public static TableService Table = new TableService();
    }
}
