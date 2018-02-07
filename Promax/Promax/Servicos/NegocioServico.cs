using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promax.Servicos
{
    public class NegocioServico : InterfaceServico
    {
        public void Cadastrar(Servico servico)
        {
            if(string.IsNullOrEmpty(servico.Titulo))
            {
                throw new Exception("Informar título");
            }

            if(string.IsNullOrEmpty(servico.Descricao))
            {
                throw new Exception("Informar a descrição");
            }

            if(string.IsNullOrEmpty(servico.Preco.ToString()))
            {
                throw new Exception("Informar o preço");
            }

            DadosServico d = new DadosServico();
            d.Cadastrar(servico);
        }

        public void Atualizar(Servico servico)
        {
            if (servico.Servico_id < 1)
            {
                throw new Exception("Informar código do serviço");
            }

            if (string.IsNullOrEmpty(servico.Titulo))
            {
                throw new Exception("Informar título");
            }

            if (string.IsNullOrEmpty(servico.Descricao))
            {
                throw new Exception("Informar a descrição");
            }

            if (string.IsNullOrEmpty(servico.Preco.ToString()))
            {
                throw new Exception("Informar o preço");
            }

            DadosServico d = new DadosServico();
            d.Atualizar(servico);
        }

        public void Remover(Servico servico)
        {
            if (servico.Servico_id < 1)
            {
                throw new Exception("Informar código do serviço");
            }

            DadosServico d = new DadosServico();
            d.Remover(servico);
        }

        public List<Servico> Listar(Servico servico)
        {
            if(string.IsNullOrEmpty(servico.Titulo))
            {
                servico.Titulo = "";
            }

            if(string.IsNullOrEmpty(servico.Descricao))
            {
                servico.Descricao = "";
            }

            DadosServico d = new DadosServico();
            return d.Listar(servico);
        }
    }
}
