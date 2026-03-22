namespace Projekt_obiektowy_w_C_s29769;

public enum UzytkownikRola 
{
    Student,
    Pracownik
}

public abstract class Uzytkownik
{
    public Guid Id { get; private set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public UzytkownikRola Rola { get; set; } 
    public abstract int LimitWypozyczen { get; }
    
    public Uzytkownik(string imie, string nazwisko, UzytkownikRola rola)
    {
        this.Id = Guid.NewGuid();
        this.Imie = imie;
        this.Nazwisko = nazwisko;
        this.Rola = rola;
    }
}