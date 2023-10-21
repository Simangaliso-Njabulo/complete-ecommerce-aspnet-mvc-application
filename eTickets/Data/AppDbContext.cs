﻿using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actor_Movies).HasForeignKey(am => am.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(a => a.Actor).WithMany(am => am.Actor_Movies).HasForeignKey(am => am.ActorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}