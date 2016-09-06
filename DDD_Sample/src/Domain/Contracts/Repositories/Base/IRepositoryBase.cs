using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
