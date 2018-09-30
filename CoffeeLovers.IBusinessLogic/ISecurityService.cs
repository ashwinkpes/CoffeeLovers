using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeLovers.IBusinessLogic
{
    public interface ISecurityService
    {
        string GetSha256Hash(string input);
    }
}
