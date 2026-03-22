namespace Projekt_obiektowy_w_C_s29769;

public class Student : Uzytkownik
{
    public override int LimitWypozyczen => 2;

    public Student(string imie, string nazwisko) : base(imie, nazwisko, UzytkownikRola.Student)
    {

        
    }
}