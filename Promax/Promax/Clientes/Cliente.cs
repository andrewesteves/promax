using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Promax.Clientes
{
    [DataContract]
    public class Cliente
    {
        private int cliente_id;
        private string nome;
        private string email;
        private string telefone;

        [DataMember (IsRequired = true)]
        public int Cliente_id { get => cliente_id; set => cliente_id = value; }
        [DataMember(IsRequired = true)]
        public string Nome { get => nome; set => nome = value; }
        [DataMember(IsRequired = true)]
        public string Email { get => email; set => email = value; }
        [DataMember(IsRequired = true)]
        public string Telefone { get => telefone; set => telefone = value; }
    }
}
