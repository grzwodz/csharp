using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public class Wizyta : IMetodyBazyDanych
    {
        public int id { get; set; }
        public String strConnString = ConfigurationManager.ConnectionStrings["Przychodnia.Properties.Settings.bazaPrzychodniaConnectionString"].ConnectionString;
       public Lekarz lekarz { get; set; }
       public Pacjent pacjent { get; set; }
       public DateTime data { get; set; }
       public String opisWizyty { get; set; }


       public void dodajDoBazy()
       {
           SqlConnection con = new SqlConnection(strConnString);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "InsertWizyta";
           cmd.Parameters.Add("@idLekarza", SqlDbType.Int).Value = this.lekarz.id;
           cmd.Parameters.Add("@idPacjenta", SqlDbType.Int).Value = this.pacjent.id;
           cmd.Parameters.Add("@dataWizyty", SqlDbType.DateTime).Value = this.data;
           cmd.Parameters.Add("@opis", SqlDbType.VarChar).Value = this.opisWizyty;
           cmd.Connection = con;
           try
           {
               con.Open();
               cmd.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               con.Close();
               con.Dispose();
           }
       }

       public void aktualizujDane()
       {
           SqlConnection con = new SqlConnection(strConnString);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "UpdateWizyta";
           cmd.Parameters.Add("@ID", SqlDbType.Int).Value = this.id;
           cmd.Parameters.Add("@opis", SqlDbType.VarChar).Value = this.opisWizyty;
           cmd.Parameters.Add("@dataWizyty", SqlDbType.DateTime).Value = this.data;
           cmd.Connection = con;
           try
           {
               con.Open();
               cmd.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               con.Close();
               con.Dispose();
           }
       }

       public void usunZBazy()
       {
           SqlConnection con = new SqlConnection(strConnString);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "DeleteWizyta";
           cmd.Parameters.Add("@ID", SqlDbType.Int).Value = this.id;
           cmd.Connection = con;
           try
           {
               con.Open();
               cmd.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               con.Close();
               con.Dispose();
           }
       }
    }
}
