using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Przychodnia
{
    public class Lekarz : Osoba, IMetodyBazyDanych
    {
        public Specjalizacja specjalizacja { get; set; }
       
     
        public Lekarz() { }
        public Lekarz(int id) { this.id = id; }

        public  void dodajDoBazy()
        {
           
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertLekarzRecord";
            cmd.Parameters.Add("@LekarzImie", SqlDbType.VarChar).Value = this.imie;
            cmd.Parameters.Add("@LekarzNazwisko", SqlDbType.VarChar).Value = this.nazwisko;
            cmd.Parameters.Add("@LekarzAdres", SqlDbType.VarChar).Value = this.adres;
            cmd.Parameters.Add("@LekarzTelefon", SqlDbType.VarChar).Value = this.telefon;
            cmd.Parameters.Add("@LekarzDataUrodzenia", SqlDbType.Date).Value = this.dataUrodzenia;
            cmd.Parameters.Add("@LekarzIdSpecjalizacji", SqlDbType.Int).Value = this.specjalizacja.id;
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
            cmd.CommandText = "UpdateLekarz";
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = this.id;
            cmd.Parameters.Add("@imie", SqlDbType.VarChar).Value = this.imie;
            cmd.Parameters.Add("@nazwisko", SqlDbType.VarChar).Value = this.nazwisko;
            cmd.Parameters.Add("@adres", SqlDbType.VarChar).Value = this.adres;
            cmd.Parameters.Add("@dataUrodzenia", SqlDbType.DateTime).Value = this.dataUrodzenia;
            cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = this.telefon;
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
            cmd.CommandText = "DeleteLekarz";
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
