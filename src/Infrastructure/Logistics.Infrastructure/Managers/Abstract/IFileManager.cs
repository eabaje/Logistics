using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Logistics.Infrastructure.Managers.Abstract
{
    public interface IFileManager
    {
        Task MoveFileAsync(IFormFile file, string directoryPath, string uniqueFileName);

        void RemoveFile(string path);
    }
}
