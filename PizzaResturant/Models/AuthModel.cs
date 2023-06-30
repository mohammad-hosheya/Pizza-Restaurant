using System.ComponentModel.DataAnnotations;

namespace PizzaResturant.Models
{
    public class AuthModel
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
