namespace Projekt_obiektowy_w_C_s29769;

public class Laptop : Sprzet
{
    public int Rozmiar { get; set; }
    public string Procesor { get; set; }
    
    
    public Laptop(string nazwa, string daneWspolne, int rozmiar, string procesor) 
        : base(nazwa, daneWspolne) 
    {
        this.Rozmiar = rozmiar;
        this.Procesor = procesor;
    }
}