using System;
using System.Threading.Tasks;

namespace NerdStore.core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}