﻿using CoffeeLovers.Common.Logging;
using CoffeeLovers.DAL;
using CoffeeLovers.DomainModels.Models;
using CoffeeLovers.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeLovers.Repositories
{
    public class DictionaryRepsository<T> : IDictionaryRepsository<T> where T : class
    {
        protected readonly CoffeeDbContext _dbContext;
        private readonly IAppLogger<DictionaryRepsository<T>> appLogger;

        public Dictionary<string, Guid> RolesDictionary { get; set; }
        public Dictionary<string, Guid> AreasDictionary { get; set; }
        
        public DictionaryRepsository(CoffeeDbContext dbContext, IAppLogger<DictionaryRepsository<T>> appLogger)
        {
            _dbContext = dbContext;
            this.appLogger = appLogger;
            
            //GetRoles().Wait();
            //GetAreas().Wait();

            IEnumerable<Role> Roles = _dbContext.Roles.ToList();
            IEnumerable<Area> Areas = _dbContext.Areas.ToList();

            var tasks = new List<Task>() { GetRoles(Roles), GetAreas(Areas) };
            WhenAllTasks(tasks);
        }

        public Task GetRoles(IEnumerable<Role> roles)
        {
            return Task.Run(() =>
            {
                RolesDictionary = (roles.Select(r => new { r.RoleName, r.RoleId }).ToDictionary(r => r.RoleName, r => r.RoleId));
            });
        }

        public Task GetAreas(IEnumerable<Area> areas)
        {
            return Task.Run(() =>
            {
                AreasDictionary = (areas.Select(r => new { r.AreaName, r.AreaId }).ToDictionary(r => r.AreaName, r => r.AreaId));
            });
        }

        //public async Task GetRoles()
        //{
        //    await Task.Run(() =>
        //    {
        //        RolesDictionary =  (_dbContext.Roles.ToList().Select(r => new { r.RoleName, r.RoleId }).ToDictionary(r => r.RoleName, r => r.RoleId));
        //    });           
        //}

        //public async Task GetAreas()
        //{
        //    await Task.Run(() =>
        //    {
        //        AreasDictionary = (_dbContext.Areas.ToList().Select(r => new { r.AreaName, r.AreaId }).ToDictionary(r => r.AreaName, r => r.AreaId));
        //    });            
        //}

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
