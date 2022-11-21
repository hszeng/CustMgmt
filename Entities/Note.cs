using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustMgmt.Entities
{
    public class Note: BaseEntity
    {

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }


        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public Guid CustomerId { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
