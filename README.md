# S.Z.S Access System

*Fejlesztők - Seres Dániel, Szabó Gergő* 

---

## A program működése 🚀


- Indításkor öt opció közül lehet választani: gyalogos beléptetése, autós beléptetése, keresés a naplóban, kilépés rögzítése, valamint a program leállítása.

- A kiválasztott belépési mód alapján bekéri a szükséges azonosító adatokat. Ha a személy vagy jármű már bent tartózkodik, nem rögzíthető újra.

- A sikeres belépést a pontos időponttal együtt elmenti a log.txt-be (tényleges napló) és a tartozkodas.txt-be (aktuálisan bent lévők) fájlokba.

- Naplókeresésnél a választott szempont és keresőszó alapján kilistázza az egyező bejegyzéseket a log.txt fájlból (ha nincs találat, külön jelzi).

- Kilépés rögzítésénél törli az illetőt a tartozkodas.txt nyilvántartásból, de a log.txt megőrzi a belépés előzményét.

- A program szigorúan ellenőrzi a bevitt adatokat. Hibás formátum megadása esetén hibaüzenetet jelenít meg, és mindaddig újra kéri az adatot, amíg az nem felel meg a formátumnak.
---

## Használati útmutató ✅

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

Mit szerene tenni? (leállítás -> 0 ; autós rögzítése -> 1 ; gyalogos rögzítése -> 2 ; keresés a naplóban -> 3 ; kilépés rögzítése -> 4)

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
Mit szerene tenni? (leállítás -> 0 ; autós rögzítése -> 1 ; gyalogos rögzítése -> 2 ; keresés a naplóban -> 3 ; kilépés rögzítése -> 4)

| 3

Mi alapján szeretne keresni? (név -> 0 ; igazolvány szám -> 1 ; rendszám -> 2)

| 1

Írja be az igazolvány számot!

| IG-12345678

2026. 11. 08. 21:20:42 | Tóth Tamás | IG-12345678 | HZT-756 | Audi R8
```

## Példa kilépés rögzítésére ❌

```bash
Mit szerene tenni? (leállítás -> 0 ; autós rögzítése -> 1 ; gyalogos rögzítése -> 2 ; keresés a naplóban -> 3 ; kilépés rögzítése -> 4)

| 4

Mi alapján szeretné a kilépő személyt azonosítani? (igazolványszám -> 0 ; rendszám -> 1)

| 0

Írja be az igazolványszámát! (Helyes formátum: IG-00000000)

| IG-12345678

A kilépés rögzítve!
```