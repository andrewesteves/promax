using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promax.Orcamentos;
using Promax.Items;
using System.Runtime.Serialization;

namespace Promax.Propostas
{
    [DataContract]
    public class Proposta
    {
        private int proposta_id;
        private Orcamento orcamento;
        private string titulo;
        private List<Item> items;

        public Proposta()
        {
            this.orcamento = new Orcamento();
        }

        [DataMember(IsRequired = true)]
        public int Proposta_id { get => proposta_id; set => proposta_id = value; }

        [DataMember(IsRequired = true)]
        public string Titulo { get => titulo; set => titulo = value; }

        [DataMember(IsRequired = true)]
        public Orcamento Orcamento { get => orcamento; set => orcamento = value; }

        [DataMember(IsRequired = true)]
        public List<Item> Items { get => items; set => items = value; }
    }
}
