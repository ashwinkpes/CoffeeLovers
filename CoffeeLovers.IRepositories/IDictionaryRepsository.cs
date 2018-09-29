using CoffeeLovers.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeLovers.IRepositories
{
    public interface IDictionaryRepsository<T> where T : class
    {
        Dictionary<string,Guid> RolesDictionary { get; set; }
    }
}
