using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoffeeLovers.DomainModels.Models
{
    public class CoffeeArea : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid CoffeeAreaId { get; set; }

        [Required(ErrorMessage = "validFrom is required")]
        public DateTime validFrom { get; set; }

        [Required(ErrorMessage = "validTo is required")]
        public DateTime validTo { get; set; }

        public int CoffeeId { get; set; }

        public int AreaId { get; set; }

        public virtual Coffee Coffee { get; set; }

        public virtual Area Area { get; set; }

    }
}
