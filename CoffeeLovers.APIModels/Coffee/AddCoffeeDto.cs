using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoffeeLovers.APIModels
{
    public class AddCoffeeDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "CoffeeName is required")]
        [MinLength(3, ErrorMessage = "CoffeeName must be minimum of 3 characters")]
        [StringLength(20, ErrorMessage = "CoffeeName cannot be grater than 20 characters")]
        public string CoffeeName { get; set; }

    }
}
