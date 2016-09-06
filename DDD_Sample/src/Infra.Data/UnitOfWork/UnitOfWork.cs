using System;
using System.Data;
using System.Data.Entity;
using Infra.Data.Contexts;

namespace Infra.Data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly EfContext _context;
        private DbContextTransaction _transaction;
        private bool _disposed;

        public UnitOfWork(EfContext context)
        {
            _context = context;
        }

        public void BeginTran()
        {
            _transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void SaveAsync()
        {
            _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            { 
                _transaction?.Dispose();
                _context?.Dispose();
            }

            _disposed = true;
        }
    }
}
