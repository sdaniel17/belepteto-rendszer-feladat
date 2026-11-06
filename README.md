# S.Z.S Access System

*Fejlesztők - Seres Dániel, Szabó Gergő*

---

## A program működése 🚀

- A program indításkor megkérdezi hogy gyalog vagy autóval jött az illető.

- Attól függően hogy hogyan jött, kölönböző kérdéseket fog feltenni, ami az illető azonosítására szolgál.

- A kérdésekre adott válaszokat elmenti egy CSV fájlba a belépés idejével együtt.

---

## Példa bemenet 🚚

```bash
Üdvözöljük a rendszerünkben!
$ S.Z.S Access

Hogyan érkezett? (leállítás -> 0 ; autó -> 1 ; gyalog -> 2)

| 1 

Írja be a nevét!

| Tóth Tamás

Írja be az igazolványszámát! (Helyes formátum: IG-00000000)

| IG-01100101

Írja be autója rendszámát! (Helyes formátumok: AAA-999 ; AA-AA-999)

| HZT-756

Írja be autója típusát! (Helyes formátum: [Autó márkája] [Autó típusa])

| Audi R8


Adatok rögzítve!
```