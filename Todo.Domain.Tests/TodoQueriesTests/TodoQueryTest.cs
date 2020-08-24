using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.TodoQueriesTests
{
    [TestClass]
    public class TodoQueryTest
    {
        private List<TodoItem> _items;

        public TodoQueryTest()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "arthur.reis"));
            _items.Add(new TodoItem("Tarefa 2", DateTime.Now, "arthur.reis"));
            _items.Add(new TodoItem("Tarefa 3", DateTime.Now, "usuario.user"));
            _items.Add(new TodoItem("Tarefa 4", DateTime.Now, "usuario.user"));
            _items.Add(new TodoItem("Tarefa 5", DateTime.Now, "chester.bennington"));

            var tarefa1 = _items.Where(t => t.Title.Equals("Tarefa 1")).FirstOrDefault();
            tarefa1.MarkAsDone();

        }

        [TestMethod]
        public void Todas_tarefas_do_usuario_arthur()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("arthur.reis"));
            Assert.AreEqual(2,result.Count());
        }

        [TestMethod]
        public void Todas_tarefas_concluidas_do_usuario()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("arthur.reis"));
            Assert.AreEqual(1, result.Count());
        }

    }
}
