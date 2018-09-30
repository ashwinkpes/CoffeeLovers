using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeLovers.APIModels.Owner
{
    public class SaveOwnerDto : DisplayOwnerDto
    {
        public Guid RoleId { get; private set; }

        public SaveOwnerDto(Guid roleid, string ownerId):base(ownerId)
        {
            this.RoleId = roleid;
        }
    }
}
