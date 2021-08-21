using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Logistics.Infrastructure.Managers.Abstract;
using Microsoft.AspNetCore.Http;

namespace Logistics.Infrastructure.Managers.Implementations
{
    internal class FileManager : IFileManager
    {
        public async Task MoveFileAsync(IFormFile file, string directoryPath, string uniqueFileName)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var imagePath = Path.Combine(directoryPath, uniqueFileName);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                try
                {
                    await file.CopyToAsync(stream);
                }
                catch (Exception e)
                {
                  //  throw new LogisticsException(ErrorCode.UnableToSavePhoto, e.Message, e);
                }
            }
        }

        public void RemoveFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
              //  throw new LogisticsException(ErrorCode.UnableToDeletePhoto, exception.Message, exception);
            }

            var directoryPath = Path.GetDirectoryName(path);

            var items = Directory.EnumerateDirectories(directoryPath).ToList();
            items.AddRange(Directory.EnumerateFiles(directoryPath));
            if (!items.Any())
            {
                Directory.Delete(directoryPath);
            }
        }
    }
}
