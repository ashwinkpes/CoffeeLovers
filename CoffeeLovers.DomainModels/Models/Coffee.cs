using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeLovers.DomainModels.Models
{
    [Table("Coffee")]
    public class Coffee : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid CoffeeId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CoffeeDisplayId is required")]
        [MinLength(3, ErrorMessage = "CoffeeDisplayId must be minimum of 3 characters")]
        [StringLength(40, ErrorMessage = "CoffeeDisplayId cannot be grater than 40 characters")]
        public string CoffeeDisplayId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CoffeeName is required")]
        [MinLength(3, ErrorMessage = "CoffeeName must be minimum of 3 characters")]
        [StringLength(20, ErrorMessage = "CoffeeName cannot be grater than 20 characters")]
        public string CoffeeName { get; set; }

        [Required(ErrorMessage = "validFrom is required")]
        public DateTime validFrom { get; set; }

        [Required(ErrorMessage = "validTo is required")]
        public DateTime validTo { get; set; }
      
    }
}
