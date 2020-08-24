using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable, IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _todoRepository;

        public TodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            // Fail Fast Validation - Se tem falha pq entrar e tentar por no banco?
            command.Validate();
            if (command.Invalid) { return new GenericCommandResult(false, "Eita, parece que sua tarefa está errada.", command.Notifications); }

            // Gera o TodoItem
            var todoItem = new TodoItem(command.Title, command.Date, command.User);
            
            // Salva no Banco o TodoItem
            _todoRepository.Create(todoItem);

            return new GenericCommandResult(true, "Sua tarefa foi criada com sucesso.", todoItem);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid) { return new GenericCommandResult(false, "Eita, parece que sua tarefa está errada.", command.Notifications); }

            // Recupera o TodoItem
            var todoItem = _todoRepository.GetById(command.Id, command.User);

            //Atualiza o título
            todoItem.UpdateTitle(command.Title);           

            // Salva no Banco o TodoItem
            _todoRepository.Update(todoItem);

            return new GenericCommandResult(true, "Sua tarefa foi criada com sucesso.", todoItem);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid) { return new GenericCommandResult(false, "Eita, parece que sua tarefa está errada.", command.Notifications); }

            // Recupera o TodoItem
            var todoItem = _todoRepository.GetById(command.Id, command.User);

            //Atualiza o título
            todoItem.MarkAsDone();

            // Salva no Banco o TodoItem
            _todoRepository.Update(todoItem);

            return new GenericCommandResult(true, "Sua tarefa foi criada com sucesso.", todoItem);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid) { return new GenericCommandResult(false, "Eita, parece que sua tarefa está errada.", command.Notifications); }

            // Recupera o TodoItem
            var todoItem = _todoRepository.GetById(command.Id, command.User);

            //Atualiza o título
            todoItem.MarkAsUndone();

            // Salva no Banco o TodoItem
            _todoRepository.Update(todoItem);

            return new GenericCommandResult(true, "Sua tarefa foi criada com sucesso.", todoItem);
        }
    }
}
