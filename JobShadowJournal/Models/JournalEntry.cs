using System;
using System.ComponentModel.DataAnnotations;

namespace JobShadowJournal.Models
{
    public class JournalEntry
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Content { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
