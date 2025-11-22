using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GesCom.BLL;
using GesCom.BO;

namespace GesCom.GUI
{
    public partial class UserControlSyntheseClient : UserControl
    {
        public UserControlSyntheseClient()
        {
            InitializeComponent();
            InitializeDataGridView();
            btnRecherche.Click += BtnRecherche_Click;
        }

        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Date",
                HeaderText = "Date",
                DataPropertyName = "Date",
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Client",
                HeaderText = "Client",
                DataPropertyName = "Client",
                Width = 150
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DevisAcceptes",
                HeaderText = "Devis acceptés",
                DataPropertyName = "DevisAcceptes",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DevisDeclines",
                HeaderText = "Devis déclinés",
                DataPropertyName = "DevisDeclines",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DevisAttente",
                HeaderText = "Devis en attente",
                DataPropertyName = "DevisAttente",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MontantTotalHT",
                HeaderText = "Montant total HT",
                DataPropertyName = "MontantTotalHT",
                Width = 150
            });
        }

        private void BtnRecherche_Click(object sender, EventArgs e)
        {
            ChargerDonnees();
        }

        private void ChargerDonnees()
        {
            DateTime dateDebut = dateTimePicker1.Value.Date;
            DateTime dateFin = dateTimePicker2.Value.Date;

            List<Devis> listDevis = DevisBLL.GetUnDevisBLL().GetListDevis();

            var devisFiltres = listDevis.Where(d => d.Date.Date >= dateDebut && d.Date.Date <= dateFin).ToList();

            var synthese = devisFiltres
                .GroupBy(d => d.Client.Code)
                .Select(g => new
                {
                    Date = g.Min(d => d.Date).ToString("dd/MM/yyyy"),
                    Client = g.First().Client.Nom,
                    DevisAcceptes = g.Count(d => d.Statut.Name.ToLower().Contains("accept")),
                    DevisDeclines = g.Count(d => d.Statut.Name.ToLower().Contains("déclin") || d.Statut.Name.ToLower().Contains("declin")),
                    DevisAttente = g.Count(d => d.Statut.Name.ToLower().Contains("attente")),
                    MontantTotalHT = g.Sum(d => d.MontantHT).ToString("N2") + " €"
                })
                .ToList();

            dataGridView1.DataSource = synthese;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
