using CoffeeLovers.Common.Extensions;
using CoffeeLovers.DomainModels.Models;
using System;
using System.Collections.Generic;
using CoffeeLovers.APIModels.Coffee;

namespace CoffeeLovers.Common.Mapping.DomainToApi
{
    public static class CoffeeFactory
    {
        public static IEnumerable<CoffeeDto> ToDtos(this IEnumerable<Coffee> cofeeEntities)
        {
            cofeeEntities.CheckArgumentIsNull(nameof(cofeeEntities));

            List<CoffeeDto> coffeeDtos = new List<CoffeeDto>();

            foreach (var coffee in cofeeEntities)
            {
                coffeeDtos.Add(coffee.ToDto());
            }

            return coffeeDtos;
        }



        public static CoffeeDto ToDto(this Coffee coffee)
        {
            coffee.CheckArgumentIsNull(nameof(coffee));
            var coffeeDto = new CoffeeDto(coffee.CoffeeDisplayId);
            coffeeDto.CoffeeName = coffee.CoffeeName;
            return coffeeDto;
        }


        public static Coffee ToEntity(this CoffeeDto coffeeDto, bool generatePrimaryKey = false)
        {
            coffeeDto.CheckArgumentIsNull(nameof(coffeeDto));

            var coffee = new Coffee()
            {
                CoffeeName = coffeeDto.CoffeeName,
                validFrom = coffeeDto.ValidFrom,
                validTo = coffeeDto.ValidTo,
                CoffeeDisplayId = coffeeDto.CoffeeDisplayId
            };

            if (generatePrimaryKey) coffee.CoffeeId = Guid.NewGuid();

            return coffee;
        }


        public static string GetNextPrimaryKey(this Coffee coffee)
        {
            string primaryKey = "Coffee-" + DateTime.Now.Year.ToString()+"-";
            if (coffee == null)
            {
                primaryKey += "1";
            }
            else
            {
               string[] splitString = coffee.CoffeeDisplayId.Split("-", StringSplitOptions.RemoveEmptyEntries);
                primaryKey += splitString.Length == 3 ?  (int.Parse(splitString[2]) + 1).ToString()  : "1";
            }

            return primaryKey;
        }
    }
}
