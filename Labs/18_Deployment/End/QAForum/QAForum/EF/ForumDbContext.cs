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
        public DbSet<Forum>? Forums { get; set; }
        public DbSet<QAForum.Models.Thread>? Threads { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<UnhandledException>? UnhandledExceptions { get; set; }

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

            modelBuilder.Entity<Forum>().HasData
                                        (
                                            new Forum { ForumId = 1, Title = "ASP.NET MVC" },
                                            new Forum { ForumId = 2, Title = "ASP.NET Blazor" },
                                            new Forum { ForumId = 3, Title = "ASP.NET WebForms" },
                                            new Forum { ForumId = 4, Title = "jQuery" },
                                            new Forum { ForumId = 5, Title = "Angular" },
                                            new Forum { ForumId = 6, Title = "Visual Studio 2022" },
                                            new Forum { ForumId = 7, Title = "WPF" }
                                        );

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
