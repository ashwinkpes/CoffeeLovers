using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeLovers.DomainModels.Models
{
    [Table("Area",Schema = "dbo")]
    public class Area : BaseEntity
    {
        public Area()
        {
            AreaOwners = new HashSet<AreaOwner>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid AreaId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "AreaDisplayId is required")]
        [MinLength(3, ErrorMessage = "AreaDisplayId must be minimum of 3 characters")]
        [MaxLength(40, ErrorMessage = "AreaDisplayId cannot be grater than 40 characters")]
        public string AreaDisplayId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "AreaName is required")]
        [MinLength(3, ErrorMessage = "AreaName must be minimum of 3 characters")]
        [MaxLength(40, ErrorMessage = "AreaName cannot be grater than 40 characters")]
        public string AreaName { get; set; }

        [Required(ErrorMessage = "PinCode is required")]    
        public int PinCode { get; set; }

        public virtual ICollection<AreaOwner> AreaOwners { get; set; }
        
    }
}
