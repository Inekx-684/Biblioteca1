using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}
