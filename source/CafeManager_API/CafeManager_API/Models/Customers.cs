using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgrest.Attributes;
using Postgrest.Models;

namespace CafeManager_API.Models
{
    [Table("customers")]
    public class Customers : BaseModel
    {
        [PrimaryKey("cusid", false)] public int CusId { get; set; }
        [Column("accid")] public int AccId { get; set; }
        [Column("fullname")] public string FullName { get; set; }
        [Column("phonenumber")] public string PhoneNumber { get; set; }
        [Column("points")] public int Points { get; set; }
    }
}
