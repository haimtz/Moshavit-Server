using System;
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

        /// <summary>
        /// User private and first name
        /// </summary>
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        /// <summary>
        /// User family name
        /// </summary>
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        /// <summary>
        /// User cellular number or home number 
        /// </summary>
        [Required(ErrorMessage = "Phone is Required")]
        public string Phone { get; set; }


        /// <summary>
        /// User personal email
        /// </summary>
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        /// <summary>
        /// User Home address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// is user owner of the in the moshav or renting
        /// </summary>
        public bool IsResident { get; set; }


        /// <summary>
        /// When user register to system
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// unique token to valid user
        /// </summary>
        public string Token { get; set; }

        public int Type { get; set; }

        /// <summary>
        /// if user approved by the system manager
        /// </summary>
        public bool IsActive { get; set; }


        ///// <summary>
        ///// Messages connection db
        ///// </summary>
        //public virtual ICollection<MessageTable> Messages { get; set; }
    }
}
