using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeLovers.DomainModels.Models
{
    [Table("Owner", Schema = "dbo")]
    public class Owner : User
    {
        public Owner()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid OwnerId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "OwnerDisplayId is required")]
        [MinLength(3, ErrorMessage = "OwnerDisplayId must be minimum of 3 characters")]
        [MaxLength(40, ErrorMessage = "OwnerDisplayId cannot be grater than 40 characters")]
        public string OwnerDisplayId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "EmailId is required")]
        [MinLength(3, ErrorMessage = "EmailId must be minimum of 3 characters")]
        [MaxLength(30, ErrorMessage = "EmailId cannot be grater than 30 characters")]
        public string EmailId { get; set; }

        public Guid RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [MinLength(3, ErrorMessage = "Password must be minimum of 3 characters")]
        [MaxLength(100, ErrorMessage = "Password cannot be grater than 100 characters")]
        public string Password { get; set; }

        public DateTimeOffset? LastLoggedIn { get; set; }

        /// <summary>
        /// every time the user changes his Password,
        /// or an admin changes his Roles or stat/IsActive,
        /// create a new `SerialNumber` GUID and store it in the DB.
        /// </summary>
        public string SerialNumber { get; set; }

        public virtual ICollection<AreaOwner> AreaOwners { get; set; } = new HashSet<AreaOwner>();
        public virtual ICollection<OwnerConfirmation> OwnerConfirmations { get; set; } = new HashSet<OwnerConfirmation>();
    }
}