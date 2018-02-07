using Promax.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promax.Servicos
{
    class DadosServico : SqlServerConexao, InterfaceServico
    {
        public void Cadastrar(Servico servico)
        {
            try
            {
                this.Abrir();

                string sql = "INSERT INTO servico (titulo, descricao, preco) VALUES (@titulo, @descricao, @preco)";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@titulo", SqlDbType.VarChar);
                cmd.Parameters["@titulo"].Value = servico.Titulo;

                cmd.Parameters.Add("@descricao", SqlDbType.VarChar);
                cmd.Parameters["@descricao"].Value = servico.Descricao;

                cmd.Parameters.Add("@preco", SqlDbType.Float);
                cmd.Parameters["@preco"].Value = servico.Preco;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar serviço: " + ex.Message);
            }
        }

        public void Atualizar(Servico servico)
        {
            try
            {
                this.Abrir();

                string sql  = "UPDATE servico SET titulo = @titulo, descricao = @descricao, preco = @preco ";
                sql += "WHERE servico_id = @servico_id";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@titulo", SqlDbType.VarChar);
                cmd.Parameters["@titulo"].Value = servico.Titulo;

                cmd.Parameters.Add("@descricao", SqlDbType.VarChar);
                cmd.Parameters["@descricao"].Value = servico.Descricao;

                cmd.Parameters.Add("@preco", SqlDbType.Float);
                cmd.Parameters["@preco"].Value = servico.Preco;

                cmd.Parameters.Add("@servico_id", SqlDbType.Int);
                cmd.Parameters["@servico_id"].Value = servico.Servico_id;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar serviço: " + ex.Message);
            }
        }

        public void Remover(Servico servico)
        {
            try
            {
                this.Abrir();

                string sql = "DELETE FROM servico WHERE servico_id = @servico_id";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@servico_id", SqlDbType.Int);
                cmd.Parameters["@servico_id"].Value = servico.Servico_id;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover serviço: " + ex.Message);
            }
        }

        public List<Servico> Listar(Servico servico)
        {
            List<Servico> servicos = new List<Servico>();

            try
            {
                this.Abrir();

                string sql = "SELECT servico_id, titulo, descricao, preco FROM servico WHERE 1 = 1 ";

                if(!string.IsNullOrEmpty(servico.Titulo))
                {
                    sql += "AND titulo LIKE @titulo ";
                }

                if(!string.IsNullOrEmpty(servico.Descricao))
                {
                    sql += "AND descricao LIKE @descricao ";
                }

                if(servico.Preco > 0)
                {
                    sql += "AND preco = @preco ";
                }

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                if(!string.IsNullOrEmpty(servico.Titulo))
                {
                    cmd.Parameters.Add("@titulo", SqlDbType.VarChar);
                    cmd.Parameters["@titulo"].Value = "%" + servico.Titulo + "%";
                }

                if (!string.IsNullOrEmpty(servico.Descricao))
                {
                    cmd.Parameters.Add("@descricao", SqlDbType.VarChar);
                    cmd.Parameters["@descricao"].Value = "%" + servico.Descricao + "%";
                }

                if (servico.Preco > 0)
                {
                    cmd.Parameters.Add("@preco", SqlDbType.Float);
                    cmd.Parameters["@preco"].Value = servico.Preco;
                }

                SqlDataReader dbReader = cmd.ExecuteReader();

                while(dbReader.Read())
                {
                    Servico s = new Servico();
                    s.Servico_id = dbReader.GetInt32(dbReader.GetOrdinal("servico_id"));
                    s.Titulo = dbReader.GetString(dbReader.GetOrdinal("titulo"));
                    s.Descricao = dbReader.GetString(dbReader.GetOrdinal("descricao"));
                    s.Preco = float.Parse(dbReader["preco"].ToString());
                    servicos.Add(s);
                }

                dbReader.Close();
                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar serviços:" + ex.Message);
            }

            return servicos;
        }
    }
}
