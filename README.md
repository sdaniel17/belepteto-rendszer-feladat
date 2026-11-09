# S.Z.S Access System

*Fejlesztők - Seres Dániel, Szabó Gergő* 

---

## A program működése 🚀


- Indításkor öt opció közül lehet választani: gyalogos beléptetése, autós beléptetése, keresés a naplóban, kilépés rögzítése, valamint a program leállítása.

- A gyalogos vagy autós rögzítése kiválasztása után attól függően hogy hogyan jött, kölönböző kérdéseket fog feltenni, ami az illető azonosítására szolgál.

- A kérdésekre adott válaszokat elmenti egy log.txt fájlba a belépés idejével együtt. Ezeket elmenti egy tartozkodas.txt-be is, amelynek az a feladata hogy nyilvántartsa az épületben tartózkodókat. Hogyha egy személyt kilépés nélkül szeretnénk rögzíteni úgy hogy már rögzítve van, a program nem fogja engedni.

- Amennyiben keresni kíván a naplóban a felhasználó, a program megkérdezi, hogy mi alapján szeretné tenni azt.

- A keresési szempont és a kifejezés megadása után a program megjeleníti az összes találatot. Hogyha nem talált a naplóban egyezést, kiírja hogy nincs találat!

- A programban elérhető egy "kilépés rögzítése" opció, amelyet akkor kell használni, ha egy személy elhagyja az épületet. Ez a log.txt-ből nem törli ki a bejegyzést, csak a tartozkodas.txt nyilvántartásból.
---

## Használati útmutató

Az alkalmazás indításakor az alábbi 5 menüpont közül lehet választani a megfelelő szám beírásával.

| Menüpont | Művelet | Leírás |
| :---: | :--- | :--- |
| **`0`** | **Leállítás** | Kilépés a programból. |
| **`1`** | **Autós rögzítése** | Gépjárművel érkező személy beléptetése. |
| **`2`** | **Gyalogos rögzítése** | Gyalogosan érkező személy beléptetése. |
| **`3`** | **Keresés a naplóban** | Keresés a `log.txt` eseménynaplóban. |
| **`4`** | **Kilépés rögzítése** | Bent tartózkodó személy vagy jármű távozásának rögzítése. |



## Példa rögzítésre 🚚

```bash
Üdvözöljük a rendszerünkben!
$ S.Z.S Access

Mit szerene tenni? (leállítás -> 0 ; autós rögzítése -> 1 ; gyalogos rögzítése -> 2 ; keresés a naplóban -> 3)

| 1 

Írja be a nevét!

| Tóth Tamás

Írja be az igazolványszámát! (Helyes formátum: IG-00000000)

| IG-12345678

Írja be autója rendszámát! (Helyes formátumok: AAA-999 ; AA-AA-999)

| HZT-756

Írja be autója típusát! (Helyes formátum: [Autó márkája] [Autó típusa])

| Audi R8


Adatok rögzítve!
```

## Példa keresésre 🔍

```bash
Mit szerene tenni? (leállítás -> 0 ; autós rögzítése -> 1 ; gyalogos rögzítése -> 2 ; keresés a naplóban -> 3)

| 3

Mi alapján szeretne keresni? (név -> 0 ; igazolvány szám -> 1 ; rendszám -> 2)

| 1

Írja be az igazolvány számot!

| IG-12345678

2026. 11. 08. 21:20:42 | Tóth Tamás | IG-12345678 | HZT-756 | Audi R8
```
