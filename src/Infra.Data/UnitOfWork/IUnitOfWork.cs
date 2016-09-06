using System;

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
