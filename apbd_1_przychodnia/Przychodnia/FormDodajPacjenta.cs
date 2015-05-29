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
    public partial class FormDodajPacjenta: Form
    {
        Form1 form;
        public FormDodajPacjenta(Form1 form)
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
                Pacjent pacjent = new Pacjent();
                pacjent.adres = textBoxAdres.Text;
                pacjent.imie = textBoxImie.Text;
                pacjent.nazwisko = textBoxNazwisko.Text;
                pacjent.dataUrodzenia = dateTimePicker1.Value;
                pacjent.telefon = textBoxTelefon.Text;

                pacjent.dodajDoBazy();
                MessageBox.Show("Dodano pacjenta do bazy");
                form.aktualizuj();
                this.Dispose();
            }
            else
                MessageBox.Show("Nie wypełniono wszystkich pól");
        }
    }
}
