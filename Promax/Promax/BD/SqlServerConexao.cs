using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promax.BD
{
    class SqlServerConexao
    {
        public SqlConnection sqlConn;

        private const string local = @"ANDREWESTEVES\SQLEXPRESS";

        private const string banco = "promax";

        private const string usuario = "sa";

        private const string senha = "4321";

        private const string conexao = @"Data Source=" + local + ";Initial Catalog=" + banco + ";UId=" + usuario + ";Password=" + senha + ";";

        public void Abrir()
        {
            this.sqlConn = new SqlConnection(conexao);
            this.sqlConn.Open();
        }

        public void Fechar()
        {
            this.sqlConn.Close();
            this.sqlConn.Dispose();
        }
    }
}
