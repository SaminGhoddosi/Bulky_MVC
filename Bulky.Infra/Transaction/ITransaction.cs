using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;

namespace Bulky.Infra.Transaction
{
    public interface ITransaction
    {
        IExecutionStrategy BeginExecutionStrategy();
        IDbContextTransaction BeginTrasaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Rollback(IDbContextTransaction transaction);
        void Commit(IDbContextTransaction transaction);
    }
}
