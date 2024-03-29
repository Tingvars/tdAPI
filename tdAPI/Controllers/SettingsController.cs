﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tdAPI.Models;
using tdAPI.Data;
using tdAPI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace tdAPI.Controllers
{
    [Route("api")]
    [ApiController]

    public class SettingsController : ControllerBase
    {

        private ISettingsRepository _repo;

        public SettingsController(ISettingsRepository repo)
        {
            _repo = repo;

        }

        [Authorize]
        [HttpGet]
        [Route("Settings")]
        public List<Settings> GetAllSettings()
        {
            return _repo.GetAllSettings();

        }

        [HttpPost]
        [Route("Settings")]
        public ActionResult<Settings> CreateSettings(SettingsDTO settingsdto)
        {

            Settings settings = new Settings()
            {

                NumToDos = settingsdto.NumToDos,
                UserId = settingsdto.UserId,
                Language = settingsdto.Language,

            };

            _repo.CreateSettings(settings);




            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetSettingsById), new { id = settings.SettingsId }, settings);
        }

        [Authorize]
        [HttpGet]
        [Route("Settings/{id}")]

        public ActionResult<Settings> GetSettingsById(int id)
        {
            Settings? settings = _repo.GetSettingsById(id);

            if (settings == null)
            {

                return NotFound();
            }
            return settings;
        }

        [HttpPut]
        [Route("Settings/{id}")]

        public IActionResult UpdateSettings(int id, Settings settingsFromBody)
        {
            if (id != settingsFromBody.SettingsId)
            {
                return BadRequest();
            }

            try
            {
                Settings? updated = _repo.UpdateSettings(id, settingsFromBody);

                if (updated == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}


