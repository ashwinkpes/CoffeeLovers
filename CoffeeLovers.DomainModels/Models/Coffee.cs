using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeLovers.DomainModels.Models
{
    [Table("Coffee", Schema = "dbo")]
    public class Coffee : Valid
    {

        public Coffee()
        {
            CoffeeAreas = new HashSet<CoffeeArea>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid CoffeeId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CoffeeDisplayId is required")]
        [MinLength(3, ErrorMessage = "CoffeeDisplayId must be minimum of 3 characters")]
        [MaxLength(40, ErrorMessage = "CoffeeDisplayId cannot be grater than 40 characters")]
        public string CoffeeDisplayId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CoffeeName is required")]
        [MinLength(3, ErrorMessage = "CoffeeName must be minimum of 3 characters")]
        [MaxLength(20, ErrorMessage = "CoffeeName cannot be grater than 20 characters")]
        public string CoffeeName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        public virtual ICollection<CoffeeArea> CoffeeAreas { get; set; }

    }
}
