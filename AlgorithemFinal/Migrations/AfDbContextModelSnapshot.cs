﻿// <auto-generated />
using System;
using AlgorithemFinal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlgorithemFinal.Migrations
{
    [DbContext(typeof(AfDbContext))]
    partial class AfDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlgorithemFinal.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("AlgorithemFinal.Models.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TimeTableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TimeTableId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("AlgorithemFinal.Models.Bell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BellOfDay")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bells");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BellOfDay = 0,
                            Label = "8-10"
                        },
                        new
                        {
                            Id = 2,
                            BellOfDay = 1,
                            Label = "10-12"
                        },
                        new
                        {
                            Id = 3,
                            BellOfDay = 2,
                            Label = "14-16"
                        },
                        new
                        {
                            Id = 4,
                            BellOfDay = 3,
                            Label = "16-18"
                        });
                });

            modelBuilder.Entity("AlgorithemFinal.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "طراحی الگوریتم",
                            UnitsCount = 3
                        },
                        new
                        {
                            Id = 2,
                            Title = "ساختمان داده ها",
                            UnitsCount = 3
                        },
                        new
                        {
                            Id = 3,
                            Title = "برنامه سازی پیشرفته",
                            UnitsCount = 3
                        });
                });

            modelBuilder.Entity("AlgorithemFinal.Models.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Days");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DayOfWeek = 0,
                            Label = "شنبه"
                        },
                        new
                        {
                            Id = 2,
                            DayOfWeek = 1,
                            Label = "یکشنبه"
                        },
                        new
                        {
                            Id = 3,
                            DayOfWeek = 2,
                            Label = "دوشنبه"
                        },
                        new
                        {
                            Id = 4,
                            DayOfWeek = 3,
                            Label = "سه‌شنبه"
                        },
                        new
                        {
                            Id = 5,
                            DayOfWeek = 4,
                            Label = "چهارشنبه"
                        },
                        new
                        {
                            Id = 6,
                            DayOfWeek = 5,
                            Label = "پنج‌شنبه"
                        },
                        new
                        {
                            Id = 7,
                            DayOfWeek = 6,
                            Label = "جمعه"
                        });
                });

            modelBuilder.Entity("AlgorithemFinal.Models.Master", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Masters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("AlgorithemFinal.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 2,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("AlgorithemFinal.Models.TimeTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("MasterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("MasterId");

                    b.ToTable("TimeTables");
                });

            modelBuilder.Entity("AlgorithemFinal.Models.TimeTableBell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BellId")
                        .HasColumnType("int");

                    b.Property<int?>("DayId")
                        .HasColumnType("int");

                    b.Property<int?>("MasterId")
                        .HasColumnType("int");

                    b.Property<int?>("TimeTableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BellId");

                    b.HasIndex("DayId");

                    b.HasIndex("MasterId");

                    b.HasIndex("TimeTableId");

                    b.ToTable("TimeTableBells");
                });

            modelBuilder.Entity("AlgorithemFinal.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MasterId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("Code")
                        .HasName("AlternateKey_Code");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminId = 1,
                            Code = "975361004",
                            FirstName = "مسعود",
                            LastName = "پورغفار اقدم",
                            Password = "$2a$11$r9ZNNAAsp7q436lBciIUROHPPhNx8w7E2uQO/VBIEGSsH.pVmJWMe"
                        },
                        new
                        {
                            Id = 2,
                            Code = "965361004",
                            FirstName = "ریحانه",
                            LastName = "زهرابی",
                            MasterId = 1,
                            Password = "$2a$11$IwhNebCxX4sOWfhVltGJy.9wG8zgxzR58HsikVZVL1q/scEe5pjhy"
                        },
                        new
                        {
                            Id = 3,
                            Code = "985361004",
                            FirstName = "نرگس",
                            LastName = "میرزایی",
                            Password = "$2a$11$QzkNKGof/P5zQGiGyOQ4.u/HKzDXaaJfZpP8cbU/BuAlMurhCdCjq",
                            StudentId = 1
                        },
                        new
                        {
                            Id = 4,
                            Code = "985361003",
                            FirstName = "طاها",
                            LastName = "علیپور",
                            Password = "$2a$11$k8wMZKTqqNWSsSJusbDkh.dTG97S1/96v8.EE9L/9Wg5.koODk9cy",
                            StudentId = 2
                        });
                });

            modelBuilder.Entity("CourseMaster", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("MastersId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "MastersId");

                    b.HasIndex("MastersId");

                    b.ToTable("CourseMaster");
                });

            modelBuilder.Entity("StudentTimeTable", b =>
                {
                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.Property<int>("TimeTablesId")
                        .HasColumnType("int");

                    b.HasKey("StudentsId", "TimeTablesId");

                    b.HasIndex("TimeTablesId");

                    b.ToTable("StudentTimeTable");
                });

            modelBuilder.Entity("AlgorithemFinal.Models.Admin", b =>
                {
                    b.HasOne("AlgorithemFinal.Models.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("AlgorithemFinal.Models.Admin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AlgorithemFinal.Models.Announcement", b =>
                {
                    b.HasOne("AlgorithemFinal.Models.TimeTable", "TimeTable")
                        .WithMany()
                        .HasForeignKey("TimeTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TimeTable");
                });

            modelBuilder.Entity("AlgorithemFinal.Models.Master", b =>
                {
                    b.HasOne("AlgorithemFinal.Models.User", "User")
                        .WithOne("Master")
                        .HasForeignKey("AlgorithemFinal.Models.Master", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AlgorithemFinal.Models.Student", b =>
                {
                    b.HasOne("AlgorithemFinal.Models.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("AlgorithemFinal.Models.Student", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AlgorithemFinal.Models.TimeTable", b =>
                {
                    b.HasOne("AlgorithemFinal.Models.Course", "Course")
                        .WithMany("TimeTables")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlgorithemFinal.Models.Master", "Master")
                        .WithMany("TimeTables")
                        .HasForeignKey("MasterId");

                    b.Navigation("Course");

                    b.Navigation("Master");
                });

            modelBuilder.Entity("AlgorithemFinal.Models.TimeTableBell", b =>
                {
                    b.HasOne("AlgorithemFinal.Models.Bell", "Bell")
                        .WithMany()
                        .HasForeignKey("BellId");

                    b.HasOne("AlgorithemFinal.Models.Day", "Day")
                        .WithMany()
                        .HasForeignKey("DayId");

                    b.HasOne("AlgorithemFinal.Models.Master", null)
                        .WithMany("TimeTableBells")
                        .HasForeignKey("MasterId");

                    b.HasOne("AlgorithemFinal.Models.TimeTable", "TimeTable")
                        .WithMany("TimeTableBells")
                        .HasForeignKey("TimeTableId");

                    b.Navigation("Bell");

                    b.Navigation("Day");

                    b.Navigation("TimeTable");
                });

            modelBuilder.Entity("CourseMaster", b =>
                {
                    b.HasOne("AlgorithemFinal.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlgorithemFinal.Models.Master", null)
                        .WithMany()
                        .HasForeignKey("MastersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentTimeTable", b =>
                {
                    b.HasOne("AlgorithemFinal.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlgorithemFinal.Models.TimeTable", null)
                        .WithMany()
                        .HasForeignKey("TimeTablesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlgorithemFinal.Models.Course", b =>
                {
                    b.Navigation("TimeTables");
                });

            modelBuilder.Entity("AlgorithemFinal.Models.Master", b =>
                {
                    b.Navigation("TimeTableBells");

                    b.Navigation("TimeTables");
                });

            modelBuilder.Entity("AlgorithemFinal.Models.TimeTable", b =>
                {
                    b.Navigation("TimeTableBells");
                });

            modelBuilder.Entity("AlgorithemFinal.Models.User", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Master");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
