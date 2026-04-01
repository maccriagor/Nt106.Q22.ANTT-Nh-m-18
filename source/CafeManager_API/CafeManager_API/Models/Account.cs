using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Postgrest.Attributes;
using Postgrest.Models;

namespace CafeManager_API.Models
{
    [Table("account")]
    public class Account : BaseModel
    {
        [PrimaryKey("accid", false)] public int AccId { get; set; }
        [Column("username")] public string Username { get; set; }
        [Column("userpassword")] public string Password { get; set; }
        [Column("email")] public string Email { get; set; }
        [Column("role")] public string Role { get; set; }
        [Column("phonenumber")] public string PhoneNumber { get; set; }
        [Column("createdat", ignoreOnInsert: true)]
        public DateTime? CreateDat { get; set; }
    }
}
