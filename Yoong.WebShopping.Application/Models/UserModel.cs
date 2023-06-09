﻿using System.ComponentModel.DataAnnotations;
using UseEntity.Entities;

namespace UseEntity.Models
{
    public class UserModel
    {
        
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Geneder? Geneder { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

    }
}
