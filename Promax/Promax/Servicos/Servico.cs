using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Promax.Servicos
{
    [DataContract]
    public class Servico
    {
        private int servico_id;
        private string titulo;
        private string descricao;
        private float preco;

        [DataMember(IsRequired = true)]
        public int Servico_id { get => servico_id; set => servico_id = value; }

        [DataMember(IsRequired = true)]
        public string Titulo { get => titulo; set => titulo = value; }

        [DataMember(IsRequired = true)]
        public string Descricao { get => descricao; set => descricao = value; }

        [DataMember(IsRequired = true)]
        public float Preco { get => preco; set => preco = value; }
    }
}
