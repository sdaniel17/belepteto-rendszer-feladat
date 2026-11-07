Console.WriteLine("Üdvözöljük a rendszerünkben!");
Console.WriteLine("$ S.Z.S Access");


string mivel_jott()
{
    string x = Console.ReadLine();
    while (x != "0" && x != "1" && x != "2")
    {
        Console.WriteLine("Helytelen bemenet! Helyes bemenetek: leállítás -> 0 ; autó -> 1 ; gyalog -> 2");
        x = Console.ReadLine();
    }
    return x;
}



void leallitas()
{
    Environment.Exit(0);
}

bool ig_szam_ellenorzes(string ig_szam)
{
    if (ig_szam == "" || ig_szam.Length != 11)
    {
        return false;
    }

    if (!(ig_szam[0] == 'I' && ig_szam[1] == 'G' && ig_szam[2] == '-'))
    {
        return false;
    }

    for (int i = 3; i < ig_szam.Length; i++)
    {
        if (!char.IsDigit(ig_szam[i]))
        {
            return false;
        }
    }

    return true;
}

bool nev_ellenorzes(string nev)
{
    if (nev == "")
    {
        return false;
    }

    foreach (char c in nev)
    {
        if (char.IsDigit(c))
        {
            return false;
        }
    }

    return true;
}

bool rendszam_ellenorzes(string rendszam)
{
    if (rendszam == null)
        return false;

    rendszam = rendszam.ToUpper();


    if (rendszam.Length == 7 &&
        char.IsLetter(rendszam[0]) &&
        char.IsLetter(rendszam[1]) &&
        char.IsLetter(rendszam[2]) &&
        rendszam[3] == '-' &&
        char.IsDigit(rendszam[4]) &&
        char.IsDigit(rendszam[5]) &&
        char.IsDigit(rendszam[6]))
    {
        return true;
    }


    if (rendszam.Length == 9 &&
        char.IsLetter(rendszam[0]) &&
        char.IsLetter(rendszam[1]) &&
        rendszam[2] == '-' &&
        char.IsLetter(rendszam[3]) &&
        char.IsLetter(rendszam[4]) &&
        rendszam[5] == '-' &&
        char.IsDigit(rendszam[6]) &&
        char.IsDigit(rendszam[7]) &&
        char.IsDigit(rendszam[8]))
    {
        return true;
    }

    return false;
}




List<string> gyalogos_belepes()
{
    Console.WriteLine("Írja be a nevét! Helyes formátum pl.: Lakatos Lóránt");
    string nev = Console.ReadLine();

    while (!nev_ellenorzes(nev))
    {
        Console.WriteLine("Helytelen formátum! Helyes formátum pl.: Lakatos Lóránt");
        nev = Console.ReadLine();
    }

    Console.WriteLine();

    Console.WriteLine("Írja be az igazolványszámát! (Helyes formátum: IG-00000000)");
    string ig_szam = Console.ReadLine();

    while (!ig_szam_ellenorzes(ig_szam))
    {
        Console.WriteLine("Helytelen formátum! Helyes formátum: IG-00000000");
        ig_szam = Console.ReadLine();
    }

    return new List<string>() { nev, ig_szam };
}

List<string> autos_bekeres()
{
    List<string> adatok = gyalogos_belepes();
    string nev = adatok[0];
    string ig_szam = adatok[1];
    Console.WriteLine("Írja be autója rendszámát! (Helyes formátumok: AAA-999 ; AA-AA-999)");
    string rendszam = Console.ReadLine();
    while (!rendszam_ellenorzes(rendszam))
    {
        Console.WriteLine("Helytelen rendszám! Helyes formátumok: AAA-999 ; AA-AA-999");
        rendszam = Console.ReadLine();
    }


    Console.WriteLine("Írja be autója típusát! (Helyes formátum: [Autó márkája] [Autó típusa])");
    string autotipus = Console.ReadLine();

    return new List<string>() { nev, ig_szam, rendszam, autotipus };
}


void file_irasa(List<string> adatok)
{
    if (File.Exists("log.txt"))
    {
        File.AppendAllText("log.txt", DateTime.Now.ToString());
        foreach (string nev in adatok)
        {
            File.AppendAllText("log.txt", " | " + nev);

        }
        File.AppendAllText("log.txt", "\n");
    }
    else
    {
        using StreamWriter iro = new("log.txt");
        File.AppendAllText("log.txt", DateTime.Now.ToString());
        foreach (string nev in adatok)
        {

            File.AppendAllText("log.txt", " | " + nev);

        }
        File.AppendAllText("log.txt", "\n");
    }


}





while (true)
{
    Console.WriteLine("Hogyan érkezett? (leállítás -> 0 ; autó -> 1 ; gyalog -> 2)");
    string mivel_jottel = mivel_jott();
    if (mivel_jottel == "0")
    {
        leallitas();
    }
    else if (mivel_jottel == "2")
    {
        List<string> gyalogos_adatok = gyalogos_belepes();
        file_irasa(gyalogos_adatok);
        Console.WriteLine("Adatok rögzítve!");


    }
    else if (mivel_jottel == "1")
    {
        List<string> autos_adatok = autos_bekeres();

        file_irasa(autos_adatok);
        Console.WriteLine("Adatok rögzítve!");
        
    }


}
