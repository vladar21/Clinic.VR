using Microsoft.EntityFrameworkCore;

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
        public DbSet<Patient> Patients { get; set; }
        
        public Clinic(DbContextOptions options)
        : base(options) { }

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

            // Сущность Contact
            modelBuilder.Entity<Contact>().HasOne(a => a.Address).WithMany(c => c.Contacts);
            modelBuilder.Entity<Contact>().Property(c => c.FirstName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Contact>().Property(c => c.MiddleName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Contact>().Property(c => c.LastName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Contact>().Property(c => c.Phone).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Contact>().Property(c => c.Email).HasMaxLength(255);

            // Сущность Patient
            modelBuilder.Entity<Patient>()
                .HasOne(a => a.Contact)
                .WithOne(b => b.Patient)
                .HasForeignKey<Patient>(b => b.ContactID);
            modelBuilder.Entity<Patient>().Property(p => p.MedicalHistoryRegistoreNumber).IsRequired().HasMaxLength(255);

            // Сущность Doc       
            modelBuilder.Entity<Doc>().HasOne(d => d.Contact).WithMany(c => c.Docs);
            modelBuilder.Entity<Doc>().Property(d => d.Office).IsRequired().HasMaxLength(255);

            // Сущность DepartmentDoc
            modelBuilder.Entity<DepartmentDoc>().HasKey(dd => new { dd.DepartmentID, dd.DocID });
            modelBuilder.Entity<DepartmentDoc>().HasOne(dd => dd.Department).WithMany(d => DepartmentDocs).HasForeignKey(dd => dd.DepartmentID);
            modelBuilder.Entity<DepartmentDoc>().HasOne(dd => dd.Doc).WithMany(d => DepartmentDocs).HasForeignKey(dd => dd.DocID);

            // Сущность DocSchedule
            modelBuilder.Entity<DocSchedule>().HasOne(d => d.Patient).WithMany(p => p.DocSchedules);
            modelBuilder.Entity<DocSchedule>().HasOne(d => d.Doc).WithMany(s => s.DocSchedules);
            modelBuilder.Entity<DocSchedule>().HasOne(d => d.Department).WithMany(s => s.DocSchedules);

            // Сущность Department
            modelBuilder.Entity<Department>().Property(d => d.Name).IsRequired().HasMaxLength(255);

        }
    }
}