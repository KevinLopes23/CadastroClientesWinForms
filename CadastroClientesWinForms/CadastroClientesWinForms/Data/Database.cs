using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace CadastroClientesWinForms.Data
{
    public static class Database
    {
        private static string connString = "Host=localhost;Port=5432;Username=postgres;Password=admin;Database=Clientes";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connString);
        }
    }
}
