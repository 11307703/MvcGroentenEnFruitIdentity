using MvcGroentenEnFruit.ViewModels;

namespace MvcGroentenEnFruit.Models
{
    public class VerkoopOrder : IOrder
    {
        public int VerkoopOrderId { get; set; }
        public int ArtikelId { get; set; }
        public DateTime Datum { get; set; }
        public int Hoeveelheid { get; set; }
        public Artikel? Artikel { get; set; }
    }
}
