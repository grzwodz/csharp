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
    public partial class FormDodajWizyte: Form
    {
        public Form1 form;
        public FormDodajWizyte(Form1 form)
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
            if (textBoxOpis.Text.Length != 0)
            {
                Wizyta wizyta = new Wizyta();
                wizyta.data = dateTimePicker1.Value;
                wizyta.lekarz = new Lekarz(Convert.ToInt32(comboBox2.SelectedValue));
                wizyta.pacjent = new Pacjent(Convert.ToInt32(comboBox1.SelectedValue));
                wizyta.opisWizyty = textBoxOpis.Text;
                wizyta.dodajDoBazy();
                form.aktualizuj();
                MessageBox.Show("Dodano element do bazy danych");
                this.Dispose();
            }
            else
                MessageBox.Show("Nie wprowadzono opisu");
        }

        private void FormDodajWizyte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bazaPrzychodniaDataSet.Lekarz' table. You can move, or remove it, as needed.
            this.lekarzTableAdapter.Fill(this.bazaPrzychodniaDataSet.Lekarz);
            // TODO: This line of code loads data into the 'bazaPrzychodniaDataSet.Pacjent' table. You can move, or remove it, as needed.
            this.pacjentTableAdapter.Fill(this.bazaPrzychodniaDataSet.Pacjent);

        }
    }
}
