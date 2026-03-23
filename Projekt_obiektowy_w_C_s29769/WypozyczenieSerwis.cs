namespace Projekt_obiektowy_w_C_s29769;

public class WypozyczalniaSerwis
{
    private List<Uzytkownik> _uzytkownicy = new List<Uzytkownik>();
    private List<Sprzet> _sprzet = new List<Sprzet>();
    private List<Wypozyczenie> _wypozyczenia = new List<Wypozyczenie>();

    public void DodajUzytkownika(Uzytkownik uzytkownik)
    {
        _uzytkownicy.Add(uzytkownik);
    }

    public void DodajSprzet(Sprzet sprzet)
    {
        _sprzet.Add(sprzet);
    }

    public void WypozyczSprzet(Guid uzytkownikId, Guid sprzetId, int liczbaDni)
    {
        Uzytkownik uzytkownik = null;
        foreach (var u in _uzytkownicy)
        {
            if (u.Id == uzytkownikId)
            {
                uzytkownik = u;
                break;
            }
        }

        Sprzet sprzet = null;
        foreach (var s in _sprzet)
        {
            if (s.Id == sprzetId)
            {
                sprzet = s;
                break;
            }
        }

        if (uzytkownik == null || sprzet == null)
        {
            throw new ArgumentException("Nie znaleziono użytkownika lub sprzetu w systemie");
        }

        if (sprzet.Status != StatusDostepnosci.Dostepne)
        {
            throw new InvalidOperationException("Sprzet nie jest obecnie dostepny do wypozyczenia");
        }

        int liczbaAktywnychWypozyczen = 0;
        foreach (var w in _wypozyczenia)
        {
            if (w.Wypozyczajacy.Id == uzytkownik.Id && w.FaktycznaDataZwrotu == null)
            {
                liczbaAktywnychWypozyczen++;
            }
        }

        if (liczbaAktywnychWypozyczen >= uzytkownik.LimitWypozyczen)
        {
            throw new InvalidOperationException($"Użytkownik osiagnal swoj limit ({uzytkownik.LimitWypozyczen}) aktywnych wypozyczen");
        }

        var noweWypozyczenie = new Wypozyczenie(uzytkownik, sprzet, liczbaDni);
        _wypozyczenia.Add(noweWypozyczenie);
        
        sprzet.Status = StatusDostepnosci.Wypozyczony;
    }
}