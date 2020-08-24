using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Entities
{
    // Inibe a possibilidade de alguem instanciar essa clase, porque é uma classe base para outras. 
    
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        // Bom porque temos todo o controle do dominio, ruim porque a performance do Guid é pior do que um Int por exemplo.
        // Private pra manter o SOLID, OpenClosed, fechada para modificações
        public Guid Id { get; private set; }

        // Futuramente, se formos comparar se uma entidade é igual a outra.
        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}
