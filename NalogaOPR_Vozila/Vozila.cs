using System;
using System.Linq;

namespace NalogaOPR_Vozila
{
    public class Vozilo
    {
        public string Tip { get; set; }
    }

    public class Znamka : Vozilo
    {
        public string ImeZnamke { get; set; }
    }

    public class Kategorija : Znamka
    {
        public string ImeKategorije { get; set; }
    }

    public class Model : Kategorija
    {
        public string ImeModela { get; set; }
        public int HP { get; set; }
    }

    public static class SkupinaAvtov
    {
        public static string[] Vozila()
        {
            return new[] { "Avto" };
        }

        public static string[] Znamke()
        {
            return new[] { "BMW", "Audi", "Volkswagen" };
        }

        public static string[] Kategorije()
        {
            return new[] { "Sport", "SUV", "Limo" };
        }

        private static readonly Model[] VsiModeli = new[]
        {
            new Model { Tip = "Avto", ImeZnamke = "BMW", ImeKategorije = "Sport", ImeModela = "M3", HP = 473 },
            new Model { Tip = "Avto", ImeZnamke = "BMW", ImeKategorije = "SUV",   ImeModela = "X5", HP = 335 },
            new Model { Tip = "Avto", ImeZnamke = "BMW", ImeKategorije = "Limo",  ImeModela = "5 Series", HP = 248 },

            new Model { Tip = "Avto", ImeZnamke = "Audi", ImeKategorije = "Sport", ImeModela = "R8", HP = 562 },
            new Model { Tip = "Avto", ImeZnamke = "Audi", ImeKategorije = "SUV",   ImeModela = "Q7", HP = 335 },
            new Model { Tip = "Avto", ImeZnamke = "Audi", ImeKategorije = "Limo",  ImeModela = "A6", HP = 248 },

            new Model { Tip = "Avto", ImeZnamke = "Volkswagen", ImeKategorije = "Sport", ImeModela = "GTI", HP = 228 },
            new Model { Tip = "Avto", ImeZnamke = "Volkswagen", ImeKategorije = "SUV",   ImeModela = "Tiguan", HP = 184 },
            new Model { Tip = "Avto", ImeZnamke = "Volkswagen", ImeKategorije = "Limo",  ImeModela = "Passat", HP = 174 },
        };

        private static readonly string[] EmptyStrings = new string[0];

        public static string[] Modeli(string znamka, string kategorija)
        {
            if (string.IsNullOrEmpty(znamka) || string.IsNullOrEmpty(kategorija))
                return EmptyStrings;

            return VsiModeli
                .Where(m => string.Equals(m.ImeZnamke, znamka, StringComparison.OrdinalIgnoreCase)
                         && string.Equals(m.ImeKategorije, kategorija, StringComparison.OrdinalIgnoreCase))
                .Select(m => m.ImeModela)
                .Distinct()
                .ToArray();
        }

        public static Model Model(string modelName, string znamka, string kategorija)
        {
            return VsiModeli.FirstOrDefault(m =>
                string.Equals(m.ImeModela, modelName, StringComparison.OrdinalIgnoreCase)
                && string.Equals(m.ImeZnamke, znamka, StringComparison.OrdinalIgnoreCase)
                && string.Equals(m.ImeKategorije, kategorija, StringComparison.OrdinalIgnoreCase));
        }
    }
}