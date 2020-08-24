using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Handlers.Contracts
{
    // Toda manipulação(handler) de um Comando passa pelo ICommand, obrigando a validação de todos comandos :}
    public interface IHandler <T> where T : ICommand
    {
        // Sempre vai retornar um ICommandResult , e o commando só vai poder ser do Tipo ICommand, onde é obrigatório o método Validate()
        ICommandResult Handle(T command);
    }
}
