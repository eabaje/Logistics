using Logistics.Infrastructure.Models;
using System.Threading.Tasks;

namespace Logistics.Infrastructure.Managers.Abstract
{
    public interface IEmailManager
    {
        Task<string> SendGridEmailAsync(string receiverAddress, string receiverName, string subject, string message);
        Task<string> SendTemplateEmail(string templatePath,string email, string name, string subject, AccountViewModel Account, string message);
    }
}
