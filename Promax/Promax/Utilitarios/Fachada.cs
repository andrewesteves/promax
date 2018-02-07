using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promax.Clientes;
using Promax.Servicos;
using Promax.Orcamentos;

namespace Promax.Utilitarios
{
    class Fachada : InterfaceCliente, InterfaceServico, InterfaceOrcamento
    {
        public void Cadastrar(Cliente cliente)
        {
            NegocioCliente n = new NegocioCliente();
            n.Cadastrar(cliente);
        }

        public void Atualizar(Cliente cliente)
        {
            NegocioCliente n = new NegocioCliente();
            n.Atualizar(cliente);
        }

        public void Remover(Cliente cliente)
        {
            NegocioCliente n = new NegocioCliente();
            n.Remover(cliente);
        }

        public List<Cliente> Listar(Cliente cliente)
        {
            NegocioCliente n = new NegocioCliente();
            return n.Listar(cliente);
        }

        public void Cadastrar(Servico servico)
        {
            NegocioServico n = new NegocioServico();
            n.Cadastrar(servico);
        }

        public void Atualizar(Servico servico)
        {
            NegocioServico n = new NegocioServico();
            n.Atualizar(servico);
        }

        public void Remover(Servico servico)
        {
            NegocioServico n = new NegocioServico();
            n.Remover(servico);
        }

        public List<Servico> Listar(Servico servico)
        {
            NegocioServico n = new NegocioServico();
            return n.Listar(servico);
        }

        public void Cadastrar(Orcamento orcamento)
        {
            NegocioOrcamento n = new NegocioOrcamento();
            n.Cadastrar(orcamento);
        }

        public void Atualizar(Orcamento orcamento)
        {
            NegocioOrcamento n = new NegocioOrcamento();
            n.Atualizar(orcamento);
        }

        public void Remover(Orcamento orcamento)
        {
            NegocioOrcamento n = new NegocioOrcamento();
            n.Remover(orcamento);
        }

        public List<Orcamento> Listar(Orcamento orcamento)
        {
            NegocioOrcamento n = new NegocioOrcamento();
            return n.Listar(orcamento);
        }
    }
}
