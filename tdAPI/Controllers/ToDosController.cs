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
using Microsoft.AspNetCore.Authorization;

using System.IdentityModel.Tokens.Jwt;

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

      //[Authorize]
        [HttpGet]
        [Route("ToDos")]
        public List<ToDo> GetAllToDos()
        {
            // var currentUser = this.User.Claims.FirstOrDefault(x => x.Type.StartsWith("Id")).Value;
            //.First<System.Security.Claims.Claim>(JwtRegisteredClaimNames.Email);

            // FindFirst(JwtRegisteredClaimNames.Email);

            //Console.WriteLine(currentUser);


            return _repo.GetAllToDos();


        }

        [HttpPost]
        [Route("ToDos")]
        public ActionResult<ToDo> CreateTodo(ToDoDTO tododto)
        {

            ToDo todo = new ToDo()
            {

                Title = tododto.Title,
                DueBy = tododto.DueBy,
                Importance = tododto.Importance,
                UserId = tododto.UserId,
                CreatedTime = DateTime.UtcNow

            };

            _repo.CreateToDo(todo);




            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetToDoById), new { id = todo.ToDoId }, todo);
        }



        [HttpPut]
        [Route("ToDos/{id}")]
        public IActionResult UpdateTodoItem(int id, ToDo todoFromBody)
        {
            if (id != todoFromBody.ToDoId)
            {
                return BadRequest();
            }



            try
            {

                ToDo? updated = _repo.UpdateTodoItem(id, todoFromBody);

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


        [HttpGet]
        [Route("ToDos/{id}")]

        public ActionResult<ToDo> GetToDoById(int id)

            //int id)
        {

            try
            {
                ToDo? todo = _repo.GetToDoById(id);

                    //id);

                if (todo == null)
                {
                    return NotFound();
                }
                return todo;


            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }



        [HttpDelete]
        [Route("ToDos/{id}")]

        public ActionResult<bool> DeleteToDoById(int id)
        {

            try
            {
                ToDo? todo = _repo.GetToDoById(id);

                if (todo == null)
                {
                    return NotFound();
                }

                 bool success = _repo.DeleteToDo(todo);

                if (!success)
                {
                    return StatusCode(500);
                }
                return Ok();


            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
    }
}


