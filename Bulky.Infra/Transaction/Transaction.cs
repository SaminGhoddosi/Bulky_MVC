using Bulky.DataAcess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Bulky.Infra.Transaction
{
    public class Transaction : ITransaction
    {
        private readonly AppDbContext _context;

        public Transaction(AppDbContext context)
        {
            _context = context;
        }

        public IExecutionStrategy BeginExecutionStrategy()
        {
            return _context.Database.CreateExecutionStrategy();
        }

        public IDbContextTransaction BeginTrasaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return _context.Database.BeginTransaction(isolationLevel);
        }

        public void Commit(IDbContextTransaction transaction)
        {
            transaction.Commit();
        }

        public void Rollback(IDbContextTransaction transaction)
        {
            transaction.Rollback();
        }
    }
}
