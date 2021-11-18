using System;
using NerdStore.core.DomainObjects;

namespace NerdStore.core.Data
{
    public interface IRepository<T>: IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}