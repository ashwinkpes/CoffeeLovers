using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeLovers.DomainModels.Models
{
    [Table("Area")]
    public class Area : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid AreaId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "AreaName is required")]
        [MinLength(3, ErrorMessage = "AreaName must be minimum of 3 characters")]
        [StringLength(40, ErrorMessage = "AreaName cannot be grater than 40 characters")]
        public string AreaName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "PinCode is required")]
        [MinLength(3, ErrorMessage = "PinCode must be minimum of 3 characters")]
        [StringLength(6, ErrorMessage = "PinCode cannot be grater than 6 characters")]
        public int PinCode { get; set; }

        public ICollection<AreaOwner> AreaOwners { get; set; }

    }
}
