using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeLovers.APIModels.Owner
{
    public class OwnerDto : AddOwnerDto
    {
        public OwnerDto(string ownerId)
        {
            this.OwnerId = ownerId;
        }

        public string OwnerId { get; private set; }
    }
}
