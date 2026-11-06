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

    if (! (ig_szam[0] == 'I' && ig_szam[1] == 'G' && ig_szam[2] == '-') )
    {
        return false;
    }
    
    for (int i = 3; i < ig_szam.Length; i++)
    {
        if (! char.IsDigit(ig_szam[i])){
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

    return new List<string>() {nev,ig_szam};
}


while (true)
{
    Console.WriteLine("Hogyan érkezett? (leállítás -> 0 ; autó -> 1 ; gyalog -> 2)");
    string mivel_jottel = mivel_jott();
    if (mivel_jottel == "0")
    {
        leallitas();
    }
    else if (mivel_jottel == "1")
    {
        List<string> xxx = gyalogos_belepes();
        Console.WriteLine(xxx[0]);
        Console.WriteLine(xxx[1]);

    }

}
