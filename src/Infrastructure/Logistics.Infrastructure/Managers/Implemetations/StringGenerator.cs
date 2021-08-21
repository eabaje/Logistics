using System;
using Logistics.Infrastructure.Managers;
using Logistics.Infrastructure.Managers.Abstract;

namespace Logistics.Infrastructure.Managers.Implementations
{
    internal class StringGenerator : IStringGenerator
    {
        public string Generate(int length)
        {
            var rd = new Random();
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
            var chars = new char[length];

            for (var i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}
