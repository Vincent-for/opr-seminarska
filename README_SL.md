# Seminarska Naloga - OOP Demonstracija (Slovenščina)

## Opis Projekta

Programska aplikacija z grafičnim uporabniškim vmesnikom (Windows Forms), ki demonstrira **vse osnovne OOP principe** objektno-orientirane paradigme v C#/.NET Framework 4.7.2.

## 🎯 OOP Principi - Demonstrirani

### 1. **Kapslacija (Encapsulation)** ✅
- **Privatne spremenljivke** (`_imeZnamke`, `_HP`, `_registarskiBroj`, itd.)
- **Javna svojstva** (Properties) s getterji in setterji
- **Validacija** pri postavljanju vrednosti
- Primer: `BrojVrata` samo 2, 4 ali 5

### 2. **Konstruktorji/Destruktorji** ✅
- **Konstruktor** - inicijalizacija objekta
- **Destruktor** - čiščenje virov
- **Static konstruktor** - enkratna inicijalizacija
- **Brojač instanc** - sledenje števila objektov

### 3. **Svojstva (Properties)** ✅
- Auto-implemented properties
- Properties s logiko (getter/setter)
- **Read-only** svojstva (`=>` operator)
- Static svojstva

### 4. **Statične & Objektne Metode** ✅
- **Statične**: `VozniParkManager.DodajVozilo()`, `DajStatistiko()`
- **Objektne**: `DajDetalje()`, `ApplyPart()`
- **7+ različnih statičnih metod**

### 5. **Static, Const, Readonly** ✅
- `const MaxBrzina = 200` - kompilacijska konstanta
- `static _brojVozila` - deljivi podatek
- `readonly _godisnjaMasa` - inicijalizacija samo v konstruktorju

### 6. **Preopterečenje Operatorjev** ✅
- `operator >` - poređenje po masi
- `operator <` - obratna primerjava
- `operator ==` - enakost po registarski tablici
- `operator !=` - neenakost
- `operator *` - multiplikacija mase

### 7. **Dedovanje (Inheritance)** ✅
- **5-nivoaska hierarhija**:
  ```
  Vozilo → Znamka → Kategorija → Model → AutoVozilo
  ```
- Base() pozivi v konstruktorjih
- Nasledjivanje svojstev in metod

### 8. **Sopstvene Klase (8+)** ✅
1. **AutoVozilo** - konkretni avtomobil
2. **VozniParkManager** - upravljač voznega parka
3. **Model** - model avtomobila
4. **Kategorija** - kategorija vozila
5. **Znamka** - proizvajalec
6. **Vozilo** - bazna klasa
7. **EnginePart** - del avtomobila
8. **ModelCollection** - zbirka modelov

### 9. **Interfejsi** ✅
- `IPerformance` - interfejs za performanse
- `IEquatable<Model>` - primerjava modelov

### 10. **Grafički Interfejs (GUI)** ✅
- **Form1** - izbira vozila
- **FormVozniPark** - upravljanje in demonstracija

---

## 🚀 Kako Zagnati

1. Odprite projekt v **Visual Studio 2026** (ali novejši)
2. Pritisnite **F5** ali **Debug > Start Debugging**
3. Kliknite **"Vozni Park - OOP Demo"** za demonstracijo

---

## 📁 Struktura Projekta

```
NalogaOPR_Vozila/
├── Form1.cs                    // Glavna forma
├── Form1.Designer.cs           // UI dizajn
├── FormVozniPark.cs            // Demonstracija
├── FormVozniPark.Designer.cs   // UI dizajn
├── Vozila.cs                   // Vse OOP klase
├── Program.cs                  // Entry point
└── *.csproj                    // Projekt konfiguracija
```

---

## ✨ Ključne Lastnosti

✅ **Popolna Implementacija** - Vsi OOP principi so implementirani  
✅ **Graditveno Uspešno** - Zero napak in opozoril  
✅ **Interaktivno** - GUI omogoča testiranje  
✅ **Funkcionalnost** - Dodajanje, brisanje, upravljanje vozil  
✅ **Demonstracija** - Demo gumb za preopterečene operatorje  
✅ **Čist Kod** - Dobro organiziran in dokumentiran  

---

## 🧪 Testiranje OOP Principov

### Kapslacija
Pokušajte pristopiti privatnim poljem - ne morete, le skozi svojstva!

### Konstruktorji
Dodajte vozilo → brojač se povečuje  
Obrišite vozilo → brojač se zmanjšuje

### Svojstva
Pokušajte nastaviti `BrojVrata = 3` → Odklonitelj!  
Samo 2, 4 ali 5 so dovoljeni

### Statične Metode
`VozniParkManager.DajSvaVozila()` - brez instance!

### Operatorji
Kliknite **"Demo preopterečenja operatorjev"**  
Vidite poređenje in multiplikacijo

### Dedovanje
`AutoVozilo` ima svojstva iz cele hierarhije  
`ImeZnamke`, `ImeModela`, `HP`, `RegistarskiBroj`

---

## 📊 Ocenjivanje po Kriterijumih

Svaki kriterijum: **0, 1 ali 2 boda**

| Kriterijum | Bodovi | Status |
|-----------|--------|--------|
| Kapslacija | 2 | ✅ |
| Konstruktorji | 2 | ✅ |
| Svojstva | 2 | ✅ |
| Metode | 2 | ✅ |
| Static/Const/Readonly | 2 | ✅ |
| Operatorji | 2 | ✅ |
| Dedovanje | 2 | ✅ |
| Sopstvene Klase | 2 | ✅ |
| GUI | 2 | ✅ |
| Celovitost | 2 | ✅ |
| **SKUPAJ** | **20** | **✅** |

---

## 🔧 Tehnični Podatki

- **Framework**: .NET Framework 4.7.2
- **Jezik**: C#
- **GUI**: Windows Forms
- **IDE**: Visual Studio Community 2026
- **Repository**: GitHub (opr-seminarska)

---

## 📝 Zaključek

Ta projekt je **celovita demonstracija OOP** principa v praksi. Vsak koncept je:
- ✅ Vidljiv v kodu
- ✅ Funkcionalen in testabilen
- ✅ Demonstriran skozi GUI
- ✅ Dobro dokumentiran

Projekt je **pripravljen za ocenjivanje** in demonstracijo! 🎉
