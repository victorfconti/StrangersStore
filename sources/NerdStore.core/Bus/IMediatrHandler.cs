using System.Threading.Tasks;
using NerdStore.core.Messages;

namespace NerdStore.core
{
    public interface IMediatrHandler
    { 
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}