using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResearchGateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchGateProject.Data
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser_Paper>().HasKey(UserAndPaper => new
            {
                UserAndPaper.ApplicationUserId,
                UserAndPaper.PaperId
            });

            modelBuilder.Entity<ApplicationUser_Paper>().HasOne(UserAndPaper => UserAndPaper.ApplicationUser).WithMany(UserAndPaper => UserAndPaper.ApplicationUsers_Papers).HasForeignKey(UserAndPaper => UserAndPaper.ApplicationUserId);
            modelBuilder.Entity<ApplicationUser_Paper>().HasOne(UserAndPaper => UserAndPaper.Paper).WithMany(UserAndPaper => UserAndPaper.ApplicationUsers_Papers).HasForeignKey(UserAndPaper => UserAndPaper.PaperId);

            base.OnModelCreating(modelBuilder);
        }


       
        public DbSet<ApplicationUser_Paper> ApplicationUsers_Papers { get; set; }
        public DbSet<Paper> Papers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }



    }
}
