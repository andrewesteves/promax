using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promax.Items
{
    public class NegocioItem : InterfaceItem
    {
        public void Cadastrar(Item item)
        {
            if(item.Preco < 1)
            {
                throw new Exception("Informar preço");
            }

            if(item.Quantidade < 1)
            {
                throw new Exception("Informar quantidade");
            }

            if(item.Servico.Servico_id < 1)
            {
                throw new Exception("Informar serviço");
            }

            if(item.Proposta.Proposta_id < 1)
            {
                throw new Exception("Informar proposta");
            }

            //DadosItem d = new DadosItem();
            //d.Cadastrar(item);
        }

        public void Atualizar(Item item)
        {
            if(item.Item_id < 1)
            {
                throw new Exception("Informar código do item");
            }

            if (item.Preco < 1)
            {
                throw new Exception("Informar preço");
            }

            if (item.Quantidade < 1)
            {
                throw new Exception("Informar quantidade");
            }

            if (item.Servico.Servico_id < 1)
            {
                throw new Exception("Informar serviço");
            }

            if (item.Proposta.Proposta_id < 1)
            {
                throw new Exception("Informar proposta");
            }

            DadosItem d = new DadosItem();
            d.Atualizar(item);
        }

        public void Remover(Item item)
        {
            if (item.Item_id < 1)
            {
                throw new Exception("Informar código do item");
            }

            DadosItem d = new DadosItem();
            d.Remover(item);
        }

        public List<Item> Listar(Item item)
        {
            DadosItem d = new DadosItem();
            return d.Listar(item);
        }
    }
}
