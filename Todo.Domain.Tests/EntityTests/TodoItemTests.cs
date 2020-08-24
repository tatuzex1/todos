using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    public class TodoItemTests
    {
        private readonly TodoItem _validTodo = new TodoItem("Título aqui", DateTime.Now, "arthur.reis");

        [TestMethod]
        public void DadoUmNovoTodoItemOMesmoNaoPodeSerConcluido()
        {
            Assert.AreEqual(_validTodo.Done, false);
        }
    }
}
