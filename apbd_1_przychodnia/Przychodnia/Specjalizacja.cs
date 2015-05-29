using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public class Specjalizacja
    {
        public int id { get; set; }
        public String nazwaSpecjalizacji { get; set; }
        public Specjalizacja(int id, String nazwaSpecjalizacji)
        {
            this.id = id;
            this.nazwaSpecjalizacji = nazwaSpecjalizacji;
        }
     
    }
}
