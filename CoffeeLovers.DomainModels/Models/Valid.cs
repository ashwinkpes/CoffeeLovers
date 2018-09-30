using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeLovers.DomainModels.Models
{
    public abstract class Valid : BaseEntity
    {
        [Required(ErrorMessage = "validFrom is required")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "validTo is required")]
        public DateTime ValidTo { get; set; }
    }
}