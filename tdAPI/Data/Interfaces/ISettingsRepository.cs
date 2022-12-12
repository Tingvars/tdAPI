using System;
using tdAPI.Models;
using tdAPI.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace tdAPI.Data.Interfaces
{
    public interface ISettingsRepository
    {

        List<Settings> GetAllSettings();
        Settings? GetSettingsById(int id);

        void CreateSettings(Settings settings);

        Settings UpdateSettings(int id, Settings settingsFromBody);


    }
}

