using Microsoft.EntityFrameworkCore;
using REST_API_CV_Hantering.Models;
using System;

namespace REST_API_CV_Hantering.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Personer { get; set; }
        public DbSet<Utbildning> Utbildningar { get; set; }
        public DbSet<Arbetserfarenhet> Arbetserfarenheter { get; set; }
    }
}
