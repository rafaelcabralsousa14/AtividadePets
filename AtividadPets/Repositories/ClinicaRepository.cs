using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using AtividadPets.Context;
using AtividadPets.Domains;

namespace AtividadPets.Repositories
{
    public class ClinicaRepository
    {
        ProjetoPetsContext conexao = new ProjetoPetsContext();

        SqlCommand cmd = new SqlCommand();

        public Clinica Alterar(int id, Clinica a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Clinica SET" +
                "Nome = @nome" +
                "Endereco = @endereco WHERE IdClinica = @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@endereco", a.Endereco);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return a;
        }

        public Clinica BuscarPorID(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Clinica WHERE IdClinica = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Clinica a = new Clinica();

            while (dados.Read())
            {
                a.IdClinica = Convert.ToInt32(dados.GetValue(0));
                a.Nome = dados.GetValue(1).ToString();
                a.Endereco = dados.GetValue(2).ToString();
            }

            conexao.Desconectar();

            return a;
        }

        public Clinica Cadastrar(Clinica a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO Clinica " +
                "(Nome, Endereco)" +
                "VALUES" +
                "(@nome, @endereco)";

            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@endereco", a.Endereco);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Clinica WHERE IdClinica = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<Clinica> ListarTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Clinica";
            SqlDataReader dados = cmd.ExecuteReader();
            List<Clinica> clinicas = new List<Clinica>();

            while (dados.Read())
            {
                clinicas.Add(
                    new Clinica()
                    {
                        IdClinica = Convert.ToInt32(dados.GetValue(0)),
                        Nome = dados.GetValue(1).ToString(),
                        Endereco = dados.GetValue(2).ToString()
                    }
                );
            }

            conexao.Desconectar();

            return clinicas;
        }
    }
}
