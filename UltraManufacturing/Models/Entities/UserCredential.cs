﻿using System;
using System.Collections.Generic;

namespace UltraManufacturing.Models.Entities
{
    public partial class UserCredential
    {
        public int Id { get; set; }
        public string HashedPassword { get; set; }
        public string PasswordSalt { get; set; }

        public User IdNavigation { get; set; }
    }
}