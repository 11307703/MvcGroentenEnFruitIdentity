using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcGroentenEnFruit.Data;
using MvcGroentenEnFruit.ViewModels;

namespace MvcGroentenEnFruit.Components
{
    public class VerkoopViewComponent : ViewComponent
    {
        GFDbContext _context;
        public VerkoopViewComponent(GFDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var artikels = _context
                .VerkoopOrders
                .Include(x=>x.Artikel)
                .OrderByDescending(x=>x.Datum)
                .Select(x=> new VerkoopViewModel
                    {
                        ArtikelId = x.ArtikelId,
                        Naam = x.Artikel.ArtikelNaam,
                        Hoeveelheid = Math.Abs(x.Hoeveelheid)
                    })
                .Take(3);
            return View(artikels);
        }
    }
}


