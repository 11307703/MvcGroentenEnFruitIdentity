using System.ComponentModel.DataAnnotations;

namespace MvcGroentenEnFruit.Models
{
    public class Artikel
    {
        public int ArtikelId { get; set; }
        [Required]
        [StringLength(50)]
        public string ArtikelNaam { get; set; }
        public ICollection<AankoopOrder>? AankoopOrders { get; set; }
        public ICollection<VerkoopOrder>? VerkoopOrders { get; set; }
    }
}

