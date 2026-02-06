using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NalogaOPR_Vozila
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (var tip in SkupinaAvtov.Vozila())
                comboBox1.Items.Add(tip);

            label1.Text = string.Empty;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = Convert.ToString(comboBox1.SelectedItem);
            if (!string.IsNullOrEmpty(a))
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();
                foreach (var z in SkupinaAvtov.Znamke())
                    comboBox2.Items.Add(z);

                comboBox3.Items.Clear();
                comboBox3.Enabled = false;
                comboBox4.Items.Clear();
                comboBox4.Enabled = false;
                label1.Text = string.Empty;
            }
            else
            {
                comboBox2.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string znamka = Convert.ToString(comboBox2.SelectedItem);
            if (!string.IsNullOrEmpty(znamka))
            {
                comboBox3.Enabled = true;
                comboBox3.Items.Clear();
                foreach (var k in SkupinaAvtov.Kategorije())
                    comboBox3.Items.Add(k);

                comboBox4.Items.Clear();
                comboBox4.Enabled = false;
                label1.Text = string.Empty;
            }
            else
            {
                comboBox3.Enabled = false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string znamka = Convert.ToString(comboBox2.SelectedItem);
            string  kategorija = Convert.ToString(comboBox3.SelectedItem);

            if (!string.IsNullOrEmpty(znamka) && !string.IsNullOrEmpty(kategorija))
            {
                comboBox4.Enabled = true;
                comboBox4.Items.Clear();
                var models = SkupinaAvtov.Modeli(znamka, kategorija);
                foreach (var m in models)
                    comboBox4.Items.Add(m);

                label1.Text = string.Empty;
            }
            else
            {
                comboBox4.Enabled = false;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string znamka = Convert.ToString(comboBox2.SelectedItem);
            string kategorija = Convert.ToString(comboBox3.SelectedItem);
            string imeModela = Convert.ToString(comboBox4.SelectedItem);

            if (!string.IsNullOrEmpty(imeModela))
            {
                var model = SkupinaAvtov.Model(imeModela, znamka, kategorija);
                if (model != null)
                {
                    label1.Text = 
                        "Model: " + model.ImeModela  +  "  " +
                        "Znamka: " + model.ImeZnamke + "  " +
                        "Kategorija: " + model.ImeKategorije + "  " +
                        "HP: " + model.HP;
                }
                else
                {
                    label1.Text = string.Empty;
                }
            }
            else
            {
                label1.Text = string.Empty;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Slike dodam naslednic
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Materiali motorja
            //classa za razlicne dele avta ki bo izracunala podatke iz drugih classov 
            //vplivalo na HP
            //dodam naslednic
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Vrsta goriva
            //classa za razlicne dele avta ki bo izracunala podatke iz drugih classov
            //vplivalo na HP
            //dodam naslednic
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
