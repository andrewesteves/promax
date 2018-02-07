using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promax.BD;
using System.Data.SqlClient;
using System.Data;
using Promax.Servicos;
using Promax.Propostas;

namespace Promax.Items
{
    class DadosItem : SqlServerConexao, InterfaceItem
    {
        public void Cadastrar(Item item)
        {
            try
            {
                this.Abrir();

                string sql = "INSERT INTO item (servico_id, proposta_id, quantidade, preco) ";
                sql += " VALUES (@servico_id, @proposta_id, @quantidade, @preco) ";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@servico_id", SqlDbType.Int);
                cmd.Parameters["@servico_id"].Value = item.Servico.Servico_id;

                cmd.Parameters.Add("@proposta_id", SqlDbType.Int);
                cmd.Parameters["@proposta_id"].Value = item.Proposta.Proposta_id;

                cmd.Parameters.Add("@quantidade", SqlDbType.Int);
                cmd.Parameters["@quantidade"].Value = item.Quantidade;

                cmd.Parameters.Add("@preco", SqlDbType.Float);
                cmd.Parameters["@preco"].Value = item.Preco;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar item: " + ex.Message);
            }
        }

        public void Atualizar(Item item)
        {
            try
            {
                this.Abrir();

                string sql = "UPDATE item SET servico_id = @servico_id, proposta_id = @proposta_id, quantidade = @quantidade, preco = @preco WHERE item_id = @item_id";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@servico_id", SqlDbType.Int);
                cmd.Parameters["@servico_id"].Value = item.Servico.Servico_id;

                cmd.Parameters.Add("@proposta_id", SqlDbType.Int);
                cmd.Parameters["@proposta_id"].Value = item.Proposta.Proposta_id;

                cmd.Parameters.Add("@quantidade", SqlDbType.Int);
                cmd.Parameters["@quantidade"].Value = item.Quantidade;

                cmd.Parameters.Add("@preco", SqlDbType.Float);
                cmd.Parameters["@preco"].Value = item.Preco;

                cmd.Parameters.Add("@item_id", SqlDbType.Int);
                cmd.Parameters["@item_id"].Value = item.Item_id;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar item: " + ex.Message);
            }
        }

        public void Remover(Item item)
        {
            try
            {
                this.Abrir();

                string sql = "DELETE FROM item WHERE item_id = @item_id";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@item_id", SqlDbType.Int);
                cmd.Parameters["@item_id"].Value = item.Item_id;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover item: " + ex.Message);
            }
        }

        public List<Item> Listar(Item item)
        {
            List<Item> items = new List<Item>();

            try
            {
                this.Abrir();

                string sql = "SELECT i.item_id, i.quantidade, i.preco, ";
                sql += " p.proposta_id, p.titulo AS proposta_titulo, ";
                sql += " s.servico_id, s.titulo AS servico_titulo, s.descricao, s.preco AS servico_preco ";
                sql += " FROM item AS i ";
                sql += " INNER JOIN proposta AS p ON p.proposta_id = i.proposta_id ";
                sql += " INNER JOIN servico AS s ON s.servico_id = i.servico_id ";
                sql += " WHERE 1 = 1 ";

                if(item.Proposta.Proposta_id > 0)
                {
                    sql += " AND p.proposta_id = @proposta_id ";
                }

                if (item.Item_id > 0)
                {
                    sql += " AND i.item_id = @item_id ";
                }

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                if(item.Proposta.Proposta_id > 0)
                {
                    cmd.Parameters.Add("@proposta_id", SqlDbType.Int);
                    cmd.Parameters["@proposta_id"].Value = item.Proposta.Proposta_id;
                }

                if (item.Item_id > 0)
                {
                    cmd.Parameters.Add("@item_id", SqlDbType.Int);
                    cmd.Parameters["@item_id"].Value = item.Item_id;
                }

                SqlDataReader dbReader = cmd.ExecuteReader();

                while(dbReader.Read())
                {
                    Item i = new Item();
                    i.Item_id = dbReader.GetInt32(dbReader.GetOrdinal("item_id"));
                    i.Quantidade = dbReader.GetInt32(dbReader.GetOrdinal("quantidade"));
                    i.Preco = float.Parse(dbReader["preco"].ToString());

                    Servico s = new Servico();
                    s.Servico_id = dbReader.GetInt32(dbReader.GetOrdinal("servico_id"));
                    s.Titulo = dbReader.GetString(dbReader.GetOrdinal("servico_titulo"));
                    s.Descricao = dbReader.GetString(dbReader.GetOrdinal("descricao"));
                    s.Preco = float.Parse(dbReader["servico_preco"].ToString());

                    Proposta p = new Proposta();
                    p.Proposta_id = dbReader.GetInt32(dbReader.GetOrdinal("proposta_id"));
                    p.Titulo = dbReader.GetString(dbReader.GetOrdinal("proposta_titulo"));

                    i.Servico = s;
                    i.Proposta = p;

                    items.Add(i);
                }

                dbReader.Close();
                cmd.Dispose();

                this.Fechar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar itens: " + ex.Message);
            }

            return items;
        }
    }
}
