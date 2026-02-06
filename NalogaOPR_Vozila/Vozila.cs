using System;
using System.Linq;

namespace NalogaOPR_Vozila
{
    // Base class with encapsulation, const and constructor
    public class Vozilo
    {
        public const string DefaultTip = "Avto"; // constant

        private string _tip;
        public string Tip
        {
            get => _tip;
            protected set => _tip = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Vozilo(string tip = DefaultTip)
        {
            Tip = tip;
        }
    }

    // Znamka inherits from Vozilo; shows protected setter (encapsulation) and constructor chaining
    public class Znamka : Vozilo
    {
        private string _imeZnamke;
        public string ImeZnamke
        {
            get => _imeZnamke;
            protected set => _imeZnamke = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Znamka(string tip, string imeZnamke) : base(tip)
        {
            ImeZnamke = imeZnamke;
        }
    }

    // Kategorija inherits from Znamka
    public class Kategorija : Znamka
    {
        private string _imeKategorije;
        public string ImeKategorije
        {
            get => _imeKategorije;
            protected set => _imeKategorije = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Kategorija(string tip, string imeZnamke, string imeKategorije)
            : base(tip, imeZnamke)
        {
            ImeKategorije = imeKategorije;
        }
    }

    // Model inherits from Kategorija; demonstrates properties, constructor, destructor, instance methods and operator overloads
    public class Model : Kategorija, IEquatable<Model>
    {
        private string _imeModela;
        private int _hp;

        public string ImeModela
        {
            get => _imeModela;
            protected set => _imeModela = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int HP
        {
            get => _hp;
            protected set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "HP ne more biti negativen");
                _hp = value;
            }
        }

        // constructor
        public Model(string tip, string imeZnamke, string imeKategorije, string imeModela, int hp)
            : base(tip, imeZnamke, imeKategorije)
        {
            ImeModela = imeModela;
            HP = hp;
        }

        // finalizer (destructor) - rarely needed, shown for demonstration only
        ~Model()
        {
            // No unmanaged resources here; avoid heavy operations.
        }

        // instance method
        public string Opis()
        {
            return $"Model: {ImeModela} | Znamka: {ImeZnamke} | Kategorija: {ImeKategorije} | HP: {HP}";
        }

        // operator overloading (compare by HP)
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

        // equality operators
        public static bool operator ==(Model a, Model b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.Equals(b);
        }

        public static bool operator !=(Model a, Model b) => !(a == b);

        public bool Equals(Model other)
        {
            if (ReferenceEquals(other, null)) return false;
            return string.Equals(ImeModela, other.ImeModela, StringComparison.OrdinalIgnoreCase)
                && string.Equals(ImeZnamke, other.ImeZnamke, StringComparison.OrdinalIgnoreCase)
                && string.Equals(ImeKategorije, other.ImeKategorije, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj) => Equals(obj as Model);

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

    // Repository / factory showing static data (readonly), static methods and a static factory method
    public static class SkupinaAvtov
    {
        // static readonly (initialized once)
        private static readonly string[] _znamke = { "BMW", "Audi", "Volkswagen" };
        private static readonly string[] _kategorije = { "Sport", "SUV", "Limo" };

        // static readonly dataset of models
        private static readonly Model[] AllModels =
        {
            new Model(Vozilo.DefaultTip, "BMW", "Sport", "M3", 473),
            new Model(Vozilo.DefaultTip, "BMW", "SUV",   "X5", 335),
            new Model(Vozilo.DefaultTip, "BMW", "Limo",  "5 Series", 248),

            new Model(Vozilo.DefaultTip, "Audi", "Sport", "R8", 562),
            new Model(Vozilo.DefaultTip, "Audi", "SUV",   "Q7", 335),
            new Model(Vozilo.DefaultTip, "Audi", "Limo",  "A6", 248),

            new Model(Vozilo.DefaultTip, "Volkswagen", "Sport", "GTI", 228),
            new Model(Vozilo.DefaultTip, "Volkswagen", "SUV",   "Tiguan", 184),
            new Model(Vozilo.DefaultTip, "Volkswagen", "Limo",  "Passat", 174),
        };

        private static readonly string[] EmptyStrings = new string[0];

        // static methods used by the UI (return clones where appropriate)
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
                return EmptyStrings;

            return AllModels
                .Where(m => string.Equals(m.ImeZnamke, znamka, StringComparison.OrdinalIgnoreCase)
                         && string.Equals(m.ImeKategorije, kategorija, StringComparison.OrdinalIgnoreCase))
                .Select(m => m.ImeModela)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();
        }

        public static Model Model(string imeModela, string znamka, string kategorija)
        {
            return AllModels.FirstOrDefault(m =>
                string.Equals(m.ImeModela, imeModela, StringComparison.OrdinalIgnoreCase)
                && string.Equals(m.ImeZnamke, znamka, StringComparison.OrdinalIgnoreCase)
                && string.Equals(m.ImeKategorije, kategorija, StringComparison.OrdinalIgnoreCase));
        }

        // static factory to create ad-hoc model instances (object method example would be Model.Opis())
        public static Model UstvariModel(string znamka, string kategorija, string imeModela, int hp)
        {
            return new Model(Vozilo.DefaultTip, znamka, kategorija, imeModela, hp);
        }
    }
}