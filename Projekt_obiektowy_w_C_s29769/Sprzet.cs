namespace Projekt_obiektowy_w_C_s29769;

public enum StatusDostepnosci
{
    Dostepne,
    Wypozyczony,
    Niedostepne
}

public abstract class Sprzet
{
    
    public Guid Id { get; private set; }
    public string Nazwa { get; set; } 
    public StatusDostepnosci Status { get; set; }
    public string DaneWspolne{ get; set; }
    
    public Sprzet(string nazwa, string daneWspolne)
    {
        this.Id = Guid.NewGuid();
        this.Nazwa = nazwa;
        this.Status = StatusDostepnosci.Dostepne;
        this.DaneWspolne = daneWspolne;
    }
}