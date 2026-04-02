using System;
using System.Linq;
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
            SkupinaAvtov.ModelSelected += SkupinaAvtov_ModelSelected;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            SkupinaAvtov.ModelSelected -= SkupinaAvtov_ModelSelected;
            base.OnFormClosed(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (string tip in SkupinaAvtov.Vozila())
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
                foreach (string z in SkupinaAvtov.Znamke())
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
                foreach (string k in SkupinaAvtov.Kategorije())
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
            string kategorija = Convert.ToString(comboBox3.SelectedItem);

            if (!string.IsNullOrEmpty(znamka) && !string.IsNullOrEmpty(kategorija))
            {
                comboBox4.Enabled = true;
                comboBox4.Items.Clear();
                foreach (string m in SkupinaAvtov.Modeli(znamka, kategorija))
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
                Model model = SkupinaAvtov.Model(imeModela, znamka, kategorija);
                if (model != null)
                {
                    SkupinaAvtov.RaiseModelSelected(model);
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

        private void SkupinaAvtov_ModelSelected(Model m)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Model>(SkupinaAvtov_ModelSelected), new object[] { m });
                return;
            }
            if (m == null)
                label1.Text = string.Empty;
            else
                label1.Text = m.Opis();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }
    }
}
