using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeServer.Services
{
    public class BillService
    {
        public async Task<bool> CheckIdExists(string tableName, string columnName, int id)
        {
            if (tableName == "nhanvien")
            {
                var res = await DatabaseService.Client.From<nhanvien>()
                    .Filter("manguoidung", Supabase.Postgrest.Constants.Operator.Equals, id)
                    .Get();
                return res.Models.Count > 0;
            }
            else if (tableName == "banan")
            {
                var res = await DatabaseService.Client.From<banan>()
                    .Filter("mabanan", Supabase.Postgrest.Constants.Operator.Equals, id)
                    .Get();
                return res.Models.Count > 0;
            }
            return false;
        }

        // 2. The internal models needed for the queries
        [Table("useraccount")]
        public class nhanvien : BaseModel
        {
            [PrimaryKey("manguoidung", false)]
            [Column("manguoidung")]
            public int manv { get; set; }
        }

        [Table("banan")]
        public class banan : BaseModel
        {
            [PrimaryKey("mabanan", false)]
            public int mabanan { get; set; }
        }
    }
}
