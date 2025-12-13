namespace MvcGroentenEnFruit.ViewModels
{
    public class StockViewModel
    {
        public int ArtikelId { get; set; }
        public string Artikel { get; set; }
        public int Aankopen { get; set; }
        public int Verkopen { get; set; }
        public int Stock => Aankopen+Verkopen;
    }
}
