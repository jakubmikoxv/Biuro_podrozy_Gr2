using Biuro_Podróży.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


var HotelList = new List<Hotel>
    {
        new Hotel() { Name = "Cancun Bay Resort", Country = "Meksyk", Prize = 450m, Rating = 4 },
        new Hotel() { Name = "Iberostar Quetzal", Country = "Meksyk", Prize = 690m, Rating = 5 },
        new Hotel() { Name = "Imperial Laguna by Faranda", Country = "Meksyk", Prize = 320m, Rating = 3 },
        new Hotel() { Name = "Playacalida", Country = "Hiszpania", Prize = 600m, Rating = 5 },
        new Hotel() { Name = "Palia Puerto del Sol", Country = "Hiszpania", Prize = 240m, Rating = 3 },
        new Hotel() { Name = "Playa Real Resort", Country = "Hiszpania", Prize = 380m, Rating = 4 },
        new Hotel() { Name = "Sea Gull", Country = "Egipt", Prize = 270m, Rating = 3 },
        new Hotel() { Name = "Continental Hurghada", Country = "Egipt", Prize = 360m, Rating = 4 },
        new Hotel() { Name = "Sharm Grand Plaza", Country = "Egipt", Prize = 620m, Rating = 5 },
        new Hotel() { Name = "Ikaros Hotel", Country = "Grecja", Prize = 220m, Rating = 3 },
        new Hotel() { Name = "Labranda Sandy Beach Resort", Country = "Grecja", Prize = 580m, Rating = 5 },
        new Hotel() { Name = "Lida Corfu", Country = "Grecja", Prize = 310m, Rating = 4 },
        new Hotel() { Name = "Mytt Beach Hotel", Country = "Tajlandia", Prize = 720m, Rating = 5 },
        new Hotel() { Name = "Novotel Rayong", Country = "Tajlandia", Prize = 410m, Rating = 4 },
        new Hotel() { Name = "Cholchan Pattaya Resort", Country = "Tajlandia", Prize = 290m, Rating = 3 }

    };


//Losowanie ofert (nie 3 takie same)(różne kontynenty)

var rnd = new Random();
var wybranePanstwa = new List<String>();
var WybraneHotele = new List<Hotel>();
do
{
    int losowaliczba = rnd.Next(HotelList.Count);
    var wylosowanyhotel = HotelList[losowaliczba];
    if (!WybraneHotele.Contains(wylosowanyhotel) && !wybranePanstwa.Contains(wylosowanyhotel.Country))
    {
        WybraneHotele.Add(wylosowanyhotel);
        wybranePanstwa.Add(wylosowanyhotel.Country);
    }
    
    if (WybraneHotele.Contains(wylosowanyhotel))
    {
      
    }
    else if (wybranePanstwa.Contains(wylosowanyhotel.Country))
    {
     
    }
    else {
        WybraneHotele.Add(wylosowanyhotel);
        wybranePanstwa.Add(wylosowanyhotel.Country);
      
    }
} while (WybraneHotele.Count < 3);



//Losowanie rodzaju oferty i długości pobytu (2 all inclusive (+1200), 1 nie)(7, 10, 14 dni)

int i = 0;
int dni(int i)
{
    if (i == 0)
    {
        return 7;
    }
    else if (i == 1)
    {
        return 10;
    }
    else
    {
        return 14;
    }
}

string wyżywienie;
int allinclusive(int i)
{
    if (i == 0)
    {
        return 0;
    }
    else if (i == 1)
    {
        return 1200;
    }
    else
    {
        return 1200;
    }
}
Console.WriteLine("Dzisiejsze promowane oferty");
int cenalotu(string Country)
{
    if (Country == "Meksyk")
    {
        return 2500;
    }
    else if (Country == "Egipt")
    {
        return 1500;
    }
    else if (Country == "Hiszpania" || Country == "Grecja")
    {
        return 1000;
    }
    else
    {
        return 2000;
    }
}
string gwiazdki(int Rating)
{
    if (Rating == 3)
    {
        return "***";
    }
    else if (Rating == 4)
    {
        return "****";
    }
    else
    {
        return "*****";
    }
}
do
{
    WybraneHotele[i].FullPrize = WybraneHotele[i].Prize * dni(i) + allinclusive(i) + cenalotu(WybraneHotele[i].Country);
    i++;
} while (i < 3);
IEnumerable<Hotel> SortowaneHotele = WybraneHotele.OrderBy(hotel => hotel.FullPrize);
i = 0;
do
{
    
    if (i == 0)
    {
        wyżywienie = "śniadanie";
    }
    else if (i == 1)
    {
        wyżywienie = "all inclusive";
    }
    else
    {
        wyżywienie = "all inclusive";
    }

    var cena = WybraneHotele[i].Prize * dni(i) + allinclusive(i) + cenalotu(WybraneHotele[i].Country);

    Console.WriteLine("-------------------------------------");
    Console.WriteLine($"Numer: {i+1}");
    Console.WriteLine($"Kraj: {WybraneHotele[i].Country}");
    var dzieńpoczątku = new DateTime(2022, 6, 15);
    var tydzień = dzieńpoczątku.AddDays(dni(i));
    Console.WriteLine($"Termin: {dzieńpoczątku.ToShortDateString()} - {tydzień.ToShortDateString()} ( { dni(i)} dni )");
    Console.WriteLine($"Hotel:{WybraneHotele[i].Name} {gwiazdki(WybraneHotele[i].Rating)}");
    Console.WriteLine($"Wyżywienie: {wyżywienie}");
    Console.WriteLine($"Cena {cena} PLN/os");
    i++;
} while (i < 3);

