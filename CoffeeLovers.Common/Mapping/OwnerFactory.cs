using CoffeeLovers.APIModels.Owner;
using CoffeeLovers.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeLovers.Common.Mapping
{
    public static class OwnerFactory
    {
        public static Owner ToEntity(this SaveOwnerDto ownerDto, bool generatePrimaryKey = false)
        {
            var owner = new Owner()
            {
              FirstName = ownerDto.FirstName,
              LastName = ownerDto.LastName,
              EmailId = ownerDto.Email,
              OwnerDisplayId = ownerDto.OwnerId,
              RoleId = ownerDto.RoleId            
            };

            if (generatePrimaryKey) owner.OwnerId = Guid.NewGuid();

            return owner;
        }




        public static string GetNextPrimaryKey(this Owner owner)
        {
            string primaryKey = "owner-" + DateTime.Now.Year.ToString() + "-";
            if (owner == null)
            {
                primaryKey += "1";
            }
            else
            {
                string[] splitString = owner.OwnerDisplayId.Split("-", StringSplitOptions.RemoveEmptyEntries);
                primaryKey += splitString.Length == 3 ? (int.Parse(splitString[2]) + 1).ToString() : "1";
            }

            return primaryKey;
        }
    }
}
