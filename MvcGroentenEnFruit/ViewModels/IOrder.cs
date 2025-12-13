namespace MvcGroentenEnFruit.ViewModels
{
    public interface IOrder
    {
        int ArtikelId { get; set; }
        DateTime Datum { get; set; }
        int Hoeveelheid { get; set; }
    }
}
