using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promax.Clientes;
using System.Runtime.Serialization;

namespace Promax.Orcamentos
{
    [DataContract]
    public class Orcamento
    {
        private int orcamento_id;
        private string descricao;
        private Cliente cliente;
        private int situacao;
        private string observacao;

        [DataMember(IsRequired = true)]
        public int Orcamento_id { get => orcamento_id; set => orcamento_id = value; }

        [DataMember(IsRequired = true)]
        public string Descricao { get => descricao; set => descricao = value; }

        [DataMember(IsRequired = true)]
        public Cliente Cliente { get => cliente; set => cliente = value; }

        [DataMember(IsRequired = true)]
        public int Situacao { get => situacao; set => situacao = value; }

        [DataMember(IsRequired = true)]
        public string Observacao { get => observacao; set => observacao = value; }
    }
}
