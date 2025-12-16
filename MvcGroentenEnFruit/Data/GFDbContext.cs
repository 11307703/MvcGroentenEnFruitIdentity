using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcGroentenEnFruit.Models;
using System.Collections.Generic;
using MvcGroentenEnFruit.ViewModels.Identity;

namespace MvcGroentenEnFruit.Data
{
    public class GFDbContext : IdentityDbContext
    {
        public GFDbContext(DbContextOptions<GFDbContext> options) : base(options)
        {
        }
        public DbSet<Artikel> Artikels { get; set; }
        public DbSet<AankoopOrder> AankoopOrders { get; set; }
        public DbSet<VerkoopOrder> VerkoopOrders { get; set; }
        public DbSet<MvcGroentenEnFruit.ViewModels.Identity.RegisterViewModel> RegisterViewModel { get; set; } = default!;
        public DbSet<MvcGroentenEnFruit.ViewModels.Identity.LoginViewModel> LoginViewModel { get; set; } = default!;
        public DbSet<MvcGroentenEnFruit.ViewModels.Identity.RoleViewModel> RoleViewModel { get; set; } = default!;
        public DbSet<MvcGroentenEnFruit.ViewModels.Identity.UserRoleViewModel> UserRoleViewModel { get; set; } = default!;
    }
}

