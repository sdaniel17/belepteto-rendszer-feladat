Console.WriteLine("Üdvözöljük a rendszerünkben!");
Console.WriteLine("$ S.Z.S Access");


string mivel_jott()
{
    string x = Console.ReadLine();
    while (x != "0" && x != "1" && x != "2" && x != "3" && x != "4")
    {
        Console.WriteLine("Helytelen bemenet! Helyes bemenetek: leállítás -> 0 ; autós rögzítése -> 1 ; gyalogos rögzítése -> 2 ; keresés a naplóban -> 3 ; kilépés rögzítése -> 4");
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

    foreach (string sor in File.ReadLines("tartozkodas.txt"))
    {
        if (sor.Contains(ig_szam))
        { 

            Console.WriteLine("Már tartózkodik egy ilyen igazolványszámú ember az épületben!");
            return new();
        }
    }


        return new List<string>() { nev, ig_szam };
}

List<string> autos_bekeres()
{
    List<string> adatok = gyalogos_belepes();

    if (adatok.Count == 0)
    {
        return new List<string>();
    }

    string nev = adatok[0];
    string ig_szam = adatok[1];

    Console.WriteLine("Írja be autója rendszámát! (Helyes formátumok: AAA-999 ; AA-AA-999)");
    string rendszam = Console.ReadLine();
    while (!rendszam_ellenorzes(rendszam))
    {
        Console.WriteLine("Helytelen rendszám! Helyes formátumok: AAA-999 ; AA-AA-999");
        rendszam = Console.ReadLine();
    }

    foreach (string sor in File.ReadLines("tartozkodas.txt"))
    {
        if (sor.Contains(rendszam))
        {
            Console.WriteLine("Már tartózkodik egy ilyen rendszámú autó az épületben!");
            return new();
        }
    }


    Console.WriteLine("Írja be autója típusát! (Helyes formátum: [Autó márkája] [Autó típusa])");
    string autotipus = Console.ReadLine();

    return new List<string>() { nev, ig_szam, rendszam, autotipus };
}


void file_irasa(List<string> adatok)
{
    try
    {
        if (adatok.Count == 0)
        {
            return;
        }
        else { 

        File.AppendAllText("log.txt", DateTime.Now.ToString());
        foreach (string nev in adatok)
        {
            File.AppendAllText("log.txt", " | " + nev);

        }
        File.AppendAllText("log.txt", "\n");

        File.AppendAllText("tartozkodas.txt", DateTime.Now.ToString());
        foreach (string nev in adatok)
        {
            File.AppendAllText("tartozkodas.txt", " | " + nev);

        }
        File.AppendAllText("tartozkodas.txt", "\n");
        }

        Console.WriteLine("Adatok rögzítve!");
    }
    catch (UnauthorizedAccessException)
    {
        Console.WriteLine("Nincs jogosultság a fájl írásához.");
    }

}

bool log_kereses_dontes_ellenorzes(string dontes)
{
    if (dontes != "0" && dontes != "1" && dontes != "2")
    {
        return false;
    }

    return true;
}
void log_kereses_dontes()
{
    Console.WriteLine("Mi alapján szeretne keresni? (név -> 0 ; igazolvány szám -> 1 ; rendszám -> 2)");
    string dontes = Console.ReadLine();

    while (!log_kereses_dontes_ellenorzes(dontes))
    {
        Console.WriteLine("Helytelen bemenet! Helyes bemenetek: név -> 0 ; igazolvány szám -> 1 ; rendszám -> 2");
        dontes = Console.ReadLine();
    }

    if (dontes == "0")
    {
        Console.WriteLine("Írja be a nevet! Helyes formátum pl.: Lakatos Lóránt");
        string nev = Console.ReadLine();

        while (!nev_ellenorzes(nev))
        {
            Console.WriteLine("Helytelen formátum! Helyes formátum pl.: Lakatos Lóránt");
            nev = Console.ReadLine();
        }
        kereses(nev);
    }
    else if (dontes == "1")
    {
        Console.WriteLine("Írja be az igazolvány számot!");
        string ig_szam = Console.ReadLine();

        while (!ig_szam_ellenorzes(ig_szam))
        {
            Console.WriteLine("Helytelen formátum! Helyes formátum: IG-00000000");
            ig_szam = Console.ReadLine();
        }
        kereses(ig_szam);
    }
    else if (dontes == "2")
    {
        Console.WriteLine("Írja be a rendszámot!");
        string rendszam = Console.ReadLine();

        while (!rendszam_ellenorzes(rendszam))
        {
            Console.WriteLine("Helytelen formátum! Helyes formátumok: AAA-999 ; AA-AA-999");
            rendszam = Console.ReadLine();
        }
        kereses(rendszam);
    }
}


void kereses(string keresesiertek)
{
    bool van = false;
    try
    {
        foreach (string sor in File.ReadLines("log.txt"))
        {

            if (sor.Contains(keresesiertek))
            {
                van = true;
                Console.WriteLine(sor);
            }
        }

        if (van == false)
        {
            Console.WriteLine("Nincs találat!");
        }

    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("A fájl nem található.");
    }
    catch (UnauthorizedAccessException)
    {
        Console.WriteLine("Nincs jogosultság a fájl olvasásához.");
    }

}

bool kilepes_dontes_ellenorzes(string dontes)
{
    if (dontes != "0" && dontes != "1") 
    {
        return false;
    }
    return true;
}
string kilepes_dontes()
{
    Console.WriteLine("Mi alapján szeretné a kilépő személyt azonosítani? (igazolványszám -> 0 ; rendszám -> 1)");
    string dontes = Console.ReadLine();
    while (!kilepes_dontes_ellenorzes(dontes))
    {
        Console.WriteLine("Helytelen bemenet! Helyes bemenetek: igazolványszám -> 0 ; rendszám -> 1");
        dontes = Console.ReadLine();
    }

    if (dontes == "0")
    {
        Console.WriteLine("Írja be az igazolványszámát! (Helyes formátum: IG-00000000");
        string ig_szam = Console.ReadLine();
        while (!ig_szam_ellenorzes(ig_szam))
        {
            Console.WriteLine("Helytelen formátum! Helyes formátum: IG-00000000");
            ig_szam = Console.ReadLine();
        }
        dontes = ig_szam;
    }
    else if (dontes == "1")
    {
        Console.WriteLine("Írja be autója rendszámát! (Helyes formátumok: AAA-999 ; AA-AA-999)");
        string rendszam = Console.ReadLine();
        while (!rendszam_ellenorzes(rendszam))
        {
            Console.WriteLine("Helytelen rendszám! Helyes formátumok: AAA-999 ; AA-AA-999");
            rendszam = Console.ReadLine();
        }
        dontes = rendszam;
    }

    return dontes;
}

void kilepes(string dontes)
{
    bool van = false;

    string[] eredeti_sorok = File.ReadAllLines("tartozkodas.txt");

    List<string> megmaradt_sorok = new();

    foreach (string sor in File.ReadLines("tartozkodas.txt"))
    {
        if (sor.Contains(dontes))
        {
            van = true;
        }
        else
        {
            megmaradt_sorok.Add(sor);
        }
    }

    if (!van)
    {
        Console.WriteLine("Nem tartózkodik ilyen azonosítójú ember az épületben!");
        return;
    }

    File.WriteAllLines("tartozkodas.txt", megmaradt_sorok);

    Console.WriteLine("A kilépés rögzítve!");
}



while (true)
{
    Console.WriteLine("Mit szerene tenni? (leállítás -> 0 ; autós rögzítése -> 1 ; gyalogos rögzítése -> 2 ; keresés a naplóban -> 3 ; kilépés rögzítése -> 4)");
    string mivel_jottel = mivel_jott();
    if (mivel_jottel == "0")
    {
        leallitas();
    }
    else if (mivel_jottel == "2")
    {
        List<string> gyalogos_adatok = gyalogos_belepes();
        file_irasa(gyalogos_adatok);


    }
    else if (mivel_jottel == "1")
    {
        List<string> autos_adatok = autos_bekeres();

        file_irasa(autos_adatok);


    }
    else if (mivel_jottel == "3")
    {
        log_kereses_dontes();
    }
    else if (mivel_jottel == "4")
    {
        kilepes(kilepes_dontes());
    }
}

