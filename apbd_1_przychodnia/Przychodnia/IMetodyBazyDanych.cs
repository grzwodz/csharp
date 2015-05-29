using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public interface IMetodyBazyDanych
    {
       void dodajDoBazy();
       void aktualizujDane();
       void usunZBazy();
    }
}
