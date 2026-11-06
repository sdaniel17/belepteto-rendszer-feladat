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

List<string> gyalogos_belepes()
{
    Console.WriteLine("Írja be a nevét!");
    string nev = Console.ReadLine();
    Console.WriteLine();

    Console.WriteLine("Írja be az igazolványszámát! (Helyes formátum: IG-00000000)");
    string ig_szam = Console.ReadLine();

        while (ig_szam.Length != 11 || ig_szam[0] != 'I' || ig_szam[1] != 'G' || ig_szam[2] != '-')
        {
            
            Console.WriteLine("Helytelen formátum! Helyes formátum: IG-00000000");
            ig_szam = Console.ReadLine();

            string ig_szam_szamok = ig_szam.Remove(0, 3);


            string szamok = "1234567890";

            foreach (char x in ig_szam_szamok)
            {
                while (! szamok.Contains(x) || ig_szam_szamok.Length != 8)
                {
                    Console.WriteLine("Helytelen formátum! Az IG- utáni 8 számot írja be újra");
                    ig_szam_szamok = Console.ReadLine();
                }
            }

            string ig_szam_checkelt = "IG-" + ig_szam_szamok;

            List<string> vege = new() {nev, ig_szam_checkelt};

            return vege;
        }
        List<string> vege_jo = new() { nev, ig_szam };
        return vege_jo;
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