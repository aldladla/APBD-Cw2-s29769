namespace Projekt_obiektowy_w_C_s29769;

public class Projector : Sprzet
{
    public string Producent { get; set; }
    public int Waga { get; set; }
    
    public Projector(string nazwa, string daneWspolne, string producent, int waga) 
        : base(nazwa, daneWspolne) 
    {
        this.Producent = producent;
        this.Waga = waga;
    }
    
}