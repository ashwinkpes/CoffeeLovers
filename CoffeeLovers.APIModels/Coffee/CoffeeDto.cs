using System;

namespace CoffeeLovers.APIModels
{
    public class CoffeeDto : AddCoffeeDto
    {
        public CoffeeDto(string coffeeDisplayId, DateTime validFrom, DateTime validTo)
        {
            this.CoffeeDisplayId = coffeeDisplayId;
            this.validFrom = validFrom;
            this.validTo = validTo;
        }

        public string CoffeeDisplayId { get; private set; }

        public DateTime validFrom { get; private set; }

        public DateTime validTo { get; private set; }

        internal DateTime Test { get; private set; }
    }
}
