using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Promax.Clientes;
using Promax.Servicos;
using Promax.Orcamentos;
using Promax.Propostas;
using Promax.Items;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        #region assinaturas do cliente
        public void Atualizar(Cliente cliente)
        {
            new NegocioCliente().Atualizar(cliente);
        }

        public void Cadastrar(Cliente cliente)
        {
            new NegocioCliente().Cadastrar(cliente);
        }
        public void Remover(Cliente cliente)
        {
            new NegocioCliente().Remover(cliente);
        }

        public List<Cliente> Listar(Cliente cliente)
        {
            return new NegocioCliente().Listar(cliente);
        }
        #endregion

        #region assinaturas do serviço
        public void AtualizarServico(Servico servico)
        {
            new NegocioServico().Atualizar(servico);
        }

        public void CadastrarServico(Servico servico)
        {
            new NegocioServico().Cadastrar(servico);
        }

        public List<Servico> ListarServico(Servico servico)
        {
            return new NegocioServico().Listar(servico);
        }

        public void RemoverServico(Servico servico)
        {
            new NegocioServico().Remover(servico);
        }
        #endregion

        #region assinaturas do orçamento
        public void AtualizarOrcamento(Orcamento orcamento)
        {
            new NegocioOrcamento().Atualizar(orcamento);
        }

        public void CadastrarOrcamento(Orcamento orcamento)
        {
            new NegocioOrcamento().Cadastrar(orcamento);
        }

        public List<Orcamento> ListarOrcamento(Orcamento orcamento)
        {
            return new NegocioOrcamento().Listar(orcamento);
        }

        public void RemoverOrcamento(Orcamento orcamento)
        {
            new NegocioOrcamento().Remover(orcamento);
        }
        #endregion

        #region assinaturas de proposta
        public void AtualizarProposta(Proposta proposta)
        {
            new NegocioProposta().Atualizar(proposta);
        }

        public void CadastrarProposta(Proposta proposta)
        {
            new NegocioProposta().Cadastrar(proposta);
        }

        public List<Proposta> ListarProposta(Proposta proposta)
        {
            return new NegocioProposta().Listar(proposta);
        }

        public List<Item> ListarItemsProposta(Proposta proposta)
        {
            Item item = new Item();
            item.Proposta = new Proposta();
            item.Proposta.Proposta_id = proposta.Proposta_id;
            return new NegocioItem().Listar(item);
        }

        public void RemoverProposta(Proposta proposta)
        {
            new NegocioProposta().Remover(proposta);
        }

        public Proposta PegarProposta(Proposta proposta)
        {
            List < Proposta > props = new NegocioProposta().Listar(proposta);
            Proposta p = new Proposta();
            for (int i = 0; i < props.Count; i++)
            { 
                p = props.ElementAt(i);
                Item item = new Item();
                item.Proposta = p;
                p.Items = new NegocioItem().Listar(item);
            }
            return p;
        }
        #endregion

        public void RemoverItem(Item item)
        {
            new NegocioItem().Remover(item);
        }
    }
}
