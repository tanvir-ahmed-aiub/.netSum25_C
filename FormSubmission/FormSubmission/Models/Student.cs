﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class Student
    {
        [Required]
        [Range(1,40)]
        public int? Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(200,MinimumLength =20)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email Needed")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        public string[] Hobbies { get; set; }

        public DateTime Dob { get; set; }

        public Student() { 
            Dob = DateTime.Now;
        }

    }
}