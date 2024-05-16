using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models
{
    public static class IdentitySeedData
    {
        // Eklenecek temel kullanıcının belirlenmesi
        private const string adminUser = "Admin";
        private const string adminPassword = "123456";
        //IApplicationbuilder özelliği taşıyan bir app gönderen metod yaratılır
        public static async void IdentityTestUser(IApplicationBuilder app)
        {

            //önce context oluştur
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityContext>();
            // Eğer migrations update yapılmamışsa update yap
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //eklenecek kullanıcının varlığı kontrol et yoksa ekle, varsa ekleme
            //user çağırılır
            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(adminUser);
            //eğer user dizisinde adminUser yoksa yarat.
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = adminUser,
                    PhoneNumber = "5327624795",
                    Email = "uozalp.uo@gmail.com"
                };
                // yaratma satırı
                await userManager.CreateAsync(user, adminPassword);
            }


        }



    }
}