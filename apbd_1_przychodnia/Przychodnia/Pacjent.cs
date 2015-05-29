using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public class Pacjent : Osoba, IMetodyBazyDanych
    {
        public Pacjent() { }
        public Pacjent(int id) { this.id = id; }
        public  void dodajDoBazy()
        {
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertPacjentRecord";
            cmd.Parameters.Add("@imie", SqlDbType.VarChar).Value = this.imie;
            cmd.Parameters.Add("@nazwisko", SqlDbType.VarChar).Value = this.nazwisko;
            cmd.Parameters.Add("@adres", SqlDbType.VarChar).Value = this.adres;
            cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = this.telefon;
            cmd.Parameters.Add("@dataUrodzenia", SqlDbType.Date).Value = this.dataUrodzenia;
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
            cmd.CommandText = "UpdatePacjent";
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

        public  void usunZBazy()
        {
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeletePacjent";
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
