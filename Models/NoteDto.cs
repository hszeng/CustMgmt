using System;

namespace CustMgmt.Models
{
    public class NoteDto
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
