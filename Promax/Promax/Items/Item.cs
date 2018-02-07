using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promax.Servicos;
using Promax.Propostas;
using System.Runtime.Serialization;

namespace Promax.Items
{
    [DataContract]
    public class Item
    {
        private int item_id;
        private Servico servico;
        private Proposta proposta;
        private int quantidade;
        private float preco;
        private float total;

        public Item()
        {
            this.proposta = new Proposta();
        }

        [DataMember(IsRequired = true)]
        public int Item_id { get => item_id; set => item_id = value; }

        [DataMember(IsRequired = true)]
        public int Quantidade { get => quantidade; set => quantidade = value; }

        [DataMember(IsRequired = true)]
        public float Preco { get => preco; set => preco = value; }

        [DataMember(IsRequired = true)]
        public Servico Servico { get => servico; set => servico = value; }

        [DataMember(IsRequired = true)]
        public Proposta Proposta { get => proposta; set => proposta = value; }
        public float Total { get => this.quantidade * this.preco; set => total = value; }
    }
}
