using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeLovers.APIModels.Owner
{
    public class AddEditOwnerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string RoleName { get; set; }

        public string AreaName { get; set; }
    }
}
