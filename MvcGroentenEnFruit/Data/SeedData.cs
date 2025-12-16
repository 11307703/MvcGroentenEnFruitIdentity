using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcGroentenEnFruit.Models;
using MvcGroentenEnFruit.ViewModels;
using System.Threading.Tasks;

namespace MvcGroentenEnFruit.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(WebApplication app)
        {
            try
            {
                using (var scope = app.Services.CreateScope())
                {                
                    var context = scope.ServiceProvider.GetRequiredService<GFDbContext>();
                    var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    if(context.Database.CanConnect())
                    {
                        string _artSla = "Ijsberg sla";
                        string _artTomaat = "Roma tomaat";
                        string _artWortel = "Wortel";
                        if (!context.Artikels.Any())
                        {
                            var sla = new Artikel();
                            sla.ArtikelNaam = _artSla;
                            context.Artikels.Add(sla);
                            var tomaat = new Artikel();
                            tomaat.ArtikelNaam = _artTomaat;
                            context.Artikels.Add(tomaat);
                            var wortel = new Artikel() ;
                            wortel.ArtikelNaam = _artWortel;
                            context.Artikels.Add(wortel);
                            context.SaveChanges();

                        }
                        if (!context.AankoopOrders.Any() && !context.VerkoopOrders.Any())
                        {
                            var sla = context.Artikels.Where(x => x.ArtikelNaam == _artSla).FirstOrDefault();
                            if (sla != null)
                            {
                                var ak1 = new AankoopOrder();
                                ak1.ArtikelId = sla.ArtikelId;
                                ak1.Hoeveelheid = 5;
                                ak1.Datum = DateTime.Now.AddDays(-2);
                                context.AankoopOrders.Add(ak1);
                                var vk1 = new VerkoopOrder();
                                vk1.ArtikelId = sla.ArtikelId;
                                vk1.Hoeveelheid = -4;
                                vk1.Datum = DateTime.Now.AddDays(-1);
                                context.VerkoopOrders.Add(vk1);
                            }
                            var tomaat = context.Artikels.Where(x => x.ArtikelNaam == _artTomaat).FirstOrDefault();
                            if (tomaat != null)
                            {
                                var ak2 = new AankoopOrder();
                                ak2.ArtikelId = tomaat.ArtikelId;
                                ak2.Hoeveelheid = 6;
                                ak2.Datum = DateTime.Now.AddDays(-2);
                                context.AankoopOrders.Add(ak2);
                                var vk2 = new VerkoopOrder();
                                vk2.ArtikelId = tomaat.ArtikelId;
                                vk2.Hoeveelheid = -4;
                                vk2.Datum = DateTime.Now.AddDays(-1);
                                context.VerkoopOrders.Add(vk2);
                            }
                            var wortel = context.Artikels.Where(x => x.ArtikelNaam == _artWortel).FirstOrDefault();
                            if (wortel != null)
                            {
                                var ak3 = new AankoopOrder();
                                ak3.ArtikelId = wortel.ArtikelId;
                                ak3.Hoeveelheid = 7;
                                ak3.Datum = DateTime.Now.AddDays(-2);
                                context.AankoopOrders.Add(ak3);
                                var vk3 = new VerkoopOrder();
                                vk3.ArtikelId = wortel.ArtikelId;
                                vk3.Hoeveelheid = -4;
                                vk3.Datum = DateTime.Now.AddDays(-1);
                                context.VerkoopOrders.Add(vk3);
                            }
                            context.SaveChanges();
                        }
                        AddIdentityRole(scope);

                    }
                    else
                    { 
                        context.Database.Migrate();
                    }  
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }   
        
        private static async Task AddIdentityRole(IServiceScope scope)
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var identityRole = new IdentityRole(RolesData.RoleAdmin);
            var result = await roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                AddIdentityUser(userManager);
            }
        }

        private static async Task AddIdentityUser(UserManager<IdentityUser> userManager)
        {
            var userName = RolesData.RoleAdmin;
            var email = "admin@pxl.be";
            var password = "Admin9999!";
            var user = new IdentityUser(userName);
            user.Email = email;
            var result = await userManager.CreateAsync(user,password);

            if (result.Succeeded)
            {
                result = await userManager.AddToRoleAsync(user,RolesData.RoleAdmin);
            }
        }

    }
}
