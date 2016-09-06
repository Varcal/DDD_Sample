using System;

namespace Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public int Id { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; set; }
        

        protected EntityBase()
        {
            DataCadastro = DateTime.Now;
        }

        public virtual void Ativar()
        {
            Ativo = true;
        }

        public virtual void Desativar()
        {
            Ativo = false;
        }
    }
}
