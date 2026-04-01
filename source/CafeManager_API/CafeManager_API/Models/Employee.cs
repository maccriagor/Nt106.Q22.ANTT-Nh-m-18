using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgrest.Attributes;
using Postgrest.Models;

namespace CafeManager_API.Models
{
    [Table("employees")]
    public class Employee : BaseModel
    {
        [PrimaryKey("empid", false)] public int EmpId { get; set; }
        [Column("accid")] public int AccId { get; set; }
        [Column("fullname")] public string FullName { get; set; }
        [Column("phonenumber")] public string PhoneNumber { get; set; }
    }
}
