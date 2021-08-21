using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.Infrastructure.Managers.Abstract
{
    public interface IEncrypter
    {
        string GetSalt();

        string GetHash(string password, string salt);
    }
}
