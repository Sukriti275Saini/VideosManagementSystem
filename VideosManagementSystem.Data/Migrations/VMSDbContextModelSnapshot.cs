﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideosManagementSystem.Data;

namespace VideosManagementSystem.Data.Migrations
{
    [DbContext(typeof(VMSDbContext))]
    partial class VMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VideosManagementSystem.Core.Blogs", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlogDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BlogDislikes")
                        .HasColumnType("int");

                    b.Property<int>("BlogLikes")
                        .HasColumnType("int");

                    b.Property<string>("BlogTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName1")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("BlogId");

                    b.HasIndex("UserName1");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("VideosManagementSystem.Core.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suggestions")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeedbackId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("VideosManagementSystem.Core.Users", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<long>("PhoneNo")
                        .HasColumnType("bigint");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.ToTable("User");
                });

            modelBuilder.Entity("VideosManagementSystem.Core.UsersVideoRecord", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DueAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UsersUserName")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("VideosVideoId")
                        .HasColumnType("int");

                    b.HasKey("RecordId");

                    b.HasIndex("UsersUserName");

                    b.HasIndex("VideosVideoId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("VideosManagementSystem.Core.Videos", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Actor")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<int>("LeaseAmount")
                        .HasColumnType("int");

                    b.Property<int>("NoOfCopies")
                        .HasColumnType("int");

                    b.Property<string>("VideoImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("YearOfRelease")
                        .HasColumnType("int");

                    b.HasKey("VideoId");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("VideosManagementSystem.Core.Blogs", b =>
                {
                    b.HasOne("VideosManagementSystem.Core.Users", "UserName")
                        .WithMany()
                        .HasForeignKey("UserName1");
                });

            modelBuilder.Entity("VideosManagementSystem.Core.UsersVideoRecord", b =>
                {
                    b.HasOne("VideosManagementSystem.Core.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersUserName");

                    b.HasOne("VideosManagementSystem.Core.Videos", "Videos")
                        .WithMany()
                        .HasForeignKey("VideosVideoId");
                });
#pragma warning restore 612, 618
        }
    }
}