//Ekran powitalny (wyświetla 3 oferty od najtańszej)
Console.WriteLine("-------------------------------------");
Console.WriteLine("Proszę podać numer wybranej oferty:");

//wybór oferty
var któraoferta = Console.ReadLine();
int numeroferty;
bool czytekst = int.TryParse(któraoferta, out numeroferty);
Console.Clear();
//czy poprawna odpowiedź
while (czytekst == false)
{
    Console.Clear();
    Console.WriteLine("Nie wpisano cyfry");
    Console.WriteLine("Proszę podać numer wybranej oferty:");
    któraoferta = Console.ReadLine();
    czytekst = int.TryParse(któraoferta, out numeroferty);
}
while (numeroferty > 3 || numeroferty < 1)
{
    Console.Clear();
    Console.WriteLine("Wpisano złą odpowiedź");
    Console.WriteLine("Proszę podać numer wybranej oferty:");
    któraoferta = Console.ReadLine();
    czytekst = int.TryParse(któraoferta, out numeroferty);
}
//wprowadzenie ilości dorosłych (nie 0)
Console.WriteLine("Proszę podać ilość osób dorosłych:");
var ilośćdorosłych = Console.ReadLine();
int liczbadorosłych;
// czy poprawna...
czytekst = int.TryParse(ilośćdorosłych, out liczbadorosłych);
while (czytekst == false)
{
    Console.Clear();
    Console.WriteLine("Nie wpisano cyfry");
    Console.WriteLine("Proszę podać ilość osób dorosłych:");
    ilośćdorosłych = Console.ReadLine();
    czytekst = int.TryParse(ilośćdorosłych, out liczbadorosłych);
}
while (liczbadorosłych < 1)
{
    Console.Clear();
    Console.WriteLine("Wpisano niepoprawną liczbę");
    Console.WriteLine("Proszę podać ilość osób dorosłych:");
    ilośćdorosłych = Console.ReadLine();
    czytekst = int.TryParse(ilośćdorosłych, out liczbadorosłych);
}
Console.Clear();
//wprowadzenie ilości dzieci
Console.WriteLine("Proszę podać ilość dzieci:");
var ilośćdzieci = Console.ReadLine();
int liczbadzieci;
//czy poprawna...
czytekst = int.TryParse(ilośćdzieci, out liczbadzieci);
while (czytekst == false)
{
    Console.Clear();
    Console.WriteLine("Nie wpisano cyfry");
    Console.WriteLine("Proszę podać ilość dzieci:");
    ilośćdzieci = Console.ReadLine();
    czytekst = int.TryParse(ilośćdzieci, out liczbadzieci);
}
while (liczbadzieci < 0)
{
    Console.Clear();
    Console.WriteLine("Wpisano ujemną liczbę");
    Console.WriteLine("Proszę podać ilość dzieci:");
    ilośćdzieci = Console.ReadLine();
    czytekst = int.TryParse(ilośćdzieci, out liczbadzieci);
}
//obliczenie i wyświetlenie ceny
numeroferty = numeroferty - 1;
var cenaostateczna = cenalotu(WybraneHotele[numeroferty].Country) + WybraneHotele[numeroferty].Prize * dni(numeroferty) + allinclusive(numeroferty);
var całkowitykoszt = cenaostateczna * liczbadorosłych + cenaostateczna / 2 * liczbadzieci;
Console.Clear();
Console.WriteLine($"Cena: {całkowitykoszt}");