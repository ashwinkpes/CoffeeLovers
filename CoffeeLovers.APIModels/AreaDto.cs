using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeLovers.APIModels
{
    public class AreaDto
    {
        public Guid AreaId { get; private set; }

        public string AreaName { get; set; }

        public int PinCode { get; set; }

        public AreaDto()
        {

        }

        public AreaDto(Guid areaId)
        {
            this.AreaId = areaId;
        }
    }
}
