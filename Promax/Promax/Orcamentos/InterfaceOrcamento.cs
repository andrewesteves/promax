using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promax.Orcamentos
{
    interface InterfaceOrcamento
    {
        void Cadastrar(Orcamento orcamento);
        void Atualizar(Orcamento orcamento);
        void Remover(Orcamento orcamento);
        List<Orcamento> Listar(Orcamento orcamento);
    }
}
