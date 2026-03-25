using System;
using Projekt_obiektowy_w_C_s29769;

WypozyczalniaSerwis serwis = new WypozyczalniaSerwis();

Student student = new Student("Jan", "Kowalski");
Pracownik pracownik = new Pracownik("Anna", "Nowak");
serwis.DodajUzytkownika(student);
serwis.DodajUzytkownika(pracownik);

Laptop laptop = new Laptop("Dell XPS", "sprzet biurowy", 15, "Intel i7");
Camera kamera = new Camera("Sony A7", "sprzet foto", 24, "Sony");
Projector projektor = new Projector("Epson X1", "sprzet video", "Epson", 3);
serwis.DodajSprzet(laptop);
serwis.DodajSprzet(kamera);
serwis.DodajSprzet(projektor);

Console.WriteLine("system zainicjowany sprzet i uzytkownicy sa w bazie");

Console.WriteLine("scenariusz 3 poprawne wypozyczenie");
serwis.WypozyczSprzet(student.Id, laptop.Id, 7);
Console.WriteLine("student wypozyczyl laptop na 7 dni");

Console.WriteLine("scenariusz 4 proba wypozyczenia sprzetu zajetego");
try 
{
    serwis.WypozyczSprzet(pracownik.Id, laptop.Id, 3);
}
catch (Exception ex)
{
    Console.WriteLine("blad zgodnie z oczekiwaniem " + ex.Message);
}

Console.WriteLine("scenariusz 4 proba przekroczenia limitu przez studenta");
try
{
    serwis.WypozyczSprzet(student.Id, kamera.Id, 2);
    serwis.WypozyczSprzet(student.Id, projektor.Id, 2);
}
catch (Exception ex)
{
    Console.WriteLine("odmowa limitu " + ex.Message);
}

Console.WriteLine("scenariusz 5 zwrot w terminie");
serwis.ZwrocSprzet(laptop.Id);
Console.WriteLine("laptop zostal zwrocony status sprzetu zmieniony na dostepny");

Console.WriteLine("scenariusz 6 zwrot opozniony");
serwis.WypozyczSprzet(pracownik.Id, projektor.Id, -5); 
decimal kara = serwis.ZwrocSprzet(projektor.Id);
Console.WriteLine("sprzet zwrocony naliczona kara wynosi " + kara + " zlotych");

Console.WriteLine("scenariusz 7 raport koncowy o stanie systemu");
var raport = serwis.PobierzCalySprzet();
foreach (var s in raport)
{
    Console.WriteLine("sprzet " + s.Nazwa + " status " + s.Status);
}