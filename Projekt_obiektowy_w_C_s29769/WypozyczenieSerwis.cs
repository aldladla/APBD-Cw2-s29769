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
        Uzytkownik znalezionyUzytkownik = null;
        foreach (var u in _uzytkownicy)
        {
            if (u.Id == uzytkownikId)
            {
                znalezionyUzytkownik = u;
            }
        }

        Sprzet znalezionySprzet = null;
        foreach (var s in _sprzet)
        {
            if (s.Id == sprzetId)
            {
                znalezionySprzet = s;
            }
        }

        if (znalezionyUzytkownik == null || znalezionySprzet == null)
        {
            throw new Exception("Nie ma takiego uzytkownika lub sprzetu.");
        }

        if (znalezionySprzet.Status != StatusDostepnosci.Dostepne)
        {
            throw new Exception("Ten sprzet jest aktualnie zajety.");
        }

        int liczbaAktywnych = 0;
        foreach (var w in _wypozyczenia)
        {
            if (w.Wypozyczajacy.Id == uzytkownikId)
            {
                if (w.FaktycznaDataZwrotu == null)
                {
                    liczbaAktywnych++;
                }
            }
        }

        if (liczbaAktywnych >= znalezionyUzytkownik.LimitWypozyczen)
        {
            throw new Exception("Ten uzytkownik ma juz za duzo wypozyczonego sprzetu.");
        }

        Wypozyczenie noweWypozyczenie = new Wypozyczenie(znalezionyUzytkownik, znalezionySprzet, liczbaDni);
        _wypozyczenia.Add(noweWypozyczenie);
        
        znalezionySprzet.Status = StatusDostepnosci.Wypozyczony;
    }

    public void ZwrocSprzet(Guid sprzetId)
    {
        Wypozyczenie doZwrotu = null;
        foreach (var w in _wypozyczenia)
        {
            if (w.WypozyczanySprzet.Id == sprzetId)
            {
                if (w.FaktycznaDataZwrotu == null)
                {
                    doZwrotu = w;
                }
            }
        }

        if (doZwrotu != null)
        {
            doZwrotu.FaktycznaDataZwrotu = DateTime.Now;
            doZwrotu.WypozyczanySprzet.Status = StatusDostepnosci.Dostepne;

            if (doZwrotu.FaktycznaDataZwrotu > doZwrotu.PlanowanaDataZwrotu)
            {
                TimeSpan roznica = (DateTime)doZwrotu.FaktycznaDataZwrotu - doZwrotu.PlanowanaDataZwrotu;
                int dniSpoznienia = roznica.Days;
                
                if (dniSpoznienia > 0)
                {
                    doZwrotu.KaraZaOpoznienie = dniSpoznienia * 10; 
                }
            }
        }
    }

    public void OznaczUszkodzony(Guid sprzetId)
    {
        foreach (var s in _sprzet)
        {
            if (s.Id == sprzetId)
            {
                s.Status = StatusDostepnosci.Niedostepne;
            }
        }
    }

    public List<Sprzet> PobierzCalySprzet()
    {
        return _sprzet;
    }

    public List<Uzytkownik> PobierzWszystkichUzytkownikow()
    {
        return _uzytkownicy;
    }
    
    public List<Sprzet> PobierzDostepnySprzet()
    {
        List<Sprzet> dostepne = new List<Sprzet>();
        foreach (var s in _sprzet)
        {
            if (s.Status == StatusDostepnosci.Dostepne)
            {
                dostepne.Add(s);
            }
        }
        return dostepne;
    }
        
    public List<Wypozyczenie> PobierzAktywneWypozyczenia(Guid uzytkownikId)
    {
        List<Wypozyczenie> aktywne = new List<Wypozyczenie>();
        foreach (var w in _wypozyczenia)
        {
            if (w.Wypozyczajacy.Id == uzytkownikId)
            {
                if (w.FaktycznaDataZwrotu == null)
                {
                    aktywne.Add(w);
                }
            }
        }
        return aktywne;
    }
        
    public List<Wypozyczenie> PobierzPrzeterminowane()
    {
        List<Wypozyczenie> przeterminowane = new List<Wypozyczenie>();
        foreach (var w in _wypozyczenia)
        {
            if (w.FaktycznaDataZwrotu == null)
            {
                if (DateTime.Now > w.PlanowanaDataZwrotu)
                {
                    przeterminowane.Add(w);
                }
            }
        }
        return przeterminowane;
    }
}