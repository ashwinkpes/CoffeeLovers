using System.ComponentModel.DataAnnotations;

namespace CoffeeLovers.APIModels.Owner
{
    public class AddOwnerDto
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
        public string Password { get; set; }

    }
}
