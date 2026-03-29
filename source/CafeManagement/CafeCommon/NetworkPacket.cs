using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCommon
{
    public class NetworkPacket //này là dữ liệu mẫu thôi
    {
        public string Command { get; set; } // LOGIN, REGISTER, LOGOUT...
        public string Data { get; set; }    // Chuỗi JSON chứa thông tin
    }
}
