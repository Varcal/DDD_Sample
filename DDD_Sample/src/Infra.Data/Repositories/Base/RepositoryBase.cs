using System.Data.Entity;
using Domain.Contracts.Repositories.Base;
using Domain.Entities.Base;
using Infra.Data.Contexts;

namespace Infra.Data.Repositories.Base
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T: EntityBase
    {
        protected EfContext Context;

        public RepositoryBase(EfContext context)
        {
            this.Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }    
    }
}
