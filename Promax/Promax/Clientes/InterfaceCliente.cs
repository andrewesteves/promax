using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promax.Clientes
{
    interface InterfaceCliente
    {
        void Cadastrar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Remover(Cliente cliente);
        List<Cliente> Listar(Cliente cliente);
    }
}
