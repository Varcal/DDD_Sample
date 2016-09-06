using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        void BeginTran();
        void Save();
        void SaveAsync();
        void Commit();
        void Rollback();
    }
}
