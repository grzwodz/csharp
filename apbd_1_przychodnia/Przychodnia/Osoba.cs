using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{ 
    public abstract class Osoba
    {
        public String strConnString = ConfigurationManager.ConnectionStrings["Przychodnia.Properties.Settings.bazaPrzychodniaConnectionString"].ConnectionString;
        public int id { get; set; }
        public String imie { get; set; }
        public String nazwisko { get; set; }
        public DateTime dataUrodzenia { get; set; }
        public String adres { get; set; }
        public String telefon { get; set; }

       
      
        public override string ToString()
        {
            return imie + " " + nazwisko;
        }
    }
}
