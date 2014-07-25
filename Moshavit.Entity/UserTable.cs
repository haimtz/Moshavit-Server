﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Moshavit.Entity.EntityTable;

namespace Moshavit.Entity.TableEntity
{
    [Table("Users")]
    public class UserTable
    {
        /// <summary>
        /// unique User Id
        /// </summary>
        [Key]
        public int IdUser { get; set; }

        /// <summary>
        /// User password' entry to the system
        /// </summary>
        [Required]
        public string Password { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone is Required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        public string Address { get; set; }

        public bool IsResident { get; set; }

        public DateTime StartTime { get; set; }

        public string Token { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<MessageTable> Messages { get; set; }
    }
}