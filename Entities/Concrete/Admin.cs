using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        public byte[] AdminName { get; set; }

        [StringLength(50)]
        public string AdminUserName { get; set; }

        [StringLength(50)]
        public string AdminPassword { get; set; }

        public string Mail { get; set; }

        [StringLength(1)]
        public string AdminRole { get; set; }

        public bool  Status { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] AdminUserNameSalt { get; set; }

        public byte[] AdminUserNameHash { get; set; }
        
    }
}
