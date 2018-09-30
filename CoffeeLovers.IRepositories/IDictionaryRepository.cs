using System;
using System.Collections.Generic;

namespace CoffeeLovers.IRepositories
{
    public interface IDictionaryRepository<T> where T : class
    {
        Dictionary<string,Guid> RolesDictionary { get; set; }
    }
}
