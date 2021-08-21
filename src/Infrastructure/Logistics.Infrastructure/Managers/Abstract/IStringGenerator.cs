using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.Infrastructure.Managers.Abstract
{
    public interface IStringGenerator
    {
        string Generate(int length);
    }
}
