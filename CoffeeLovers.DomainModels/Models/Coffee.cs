using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoffeeLovers.DomainModels.Models
{
    [Table("Coffee")]
    public class Coffee : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid CoffeeId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CoffeeName is required")]
        [MinLength(3, ErrorMessage = "CoffeeName must be minimum of 3 characters")]
        [StringLength(20, ErrorMessage = "CoffeeName cannot be grater than 20 characters")]
        public string CoffeeName { get; set; }

        [Required(ErrorMessage = "validFrom is required")]
        public DateTime validFrom { get; set; }

        [Required(ErrorMessage = "validTo is required")]
        public DateTime validTo { get; set; }

        public ICollection<CoffeeArea> CoffeeAreas { get; set; }

        public ICollection<AreaOwner> AreaOwners { get; set; }
    }
}
