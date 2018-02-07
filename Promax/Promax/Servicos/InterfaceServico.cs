using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promax.Servicos
{
    interface InterfaceServico
    {
        void Cadastrar(Servico servico);
        void Atualizar(Servico servico);
        void Remover(Servico servico);
        List<Servico> Listar(Servico servico);
    }
}
