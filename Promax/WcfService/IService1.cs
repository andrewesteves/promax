using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Promax.Clientes;
using Promax.Servicos;
using Promax.Orcamentos;
using Promax.Propostas;
using Promax.Items;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IService1
    {
        #region assinaturas do cliente
        [OperationContract]
        void Cadastrar(Cliente cliente);

        [OperationContract]
        void Atualizar(Cliente cliente);

        [OperationContract]
        void Remover(Cliente cliente);

        [OperationContract]
        List<Cliente> Listar(Cliente cliente);
        #endregion

        #region assinaturas do serviço
        [OperationContract]
        void CadastrarServico(Servico servico);

        [OperationContract]
        void AtualizarServico(Servico servico);

        [OperationContract]
        void RemoverServico(Servico servico);

        [OperationContract]
        List<Servico> ListarServico(Servico servico);
        #endregion

        #region assinaturas do orçamento
        [OperationContract]
        void CadastrarOrcamento(Orcamento orcamento);

        [OperationContract]
        void AtualizarOrcamento(Orcamento orcamento);

        [OperationContract]
        void RemoverOrcamento(Orcamento orcamento);

        [OperationContract]
        List<Orcamento> ListarOrcamento(Orcamento orcamento);
        #endregion

        #region assinaturas de proposta
        [OperationContract]
        void CadastrarProposta(Proposta proposta);

        [OperationContract]
        void AtualizarProposta(Proposta proposta);

        [OperationContract]
        void RemoverProposta(Proposta proposta);

        [OperationContract]
        List<Proposta> ListarProposta(Proposta proposta);

        [OperationContract]
        Proposta PegarProposta(Proposta proposta);

        [OperationContract]
        List<Item> ListarItemsProposta(Proposta proposta);

        [OperationContract]
        void RemoverItem(Item item);
        #endregion

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
