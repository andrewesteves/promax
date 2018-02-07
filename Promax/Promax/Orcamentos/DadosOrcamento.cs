using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promax.BD;
using System.Data.SqlClient;
using System.Data;
using Promax.Clientes;

namespace Promax.Orcamentos
{
    class DadosOrcamento : SqlServerConexao, InterfaceOrcamento
    {
        public void Cadastrar(Orcamento orcamento)
        {
            try
            {
                this.Abrir();

                string sql = "INSERT INTO orcamento (cliente_id, descricao, situacao, observacao) VALUES (@cliente_id, @descricao, @situacao, @observacao)";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@cliente_id", SqlDbType.Int);
                cmd.Parameters["@cliente_id"].Value = orcamento.Cliente.Cliente_id;

                cmd.Parameters.Add("@descricao", SqlDbType.VarChar);
                cmd.Parameters["@descricao"].Value = orcamento.Descricao;

                cmd.Parameters.Add("@situacao", SqlDbType.Int);
                cmd.Parameters["@situacao"].Value = orcamento.Situacao;

                cmd.Parameters.Add("@observacao", SqlDbType.VarChar);
                cmd.Parameters["@observacao"].Value = orcamento.Observacao;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar orçamento: " + ex.Message);
            }
        }

        public void Atualizar(Orcamento orcamento)
        {
            try
            {
                this.Abrir();

                string sql = "UPDATE orcamento SET cliente_id = @cliente_id, descricao = @descricao, situacao = @situacao, observacao = @observacao WHERE orcamento_id = @orcamento_id";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@cliente_id", SqlDbType.Int);
                cmd.Parameters["@cliente_id"].Value = orcamento.Cliente.Cliente_id;

                cmd.Parameters.Add("@descricao", SqlDbType.VarChar);
                cmd.Parameters["@descricao"].Value = orcamento.Descricao;

                cmd.Parameters.Add("@situacao", SqlDbType.Int);
                cmd.Parameters["@situacao"].Value = orcamento.Situacao;

                cmd.Parameters.Add("@observacao", SqlDbType.VarChar);
                cmd.Parameters["@observacao"].Value = orcamento.Observacao;

                cmd.Parameters.Add("@orcamento_id", SqlDbType.Int);
                cmd.Parameters["@orcamento_id"].Value = orcamento.Orcamento_id;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar orçamento: " + ex.Message);
            }
        }

        public void Remover(Orcamento orcamento)
        {
            try
            {
                this.Abrir();

                string sql = "DELETE FROM orcamento WHERE orcamento_id = @orcamento_id";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@orcamento_id", SqlDbType.Int);
                cmd.Parameters["@orcamento_id"].Value = orcamento.Orcamento_id;

                cmd.ExecuteNonQuery();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover orçamento: " + ex.Message);
            }
        }

        public List<Orcamento> Listar(Orcamento orcamento)
        {
            List<Orcamento> orcamentos = new List<Orcamento>();
            try
            {
                this.Abrir();

                string sql = "SELECT o.orcamento_id, o.cliente_id, o.descricao, o.situacao, o.observacao, c.nome, c.email, c.telefone ";
                sql += "FROM orcamento AS o INNER JOIN cliente AS c ON c.cliente_id = o.cliente_id ";
                sql += "WHERE 1 = 1 ";
                
                if (orcamento.Orcamento_id > 0)
                {
                    sql += " AND o.orcamento_id = @orcamento_id ";
                }

                if (orcamento.Cliente.Cliente_id > 0)
                {
                    sql += " AND o.cliente_id = @cliente_id ";
                }

                sql += " ORDER BY orcamento_id DESC ";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                if (orcamento.Orcamento_id > 0)
                {
                    cmd.Parameters.Add("@orcamento_id", SqlDbType.Int);
                    cmd.Parameters["@orcamento_id"].Value = orcamento.Orcamento_id;
                }

                if (orcamento.Cliente.Cliente_id > 0)
                {
                    cmd.Parameters.Add("@cliente_id", SqlDbType.Int);
                    cmd.Parameters["@cliente_id"].Value = orcamento.Cliente.Cliente_id;
                }

                SqlDataReader dbReader = cmd.ExecuteReader();

                while(dbReader.Read())
                {
                    Orcamento o = new Orcamento();
                    o.Orcamento_id = dbReader.GetInt32(dbReader.GetOrdinal("orcamento_id"));
                    o.Descricao = dbReader.GetString(dbReader.GetOrdinal("descricao"));
                    o.Situacao = dbReader.GetInt32(dbReader.GetOrdinal("situacao"));
                    o.Observacao = dbReader.GetString(dbReader.GetOrdinal("observacao"));

                    Cliente c = new Cliente();
                    c.Cliente_id = dbReader.GetInt32(dbReader.GetOrdinal("cliente_id"));
                    c.Nome = dbReader.GetString(dbReader.GetOrdinal("nome"));
                    c.Email = dbReader.GetString(dbReader.GetOrdinal("email"));
                    c.Telefone = dbReader.GetString(dbReader.GetOrdinal("telefone"));

                    o.Cliente = c;

                    orcamentos.Add(o);
                }

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar orçamentos: " + ex.Message);
            }
            return orcamentos;
        }
    }
}
