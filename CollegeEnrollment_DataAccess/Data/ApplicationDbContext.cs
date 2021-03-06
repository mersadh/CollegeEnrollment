using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeEnrollment_DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Major> Majors { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<EnrollmentHeader> EnrollmentHeaders { get; set; }
        public DbSet<EnrollmentDetail> EnrollmentDetails { get; set; }   
    }
}
