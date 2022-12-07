using System;
using System.ComponentModel.DataAnnotations;

namespace tdAPI.Models
{
    public class ToDo
    {
        public int ToDoId { get; set; }
        [MaxLength(300)]
        public string? Title { get; set; }
        public int DueBy { get; set; }
        public int CreatedTime { get; set; }
        public int Importance { get; set; }
    }


}

