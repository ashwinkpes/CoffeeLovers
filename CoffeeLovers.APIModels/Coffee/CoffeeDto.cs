using System;

namespace CoffeeLovers.APIModels.Coffee
{
    public class CoffeeDto : AddCoffeeDto
    {
        public CoffeeDto(string coffeeDisplayId) : this(coffeeDisplayId,DateTime.Now)
        {
         
        }

        private CoffeeDto(string coffeeDisplayId, DateTime dateTime)
        {
            this.CoffeeDisplayId = coffeeDisplayId;
            this.ValidFrom = ValidFrom;
            this.ValidTo = ValidTo;
        }

        public string CoffeeDisplayId { get; private set; }

        public DateTime ValidFrom { get; private set; }

        public DateTime ValidTo { get; private set; }       
    }
}
