using CoffeeLovers.APIModels;
using CoffeeLovers.Common.Extensions;
using CoffeeLovers.DomainModels.Models;
using System;
using System.Collections.Generic;

namespace CoffeeLovers.Common.Mapping.DomainToApi
{
    public static class AreaFactory
    {
        public static IEnumerable<AreaDto> ToDtos(this IEnumerable<Area> areaEntities)
        {
            areaEntities.CheckArgumentIsNull(nameof(areaEntities));

            List<AreaDto> areaDtos = new List<AreaDto>();

            foreach (var area in areaEntities)
            {
                areaDtos.Add(area.ToDto());
            }

            return areaDtos;
        }



        public static AreaDto ToDto(this Area area)
        {
            area.CheckArgumentIsNull(nameof(area));

            var areaDto = new AreaDto()
            {
              AreaDisplayId = area.AreaDisplayId,
              AreaName = area.AreaName,
              PinCode = area.PinCode
            };

            return areaDto;
        }


        public static Area ToEntity(this AreaDto areaDto , bool generatePrimaryKey = false)
        {
            areaDto.CheckArgumentIsNull(nameof(areaDto));

            var area = new Area()
            {
                AreaName = areaDto.AreaName,               
                PinCode = areaDto.PinCode,
                AreaDisplayId = areaDto.AreaDisplayId
            };

            if (generatePrimaryKey) area.AreaId = Guid.NewGuid();

            return area;
        }


        public static string GetNextPrimaryKey(this Area area)
        {
            string primaryKey = "Area-"+ DateTime.Now.Year.ToString()+"-";
            if (area == null)
            {
                primaryKey += "1";
            }
            else
            {
               string[] splitString = area.AreaDisplayId.Split("-", StringSplitOptions.RemoveEmptyEntries);
                primaryKey += splitString.Length == 3 ?  (int.Parse(splitString[2]) + 1).ToString()  : "1";
            }

            return primaryKey;
        }
    }
}
