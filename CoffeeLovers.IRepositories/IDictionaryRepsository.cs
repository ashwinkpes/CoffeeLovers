using System;
using System.Collections.Generic;

namespace CoffeeLovers.IRepositories
{
    public interface IDictionaryRepsository<T> where T : class
    {
        Dictionary<string,Guid> RolesDictionary { get; set; }
    }
}
