using System.ComponentModel.DataAnnotations;

namespace PizzaResturant.Models
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        public AuthModel Auth { get; set; }
        public string Username { get; set; }
        public PizzaModel Pizza { get; set; } 
        public int PizzaId { get; set; }
    }
}
