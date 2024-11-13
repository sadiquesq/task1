using Microsoft.EntityFrameworkCore;
using task1.models;

namespace task1.Controllers
{
    public class MainDbContext :DbContext
    {

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Address> Addresss { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasKey(e => e.Id);

            modelBuilder.Entity<Department>().HasKey(e=> e.DepartmentId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(e => e.Employee)
                .HasForeignKey(e => e.DepartmentId);


            modelBuilder.Entity<Student>()
                .HasKey(e=>e.StudentId);


            modelBuilder.Entity<Address>()
                .HasKey(e=>e.AddressId);

            modelBuilder.Entity<Student>()
                .HasOne(e => e.Address)
                .WithOne(e => e.Student)
                .HasForeignKey<Address>(e => e.AddressId);

            modelBuilder.Entity<Student>()
                .HasAlternateKey(e => e.AddressId);

            //modelBuilder.Entity<Student>()
            //.HasP

            //modelBuilder.Entity<Student>()
            //    .HasData(new Student()
            //    {
            //        StudentId=1,
            //        StudentName = "ajfar",
            //        AddressId = 2
            //    });

        }
    }
}
