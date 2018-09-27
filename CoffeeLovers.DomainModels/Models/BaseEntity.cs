using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoffeeLovers.DomainModels.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            IsActive = true;
        }


        [Required(AllowEmptyStrings = false, ErrorMessage = "CreatedBy is required")]
        [MinLength(3,ErrorMessage = "CreatedBy must be minimum of 3 characters")]
        [MaxLength(20, ErrorMessage = "CreatedBy cannot be grater than 20 characters")]
        public string CreatedBy { get; set; }
              
        [Required(ErrorMessage = "Createdtime is required")]
        public DateTime Createdtime { get; set; }

        [DefaultValue("System")]
        [MinLength(3, ErrorMessage = "UpdatedBy must be minimum of 3 characters")]
        [MaxLength(20, ErrorMessage = "UpdatedBy cannot be grater than 20 characters")]
        public string UpdatedBy { get; set; }
                
        public DateTime? Updatedtime { get; set; }

        [Required(ErrorMessage = "IsActive is required")]     
        public bool IsActive { get; set; }
    }
}
