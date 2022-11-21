using System;
using System.ComponentModel.DataAnnotations;

namespace CustMgmt.Models
{
    public class NoteForUpdateDto
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Content can't exceed 1000")]
        public string Content { get; set; }

    }
}
