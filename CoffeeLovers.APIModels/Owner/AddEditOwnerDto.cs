using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoffeeLovers.APIModels.Owner
{
    public class AddEditOwnerDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string RoleName { get; set; }

        [Required]
        public string AreaName { get; set; }
    }
}
