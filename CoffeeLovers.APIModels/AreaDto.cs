using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeLovers.APIModels
{
    public class AreaDto
    {
        public string AreaDisplayId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "AreaName is required")]
        [MinLength(3, ErrorMessage = "AreaName must be minimum of 3 characters")]
        [StringLength(40, ErrorMessage = "AreaName cannot be grater than 40 characters")]
        public string AreaName { get; set; }

        [Required(ErrorMessage = "PinCode is required")]
        public int PinCode { get; set; }

        public AreaDto()
        {

        }
      
    }
}
