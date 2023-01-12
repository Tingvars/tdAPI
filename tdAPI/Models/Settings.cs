using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tdAPI.Models
{
    public class Settings
    {

        public int SettingsId { get; set; }
        public int NumToDos { get; set; }
        public string Language { get; set; }
        public string UserId { get; set; }
    }


}

