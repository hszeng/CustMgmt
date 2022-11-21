using System;
using System.ComponentModel.DataAnnotations;

namespace CustMgmt.Models
{
    public class NoteForCreationDto
    {
        [Required]
        [MaxLength(1000, ErrorMessage ="Content length can't exceed 1000")]
        public string Content { get; set; }
    }
}
