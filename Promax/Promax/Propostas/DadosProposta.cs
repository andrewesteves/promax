using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promax.BD;
using System.Data;
using System.Data.SqlClient;

using Promax.Orcamentos;
using Promax.Items;

namespace Promax.Propostas
{
    class DadosProposta : SqlServerConexao, InterfaceProposta
    {
        public void Cadastrar(Proposta proposta)
        {
            try
            {
                this.Abrir();

                string sql = "INSERT INTO proposta (orcamento_id, titulo) OUTPUT INSERTED.proposta_id VALUES (@orcamento_id, @titulo) ";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@orcamento_id", SqlDbType.Int);
                cmd.Parameters["@orcamento_id"].Value = proposta.Orcamento.Orcamento_id;

                cmd.Parameters.Add("@titulo", SqlDbType.VarChar);
                cmd.Parameters["@titulo"].Value = proposta.Titulo;

                //cmd.ExecuteNonQuery();

                int proposta_id = Convert.ToInt32(cmd.ExecuteScalar());

                DadosItem di = new DadosItem();
                foreach (Item i in proposta.Items)
                {
                    i.Proposta = new Proposta();
                    i.Proposta.Proposta_id = proposta_id;
                    di.Cadastrar(i);
                }

                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar proposta: " + ex.Message);
            }
        }

        public void Atualizar(Proposta proposta)
        {
            try
            {
                this.Abrir();

                string sql = "UPDATE proposta SET titulo = @titulo WHERE proposta_id = @proposta_id";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@titulo", SqlDbType.VarChar);
                cmd.Parameters["@titulo"].Value = proposta.Titulo;

                cmd.Parameters.Add("@proposta_id", SqlDbType.Int);
                cmd.Parameters["@proposta_id"].Value = proposta.Proposta_id;

                DadosItem di = new DadosItem();
                foreach (Item i in proposta.Items)
                {
                    i.Proposta = new Proposta();
                    i.Proposta.Proposta_id = proposta.Proposta_id;
                    di.Cadastrar(i);
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar proposta: " + ex.Message);
            }
        }

        public void Remover(Proposta proposta)
        {
            try
            {
                this.Abrir();

                string sql = "DELETE FROM proposta WHERE proposta_id = @proposta_id";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@proposta_id", SqlDbType.Int);
                cmd.Parameters["@proposta_id"].Value = proposta.Proposta_id;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover proposta: " + ex.Message);
            }
        }

        public List<Proposta> Listar(Proposta proposta)
        {
            List<Proposta> propostas = new List<Proposta>();
            try
            {
                this.Abrir();

                string sql = "SELECT p.proposta_id, p.orcamento_id, p.titulo ";
                sql += "FROM proposta AS p ";
                sql += "WHERE 1 = 1 ";

                if (proposta.Orcamento.Orcamento_id > 0)
                {
                    sql += " AND p.orcamento_id = @orcamento_id ";
                }

                if (!string.IsNullOrEmpty(proposta.Titulo))
                {
                    sql += " AND p.titulo = @titulo ";
                }

                sql += " ORDER BY proposta_id DESC ";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                if (proposta.Orcamento.Orcamento_id > 0)
                {
                    cmd.Parameters.Add("@orcamento_id", SqlDbType.Int);
                    cmd.Parameters["@orcamento_id"].Value = proposta.Orcamento.Orcamento_id;
                }

                if (!string.IsNullOrEmpty(proposta.Titulo))
                {
                    cmd.Parameters.Add("@titulo", SqlDbType.VarChar);
                    cmd.Parameters["@titulo"].Value = proposta.Titulo;
                }

                SqlDataReader dbReader = cmd.ExecuteReader();

                while (dbReader.Read())
                {
                    Proposta p = new Proposta();
                    p.Proposta_id = dbReader.GetInt32(dbReader.GetOrdinal("proposta_id"));
                    p.Orcamento = new Orcamento();
                    p.Orcamento.Orcamento_id = dbReader.GetInt32(dbReader.GetOrdinal("orcamento_id"));
                    p.Titulo = dbReader.GetString(dbReader.GetOrdinal("titulo"));

                    //List<Item> items = new List<Item>();
                    //DadosItem di = new DadosItem();
                    //Item i = new Item();
                    //i.Proposta.Proposta_id = p.Proposta_id;
                    //items = di.Listar(i);

                    //p.Items = items;

                    propostas.Add(p);
                }

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar propostas: " + ex.Message);
            }
            return propostas;
        }
    }
}
