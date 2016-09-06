using Domain.Entities.Base;

namespace Domain.Contracts.Repositories.Base
{
    public interface IRepositoryBase<T> where T: EntityBase
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
