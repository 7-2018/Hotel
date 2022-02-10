﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class Receptionist
    {
        [Column(name: "Email")]
        [Key]
        public string Email { get; set; }
        [Required]
        [Column(name: "Password")]
        public string Password { get; set; }

    }
}
