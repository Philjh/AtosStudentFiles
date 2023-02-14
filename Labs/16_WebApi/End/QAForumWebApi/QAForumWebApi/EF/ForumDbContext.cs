using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Proxies;
using QAForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.EF
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options)
            : base(options)
        {

        }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<QAForum.Models.Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QAForum.Models.Thread>()
                .HasOne(t => t.Forum)
                .WithMany(f => f.Threads)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Thread)
                .WithMany(t => t.Posts)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class ForumContextFactory : IDesignTimeDbContextFactory<ForumDbContext>
    {
        public ForumDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ForumDbContext>();
            string conn = @"Server=.\SqlExpress;Database=Forum.Data;Trusted_Connection=true; MultipleActiveResultSets=True";
            optionsBuilder.UseSqlServer(conn);

            return new ForumDbContext(optionsBuilder.Options);
        }
    }
}
