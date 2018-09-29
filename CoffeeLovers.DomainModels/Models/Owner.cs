using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeLovers.DomainModels.Models
{
    [Table("Owner", Schema = "dbo")]
    public class Owner : User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid OwnerId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "OwnerDisplayId is required")]
        [MinLength(3, ErrorMessage = "OwnerDisplayId must be minimum of 3 characters")]
        [MaxLength(40, ErrorMessage = "OwnerDisplayId cannot be grater than 40 characters")]
        public string OwnerDisplayId { get; set; }

        public virtual ICollection<AreaOwner> AreaOwners { get; set; }
    }
}
