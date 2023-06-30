using System.ComponentModel.DataAnnotations;

namespace PizzaResturant.Models
{
    public class PizzaModel
    {
        [Key]
        public int PizzaId { get; set; }
        public string ImgPath { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        
    }
}
