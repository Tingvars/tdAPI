using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tdAPI.Models
{
    public class ToDo
    {

        public int ToDoId { get; set; }
        [MaxLength(300)]
        public string? Title { get; set; }
        public DateTime DueBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public int Importance { get; set; }
        public string UserId { get; set; }
    }


}

