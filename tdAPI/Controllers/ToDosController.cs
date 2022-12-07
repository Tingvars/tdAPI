using System;
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

namespace tdAPI.Controllers
{
    [Route("api")]
    [ApiController]

    public class ToDosController : ControllerBase
    {

        private IToDoRepository _repo;

        public ToDosController(IToDoRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        [Route("ToDos")]
        public List<ToDo> GetAllToDos()
        {
            return _repo.GetAllToDos();
                                    
        }

        [HttpPost]
        [Route("ToDos")]
        public ActionResult<ToDo> CreateTodo(ToDoDTO tododto)
        {

            ToDo todo = new ToDo() {

                Title = tododto.Title,
                DueBy = tododto.DueBy,
                Importance = tododto.Importance,
                CreatedTime = 100

    };

            _repo.CreateToDo(todo);

       
     

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetToDoById), new { id = todo.ToDoId }, todo);
        }

        [HttpGet]
        [Route("{id}")]

        public ActionResult<ToDo> GetToDoById(int id)
        {
            ToDo? todo = _repo.GetToDoById(id);

            if (todo == null)
            {

                return NotFound();
            }
            return todo;
        }

        [HttpPut]
        [Route("ToDos/{id}")]

        public IActionResult UpdateTodo(int id, ToDo todoFromBody)
        {
            if (id != todoFromBody.ToDoId)
            {
                return BadRequest();
            }

            try
            {
                ToDo? updated = _repo.UpdateTodo(id, todoFromBody);

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


