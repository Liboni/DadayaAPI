
namespace DadayaAPI.Data
{
    using System;
    using System.Linq;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class SeedDatabase
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            ApplicationDbContext context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (context.Roles.Any()) return;
            await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            await roleManager.CreateAsync(new IdentityRole { Name = "Staff" });
            await roleManager.CreateAsync(new IdentityRole { Name = "Student" });
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (context.Users.Any()) return;
            ApplicationUser user = new ApplicationUser
                                       {
                                           Email = "admin@dadaya.co.zw",
                                           SecurityStamp = Guid.NewGuid().ToString(),
                                           UserName = "admin@dadaya.co.zw",
                                           EmailConfirmed = true
                                       };
            await userManager.CreateAsync(user, "Password@123");
            await userManager.AddToRoleAsync(user, "Admin");
            context.GalleryTypes.Add(new GalleryType{Name = "Administration Block"});
            context.SaveChanges();
            context.GalleryTypes.Add(new GalleryType{Name = "Classrooms"});
            context.SaveChanges();
            context.GalleryTypes.Add(new GalleryType{Name = "Dinning Hall"});
            context.SaveChanges();
            context.GalleryTypes.Add(new GalleryType{Name = "Physics Laboratory"});
            context.SaveChanges();
            context.GalleryTypes.Add(new GalleryType{Name = "Chemistry Laboratory" });
            context.SaveChanges();
            context.GalleryTypes.Add(new GalleryType{Name = "Boys Hostels"});
            context.SaveChanges();
            context.GalleryTypes.Add(new GalleryType{Name = "Girls Hostels"});
            context.SaveChanges();
            context.GalleryTypes.Add(new GalleryType{Name = "Poster"});
            context.SaveChanges();
            context.GalleryTypes.Add(new GalleryType{Name = "Computer Science Laboratory" });
            context.SaveChanges();
            context.GalleryTypes.Add(new GalleryType{Name = "Staff Houses"});
            context.SaveChanges();
        }
    }
}
