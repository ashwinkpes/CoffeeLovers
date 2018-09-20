using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoffeeLovers.DomainModels.Models
{
    [Table("AreaOwner")]
    public class AreaOwner : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid AreaOwnerId { get; set; }

        public int AreaId { get; set; }

        public int OwnerId { get; set; }

        [Required(ErrorMessage = "validFrom is required")]
        public DateTime validFrom { get; set; }

        [Required(ErrorMessage = "validTo is required")]
        public DateTime validTo { get; set; }

        public virtual Area Area { get; set; }

        public virtual Owner Owner { get; set; }
    }
}
