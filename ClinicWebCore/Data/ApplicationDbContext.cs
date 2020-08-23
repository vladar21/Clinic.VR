using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClinicWebCore.Models;


namespace ClinicWebCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentDoc> DepartmentDocs { get; set; }
        public DbSet<Doc> Docs { get; set; }
        public DbSet<DocSchedule> DocSchedules { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<BookCategory>()
            //    .HasKey(bc => new { bc.BookId, bc.CategoryId });

            //modelBuilder.Entity<BookCategory>()
            //    .HasOne(bc => bc.Book)
            //    .WithMany(b => b.BookCategories)
            //    .HasForeignKey(bc => bc.BookId);

            //modelBuilder.Entity<BookCategory>()
            //    .HasOne(bc => bc.Category)
            //    .WithMany(c => c.BookCategories)
            //    .HasForeignKey(bc => bc.CategoryId);            

            // Сущность Address
            modelBuilder.Entity<Address>().Property(a => a.ZipCode).HasMaxLength(255);
            modelBuilder.Entity<Address>().Property(a => a.Country).HasMaxLength(255);
            modelBuilder.Entity<Address>().Property(a => a.Region).HasMaxLength(255);
            modelBuilder.Entity<Address>().Property(a => a.Locality).HasMaxLength(255);
            modelBuilder.Entity<Address>().Property(a => a.Street).HasMaxLength(255);
            modelBuilder.Entity<Address>().Property(a => a.House).HasMaxLength(255);
            modelBuilder.Entity<Address>().Property(a => a.Apartment).HasMaxLength(255);
            modelBuilder.Entity<Address>().HasMany(c => c.Contacts).WithOne(a => a.Address);
            
            #region Address
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    AddressID = 1,
                    ZipCode = "69000",
                    Country = "Україна",
                    Region = "Запорізька область",
                    Locality = "Запоріжжя",
                    Street = "пр. Соборний",
                    House = "151",
                    Apartment = "24"
                },
                new Address
                {
                    AddressID = 2,
                    ZipCode = "69001",
                    Country = "Україна",
                    Region = "Запорізька область",
                    Locality = "Запоріжжя",
                    Street = "площф Маяковського",
                    House = "11",
                    Apartment = "7"
                },
                new Address
                {
                    AddressID = 3,
                    ZipCode = "69003",
                    Country = "Україна",
                    Region = "Запорізька область",
                    Locality = "Запоріжжя",
                    Street = "пр. Ювілейний",
                    House = "230",
                    Apartment = "112"
                },
                new Address
                {
                    AddressID = 4,
                    ZipCode = "69004",
                    Country = "Україна",
                    Region = "Запорізька область",
                    Locality = "Запоріжжя",
                    Street = "бульвар Шевченка",
                    House = "10",
                    Apartment = "19"
                },
                new Address
                {
                    AddressID = 5,
                    ZipCode = "69005",
                    Country = "Україна",
                    Region = "Запорізька область",
                    Locality = "Запоріжжя",
                    Street = "вулиця Перемоги ",
                    House = "97",
                    Apartment = "129"
                },
                new Address
                {
                    AddressID = 6,
                    ZipCode = "69003",
                    Country = "Україна",
                    Region = "Запорізька область",
                    Locality = "Запоріжжя",
                    Street = "вулиця Запорізького Козацтва",
                    House = "117",
                    Apartment = "39"
                }
            );
            #endregion

            // Сущность Contact
            modelBuilder.Entity<Contact>().HasOne(a => a.Address).WithMany(c => c.Contacts);
            modelBuilder.Entity<Contact>().Property(c => c.FirstName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Contact>().Property(c => c.MiddleName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Contact>().Property(c => c.LastName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Contact>().Property(c => c.Phone).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Contact>().Property(c => c.Email).HasMaxLength(255);

            #region Contact
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactID = 1,
                    AddressID = 1,
                    FirstName = "Ольга",
                    MiddleName = "Вікторівна",
                    LastName = "Бородіна",
                    Phone = "(068) 234-23-21",
                    Email = "olga@com.ua",
                    Birthday = DateTime.Parse("1950-03-03 10:30:00"),
                    CreatedAt = DateTime.Parse("2020-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Contact
                {
                    ContactID = 2,
                    AddressID = 2,
                    FirstName = "Марія",
                    MiddleName = "Олександрівна",
                    LastName = "Колесник",
                    Phone = "(061) 233-21-22",
                    Email = "mariya@com.ua",
                    Birthday = DateTime.Parse("1955-11-23 21:05:00"),
                    CreatedAt = DateTime.Parse("2020-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Contact
                {
                    ContactID = 3,
                    AddressID = 3,
                    FirstName = "Семен",
                    MiddleName = "Павлович",
                    LastName = "Коротич",
                    Phone = "(050) 842-32-62",
                    Email = "semen@com.ua",
                    Birthday = DateTime.Parse("1970-07-15 14:35:00"),
                    CreatedAt = DateTime.Parse("2020-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Contact
                {
                    ContactID = 4,
                    AddressID = 1,
                    FirstName = "Іван",
                    MiddleName = "Володимирович",
                    LastName = "Бородін",
                    Phone = "(067) 622-84-96",
                    Email = "ivan@com.ua",
                    Birthday = DateTime.Parse("1951-08-02 12:00:00"),
                    CreatedAt = DateTime.Parse("2020-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Contact
                {
                    ContactID = 5,
                    AddressID = 2,
                    FirstName = "Гнат",
                    MiddleName = "Миколайович",
                    LastName = "Колесник",
                    Phone = "(050) 230-30-20",
                    Email = "gnat@com.ua",
                    Birthday = DateTime.Parse("1954-05-04 13:15:00"),
                    CreatedAt = DateTime.Parse("2020-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Contact
                {
                    ContactID = 6,
                    AddressID = 2,
                    FirstName = "Олена",
                    MiddleName = "Гнатовна",
                    LastName = "Колесник",
                    Phone = "(063) 333-77-55",
                    Email = "alena@com.ua",
                    Birthday = DateTime.Parse("1981-02-09 08:38:00"),
                    CreatedAt = DateTime.Parse("20-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Contact
                {
                    ContactID = 7,
                    AddressID = 4,
                    FirstName = "Віталій",
                    MiddleName = "Сергійович",
                    LastName = "Чуб",
                    Phone = "(098) 543-32-12",
                    Email = "vitaly@com.ua",
                    Birthday = DateTime.Parse("1981-03-02 12:00:00"),
                    CreatedAt = DateTime.Parse("2020-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Contact
                {
                    ContactID = 8,
                    AddressID = 5,
                    FirstName = "Ганна",
                    MiddleName = "Іванівна",
                    LastName = "Сумська",
                    Phone = "(068) 467-33-20",
                    Email = "ganna@com.ua",
                    Birthday = DateTime.Parse("2014-09-14 10:15:00"),
                    CreatedAt = DateTime.Parse("2020-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Contact
                {
                    ContactID = 9,
                    AddressID = 6,
                    FirstName = "Олеся",
                    MiddleName = "Романівна",
                    LastName = "Богдан",
                    Phone = "(061) 220-83-21",
                    Email = "olesyaa@com.ua",
                    Birthday = DateTime.Parse("1991-12-12 18:30:00"),
                    CreatedAt = DateTime.Parse("20-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                }
            );
            #endregion

            // Сущность Patient
            modelBuilder.Entity<Patient>().Property(p => p.MedicalHistoryRegistoreNumber).IsRequired().HasMaxLength(255);
            //modelBuilder.Entity<Patient>().HasOne<Contact>().WithOne().HasForeignKey<Patient>(p => p.ContactID);

            #region Patient
            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    PatientID = 1,
                    ContactID = 1,
                    MedicalHistoryRegistoreNumber = "MHR-001",
                    CreatedAt = DateTime.Parse("20-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Patient
                {
                    PatientID = 2,
                    ContactID = 4,
                    MedicalHistoryRegistoreNumber = "MHR-002",
                    CreatedAt = DateTime.Parse("20-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Patient
                {
                    PatientID = 3,
                    ContactID = 7,
                    MedicalHistoryRegistoreNumber = "MHR-003",
                    CreatedAt = DateTime.Parse("20-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Patient
                {
                    PatientID = 4,
                    ContactID = 8,
                    MedicalHistoryRegistoreNumber = "MHR-004",
                    CreatedAt = DateTime.Parse("20-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Patient
                {
                    PatientID = 5,
                    ContactID = 9,
                    MedicalHistoryRegistoreNumber = "MHR-005",
                    CreatedAt = DateTime.Parse("20-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                }

            );
            #endregion

            // Сущность Doc       
            modelBuilder.Entity<Doc>().HasOne(d => d.Contact).WithMany(c => c.Docs);
            modelBuilder.Entity<Doc>().Property(d => d.Office).IsRequired().HasMaxLength(255);

            #region Doc
            modelBuilder.Entity<Doc>().HasData(
                new Doc
                {
                    DocID = 1,
                    ContactID = 2,
                    DepartmentID = 1,
                    Specialty = "терапевт",
                    Office = "101",
                    HiredAt = DateTime.Parse("1978-01-01 10:30:01")                    
                },
                new Doc
                {
                    DocID = 2,
                    ContactID = 5,
                    DepartmentID = 2,
                    Specialty = "хірург",
                    Office = "207",
                    HiredAt = DateTime.Parse("1985-03-21 09:00:00")
                },
                new Doc
                {
                    DocID = 3,
                    ContactID = 6,
                    DepartmentID = 1,
                    Specialty = "педіатр",
                    Office = "101",
                    HiredAt = DateTime.Parse("2010-12-27 14:00:15")
                },
                new Doc
                {
                    DocID = 4,
                    ContactID = 3,
                    DepartmentID = 3,
                    Specialty = "кардіолог",
                    Office = "23",
                    HiredAt = DateTime.Parse("2000-07-12 08:37:00")
                }

            );
            #endregion

            // Сущность DepartmentDoc
            modelBuilder.Entity<DepartmentDoc>().HasKey(dd => new { dd.DepartmentID, dd.DocID });
            modelBuilder.Entity<DepartmentDoc>().HasOne(dd => dd.Department).WithMany(d => d.DepartmentDocs).HasForeignKey(dd => dd.DepartmentID);
            modelBuilder.Entity<DepartmentDoc>().HasOne(dd => dd.Doc).WithMany(d => d.DepartmentDocs).HasForeignKey(dd => dd.DocID);

            // Сущность DocSchedule
            modelBuilder.Entity<DocSchedule>().HasOne(d => d.Patient).WithMany(p => p.DocSchedules);
            modelBuilder.Entity<DocSchedule>().HasOne(d => d.Doc).WithMany(s => s.DocSchedules);
            

            // Сущность Department
            modelBuilder.Entity<Department>().Property(d => d.Name).IsRequired().HasMaxLength(255);

            #region Department
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentID = 1,
                    ParentID = null,
                    Name = "Адміністрація",
                    CreatedAt = DateTime.Parse("20-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Department
                {
                    DepartmentID = 2,
                    ParentID = 1,
                    Name = "Головний лікарь",
                    CreatedAt = DateTime.Parse("20-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Department
                {
                    DepartmentID = 3,
                    ParentID = null,
                    Name = "Стаціонар",
                    CreatedAt = DateTime.Parse("20-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Department
                {
                    DepartmentID = 4,
                    ParentID = 3,
                    Name = "хірургічне відділення",
                    CreatedAt = DateTime.Parse("20-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Department
                {
                    DepartmentID = 5,
                    ParentID = null,
                    Name = "Амбулаторно-поліклінічна служба",
                    CreatedAt = DateTime.Parse("20-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Department
                {
                    DepartmentID = 6,
                    ParentID = 5,
                    Name = "амбулаторне ортопедично-травматологічне відділення",
                    CreatedAt = DateTime.Parse("20-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                },
                new Department
                {
                    DepartmentID = 7,
                    ParentID = 3,
                    Name = "терапевтичне відділення",
                    CreatedAt = DateTime.Parse("20-08-19 15:18:00"),
                    UpdatedAt = DateTime.Parse("2020-08-19 15:18:00")
                }
            );
            #endregion
        }
    }

}

