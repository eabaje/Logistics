using System.Threading.Tasks;

namespace Logistics.Infrastructure.Managers.Abstract
{
    public interface IQueueManager
    {
        Task AddMessageAsync(string message);
    }
}
