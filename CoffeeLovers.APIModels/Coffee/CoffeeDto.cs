using System;

namespace CoffeeLovers.APIModels
{
    public class CoffeeDto : AddCoffeeDto
    {
        public CoffeeDto(string coffeeDisplayId) : this(coffeeDisplayId,DateTime.Now)
        {
         
        }

        private CoffeeDto(string coffeeDisplayId, DateTime dateTime)
        {
            this.CoffeeDisplayId = coffeeDisplayId;
            this.validFrom = validFrom;
            this.validTo = validTo;
        }

        public string CoffeeDisplayId { get; private set; }

        public DateTime validFrom { get; private set; }

        public DateTime validTo { get; private set; }       
    }
}
