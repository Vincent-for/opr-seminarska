using System;
using System.Windows.Forms;

namespace NalogaOPR_Vozila
{
    /// <summary>
    /// Obrazec za demonstracijo OOP principov
    /// Prikazuje upravljanje voznega parka z vsemi funkcionalnostmi
    /// </summary>
    public partial class FormVozniPark : Form
    {
        /// <summary>Izbrano vozilo v listi</summary>
        private AutoVozilo _izbranVozilo = null;

        /// <summary>Konstruktor obrazca</summary>
        public FormVozniPark()
        {
            InitializeComponent();
        }

        /// <summary>Nalaganje obrazca - inicijalizacija podatkov</summary>
        private void FormVozniPark_Load(object sender, EventArgs e)
        {
            OsveziSeznam();
            OsveziStatistiko();
        }

        /// <summary>Osvežitev seznama vozil iz upravljalnika</summary>
        private void OsveziSeznam()
        {
            listBoxVozila.Items.Clear();
            foreach (var vozilo in VozniParkManager.DajSvaVozila())
            {
                listBoxVozila.Items.Add($"{vozilo.ImeZnamke} {vozilo.ImeModela} ({vozilo.RegistarskiBroj})");
            }
        }

        /// <summary>Osvežitev statističnih podatkov o voznem parku</summary>
        private void OsveziStatistiko()
        {
            textBoxStatistika.Text = VozniParkManager.DajStatistiko();
            labelBrojVozila.Text = $"Skupaj vozil: {VozniParkManager.BrojVozilaUParku}";
            labelUkupnaMasa.Text = $"Skupna masa: {VozniParkManager.UkupnaMasaSvihVozila()}kg";
        }

        private void listBoxVozila_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxVozila.SelectedIndex >= 0)
            {
                var vozila = VozniParkManager.DajSvaVozila();
                if (listBoxVozila.SelectedIndex < vozila.Count)
                {
                    _izbranVozilo = vozila[listBoxVozila.SelectedIndex];
                    PrikuziDetalje();
                }
            }
        }

        /// <summary>Prikazuje podrobnosti izbranoga vozila</summary>
        private void PrikuziDetalje()
        {
            if (_izbranVozilo != null)
            {
                textBoxDetalji.Text = _izbranVozilo.DajDetalje();
                labelMaksimalnaBrzina.Text = $"Največja hitrost: {AutoVozilo.MaxBrzina}km/h";
            }
        }

        /// <summary>Hitrost vozila povečanje</summary>
        private void buttonUbrzaj_Click(object sender, EventArgs e)
        {
            if (_izbranVozilo != null)
            {
                int prirastaj = (int)numericUpDownBrzina.Value;
                _izbranVozilo.ApplyPart(new EnginePart(prirastaj));
                PrikuziDetalje();
            }
        }

        /// <summary>Hitrost vozila zmanjšanje</summary>
        private void buttonUspora_Click(object sender, EventArgs e)
        {
            if (_izbranVozilo != null)
            {
                int smanjenje = (int)numericUpDownBrzina.Value;
                int noviHP = _izbranVozilo.HP - smanjenje;
                if (noviHP >= 0)
                {
                    MessageBox.Show($"Trenutna moč: {_izbranVozilo.HP}. Moguče je samo povečati!", 
                                   "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>Dodajanje novega vozila v vozni park</summary>
        private void buttonDodajVozilo_Click(object sender, EventArgs e)
        {
            // Validacija vstopa
            if (string.IsNullOrWhiteSpace(textBoxMarka.Text) ||
                string.IsNullOrWhiteSpace(textBoxRegistar.Text) ||
                !int.TryParse(textBoxMasa.Text, out int masa) ||
                !int.TryParse(textBoxZapremina.Text, out int zapremina))
            {
                MessageBox.Show("Izpolnite vsa polja pravilno!", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validacija registrske tablice
            if (!AutoVozilo.JeValidanRegistarskiBroj(textBoxRegistar.Text))
            {
                MessageBox.Show("Registrska tablica mora vsebovati najmanj 3 znake!", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int brojVrata = (int)numericUpDownVrata.Value;
            AutoVozilo novo = new AutoVozilo(
                Vozilo.DefaultTip,
                textBoxMarka.Text,
                "Ostalo",
                "Model",
                150,
                textBoxRegistar.Text,
                brojVrata,
                zapremina,
                masa
            );

            VozniParkManager.DodajVozilo(novo);
            OsveziSeznam();
            OsveziStatistiko();

            // Očisti vnose
            textBoxMarka.Clear();
            textBoxRegistar.Clear();
            textBoxMasa.Clear();
            textBoxZapremina.Clear();
            numericUpDownVrata.Value = 4;
            comboBoxBoja.SelectedIndex = 0;

            MessageBox.Show("Vozilo je uspešno dodano!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Brisanje izbranega vozila</summary>
        private void buttonObrisiVozilo_Click(object sender, EventArgs e)
        {
            if (_izbranVozilo != null)
            {
                VozniParkManager.UkloniVozilo(_izbranVozilo.RegistarskiBroj);
                OsveziSeznam();
                OsveziStatistiko();
                _izbranVozilo = null;
            }
        }

        /// <summary>Demonstracija preopterečenih operatorjev</summary>
        private void buttonOperatoriDemo_Click(object sender, EventArgs e)
        {
            var vozila = VozniParkManager.DajSvaVozila();
            if (vozila.Count >= 2)
            {
                AutoVozilo a1 = vozila[0];
                AutoVozilo a2 = vozila[1];

                string prikaz = $"Primerjava vozil:\n\n";
                prikaz += $"{a1.ImeZnamke} {a1.ImeModela}: {a1.GodisnjaMasa}kg\n";
                prikaz += $"{a2.ImeZnamke} {a2.ImeModela}: {a2.GodisnjaMasa}kg\n\n";
                prikaz += $"{a1.ImeZnamke} > {a2.ImeZnamke}: {(a1 > a2)}\n";
                prikaz += $"{a1.ImeZnamke} < {a2.ImeZnamke}: {(a1 < a2)}\n";
                prikaz += $"{a1.ImeZnamke} == {a2.ImeZnamke}: {(a1 == a2)}\n";

                AutoVozilo a3 = a1 * 1.2;
                prikaz += $"\n{a1.ImeZnamke} * 1.2 = nova masa: {a3.GodisnjaMasa}kg";

                MessageBox.Show(prikaz, "Demonstracija operatorjev", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Potrebujete najmanj 2 vozili za primerjavo!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
