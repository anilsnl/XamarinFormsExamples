using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    public class Note
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteID { get; set; }
        [Required,MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string NoteDetail { get; set; }
        public DateTime RegisteredDate { get; set; } = DateTime.Now;
    }
}
