using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

using Microsoft.EntityFrameworkCore;
namespace PizzaResturant.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<PizzaModel> Pizzas { get; set; }

        public DbSet<OrderModel> Orders { get; set; }

    }
}