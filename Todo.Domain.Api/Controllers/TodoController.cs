using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler todoHandler)
        {
            command.User = User.Claims.FirstOrDefault(us => us.Type.Equals("user_id"))?.Value;  

            return (GenericCommandResult)todoHandler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone([FromBody] MarkTodoAsDoneCommand command,
     [FromServices] TodoHandler todoHandler)
        {
            var user = User.Claims.FirstOrDefault(us => us.Type.Equals("user_id"))?.Value;
            command.User = user;
            return (GenericCommandResult)todoHandler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone([FromBody] MarkTodoAsUndoneCommand command,
[FromServices] TodoHandler todoHandler)
        {
            command.User = User.Claims.FirstOrDefault(us => us.Type.Equals("user_id"))?.Value;
            return (GenericCommandResult)todoHandler.Handle(command);
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone(
             [FromServices] ITodoRepository todoRepository)
        {
            var user = User.Claims.FirstOrDefault(us => us.Type.Equals("user_id"))?.Value;
            return todoRepository.GetAllDone(user);
        }   

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone(
[FromServices] ITodoRepository todoRepository)
        {
            var user = User.Claims.FirstOrDefault(us => us.Type.Equals("user_id"))?.Value;
            return todoRepository.GetAllUndone(user);
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday(
[FromServices] ITodoRepository todoRepository)
        {
            var user = User.Claims.FirstOrDefault(us => us.Type.Equals("user_id"))?.Value;

            return todoRepository.GetByPeriod(user, DateTime.Now.Date, true);
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForToday(
[FromServices] ITodoRepository todoRepository)
        {
            var user = User.Claims.FirstOrDefault(us => us.Type.Equals("user_id"))?.Value;

            return todoRepository.GetByPeriod(user, DateTime.Now.Date, false);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow(
[FromServices] ITodoRepository todoRepository)
        {
            var user = User.Claims.FirstOrDefault(us => us.Type.Equals("user_id"))?.Value;

            return todoRepository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), true);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForTomorrow(
[FromServices] ITodoRepository todoRepository)
        {
            var user = User.Claims.FirstOrDefault(us => us.Type.Equals("user_id"))?.Value;

            return todoRepository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), false);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll(
[FromServices] ITodoRepository todoRepository)
        {
            var user = User.Claims.FirstOrDefault(us => us.Type.Equals("user_id"))?.Value;

            return todoRepository.GetAll(user);
        }
    }
}