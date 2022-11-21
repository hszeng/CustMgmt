using CustMgmt.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustMgmt.Entities
{
    public class Customer : BaseEntity
    {
     
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }


        public string Address { get; set; }

        public CustomerStatus Status { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
