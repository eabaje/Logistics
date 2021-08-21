
using System.Threading.Tasks;

namespace Logistics.Infrastructure.Managers.Abstract
{
    public interface IEmailTemplatesManager
    {
        Task<string> ReadTemplateAsync(string templateName);

        //  Task<string> PrepareForgottenPasswordEmailAsync(AppUser user);
    }
}
