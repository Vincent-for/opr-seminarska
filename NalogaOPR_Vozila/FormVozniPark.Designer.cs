namespace NalogaOPR_Vozila
{
    partial class FormVozniPark
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxVozila = new System.Windows.Forms.ListBox();
            this.textBoxDetalji = new System.Windows.Forms.TextBox();
            this.textBoxStatistika = new System.Windows.Forms.TextBox();
            this.labelBrojVozila = new System.Windows.Forms.Label();
            this.labelUkupnaMasa = new System.Windows.Forms.Label();
            this.labelMaksimalnaBrzina = new System.Windows.Forms.Label();
            this.buttonUbrzaj = new System.Windows.Forms.Button();
            this.buttonUspora = new System.Windows.Forms.Button();
            this.numericUpDownBrzina = new System.Windows.Forms.NumericUpDown();
            this.textBoxMarka = new System.Windows.Forms.TextBox();
            this.textBoxRegistar = new System.Windows.Forms.TextBox();
            this.textBoxMasa = new System.Windows.Forms.TextBox();
            this.textBoxZapremina = new System.Windows.Forms.TextBox();
            this.numericUpDownVrata = new System.Windows.Forms.NumericUpDown();
            this.comboBoxBoja = new System.Windows.Forms.ComboBox();
            this.buttonDodajVozilo = new System.Windows.Forms.Button();
            this.buttonObrisiVozilo = new System.Windows.Forms.Button();
            this.buttonOperatoriDemo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrzina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVrata)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxVozila
            // 
            this.listBoxVozila.Location = new System.Drawing.Point(12, 30);
            this.listBoxVozila.Name = "listBoxVozila";
            this.listBoxVozila.Size = new System.Drawing.Size(250, 290);
            this.listBoxVozila.TabIndex = 0;
            this.listBoxVozila.SelectedIndexChanged += new System.EventHandler(this.listBoxVozila_SelectedIndexChanged);
            // 
            // textBoxDetalji
            // 
            this.textBoxDetalji.Location = new System.Drawing.Point(280, 30);
            this.textBoxDetalji.Multiline = true;
            this.textBoxDetalji.Name = "textBoxDetalji";
            this.textBoxDetalji.ReadOnly = true;
            this.textBoxDetalji.Size = new System.Drawing.Size(400, 100);
            this.textBoxDetalji.TabIndex = 1;
            // 
            // textBoxStatistika
            // 
            this.textBoxStatistika.Location = new System.Drawing.Point(280, 150);
            this.textBoxStatistika.Multiline = true;
            this.textBoxStatistika.Name = "textBoxStatistika";
            this.textBoxStatistika.ReadOnly = true;
            this.textBoxStatistika.Size = new System.Drawing.Size(400, 100);
            this.textBoxStatistika.TabIndex = 2;
            // 
            // labelBrojVozila
            // 
            this.labelBrojVozila.AutoSize = true;
            this.labelBrojVozila.Location = new System.Drawing.Point(280, 260);
            this.labelBrojVozila.Name = "labelBrojVozila";
            this.labelBrojVozila.Size = new System.Drawing.Size(81, 13);
            this.labelBrojVozila.TabIndex = 3;
            this.labelBrojVozila.Text = "Ukupno vozila: 0";
            // 
            // labelUkupnaMasa
            // 
            this.labelUkupnaMasa.AutoSize = true;
            this.labelUkupnaMasa.Location = new System.Drawing.Point(280, 280);
            this.labelUkupnaMasa.Name = "labelUkupnaMasa";
            this.labelUkupnaMasa.Size = new System.Drawing.Size(82, 13);
            this.labelUkupnaMasa.TabIndex = 4;
            this.labelUkupnaMasa.Text = "Ukupna masa: 0";
            // 
            // labelMaksimalnaBrzina
            // 
            this.labelMaksimalnaBrzina.AutoSize = true;
            this.labelMaksimalnaBrzina.Location = new System.Drawing.Point(280, 300);
            this.labelMaksimalnaBrzina.Name = "labelMaksimalnaBrzina";
            this.labelMaksimalnaBrzina.Size = new System.Drawing.Size(141, 13);
            this.labelMaksimalnaBrzina.TabIndex = 5;
            this.labelMaksimalnaBrzina.Text = "Maksimalna brzina: 0 km/h";
            // 
            // buttonUbrzaj
            // 
            this.buttonUbrzaj.Location = new System.Drawing.Point(280, 330);
            this.buttonUbrzaj.Name = "buttonUbrzaj";
            this.buttonUbrzaj.Size = new System.Drawing.Size(100, 30);
            this.buttonUbrzaj.TabIndex = 6;
            this.buttonUbrzaj.Text = "Ubrzaj";
            this.buttonUbrzaj.Click += new System.EventHandler(this.buttonUbrzaj_Click);
            // 
            // buttonUspora
            // 
            this.buttonUspora.Location = new System.Drawing.Point(390, 330);
            this.buttonUspora.Name = "buttonUspora";
            this.buttonUspora.Size = new System.Drawing.Size(100, 30);
            this.buttonUspora.TabIndex = 7;
            this.buttonUspora.Text = "Uspori";
            this.buttonUspora.Click += new System.EventHandler(this.buttonUspora_Click);
            // 
            // numericUpDownBrzina
            // 
            this.numericUpDownBrzina.Location = new System.Drawing.Point(500, 330);
            this.numericUpDownBrzina.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            this.numericUpDownBrzina.Name = "numericUpDownBrzina";
            this.numericUpDownBrzina.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownBrzina.TabIndex = 8;
            this.numericUpDownBrzina.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Dodaj novo vozilo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 345);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Marka:";
            // 
            // textBoxMarka
            // 
            this.textBoxMarka.Location = new System.Drawing.Point(60, 345);
            this.textBoxMarka.Name = "textBoxMarka";
            this.textBoxMarka.Size = new System.Drawing.Size(100, 20);
            this.textBoxMarka.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Registar:";
            // 
            // textBoxRegistar
            // 
            this.textBoxRegistar.Location = new System.Drawing.Point(60, 370);
            this.textBoxRegistar.Name = "textBoxRegistar";
            this.textBoxRegistar.Size = new System.Drawing.Size(100, 20);
            this.textBoxRegistar.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Masa:";
            // 
            // textBoxMasa
            // 
            this.textBoxMasa.Location = new System.Drawing.Point(60, 395);
            this.textBoxMasa.Name = "textBoxMasa";
            this.textBoxMasa.Size = new System.Drawing.Size(100, 20);
            this.textBoxMasa.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Boja:";
            // 
            // comboBoxBoja
            // 
            this.comboBoxBoja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBoja.FormattingEnabled = true;
            this.comboBoxBoja.Items.AddRange(new object[] { "Bela", "Crna", "Plava", "Siva", "Crvena", "Zuta" });
            this.comboBoxBoja.Location = new System.Drawing.Point(205, 345);
            this.comboBoxBoja.Name = "comboBoxBoja";
            this.comboBoxBoja.Size = new System.Drawing.Size(75, 21);
            this.comboBoxBoja.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Vrata:";
            // 
            // numericUpDownVrata
            // 
            this.numericUpDownVrata.Location = new System.Drawing.Point(205, 370);
            this.numericUpDownVrata.Name = "numericUpDownVrata";
            this.numericUpDownVrata.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownVrata.TabIndex = 13;
            this.numericUpDownVrata.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Zapremina:";
            // 
            // textBoxZapremina
            // 
            this.textBoxZapremina.Location = new System.Drawing.Point(235, 395);
            this.textBoxZapremina.Name = "textBoxZapremina";
            this.textBoxZapremina.Size = new System.Drawing.Size(45, 20);
            this.textBoxZapremina.TabIndex = 14;
            // 
            // buttonDodajVozilo
            // 
            this.buttonDodajVozilo.Location = new System.Drawing.Point(60, 420);
            this.buttonDodajVozilo.Name = "buttonDodajVozilo";
            this.buttonDodajVozilo.Size = new System.Drawing.Size(100, 30);
            this.buttonDodajVozilo.TabIndex = 15;
            this.buttonDodajVozilo.Text = "Dodaj vozilo";
            this.buttonDodajVozilo.Click += new System.EventHandler(this.buttonDodajVozilo_Click);
            // 
            // buttonObrisiVozilo
            // 
            this.buttonObrisiVozilo.Location = new System.Drawing.Point(170, 420);
            this.buttonObrisiVozilo.Name = "buttonObrisiVozilo";
            this.buttonObrisiVozilo.Size = new System.Drawing.Size(110, 30);
            this.buttonObrisiVozilo.TabIndex = 16;
            this.buttonObrisiVozilo.Text = "Obriši vozilo";
            this.buttonObrisiVozilo.Click += new System.EventHandler(this.buttonObrisiVozilo_Click);
            // 
            // buttonOperatoriDemo
            // 
            this.buttonOperatoriDemo.Location = new System.Drawing.Point(280, 370);
            this.buttonOperatoriDemo.Name = "buttonOperatoriDemo";
            this.buttonOperatoriDemo.Size = new System.Drawing.Size(200, 30);
            this.buttonOperatoriDemo.TabIndex = 17;
            this.buttonOperatoriDemo.Text = "Demo preopterećenja operatora";
            this.buttonOperatoriDemo.Click += new System.EventHandler(this.buttonOperatoriDemo_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Vozila u parku:";
            // 
            // FormVozniPark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 460);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxZapremina);
            this.Controls.Add(this.numericUpDownVrata);
            this.Controls.Add(this.comboBoxBoja);
            this.Controls.Add(this.textBoxMasa);
            this.Controls.Add(this.textBoxRegistar);
            this.Controls.Add(this.textBoxMarka);
            this.Controls.Add(this.numericUpDownBrzina);
            this.Controls.Add(this.buttonUspora);
            this.Controls.Add(this.buttonUbrzaj);
            this.Controls.Add(this.labelMaksimalnaBrzina);
            this.Controls.Add(this.labelUkupnaMasa);
            this.Controls.Add(this.labelBrojVozila);
            this.Controls.Add(this.textBoxStatistika);
            this.Controls.Add(this.textBoxDetalji);
            this.Controls.Add(this.listBoxVozila);
            this.Controls.Add(this.buttonDodajVozilo);
            this.Controls.Add(this.buttonObrisiVozilo);
            this.Controls.Add(this.buttonOperatoriDemo);
            this.Name = "FormVozniPark";
            this.Text = "Vozni Park - Demonstracija OOP principa";
            this.Load += new System.EventHandler(this.FormVozniPark_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrzina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVrata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListBox listBoxVozila;
        private System.Windows.Forms.TextBox textBoxDetalji;
        private System.Windows.Forms.TextBox textBoxStatistika;
        private System.Windows.Forms.Label labelBrojVozila;
        private System.Windows.Forms.Label labelUkupnaMasa;
        private System.Windows.Forms.Label labelMaksimalnaBrzina;
        private System.Windows.Forms.Button buttonUbrzaj;
        private System.Windows.Forms.Button buttonUspora;
        private System.Windows.Forms.NumericUpDown numericUpDownBrzina;
        private System.Windows.Forms.TextBox textBoxMarka;
        private System.Windows.Forms.TextBox textBoxRegistar;
        private System.Windows.Forms.TextBox textBoxMasa;
        private System.Windows.Forms.TextBox textBoxZapremina;
        private System.Windows.Forms.NumericUpDown numericUpDownVrata;
        private System.Windows.Forms.ComboBox comboBoxBoja;
        private System.Windows.Forms.Button buttonDodajVozilo;
        private System.Windows.Forms.Button buttonObrisiVozilo;
        private System.Windows.Forms.Button buttonOperatoriDemo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}
