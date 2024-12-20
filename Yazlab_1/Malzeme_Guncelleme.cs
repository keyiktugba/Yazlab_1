﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazlab_1
{
    public partial class Malzeme_Guncelleme : Form
    {
        private MalzemeMethodları malzemeYardimcisi;
        private int malzemeID;

        public Malzeme_Guncelleme(int malzemeID)
        {
            InitializeComponent();
            this.malzemeID = malzemeID; 
            malzemeYardimcisi = new MalzemeMethodları();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Malzeme_Guncelleme_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 0; 
            numericUpDown1.Maximum = 100000; 
            numericUpDown2.Minimum = 0;
            numericUpDown2.Maximum = 100000; 

            LoadMalzemeBilgileri();
        }
        private void LoadMalzemeBilgileri()
        {
            List<Malzemeler> malzemeListesi = malzemeYardimcisi.GetMalzemeler();
            Malzemeler malzeme = malzemeListesi.Find(m => m.MalzemeID == malzemeID);
            comboBox1.Items.Add("gram");
            comboBox1.Items.Add("mililitre");

            if (malzeme != null)
            {
                textBox1.Text = malzeme.MalzemeAdi; 
                comboBox1.SelectedItem = malzeme.MalzemeBirim.ToString();

                numericUpDown2.Value = malzeme.BirimFiyat; 

                numericUpDown1.Value = Convert.ToDecimal(malzeme.ToplamMiktar); 

            }
            else
            {
                MessageBox.Show("Malzeme bulunamadı.");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string malzemeAdi = textBox1.Text;
            string malzemeBirim = comboBox1.SelectedItem.ToString();
            decimal birimFiyat = numericUpDown2.Value;
            int eklenenMiktar = (int)numericUpDown1.Value;

            malzemeYardimcisi.MalzemeGuncelle(malzemeID, malzemeAdi, eklenenMiktar.ToString(), malzemeBirim, birimFiyat);

            var depoFormu = Application.OpenForms.OfType<Malzeme_Deposu>().FirstOrDefault();
            if (depoFormu != null)
            {
                depoFormu.LoadMalzemeler(); 
            }
           
            this.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
