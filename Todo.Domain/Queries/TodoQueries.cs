using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    // Estática -> classes que não precisam ser instanciadas
    public static class TodoQueries
    {

        public static Expression<Func<TodoItem,bool>> GetAll (string user)
        {
            return td => td.User == user;
        }

        public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
        {
            return td => td.User == user &&
            td.Done;
        }

        public static Expression<Func<TodoItem, bool>> GetAllUndone(string user)
        {
            return td => td.User == user &&
            td.Done == false;
        }

        public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done)
        {
            return td => td.User == user &&
            td.Done == done &&
            td.Date.Date == date.Date;
        }
    }
}
