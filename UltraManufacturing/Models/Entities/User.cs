using System;
using System.Collections.Generic;

namespace UltraManufacturing.Models.Entities
{
    public partial class User
    {
        public User()
        {
            UserPermission = new HashSet<UserPermission>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }

        public UserCredential UserCredential { get; set; }
        public ICollection<UserPermission> UserPermission { get; set; }
    }
}
