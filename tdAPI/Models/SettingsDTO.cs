using System;
using System.ComponentModel.DataAnnotations;

namespace tdAPI.Models
{
    public class SettingsDTO
    {

        public int NumToDos { get; set; }
        public string Language { get; set; }
        public string UserId { get; set; }
    }
}

