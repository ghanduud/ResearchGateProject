
using ResearchGateProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResearchGateProject.Data;
using ResearchGateProject.Data.Static;

namespace ResearchGateProject.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Comment
                if (!context.Comments.Any())
                {
                    context.Comments.AddRange(new List<Comment>()
                    {
                        new Comment()
                        {
                            Body = "Comment 1",

                        },
                      new Comment()
                        {
                            Body = "Comment 2",

                        },new Comment()
                        {
                            Body = "Comment 3",

                        },new Comment()
                        {
                            Body = "Comment 4",

                        },new Comment()
                        {
                            Body = "Comment 5",

                       }
                       });
                    
                }
                
                if (!context.Papers.Any())
                {
                    context.Papers.AddRange(new List<Paper>()
                    {
                        new Paper()
                        {
                            Title = "Paper 1",
                            Body ="This is the the first Paper",
                            CreatedDate = DateTime.Now.AddDays(-10)
                            
                        },
                        new Paper()
                        {
                            Title = "Paper 1",
                            Body ="This is the the first Paper",
                            CreatedDate = DateTime.Now.AddDays(-10)
                            
                        },
                         new Paper()
                        {
                            Title = "Paper 1",
                            Body ="This is the the first Paper",
                            CreatedDate = DateTime.Now.AddDays(-10)
                            
                        },
                          new Paper()
                        {
                            Title = "Paper 1",
                            Body ="This is the the first Paper",
                            CreatedDate = DateTime.Now.AddDays(-10)
                            
                        },
                           new Paper()
                        {
                            Title = "Paper 1",
                            Body ="This is the the first Paper",
                            CreatedDate = DateTime.Now.AddDays(-10)
                            
                           
                        },
                            new Paper()
                        {
                            Title = "Paper 1",
                            Body ="This is the the first Paper",
                            CreatedDate = DateTime.Now.AddDays(-10)
                            
                        },

                    });
                    
                }
              
                if (!context.Likes.Any())
                {
                    context.Likes.AddRange(new List<Like>()
                    {
                        new Like()
                        {
                            Type = "Like",
                            
                        },
                         new Like()
                        {
                            Type = "dislike",

                        },

                    });
                    context.SaveChanges();
                }
               
                if (!context.ApplicationUsers_Papers.Any())
                {
                    context.ApplicationUsers_Papers.AddRange(new List<ApplicationUser_Paper>()
                    {
                       new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "1",
                            PaperId = "1"
                        },
                        new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "3",
                            PaperId = "1"
                        },

                         new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "1",
                            PaperId = "2"
                        },
                         new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "4",
                            PaperId = "2"
                        },

                        new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "1",
                            PaperId = "3"
                        },
                        new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "2",
                            PaperId = "3"
                        },
                        new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "5",
                            PaperId = "2"
                        },


                        new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "2",
                            PaperId = "4"
                        },
                        new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "3",
                            PaperId = "4"
                        },
                        new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "4",
                            PaperId = "4"
                        },


                        new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "2",
                            PaperId = "5"
                        },
                        new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "3",
                            PaperId = "5"
                        },
                        new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "4",
                            PaperId = "5"
                        },
                        new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "5",
                            PaperId = "5"
                        },


                        new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "3",
                            PaperId = "6"
                        },
                        new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "4",
                            PaperId = "4"
                        },
                        new ApplicationUser_Paper()
                        {
                            ApplicationUserId = "5",
                            PaperId = "6"
                        },
                    });
                  
                }
            }

        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
               
                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {

                        FirstName = "Admin User",
                        LastName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true,                                               
                        PhoneNumber = "01129552459",
                        Uni = "hewlan",
                        Dept = "is",                      
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg",
                        
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                
            }
        }

    }
}
