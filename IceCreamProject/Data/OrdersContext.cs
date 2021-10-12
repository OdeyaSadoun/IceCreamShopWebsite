using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IceCreamProject.Models;

    public class OrdersContext : DbContext
    {
        public OrdersContext (DbContextOptions<OrdersContext> options)
            : base(options)
        {
        }

        public DbSet<IceCreamProject.Models.Order> Order { get; set; }

        public DbSet<IceCreamProject.Models.IceCream> IceCream { get; set; }

        public DbSet<IceCreamProject.Models.ConnectUs> ConnectUs { get; set; }

        public DbSet<IceCreamProject.Models.Login> Login { get; set; }
    }
