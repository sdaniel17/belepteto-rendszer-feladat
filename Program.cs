Console.WriteLine("Üdvözöljük a rendszerünkben!");
Console.WriteLine("$ S.Z.S Access");


string mivel_jott()
{
    string x = Console.ReadLine();
    while (x!="0" && x!="1" && x != "2")
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

List<string> gyalogos_belepes()
{
    Console.WriteLine("Írja be a nevét!");
    string nev = Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("Írja be az igazolványszámát! (Helyes formátum: IG-00000000)");
    string ig_szam = Console.ReadLine();

    while (ig_szam.Length != 11 || ig_szam[0] !='I' || ig_szam[1] != 'G' || ig_szam[2] != '-')
    {
        Console.WriteLine("Helytelen formátum! Helyes formátum: IG-00000000");
        ig_szam = Console.ReadLine();

        string ig_szam_szamok = ig_szam.Remove(0, 3);
        foreach (char x in ig_szam)
        {

        }
        
    }

    return new();

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
        gyalogos_belepes();
    }
    

}