using CoffeeLovers.APIModels;
using CoffeeLovers.Common.Extensions;
using CoffeeLovers.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeLovers.Common.Mapping.DomainToApi
{
    public static class AreaFactory
    {
        public static IEnumerable<AreaDto> ToToDtos(this IEnumerable<Area> areaEntities)
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

            var areaDto = new AreaDto(area.AreaId)
            {
              AreaName = area.AreaName,
              PinCode = area.PinCode
            };

            return areaDto;
        }
    }
}
