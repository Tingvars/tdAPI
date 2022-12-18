using System;
using tdAPI.Models;
using tdAPI.Controllers;
using tdAPI.Data;
using tdAPI.Data.Interfaces;

namespace tdAPI.Data
{
    public class ToDoRepository : IToDoRepository
    {
        private ToDoDbContext _dbContext;

        public ToDoRepository()
        {

            _dbContext = new ToDoDbContext();
        }

        public void CreateToDo(ToDo todo)
        {
            _dbContext.ToDos.Add(todo);
            _dbContext.SaveChanges();
        }

        public bool DeleteToDo(ToDo todo)
        {

            try {
            
            _dbContext.ToDos.Remove(todo);
            _dbContext.SaveChanges();
             
            return true;
            } catch (Exception)
            {
                return false;
            }

        }

        public List<ToDo> GetAllToDos()
        {

        return _dbContext.ToDos.ToList();

        }

        public ToDo? GetToDoById(int id)
        {

            return _dbContext.ToDos.Where(t => t.ToDoId == id).FirstOrDefault();
        }

        public ToDo? UpdateTodo(int id, ToDo todoFromBody)
        {
            ToDo? todoFromDB = GetToDoById(id);

            if (todoFromDB == null)
            {
                return null;
            }

            todoFromDB.Title = todoFromBody.Title;
            todoFromDB.DueBy = todoFromBody.DueBy;
            todoFromDB.UserId = todoFromBody.UserId;
            todoFromDB.UserId = todoFromBody.UserId;

            _dbContext.SaveChanges();

            return todoFromDB;
        }

        public ToDo? UpdateTodoItem(int id, ToDo todoFromBody)
        {
            ToDo? todoFromDB = GetToDoById(id);

            if (todoFromDB == null)
            {
                return null;
            }

            todoFromDB.Title = todoFromBody.Title;
            todoFromDB.DueBy = todoFromBody.DueBy;
            todoFromDB.Importance = todoFromBody.Importance;
            todoFromDB.UserId = todoFromBody.UserId;

            _dbContext.SaveChanges();

            return todoFromDB;
        }
    }
}

