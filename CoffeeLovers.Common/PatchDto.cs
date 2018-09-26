using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoffeeLovers.Common
{
    public class PatchDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "PropertyName is required")]
        public string PropertyName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "PropertyValue is required")]
        public object PropertyValue { get; set; }
    }
}
