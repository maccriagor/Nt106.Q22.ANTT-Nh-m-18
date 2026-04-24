using CafeClient;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace CafeCommon
{
    public static class PrimaryKeyCheck
    {

        public static async Task<bool> Exists(string tableName, string columnName, int id)
        {
            try
            {
                // We reuse the SocketClient to ask the server
                // Command format: CHECK_EXISTS|table|column|id
                string request = $"CHECK_EXISTS|{tableName}|{columnName}|{id}";
                string response = await SocketClient.SendRequestAsync(request);

                return response == "EXISTS_TRUE";
            }
            catch
            {
                return false;
            }
        }
    }
}