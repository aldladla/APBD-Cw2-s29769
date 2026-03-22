namespace Projekt_obiektowy_w_C_s29769;

public class Pracownik : Uzytkownik
{
    public override int LimitWypozyczen => 5;
    
    public Pracownik(string imie, string nazwisko) : base(imie, nazwisko, UzytkownikRola.Pracownik)
    {
        
    }
    
}