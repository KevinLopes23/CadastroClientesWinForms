using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroClientesWinForms.Data;
using CadastroClientesWinForms.Models;
using Npgsql;

namespace CadastroClientesWinForms.Services
{
    public static class ClienteService
    {
        public static void Inserir(Cliente cliente)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO clientes (nome, email, telefone, data_nascimento) 
                               VALUES (@nome, @email, @telefone, @data_nascimento)";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("email", cliente.Email);
                    cmd.Parameters.AddWithValue("telefone", cliente.Telefone);
                    cmd.Parameters.AddWithValue("data_nascimento", cliente.DataNascimento);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable ListarTodos()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM clientes ORDER BY id DESC";

                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var tabela = new DataTable();
                    tabela.Load(reader);
                    return tabela;
                }
            }
        }



        public static void Atualizar(Cliente cliente)
        {
            using(var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE clientes 
                       SET nome = @nome, email = @email, telefone = @telefone, data_nascimento = @data_nascimento 
                       WHERE id = @id";


                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("email", cliente.Email);
                    cmd.Parameters.AddWithValue("telefone", cliente.Telefone);
                    cmd.Parameters.AddWithValue("data_nascimento", cliente.DataNascimento);
                    cmd.Parameters.AddWithValue("id", cliente.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        public static void Excluir(int id)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM clientes WHERE id = @id";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }





    }

}


