using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Application.Interfaces;
using IMS.Infrastructure.Data;

namespace IMS.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContextFactory _factory;
        private bool _disposed;

        public UnitOfWork(IDbContextFactory factory)
        {
            _factory = factory;
        }

        public IDbConnection? Connection { get; private set; }
        public IDbTransaction? Transaction { get; private set; }


        public async Task BeginAsync(CancellationToken ct = default)
        {
            if (Connection is null)
                Connection = _factory.CreateOpenConnection();

            if (Transaction is null)
                Transaction = Connection.BeginTransaction();

            await Task.CompletedTask;
        }

        public async Task CommitAsync(CancellationToken ct = default)
        {
            Transaction?.Commit();
            await Task.CompletedTask;
            DisposeTransaction();
        }

        public async Task RollbackAsync(CancellationToken ct = default)
        {
            if (Transaction is not null)
                Transaction.Rollback();

            await Task.CompletedTask;
            DisposeTransaction();
        }

        private void DisposeTransaction()
        {
            Transaction?.Dispose();
            Transaction = null;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            DisposeTransaction();
            Connection?.Dispose();
            Connection = null;
        }
    }
}
