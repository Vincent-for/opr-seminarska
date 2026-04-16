using System;
using System.Collections.Generic;
using System.Linq;

namespace NalogaOPR_Vozila
{
    /// <summary>Interfejs za performanse vozila</summary>
    public interface IPerformance
    {
        int GetPerformanceBoost();
    }

    /// <summary>Interfejs za poređenje vozila</summary>
    public interface IVoziloComparable : IComparable<Vozilo>
    {
        int CompareTo(Vozilo other);
    }

    /// <summary>Interfejs za pristup elementima kolekcije</summary>
    public interface IVoziloKolekcija
    {
        int Count { get; }
        Vozilo this[int index] { get; set; }
        void Add(Vozilo vozilo);
        void Remove(Vozilo vozilo);
    }

    /// <summary>Abstraktna klasa za delove vozila</summary>
    public abstract class AutoPart
    {
        /// <summary>Masa dela</summary>
        public abstract int Weight { get; }

        /// <summary>Uticaj na HP motora</summary>
        public abstract int AffectHP(Model m);

        /// <summary>Virtualna metoda - može biti override-ovana</summary>
        public virtual string GetDescription()
        {
            return $"Auto Part - Weight: {Weight}";
        }
    }

    /// <summary>Motorni deo - polimorfna implementacija</summary>
    public class EnginePart : AutoPart
    {
        private readonly int _boost;

        public EnginePart(int boost)
        {
            _boost = boost;
        }

        public override int Weight
        {
            get { return 150; }
        }

        public override int AffectHP(Model m)
        {
            return _boost;
        }

        /// <summary>Override virtualne metode iz bazne klase</summary>
        public override string GetDescription()
        {
            return $"Engine Part - Boost: +{_boost} HP, Weight: {Weight}g";
        }
    }

    /// <summary>Suspenzijski deo - dodatna polimorfna klasa</summary>
    public class SuspensionPart : AutoPart
    {
        private readonly int _gripBoost;

        public SuspensionPart(int gripBoost)
        {
            _gripBoost = gripBoost;
        }

        public override int Weight
        {
            get { return 200; }
        }

        public override int AffectHP(Model m)
        {
            return 0; // Suspenzija ne povećava HP
        }

        /// <summary>Polimorfna virtuelna metoda</summary>
        public override string GetDescription()
        {
            return $"Suspension Part - Grip: +{_gripBoost}%, Weight: {Weight}g";
        }
    }

    /// <summary>Brejk deo - tre će polimorfna klasa</summary>
    public class BrakePart : AutoPart
    {
        private readonly int _brakePower;

        public BrakePart(int brakePower)
        {
            _brakePower = brakePower;
        }

        public override int Weight
        {
            get { return 100; }
        }

        public override int AffectHP(Model m)
        {
            return -10; // Brejkovi smanjuju performanse
        }

        /// <summary>Polimorfna virtuelna metoda</summary>
        public override string GetDescription()
        {
            return $"Brake Part - Power: {_brakePower}%, Weight: {Weight}g";
        }
    }

    /// <summary>Bazna klasa za sva vozila - sa virtualnim metodama za polimorfizem</summary>
    public class Vozilo : IVoziloComparable
    {
        public const string DefaultTip = "Avto";
        private string _tip;

