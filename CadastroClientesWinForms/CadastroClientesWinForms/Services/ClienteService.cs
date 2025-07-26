using System;
using System.Collections.Generic;
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
        }
}
