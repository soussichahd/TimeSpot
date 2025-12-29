using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAmazonstore3.Models;

namespace MyAmazonstore3.Data
{
    public class MyAmazonstore3Context : DbContext
    {
        public MyAmazonstore3Context (DbContextOptions<MyAmazonstore3Context> options)
            : base(options)
        {
        }

        public DbSet<MyAmazonstore3.Models.Produit> Produit { get; set; } = default!;
        public DbSet<MyAmazonstore3.Models.Categorie> Categorie { get; set; } = default!;
<<<<<<< HEAD
        
=======
       
>>>>>>> 1c2ddfc245832854bdad923b7887e7d48c0085e7
        public DbSet<MyAmazonstore3.Models.User> User { get; set; } = default!;
    }
}
