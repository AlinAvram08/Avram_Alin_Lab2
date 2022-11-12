using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Avram_Alin_Lab2.Models;

namespace Avram_Alin_Lab2.Data
{
    public class Avram_Alin_Lab2Context : DbContext
    {
        public Avram_Alin_Lab2Context (DbContextOptions<Avram_Alin_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Avram_Alin_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Avram_Alin_Lab2.Models.Publisher> Publisher { get; set; }

        public DbSet<Avram_Alin_Lab2.Models.Category> Category { get; set; }
    }
}
