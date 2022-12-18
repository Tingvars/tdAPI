using System;
using System.ComponentModel.DataAnnotations;

namespace tdAPI.Models
{
    public class ToDoDTO
    {
        
        [MaxLength(300)]
        public string? Title { get; set; }
        public DateTime DueBy { get; set; }
        public int Importance { get; set; }
        public string UserId { get; set; }
    }
}

