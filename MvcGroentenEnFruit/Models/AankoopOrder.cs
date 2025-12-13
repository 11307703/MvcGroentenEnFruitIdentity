using MvcGroentenEnFruit.Models;
using MvcGroentenEnFruit.ViewModels;

namespace MvcGroentenEnFruit.Models
{
    public class AankoopOrder : IOrder
    {
        public int AankoopOrderId { get; set; }
        public int ArtikelId { get; set; }
        public DateTime Datum { get; set; }
        public int Hoeveelheid { get; set; }
        public Artikel? Artikel { get; set; }
    }
}

