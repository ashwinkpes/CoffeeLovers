using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeLovers.DomainModels.Models
{
    [Table("Role", Schema = "dbo")]
    public class Role : Valid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid RoleId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "RoleDisplayId is required")]
        [MinLength(3, ErrorMessage = "RoleDisplayId must be minimum of 3 characters")]
        [MaxLength(40, ErrorMessage = "RoleDisplayId cannot be grater than 40 characters")]
        public string RoleDisplayId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "RoleName is required")]
        [MinLength(3, ErrorMessage = "RoleName must be minimum of 3 characters")]
        [MaxLength(40, ErrorMessage = "RoleName cannot be grater than 40 characters")]
        public string RoleName { get; set; }
    }
}