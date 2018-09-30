using System;

namespace CoffeeLovers.APIModels.Owner
{
    public class SaveOwnerDto : DisplayOwnerDto
    {
        public Guid RoleId { get; private set; }

        public SaveOwnerDto(Guid roleId, string ownerId):base(ownerId)
        {
            this.RoleId = roleId;
        }
    }
}
