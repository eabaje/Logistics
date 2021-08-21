using System;


namespace Logistics.Infrastructure.Managers.Abstract
{
    public interface ITokenManager
    {
    //    TokenModel GetToken(Guid userId, string email, string role);

        Guid GetUserIdFromExpiredToken(string token);
    }
}
