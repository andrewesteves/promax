using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promax.Clientes
{
    public class NegocioCliente: InterfaceCliente
    {
        public void Cadastrar(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
            {
                throw new Exception("Informar o nome");
            }

            if (string.IsNullOrEmpty(cliente.Email))
            {
                throw new Exception("Informar e-mail");
            }

            if (string.IsNullOrEmpty(cliente.Telefone))
            {
                throw new Exception("Informar telefone");
            }

            DadosCliente d = new DadosCliente();
            d.Cadastrar(cliente);
        }

        public void Atualizar(Cliente cliente)
        {
            if (cliente.Cliente_id < 1)
            {
                throw new Exception("Informar código de cliente");
            }

            if (string.IsNullOrEmpty(cliente.Nome))
            {
                throw new Exception("Infomar nome");
            }

            if (string.IsNullOrEmpty(cliente.Email))
            {
                throw new Exception("Informar e-mail");
            }

            if (string.IsNullOrEmpty(cliente.Telefone))
            {
                throw new Exception("Informar telefone");
            }

            DadosCliente d = new DadosCliente();
            d.Atualizar(cliente);
        }

        public void Remover(Cliente cliente)
        {
            if (cliente.Cliente_id < 1)
            {
                throw new Exception("Informar código de cliente");
            }

            DadosCliente d = new DadosCliente();
            d.Remover(cliente);
        }

        public List<Cliente> Listar(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
            {
                cliente.Nome = "";
            }

            if (string.IsNullOrEmpty(cliente.Email))
            {
                cliente.Email = "";
            }

            if (string.IsNullOrEmpty(cliente.Telefone))
            {
                cliente.Telefone = "";
            }

            DadosCliente d = new DadosCliente();
            return d.Listar(cliente);
        }
    }
}
