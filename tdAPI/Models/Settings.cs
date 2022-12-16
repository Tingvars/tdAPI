using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tdAPI.Models
{
    public class Settings
    {

        public int SettingsId { get; set; }
        public int NumToDos { get; set; }
    }


}

