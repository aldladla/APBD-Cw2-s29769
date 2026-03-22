namespace Projekt_obiektowy_w_C_s29769;

public class Wypozyczenie
{
    public Guid Id { get; private set; }
    public Uzytkownik Wypozyczajacy { get; set; }
    public Sprzet WypozyczanySprzet { get; set; }
    public DateTime DataWypozyczenia { get; set; }
    public DateTime PlanowanaDataZwrotu { get; set; } 
    public DateTime? FaktycznaDataZwrotu { get; set; } 
    public decimal KaraZaOpoznienie { get; set; } 
    
    public Wypozyczenie(Uzytkownik wypozyczajacy, Sprzet sprzet, int liczbaDni)
    {
        this.Id = Guid.NewGuid();
        this.Wypozyczajacy = wypozyczajacy;
        this.WypozyczanySprzet = sprzet;
        this.DataWypozyczenia = DateTime.Now;
        this.PlanowanaDataZwrotu = DateTime.Now.AddDays(liczbaDni);
    }
}