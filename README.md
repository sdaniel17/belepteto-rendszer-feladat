# S.Z.S Access System

*Fejlesztők - Seres Dániel, Szabó Gergő* 

---

## A program működése 🚀

- A program indításkor megkérdezi hogy mivel jött az illető vagy hogy kíván-e keresni a fájlban.

- Attól függően hogy hogyan jött, kölönböző kérdéseket fog feltenni, ami az illető azonosítására szolgál.

- A kérdésekre adott válaszokat elmenti egy TXT fájlba a belépés idejével együtt.

- Amennyiben keresni kíván a naplóban a felhasználó, a program megkérdezi, hogy mi alapján szeretné tenni azt.

- Miután a felhasználó ezt kiválasztotta és beírta a keresés alapját, a program kilistázza azokat a sorokat amelyekben szerepel az alap.

---

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

| 2026. 11. 08. 21:20:42 | Tóth Tamás | IG-12345678 | HZT-756 | Audi R8
```