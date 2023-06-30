using System.ComponentModel.DataAnnotations;

namespace PizzaResturant.Models
{
    public class UserModel
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public bool AdminFlag { get; set; }
    }
}
