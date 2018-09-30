using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeLovers.DomainModels.Models
{
    public abstract class User : BaseEntity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName is required")]
        [MinLength(3, ErrorMessage = "FirstName must be minimum of 3 characters")]
        [MaxLength(20, ErrorMessage = "FirstName cannot be grater than 20 characters")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName is required")]
        [MinLength(3, ErrorMessage = "LastName must be minimum of 3 characters")]
        [MaxLength(20, ErrorMessage = "LastName cannot be grater than 20 characters")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => FirstName + LastName;
    }
}
