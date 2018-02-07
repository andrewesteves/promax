using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promax.Orcamentos
{
    public class NegocioOrcamento : InterfaceOrcamento
    {

        public void Cadastrar(Orcamento orcamento)
        {
            if(orcamento.Cliente.Cliente_id < 1)
            {
                throw new Exception("Informar o cliente");
            }

            if (string.IsNullOrEmpty(orcamento.Descricao))
            {
                throw new Exception("Informar a descrição");
            }

            DadosOrcamento d = new DadosOrcamento();
            d.Cadastrar(orcamento);
        }

        public void Atualizar(Orcamento orcamento)
        {
            if (orcamento.Orcamento_id < 1)
            {
                throw new Exception("Informar código de orçamento");
            }

            if (orcamento.Cliente.Cliente_id < 1)
            {
                throw new Exception("Informar o cliente");
            }

            if (string.IsNullOrEmpty(orcamento.Descricao))
            {
                throw new Exception("Informar a descrição");
            }

            DadosOrcamento d = new DadosOrcamento();
            d.Atualizar(orcamento);
        }

        public void Remover(Orcamento orcamento)
        {
            if (orcamento.Orcamento_id < 1)
            {
                throw new Exception("Informar código de orçamento");
            }

            DadosOrcamento d = new DadosOrcamento();
            d.Remover(orcamento);
        }

        public List<Orcamento> Listar(Orcamento orcamento)
        {
            if (orcamento.Orcamento_id < 1)
            {
                orcamento.Orcamento_id = 0;
            }

            if (orcamento.Cliente.Cliente_id < 1)
            {
                orcamento.Cliente.Cliente_id = 0;
            }

            DadosOrcamento d = new DadosOrcamento();
            return d.Listar(orcamento);
        }
    }
}
