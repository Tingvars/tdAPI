using System;
using tdAPI.Models;
using tdAPI.Controllers;
using tdAPI.Data.Interfaces;

namespace tdAPI.Data
{
	public class MockRepository : IToDoRepository
	{

        List<ToDo> ToDos = new List<ToDo>() {
                new ToDo() { ToDoId = 1, Title = "Feed the cat", Importance = 2, },
                new ToDo() { ToDoId = 2, Title = "Water plants", Importance = 3, },
                new ToDo() { ToDoId = 3, Title = "Buy milk", Importance = 1, },
                                             };

        public void CreateToDo(ToDo todo)
        {
            throw new NotImplementedException();
        }

        public bool DeleteToDo(ToDo todo)
        {
            throw new NotImplementedException();
        }

        public List<ToDo> GetAllToDos()
        {

            return ToDos;
                                    
        }

        public ToDo? GetToDoById(int id)
        {
            
            foreach (ToDo todo in ToDos)
            {
                if (todo.ToDoId == id)
                {
                    return todo;
                }
            }
            return null;
        }

        public ToDo? UpdateTodoItem(int id, ToDo todoFromBody)
        {
            throw new NotImplementedException();
        }
    }
}

