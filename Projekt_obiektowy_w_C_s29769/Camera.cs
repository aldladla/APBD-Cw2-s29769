namespace Projekt_obiektowy_w_C_s29769;

public class Camera : Sprzet
{
    public int Resolution { get; set; }
    public string Producent { get; set; }
    
    public Camera(string nazwa, string daneWspolne, int resolution,string producent) : base(nazwa, daneWspolne)
    {
        this.Resolution = resolution;
        this.Producent = producent;
    }
    
}