        public string Tip
        {
            get { return _tip; }
            protected set { _tip = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        public Vozilo(string tip)
        {
            Tip = tip;
        }

        /// <summary>Virtualna metoda - može biti override-ovana u nasledjenim klasama</summary>
        public virtual string Opis()
        {
            return $"Vozilo tipa: {Tip}";
        }

        /// <summary>Virtualna metoda za poređenje</summary>
        public virtual int CompareTo(Vozilo other)
        {
            if (other == null) return 1;
            return Tip.CompareTo(other.Tip);
        }

        /// <summary>Virtualna metoda za prikaz karakteristika</summary>
        public virtual void PrikaziKarakteristike()
        {
            System.Diagnostics.Debug.WriteLine($"Tip: {Tip}");
        }
    }

    /// <summary>Klasa Znamka - override-uje virtuelne metode</summary>
    public class Znamka : Vozilo
    {
        private string _imeZnamke;

        public string ImeZnamke
        {
            get { return _imeZnamke; }
            protected set { _imeZnamke = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        public Znamka(string tip, string imeZnamke) : base(tip)
        {
            ImeZnamke = imeZnamke;
        }

        /// <summary>Override virtuelne metode iz Vozilo</summary>
        public override string Opis()
        {
            return $"Znamka: {ImeZnamke}, Tip: {Tip}";
        }

        /// <summary>Override poređenja - po imenu znamke</summary>
        public override int CompareTo(Vozilo other)
        {
            if (other is Znamka otherZnamka)
                return ImeZnamke.CompareTo(otherZnamka.ImeZnamke);
            return base.CompareTo(other);
        }

        /// <summary>Override prikaza karakteristika</summary>
        public override void PrikaziKarakteristike()
        {
            System.Diagnostics.Debug.WriteLine($"Znamka: {ImeZnamke}, Tip: {Tip}");
        }
    }

    /// <summary>Klasa Kategorija - override-uje virtuelne metode</summary>
    public class Kategorija : Znamka
    {
        private string _imeKategorije;

        public string ImeKategorije
        {
            get { return _imeKategorije; }
            protected set { _imeKategorije = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        public Kategorija(string tip, string imeZnamke, string imeKategorije) 
            : base(tip, imeZnamke)
        {
            ImeKategorije = imeKategorije;
        }

        /// <summary>Override virtuelne metode</summary>
        public override string Opis()
        {
            return $"Kategorija: {ImeKategorije}, Znamka: {ImeZnamke}, Tip: {Tip}";
        }

        /// <summary>Override poređenja - po kategoriji</summary>
        public override int CompareTo(Vozilo other)
        {
            if (other is Kategorija otherKat)
                return ImeKategorije.CompareTo(otherKat.ImeKategorije);
            return base.CompareTo(other);
        }

        /// <summary>Override prikaza karakteristika</summary>
        public override void PrikaziKarakteristike()
        {
            System.Diagnostics.Debug.WriteLine($"Kategorija: {ImeKategorije}, Znamka: {ImeZnamke}");
        }
    }

    /// <summary>Klasa Model - sa polimorfizmom, indeksatorima i interfejsima</summary>
    public class Model : Kategorija, IEquatable<Model>, IPerformance
    {
        private string _imeModela;
        private int _hp;
        private List<AutoPart> _parts = new List<AutoPart>();

        public string ImeModela
        {
            get { return _imeModela; }
            protected set { _imeModela = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        public int HP
        {
            get { return _hp; }
            protected set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                _hp = value;
            }
        }

        public Model(string tip, string imeZnamke, string imeKategorije, string imeModela, int hp) 
            : base(tip, imeZnamke, imeKategorije)
        {
            ImeModela = imeModela;
            HP = hp;
        }

        ~Model()
        {
        }

        /// <summary>INDEKSATOR - pristup delovima po indeksu</summary>
        public AutoPart this[int index]
        {
            get
            {
                if (index < 0 || index >= _parts.Count)
                    throw new IndexOutOfRangeException("Deo sa ovim indeksom ne postoji!");
                return _parts[index];
            }
            set
            {
                if (index < 0 || index >= _parts.Count)
                    throw new IndexOutOfRangeException("Deo sa ovim indeksom ne postoji!");
                _parts[index] = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        /// <summary>INDEKSATOR - pristup svojstvima po imena</summary>
        public string this[string propertyName]
        {
            get
            {
                if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));

                switch (propertyName.ToLower())
                {
                    case "imemodela": return ImeModela;
                    case "imeznamke": return ImeZnamke;
                    case "imekateogorije": return ImeKategorije;
                    case "hp": return HP.ToString();
                    case "tip": return Tip;
                    default: throw new ArgumentException($"Nepoznato svojstvo: {propertyName}");
                }
            }
        }

        /// <summary>Broj delova na vozilu</summary>
        public int BrojDelova => _parts.Count;

        /// <summary>POLIMORFIZEM - Override virtuelne metode iz Vozilo</summary>
        public override string Opis()
        {
            return $"Model: {ImeModela} | Znamka: {ImeZnamke} | Kategorija: {ImeKategorije} | HP: {HP} | Delova: {BrojDelova}";
        }

        /// <summary>Override virtuelne metode za poređenje</summary>
        public override int CompareTo(Vozilo other)
        {
            if (other is Model otherModel)
                return HP.CompareTo(otherModel.HP);
            return base.CompareTo(other);
        }

        /// <summary>Override virtuelne metode za prikaz karakteristika</summary>
        public override void PrikaziKarakteristike()
        {
            System.Diagnostics.Debug.WriteLine(
                $"Model: {ImeModela}, Znamka: {ImeZnamke}, Kategorija: {ImeKategorije}, HP: {HP}, Delova: {BrojDelova}");
        }

        /// <summary>Dodaj deo na vozilo</summary>
        public void ApplyPart(AutoPart part)
        {
            if (part == null) throw new ArgumentNullException(nameof(part));
            int boost = part.AffectHP(this);
            HP = HP + boost;
            _parts.Add(part);
        }

        /// <summary>Implementacija interfejsa IPerformance</summary>
        public int GetPerformanceBoost()
        {
            return HP + _parts.Sum(p => p.Weight);
        }

        /// <summary>Dobij opis svih delova</summary>
        public string GetPartsDescription()
        {
            if (_parts.Count == 0) return "Nema instaliranih delova";
            return string.Join(", ", _parts.Select(p => p.GetDescription()));
        }

        public static bool operator >(Model a, Model b)
        {
            if (ReferenceEquals(a, null)) return false;
            if (ReferenceEquals(b, null)) return true;
            return a.HP > b.HP;
        }

        public static bool operator <(Model a, Model b)
        {
            if (ReferenceEquals(a, null)) return !ReferenceEquals(b, null);
            if (ReferenceEquals(b, null)) return false;
            return a.HP < b.HP;
        }

        public static bool operator ==(Model a, Model b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.Equals(b);
        }

        public static bool operator !=(Model a, Model b)
        {
            return !(a == b);
        }

        public bool Equals(Model other)
        {
            if (ReferenceEquals(other, null)) return false;
            return string.Equals(ImeModela, other.ImeModela, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(ImeZnamke, other.ImeZnamke, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(ImeKategorije, other.ImeKategorije, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Model);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (ImeModela ?? "").ToLowerInvariant().GetHashCode();
                hash = hash * 23 + (ImeZnamke ?? "").ToLowerInvariant().GetHashCode();
                hash = hash * 23 + (ImeKategorije ?? "").ToLowerInvariant().GetHashCode();
                return hash;
            }
        }
    }

    /// <summary>
    /// AutoVozilo - konkretna klasa sa svim OOP principima
    /// POLIMORFIZEM - nasledjuje Model i override-uje virtuelne metode
    /// INDEKSATORI - pristup svojstvima
    /// INTERFEJSI - implementira IVoziloKolekcija
    /// </summary>
    public class AutoVozilo : Model, IVoziloKolekcija
    {
        private string _registarskiBroj;
        private int _brojVrata;
        private int _zapremina;
        private readonly int _godisnjaMasa;
        private List<Vozilo> _listaVozila = new List<Vozilo>();

        public string RegistarskiBroj
        {
            get { return _registarskiBroj; }
            set { _registarskiBroj = value; }
        }

        public int BrojVrata
        {
            get { return _brojVrata; }
            set
            {
                if (value == 2 || value == 4 || value == 5)
                    _brojVrata = value;
            }
        }

        public int Zapremina
        {
            get { return _zapremina; }
            set { if (value > 0) _zapremina = value; }
        }

        public int GodisnjaMasa => _godisnjaMasa;

        public AutoVozilo(string tip, string imeZnamke, string imeKategorije, 
                         string imeModela, int hp, string registarskiBroj, 
                         int brojVrata, int zapremina, int masa)
            : base(tip, imeZnamke, imeKategorije, imeModela, hp)
        {
            RegistarskiBroj = registarskiBroj;
            BrojVrata = brojVrata;
            Zapremina = zapremina;
            _godisnjaMasa = masa;
        }

        /// <summary>INDEKSATOR - pristup vozilima iz kolekcije</summary>
        public Vozilo this[int index]
        {
            get
            {
                if (index < 0 || index >= _listaVozila.Count)
                    throw new IndexOutOfRangeException("Vozilo sa ovim indeksom ne postoji!");
                return _listaVozila[index];
            }
            set
            {
                if (index < 0 || index >= _listaVozila.Count)
                    throw new IndexOutOfRangeException("Vozilo sa ovim indeksom ne postoji!");
                _listaVozila[index] = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        /// <summary>Broj vozila u kolekciji - interfejs IVoziloKolekcija</summary>
        public int Count => _listaVozila.Count;

        /// <summary>Dodaj vozilo - interfejs IVoziloKolekcija</summary>
        public void Add(Vozilo vozilo)
        {
            if (vozilo == null) throw new ArgumentNullException(nameof(vozilo));
            _listaVozila.Add(vozilo);
        }

        /// <summary>Ukloni vozilo - interfejs IVoziloKolekcija</summary>
        public void Remove(Vozilo vozilo)
        {
            if (vozilo == null) throw new ArgumentNullException(nameof(vozilo));
            _listaVozila.Remove(vozilo);
        }

        /// <summary>POLIMORFIZEM - Override virtuelne metode iz Model</summary>
        public override string Opis()
        {
            return $"Auto: {ImeZnamke} {ImeModela} ({RegistarskiBroj})\n" +
                   $"Masa: {GodisnjaMasa}kg | Motor: {Zapremina}cc | Vrata: {BrojVrata}\n" +
                   $"HP: {HP}";
        }

        /// <summary>Override virtuelne metode za prikaz karakteristika</summary>
        public override void PrikaziKarakteristike()
        {
            System.Diagnostics.Debug.WriteLine(
                $"AutoVozilo: {ImeZnamke} {ImeModela}, Registar: {RegistarskiBroj}, " +
                $"Masa: {GodisnjaMasa}kg, Zapremina: {Zapremina}cc, Vrata: {BrojVrata}, HP: {HP}");
        }

        /// <summary>POLIMORFIZEM - Override poređenja</summary>
        public override int CompareTo(Vozilo other)
        {
            if (other is AutoVozilo otherAuto)
                return GodisnjaMasa.CompareTo(otherAuto.GodisnjaMasa);
            return base.CompareTo(other);
        }

        /// <summary>Statička metoda - validacija registarske tablice</summary>
        public static bool JeValidanRegistarskiBroj(string broj)
        {
            return !string.IsNullOrEmpty(broj) && broj.Length >= 3;
        }

        /// <summary>Preopterečeni operatori za AutoVozilo</summary>
        public static bool operator >(AutoVozilo a1, AutoVozilo a2)
        {
            if (a1 == null || a2 == null) return false;
            return a1.GodisnjaMasa > a2.GodisnjaMasa;
        }

        public static bool operator <(AutoVozilo a1, AutoVozilo a2)
        {
            if (a1 == null || a2 == null) return false;
            return a1.GodisnjaMasa < a2.GodisnjaMasa;
        }

        public static bool operator ==(AutoVozilo a1, AutoVozilo a2)
        {
            if (ReferenceEquals(a1, a2)) return true;
            if (a1 is null || a2 is null) return false;
            return a1.RegistarskiBroj == a2.RegistarskiBroj;
        }

        public static bool operator !=(AutoVozilo a1, AutoVozilo a2)
        {
            return !(a1 == a2);
        }

        public static AutoVozilo operator *(AutoVozilo auto, double faktor)
        {
            if (auto == null) return null;
            return new AutoVozilo(auto.Tip, auto.ImeZnamke, auto.ImeKategorije, 
                                 auto.ImeModela, auto.HP, auto.RegistarskiBroj,
                                 auto.BrojVrata, auto.Zapremina,
                                 (int)(auto.GodisnjaMasa * faktor));
        }

        public override bool Equals(object obj)
        {
            return obj is AutoVozilo auto && this == auto;
        }

        public override int GetHashCode()
        {
            return RegistarskiBroj?.GetHashCode() ?? 0;
        }
    }

    /// <summary>Kolekcija modela sa indeksatorima</summary>
    public class ModelCollection
    {
        private readonly Model[] _items;

        public ModelCollection(Model[] items)
        {
            _items = items;
        }

        public int Count
        {
            get
            {
                if (_items == null)
                {
                    return 0;
                }
                return _items.Length;
            }
        }
        public Model this[int index]
        {
            get
            {
                if (index < 0 || index >= _items.Length)
                {
                    return null;
                }
                return _items[index];
            }
        }
    }

    public delegate void ModelSelectedHandler(Model model);

    public static class SkupinaAvtov
    {
        private static readonly string[] _znamke = { "BMW", "Audi", "Volkswagen" };
        private static readonly string[] _kategorije = { "Sport", "SUV", "Limo" };
        private static readonly Model[] AllModels =
        {
            new Model(Vozilo.DefaultTip, "BMW", "Sport", "M3", 473),
            new Model(Vozilo.DefaultTip, "BMW", "SUV", "X5", 335),
            new Model(Vozilo.DefaultTip, "BMW", "Limo", "5 Series", 248),
            new Model(Vozilo.DefaultTip, "Audi", "Sport", "R8", 562),
            new Model(Vozilo.DefaultTip, "Audi", "SUV", "Q7", 335),
            new Model(Vozilo.DefaultTip, "Audi", "Limo", "A6", 248),
            new Model(Vozilo.DefaultTip, "Volkswagen", "Sport", "GTI", 228),
            new Model(Vozilo.DefaultTip, "Volkswagen", "SUV", "Tiguan", 184),
            new Model(Vozilo.DefaultTip, "Volkswagen", "Limo", "Passat", 174)
        };
        private static readonly string[] EmptyStrings = new string[0];
        public static event ModelSelectedHandler ModelSelected;
        public static string[] Vozila()
        {
            return new[] { Vozilo.DefaultTip };
        }
        public static string[] Znamke()
        {
            return (string[])_znamke.Clone();
        }
        public static string[] Kategorije()
        {
            return (string[])_kategorije.Clone();
        }
        public static string[] Modeli(string znamka, string kategorija)
        {
            if (string.IsNullOrEmpty(znamka) || string.IsNullOrEmpty(kategorija))
            {
                return EmptyStrings;
            }
            return AllModels.Where(m => string.Equals(m.ImeZnamke, znamka, StringComparison.OrdinalIgnoreCase) && string.Equals(m.ImeKategorije, kategorija, StringComparison.OrdinalIgnoreCase)).Select(m => m.ImeModela).Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
        }
        public static Model Model(string imeModela, string znamka, string kategorija)
        {
            return AllModels.FirstOrDefault(m => string.Equals(m.ImeModela, imeModela, StringComparison.OrdinalIgnoreCase) && string.Equals(m.ImeZnamke, znamka, StringComparison.OrdinalIgnoreCase) && string.Equals(m.ImeKategorije, kategorija, StringComparison.OrdinalIgnoreCase));
        }
        public static Model UstvariModel(string znamka, string kategorija, string imeModela, int hp)
        {
            return new Model(Vozilo.DefaultTip, znamka, kategorija, imeModela, hp);
        }
        public static ModelCollection GetAllModels()
        {
            return new ModelCollection(AllModels);
        }
        public static void RaiseModelSelected(Model model)
        {
            ModelSelectedHandler handler = ModelSelected;
            if (handler != null)
            {
                handler(model);
            }
        }
    }
}