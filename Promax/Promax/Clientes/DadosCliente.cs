using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promax.BD;
using System.Data;
using System.Data.SqlClient;

namespace Promax.Clientes
{
    class DadosCliente: SqlServerConexao, InterfaceCliente
    {
        public void Cadastrar(Cliente cliente)
        {
            try
            {
                this.Abrir();

                string sql = "INSERT INTO cliente (nome, email, telefone) VALUES (@nome, @email, @telefone)";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                cmd.Parameters["@nome"].Value = cliente.Nome;

                cmd.Parameters.Add("@email", SqlDbType.VarChar);
                cmd.Parameters["@email"].Value = cliente.Email;

                cmd.Parameters.Add("@telefone", SqlDbType.VarChar);
                cmd.Parameters["@telefone"].Value = cliente.Telefone;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar cliente: " + ex.Message);
            }
        }

        public void Atualizar(Cliente cliente)
        {
            try
            {
                this.Abrir();

                string sql = "UPDATE cliente SET nome = @nome, email = @email, telefone = @telefone ";
                sql += "WHERE cliente_id = @cliente_id";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                cmd.Parameters["@nome"].Value = cliente.Nome;

                cmd.Parameters.Add("@email", SqlDbType.VarChar);
                cmd.Parameters["@email"].Value = cliente.Email;

                cmd.Parameters.Add("@telefone", SqlDbType.VarChar);
                cmd.Parameters["@telefone"].Value = cliente.Telefone;

                cmd.Parameters.Add("@cliente_id", SqlDbType.VarChar);
                cmd.Parameters["@cliente_id"].Value = cliente.Cliente_id;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar cliente: " + ex.Message);
            }
        }

        public void Remover(Cliente cliente)
        {
            try
            {
                this.Abrir();

                string sql = "DELETE FROM cliente WHERE cliente_id = @cliente_id";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@cliente_id", SqlDbType.Int);
                cmd.Parameters["@cliente_id"].Value = cliente.Cliente_id;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover cliente: " + ex.Message);
            }
        }

        public List<Cliente> Listar(Cliente cliente)
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                this.Abrir();

                string sql = "SELECT cliente_id, nome, email, telefone FROM cliente WHERE 1 = 1 ";

                if (!string.IsNullOrEmpty(cliente.Nome))
                {
                    sql += "AND nome LIKE @nome ";
                }

                if (!string.IsNullOrEmpty(cliente.Email))
                {
                    sql += "AND email = @email ";
                }

                if (!string.IsNullOrEmpty(cliente.Telefone))
                {
                    sql += "AND telefone = @telefone ";
                }

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                if (!string.IsNullOrEmpty(cliente.Nome))
                {
                    cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                    cmd.Parameters["@nome"].Value = "%" + cliente.Nome + "%";
                }

                if (!string.IsNullOrEmpty(cliente.Email))
                {
                    cmd.Parameters.Add("@email", SqlDbType.VarChar);
                    cmd.Parameters["@email"].Value = cliente.Email;
                }

                if (!string.IsNullOrEmpty(cliente.Telefone))
                {
                    cmd.Parameters.Add("@telefone", SqlDbType.VarChar);
                    cmd.Parameters["@telefone"].Value = cliente.Telefone;
                }

                SqlDataReader dbReader = cmd.ExecuteReader();

                while (dbReader.Read())
                {
                    Cliente c = new Cliente();
                    c.Cliente_id = dbReader.GetInt32(dbReader.GetOrdinal("cliente_id"));
                    c.Nome = dbReader.GetString(dbReader.GetOrdinal("nome"));
                    c.Email = dbReader.GetString(dbReader.GetOrdinal("email"));
                    c.Telefone = dbReader.GetString(dbReader.GetOrdinal("telefone"));
                    clientes.Add(c);
                }

                dbReader.Close();
                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar clientes: " + ex.Message);
            }
            return clientes;
        }
    }
}
