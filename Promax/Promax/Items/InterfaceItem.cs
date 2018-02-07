using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promax.Items
{
    interface InterfaceItem
    {
        void Cadastrar(Item item);
        void Atualizar(Item item);
        void Remover(Item item);
        List<Item> Listar(Item item);
    }
}
