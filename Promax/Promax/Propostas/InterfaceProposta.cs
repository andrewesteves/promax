using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promax.Propostas
{
    interface InterfaceProposta
    {
        void Cadastrar(Proposta proposta);
        void Atualizar(Proposta proposta);
        void Remover(Proposta proposta);
        List<Proposta> Listar(Proposta proposta);
    }
}
