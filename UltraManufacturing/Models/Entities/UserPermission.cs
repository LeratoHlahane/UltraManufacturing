using System;
using System.Collections.Generic;

namespace UltraManufacturing.Models.Entities
{
    public partial class UserPermission
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        public Permission Permission { get; set; }
        public User User { get; set; }
    }
}
