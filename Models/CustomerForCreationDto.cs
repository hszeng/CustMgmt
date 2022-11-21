using CustMgmt.Helpers.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustMgmt.Models
{
    public class CustomerForCreationDto
    {
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(200)]
        public string Name { get; set; }
       
        
        public string Address { get; set; }



        [EmailAddress(ErrorMessage = "Email format is not correct")]
        public string Email { get; set; }

        public CustomerStatus Status { get; set; }
    }
}