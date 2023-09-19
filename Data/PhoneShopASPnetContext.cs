using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneShopASPnet.Models;

namespace PhoneShopASPnet.Data
{
    public class PhoneShopASPnetContext : DbContext
    {
        public PhoneShopASPnetContext (DbContextOptions<PhoneShopASPnetContext> options)
            : base(options)
        {
        }

        public DbSet<PhoneShopASPnet.Models.Users> Users { get; set; } = default!;

        public DbSet<PhoneShopASPnet.Models.Brand>? Brand { get; set; }

        public DbSet<PhoneShopASPnet.Models.Category>? Category { get; set; }

        public DbSet<PhoneShopASPnet.Models.Product>? Product { get; set; }
    }
}
