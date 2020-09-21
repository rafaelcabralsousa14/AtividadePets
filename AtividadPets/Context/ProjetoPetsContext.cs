using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AtividadPets.Context
{
    public class ProjetoPetsContext
    {
        SqlConnection con = new SqlConnection();

        public ProjetoPetsContext()
        {
            con.ConnectionString = @"Data Source=LAPTOP-HJTFSJFK;Initial Catalog=boletim;Integrated Security=True";
        }

        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
