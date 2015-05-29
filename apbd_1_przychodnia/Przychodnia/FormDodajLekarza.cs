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
    public partial class FormDodajLekarza : Form
    {
        Form1 form;
        public FormDodajLekarza(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxImie.Text.Length != 0 && textBoxNazwisko.Text.Length != 0 &&
                textBoxTelefon.Text.Length != 0 && textBoxTelefon.Text.Length != 0)
            {
                Lekarz lekarz = new Lekarz();
                lekarz.adres = textBoxAdres.Text;
                lekarz.imie = textBoxImie.Text;
                lekarz.nazwisko = textBoxNazwisko.Text;
                lekarz.dataUrodzenia = dateTimePicker1.Value;
                lekarz.telefon = textBoxTelefon.Text;
                lekarz.specjalizacja = new Specjalizacja(Convert.ToInt32(comboBox1.SelectedValue),
                    comboBox1.SelectedItem.ToString());
                lekarz.dodajDoBazy();
                MessageBox.Show("Dodano lekarza do bazy");
                form.aktualizuj();
                this.Dispose();
            }
            else
                MessageBox.Show("Nie wypełniono wszystkich pól");
        }

        private void FormDodajLekarza_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bazaPrzychodniaDataSet.Specjalizacja' table. You can move, or remove it, as needed.
            this.specjalizacjaTableAdapter.Fill(this.bazaPrzychodniaDataSet.Specjalizacja);

        }
    }
}
