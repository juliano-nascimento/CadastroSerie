using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Context
{
    public class SerieContext : DbContext
    {
        public SerieContext(DbContextOptions<SerieContext> options) : base(options)
        {
        }

        public DbSet<Serie> Series { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Serie>()
        //        .HasKey(s => new { s.Id });
        //}
    }
}
