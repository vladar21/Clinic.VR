﻿using Microsoft.EntityFrameworkCore;

namespace Clinic.VR
{
    public class Clinic : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentDoc> DepartmentDocs { get; set; }
        public DbSet<Doc> Docs { get; set; }
        public DbSet<DocSchedule> DocSchedules { get; set; }
        public DbSet<FIO> FIOs { get; set; }
        public DbSet<Patient> Patients { get; set; }
        
        public Clinic(DbContextOptions options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<DepartmentDoc>().HasKey(dd => new { dd.DepartmentID, dd.DocID });

            modelBuilder.Entity<DepartmentDoc>().HasOne(dd => dd.Department).WithMany(d => DepartmentDocs).HasForeignKey(dd => dd.DepartmentID);

            modelBuilder.Entity<DepartmentDoc>().HasOne(dd => dd.Doc).WithMany(d => DepartmentDocs).HasForeignKey(dd => dd.DocID);


        }
    }
}