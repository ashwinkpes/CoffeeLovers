using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoffeeLovers.DomainModels.Models
{
    [Table("CoffeeAreas", Schema = "dbo")]
    public class CoffeeArea : Valid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid CoffeeAreaId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CoffeeAreaDisplayId is required")]
        [MinLength(3, ErrorMessage = "CoffeeAreaDisplayId must be minimum of 3 characters")]
        [MaxLength(40, ErrorMessage = "CoffeeAreaDisplayId cannot be grater than 40 characters")]
        public string CoffeeAreaDisplayId { get; set; }

        public Guid AreaId { get; set; }

        [ForeignKey("AreaId")]
        public virtual Area Area { get; set; }

        public Guid CoffeeId { get; set; }

        [ForeignKey("CoffeeId")]
        public virtual Coffee Coffee { get; set; }


    }
}
