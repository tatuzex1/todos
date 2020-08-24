using Flunt.Validations;

namespace Todo.Domain.Commands.Contracts
{
    // Todo Command que herdar de ICommands, é obrigatório ter a function Validate.
    public interface ICommand : IValidatable
    {
    }
}
