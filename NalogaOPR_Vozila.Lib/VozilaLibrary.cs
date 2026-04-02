using System;
using System.Linq;

namespace VozilaLibrary
{
    public class Vozilo
    {
        public const string DefaultTip = "Avto";
        private string _tip;
        public string Tip
        {
            get { return _tip; }
            protected set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                _tip = value;
            }
        }
        public Vozilo(string tip)
        {
            Tip = tip;
        }
    }

    public class Znamka : Vozilo
    {
        private string _imeZnamke;
        public string ImeZnamke
        {
            get { return _imeZnamke; }
            protected set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                _imeZnamke = value;
            }
        }
        public Znamka(string tip, string imeZnamke) : base(tip)
        {
            ImeZnamke = imeZnamke;
        }
    }

    public class Kategorija : Znamka
    {
        private string _imeKategorije;
        public string ImeKategorije
        {
            get { return _imeKategorije; }
            protected set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                _imeKategorije = value;
            }
        }
        public Kategorija(string tip, string imeZnamke, string imeKategorije) : base(tip, imeZnamke)
        {
            ImeKategorije = imeKategorije;
        }
    }

    public class Model : Kategorija, IEquatable<Model>
    {
        private string _imeModela;
        private int _hp;
        public string ImeModela
        {
            get { return _imeModela; }
            protected set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                _imeModela = value;
            }
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
        public Model(string tip, string imeZnamke, string imeKategorije, string imeModela, int hp) : base(tip, imeZnamke, imeKategorije)
        {
            ImeModela = imeModela;
            HP = hp;
        }
        ~Model()
        {
        }
        public string Opis()
        {
            return "Model: " + ImeModela + " | Znamka: " + ImeZnamke + " | Kategorija: " + ImeKategorije + " | HP: " + HP;
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
            return string.Equals(ImeModela, other.ImeModela, StringComparison.OrdinalIgnoreCase)
                && string.Equals(ImeZnamke, other.ImeZnamke, StringComparison.OrdinalIgnoreCase)
                && string.Equals(ImeKategorije, other.ImeKategorije, StringComparison.OrdinalIgnoreCase);
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
            if (string.IsNullOrEmpty(znamka) || string.IsNullOrEmpty(kategorija)) return EmptyStrings;
            return AllModels.Where(m => string.Equals(m.ImeZnamke, znamka, StringComparison.OrdinalIgnoreCase) && string.Equals(m.ImeKategorije, kategorija, StringComparison.OrdinalIgnoreCase)).Select(m => m.ImeModela).Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
        }
        public static Model Model(string imeModela, string znamka, string kategorija)
        {
            return AllModels.FirstOrDefault(m => string.Equals(m.ImeModela, imeModela, StringComparison.OrdinalIgnoreCase) && string.Equals(m.ImeZnamke, znamka, StringComparison.OrdinalIgnoreCase) && string.Equals(m.ImeKategorije, kategorija, StringComparison.OrdinalIgnoreCase));
        }
    }
}