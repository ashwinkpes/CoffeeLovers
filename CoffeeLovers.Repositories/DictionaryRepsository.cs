using CoffeeLovers.Common.Logging;
using CoffeeLovers.DAL;
using CoffeeLovers.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLovers.Repositories
{
    public class DictionaryRepsository<T> : IDictionaryRepsository<T> where T : class
    {
        protected readonly CoffeeDbContext _dbContext;
        private readonly IAppLogger<DictionaryRepsository<T>> appLogger;
        private Dictionary<string, Guid> _rolesDictionary;
        private Dictionary<string, Guid> _areasDictionary;

        private List<Task> tasks;

        public DictionaryRepsository(CoffeeDbContext dbContext, IAppLogger<DictionaryRepsository<T>> appLogger)
        {
            _dbContext = dbContext;
            this.appLogger = appLogger;
            tasks = new List<Task>();
            tasks.Add(GetRoles());
            tasks.Add(GetAreas());
            var res = WhenAllTasks(tasks);
        }

        public Dictionary<string, Guid> RolesDictionary
        {
            get
            {
                return _rolesDictionary ?? (_rolesDictionary = GetRoles().Result);
            }
            set
            {
                _rolesDictionary = value;
            }
        }

        public Dictionary<string, Guid> AreasDictionary
        {
            get
            {
                return _areasDictionary ?? (_areasDictionary = GetAreas().Result);
            }
            set
            {
                _areasDictionary = value;
            }
        }

        public Task<Dictionary<string,Guid>> GetRoles()
        {
           var rolesDictionary = ( _dbContext.Roles.ToList().Select(r => new { r.RoleName, r.RoleId }).ToDictionary(r => r.RoleName, r => r.RoleId));
            return Task.FromResult(rolesDictionary);
        }

        public Task<Dictionary<string, Guid>> GetAreas()
        {
            var areasDictionary = (_dbContext.Areas.ToList().Select(r => new { r.AreaName, r.AreaId }).ToDictionary(r => r.AreaName, r => r.AreaId));
            return Task.FromResult(areasDictionary);
        }

        private Task WhenAllTasks(List<Task> tasks)
        {
            Task allTasks = Task.WhenAll(tasks);
            try
            {
                allTasks.Wait();
            }
            catch (Exception ex)
            {
                appLogger.LogWarning($"WhenAllTasks Exception: {ex.ToString()}");
            }

            appLogger.LogWarning($"WhenAllTasks status: {allTasks.Status}");

            if (allTasks.Exception != null)
            {
                throw allTasks.Exception;
            }
            return allTasks;
        }
    }
}
