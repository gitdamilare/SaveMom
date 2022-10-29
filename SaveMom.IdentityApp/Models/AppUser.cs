﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SaveMom.IdentityApp.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [MaxLength(250)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(250)]
        public string? LastName { get; set; }

        public string? IdentityDocumentUrl { get; set; }
    }
}
