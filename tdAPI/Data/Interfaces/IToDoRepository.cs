using System;
using tdAPI.Models;
using tdAPI.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace tdAPI.Data.Interfaces
{
	public interface IToDoRepository
	{

        List<ToDo> GetAllToDos();
        ToDo? GetToDoById(int id);

        void CreateToDo(ToDo todo);

        ToDo? UpdateTodo(int id, ToDo todoFromBody);


    }
}

