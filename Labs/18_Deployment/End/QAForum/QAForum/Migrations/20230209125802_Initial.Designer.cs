// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QAForum.EF;

#nullable disable

namespace QAForum.Migrations
{
    [DbContext(typeof(ForumDbContext))]
    [Migration("20230209125802_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QAForum.Models.Forum", b =>
                {
                    b.Property<int>("ForumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ForumId"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ForumId");

                    b.ToTable("Forums");

                    b.HasData(
                        new
                        {
                            ForumId = 1,
                            Title = "ASP.NET MVC"
                        },
                        new
                        {
                            ForumId = 2,
                            Title = "ASP.NET Blazor"
                        },
                        new
                        {
                            ForumId = 3,
                            Title = "ASP.NET WebForms"
                        },
                        new
                        {
                            ForumId = 4,
                            Title = "jQuery"
                        },
                        new
                        {
                            ForumId = 5,
                            Title = "Angular"
                        },
                        new
                        {
                            ForumId = 6,
                            Title = "Visual Studio 2022"
                        },
                        new
                        {
                            ForumId = 7,
                            Title = "WPF"
                        });
                });

            modelBuilder.Entity("QAForum.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"), 1L, 1);

                    b.Property<string>("PostBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("ThreadId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostId");

                    b.HasIndex("ThreadId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("QAForum.Models.Thread", b =>
                {
                    b.Property<int>("ThreadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThreadId"), 1L, 1);

                    b.Property<int>("ForumId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThreadId");

                    b.HasIndex("ForumId");

                    b.ToTable("Threads");
                });

            modelBuilder.Entity("QAForum.Models.UnhandledException", b =>
                {
                    b.Property<int>("UnhandledExceptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnhandledExceptionId"), 1L, 1);

                    b.Property<string>("BaseExceptionMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExceptionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExceptionMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StackTrace")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnhandledExceptionId");

                    b.ToTable("UnhandledExceptions");
                });

            modelBuilder.Entity("QAForum.Models.Post", b =>
                {
                    b.HasOne("QAForum.Models.Thread", "Thread")
                        .WithMany("Posts")
                        .HasForeignKey("ThreadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Thread");
                });

            modelBuilder.Entity("QAForum.Models.Thread", b =>
                {
                    b.HasOne("QAForum.Models.Forum", "Forum")
                        .WithMany("Threads")
                        .HasForeignKey("ForumId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Forum");
                });

            modelBuilder.Entity("QAForum.Models.Forum", b =>
                {
                    b.Navigation("Threads");
                });

            modelBuilder.Entity("QAForum.Models.Thread", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
