using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promax.Items;

namespace Promax.Propostas
{
    public class NegocioProposta : InterfaceProposta
    {
        public void Cadastrar(Proposta proposta)
        {
            if(proposta.Orcamento.Orcamento_id < 0)
            {
                throw new Exception("Informar orçamento");
            }

            if(string.IsNullOrEmpty(proposta.Titulo))
            {
                throw new Exception("Informar título");
            }

            DadosProposta d = new DadosProposta();
            d.Cadastrar(proposta);
        }

        public void Atualizar(Proposta proposta)
        {
            if (proposta.Proposta_id < 0)
            {
                throw new Exception("Informar código de proposta");
            }

            if (proposta.Orcamento.Orcamento_id < 0)
            {
                throw new Exception("Informar orçamento");
            }

            if (string.IsNullOrEmpty(proposta.Titulo))
            {
                throw new Exception("Informar título");
            }

            DadosProposta d = new DadosProposta();
            d.Atualizar(proposta);
        }

        public void Remover(Proposta proposta)
        {
            if (proposta.Proposta_id < 0)
            {
                throw new Exception("Informar código de proposta");
            }

            DadosProposta d = new DadosProposta();
            d.Remover(proposta);
        }

        public List<Proposta> Listar(Proposta proposta)
        {
            if (proposta.Proposta_id < 1)
            {
                proposta.Proposta_id = 0;
            }

            if (proposta.Orcamento.Orcamento_id < 1)
            {
                proposta.Orcamento.Orcamento_id = 0;
            }

            DadosProposta d = new DadosProposta();
            return d.Listar(proposta);
        }
    }
}
