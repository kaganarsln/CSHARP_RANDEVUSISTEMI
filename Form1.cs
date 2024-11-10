using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listkullanimi
{
    public partial class Form1 : Form
    {
        BindingList<Hasta> hastalar = new BindingList<Hasta>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hasta hasta1 = new Hasta { Id = 1, AdSoyad = "Kağan Arslangörür", Birim = "Göz", Tarih = DateTime.Now, Yas = 20, Sigorta = true };
            Hasta hasta2 = new Hasta { Id = 1, AdSoyad = "Batuhan Ensar Dağlar", Birim = "Nöroloji", Tarih = DateTime.Now, Yas = 20, Sigorta = false };
            Hasta hasta3 = new Hasta { Id = 1, AdSoyad = "Elif Nehir Öğüt", Birim = "KBB", Tarih = DateTime.Now, Yas = 20, Sigorta = false };

            hastalar.Add(hasta1);
            hastalar.Add(hasta2);
            hastalar.Add(hasta3);

            dataGridView1.DataSource = hastalar;
        }

        

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string adSoyad = txtAdSoyad.Text;
            string birim = cmbBirim.Text;
            int yas = Convert.ToInt32(txtYas.Text);
            bool sigorta = cbSigorta.Checked;
            DateTime dateTime = dtTarih.Value;

            Hasta hasta = new Hasta { Id = id, AdSoyad = adSoyad, Birim = birim, Tarih = dateTime, Yas = yas, Sigorta = sigorta };
            hastalar.Add(hasta);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Hasta hasta = (Hasta)dataGridView1.SelectedRows[0].DataBoundItem;

                txtId.Text = hasta.Id.ToString();
                txtAdSoyad.Text = hasta.AdSoyad;
                cmbBirim.Text = hasta.Birim;
                txtYas.Text = hasta.Yas.ToString();
                cbSigorta.Checked = hasta.Sigorta;
                dtTarih.Value = hasta.Tarih;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0) 
            {
               Hasta hasta = (Hasta)dataGridView1.SelectedRows[0].DataBoundItem;

                hasta.AdSoyad = txtAdSoyad.Text;
                hasta.Yas = Convert.ToInt32(txtYas.Text);
                hasta.Birim = cmbBirim.Text;
                hasta.Tarih = dtTarih.Value;
                hasta.Sigorta = cbSigorta.Checked;

                dataGridView1.Refresh();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Hasta hasta = (Hasta)dataGridView1.SelectedRows[0].DataBoundItem;

                DialogResult result = MessageBox.Show(hasta.AdSoyad + " Silinsin mi ? ", " Randevu Sil ", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes) 
                {
                    hastalar.Remove(hasta);

                    dataGridView1.Refresh();
                }
            }
        }
    }
}

