using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Net.UI.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);




            //Seed Roles (User,Admin,SuperAdmin)
            var adminRoleId = "9e56b92e-08c8-453d-a867-747b0b081bfd";
            var superAdminRoleId = "48aa3fdf-ab94-4b40-afe7-0dddea608031";
            var userRoleId = "66ffb24c-8f47-4889-aacd-c152e19d0337";

            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
Name = "Admin",
NormalizedName = "Admin",
Id = adminRoleId,
ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                }, new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id=userRoleId,
                    ConcurrencyStamp=userRoleId
                }
            };


            builder.Entity<IdentityRole>().HasData(roles);

            // Seed SuperAdminUser
            var superAdminId = "a9d93d35-538c-449a-9de4-92dbcecf381b";
            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@asp.com",
                Email = "superadmin@asp.com",
                NormalizedEmail = "superadmin@asp.com".ToUpper(),
                NormalizedUserName = "superadmin@asp.com".ToUpper(),
                Id = superAdminId
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "Superadmin@123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //Add All roles to SuperAdminUser

            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
RoleId =adminRoleId,
UserId=superAdminId
                },             new IdentityUserRole<string>
                {
RoleId =superAdminRoleId,
UserId=superAdminId
                },             new IdentityUserRole<string>
                {
RoleId =userRoleId,
UserId=superAdminId
                }
            };


            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);


        



    }

    }
}
