using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeLovers.DomainModels.Models
{
    [Table("OwnerConfirmation", Schema = "dbo")]
    public class OwnerConfirmation : Valid
    {
        public OwnerConfirmation()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid OwnerConfirmationId { get; set; }

        public Guid confirmationToken { get; set; }

        public Guid OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual Owner Owner { get; set; }
    }
}