namespace CoffeeLovers.APIModels.Owner
{
    public class DisplayOwnerDto : AddOwnerDto
    {
        public DisplayOwnerDto(string ownerId)
        {
            this.OwnerId = ownerId;
        }

        public string OwnerId { get; private set; }
    }
}