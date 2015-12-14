using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEversol.Models;

namespace UberEversol
{
    public class UberEversolContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<MediaType> MediaType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename=UberEversol.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Make Session.id required
            modelBuilder.Entity<Session>();
        }
    }

}
