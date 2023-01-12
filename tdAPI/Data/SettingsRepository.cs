using System;
using tdAPI.Models;
using tdAPI.Controllers;
using tdAPI.Data;
using tdAPI.Data.Interfaces;

namespace tdAPI.Data
{
    public class SettingsRepository : ISettingsRepository
    {
        private ToDoDbContext _dbContext;

        public SettingsRepository()
        {

            _dbContext = new ToDoDbContext();
        }

        public void CreateSettings(Settings settings)
        {
            _dbContext.Settings.Add(settings);
            _dbContext.SaveChanges();
        }

        public List<Settings> GetAllSettings()
        {

            return _dbContext.Settings.ToList();

        }

        public Settings? GetSettingsById(int id)
        {

            return _dbContext.Settings.Where(t => t.SettingsId == id).FirstOrDefault();
        }

        public Settings? UpdateSettings(int id, Settings settingsFromBody)
        {
            Settings? settingsFromDB = GetSettingsById(id);

            if (settingsFromDB == null)
            {
                return null;
            }

            settingsFromDB.NumToDos = settingsFromBody.NumToDos;
            settingsFromDB.Language = settingsFromBody.Language;

            _dbContext.SaveChanges();

            return settingsFromDB;
        }
    }
}

