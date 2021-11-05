using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ConexaoSQLite
{
    class Conexao
    {
        public SQLiteConnection conn = new ("Data Source=Usuario.db");

        public void Conectar()
        {
            conn.Open();
        }

        public void Desconectar()
        {
            conn.Close();
        }
    }
}
