using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Przychodnia
{
    public partial class Form1 : Form
    {
        enum wybranaTabela { Lekarze, Pacjenci, Specjalizacje, Wizyty };
        wybranaTabela WybranaTabela;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            dataGridView1.CellMouseDown += new DataGridViewCellMouseEventHandler(this.DataGridCellMouseClick);
            dataGridViewWizyta.CellMouseDown += new DataGridViewCellMouseEventHandler(this.DataGridCellMouseClick);
            dataGridViewPacjenci.CellMouseDown += new DataGridViewCellMouseEventHandler(this.DataGridCellMouseClick);
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(this.DataGridCellValueChanged);
            dataGridViewWizyta.CellValueChanged += new DataGridViewCellEventHandler(this.DataGridCellValueChanged);
            dataGridViewPacjenci.CellValueChanged += new DataGridViewCellEventHandler(this.DataGridCellValueChanged);
            comboBox1.SelectedIndex = 0;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(this.MainForm_KeyDown);
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                FormDodajPacjenta form = new FormDodajPacjenta(this);
                form.Show();
            }
            else if (e.Control && e.KeyCode == Keys.L)
            {
                FormDodajLekarza form = new FormDodajLekarza(this);
                form.Show();
            }
            else if (e.Control && e.KeyCode == Keys.W)
            {

                FormDodajWizyte form = new FormDodajWizyte(this);
                form.Show();
            }
        }
        private void DataGridCellValueChanged(object sender,DataGridViewCellEventArgs e)
        {
            if (WybranaTabela == wybranaTabela.Lekarze)
            {
                Lekarz lekarz = new Lekarz();
                lekarz.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                lekarz.imie = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                lekarz.nazwisko = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                lekarz.adres = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                lekarz.telefon = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                lekarz.dataUrodzenia = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                if (lekarz.id > 0)
                {
                    lekarz.aktualizujDane();
                }
            }
            else if (WybranaTabela == wybranaTabela.Pacjenci)
            {
                Pacjent lekarz = new Pacjent();
                lekarz.id = Convert.ToInt32(dataGridViewPacjenci.CurrentRow.Cells[0].Value);
                lekarz.imie = dataGridViewPacjenci.CurrentRow.Cells[1].Value.ToString();
                lekarz.nazwisko = dataGridViewPacjenci.CurrentRow.Cells[2].Value.ToString();
                lekarz.adres = dataGridViewPacjenci.CurrentRow.Cells[3].Value.ToString();
                lekarz.telefon = dataGridViewPacjenci.CurrentRow.Cells[4].Value.ToString();
                lekarz.dataUrodzenia = Convert.ToDateTime(dataGridViewPacjenci.CurrentRow.Cells[5].Value.ToString());
                if (lekarz.id > 0)
                {
                    lekarz.aktualizujDane();
                }

            }
            else if (WybranaTabela == wybranaTabela.Wizyty)
            {
                Wizyta wizyta = new Wizyta();
                wizyta.id = Convert.ToInt32(dataGridViewWizyta.CurrentRow.Cells[0].Value);
                wizyta.data = Convert.ToDateTime(dataGridViewWizyta.CurrentRow.Cells[3].Value.ToString());
                wizyta.opisWizyty = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                if (wizyta.id > 0)
                    wizyta.aktualizujDane();
            }
        }
        private void DataGridCellMouseClick(object sender,DataGridViewCellMouseEventArgs e)
        {
            DataGridView dataGridView1 = (DataGridView)sender;
            if (e.Button == MouseButtons.Right)
            {
                // Add this
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Can leave these here - doesn't hurt
                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.Focus();
            }

        }
        private void lekarzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDodajLekarza form = new FormDodajLekarza(this);
            form.Show();
        }

        private void pacjentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDodajPacjenta form = new FormDodajPacjenta(this);
            form.Show();
        }
        private void schowajDataGridView()
        {

            dataGridViewPacjenci.Visible = false;
            dataGridView1.Visible = false;
            dataGridViewWizyta.Visible = false;
            dataGridViewSpecjalizacja.Visible = false;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            schowajDataGridView();
            if (comboBox1.SelectedItem.ToString().Equals("Lekarze"))
            {
                WybranaTabela = wybranaTabela.Lekarze;
                dataGridView1.Visible = true;
            }
            else if (comboBox1.SelectedItem.ToString().Equals("Pacjenci")){
                WybranaTabela = Form1.wybranaTabela.Pacjenci;
                dataGridViewPacjenci.Visible = true;
            }
            else if (comboBox1.SelectedItem.ToString().Equals("Specjalizacja"))
            {
                WybranaTabela = Form1.wybranaTabela.Specjalizacje;
                dataGridViewSpecjalizacja.Visible = true;
            }
            else if (comboBox1.SelectedItem.ToString().Equals("Wizyta"))
            {
                 WybranaTabela = Form1.wybranaTabela.Wizyty;
                 dataGridViewWizyta.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            aktualizuj();

        }
        public void aktualizuj()
        {
            this.lekarzTableAdapter.Fill(this.bazaPrzychodniaDataSet.Lekarz);
            this.wizytaTableAdapter.Fill(this.bazaPrzychodniaDataSet.Wizyta);
            // TODO: This line of code loads data into the 'bazaPrzychodniaDataSet.Specjalizacja' table. You can move, or remove it, as needed.
            this.specjalizacjaTableAdapter.Fill(this.bazaPrzychodniaDataSet.Specjalizacja);
            // TODO: This line of code loads data into the 'bazaPrzychodniaDataSet.Pacjent' table. You can move, or remove it, as needed.
            this.pacjentTableAdapter.Fill(this.bazaPrzychodniaDataSet.Pacjent);
        }

        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WybranaTabela == wybranaTabela.Lekarze)
            {
                Lekarz lekarz = new Lekarz();
                lekarz.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                if (lekarz.id > 0)
                {
                    lekarz.usunZBazy();
                    MessageBox.Show("Udało się usunąć lekarza z bazy");
                    this.aktualizuj();
                }
            }
            else if (WybranaTabela == wybranaTabela.Pacjenci)
            {
                Pacjent pacjent = new Pacjent();
                pacjent.id = Convert.ToInt32(dataGridViewPacjenci.CurrentRow.Cells[0].Value);
                if (pacjent.id > 0)
                {
                    pacjent.usunZBazy();
                    MessageBox.Show("Udało się usunąć pacjenta z bazy");
                    this.aktualizuj();
                }
            }
            else if (WybranaTabela == wybranaTabela.Wizyty)
            {
                Wizyta wizyta = new Wizyta();
                wizyta.id = Convert.ToInt32(dataGridViewWizyta.CurrentRow.Cells[0].Value);
                if (wizyta.id > 0)
                {
                    wizyta.usunZBazy();
                    MessageBox.Show("Udało się usunąć wizytę z bazy danych");
                    this.aktualizuj();
                }
            }
        }

        private void wizytęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDodajWizyte form = new FormDodajWizyte(this);
            form.Show();
        }
    }

}
