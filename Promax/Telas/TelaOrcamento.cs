using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telas.localhost;

using System.IO;
using System.Threading;
using System.Xml;

namespace Telas
{
    public partial class TelaOrcamento : Form
    {
        List<Orcamento> orcamentos = new List<Orcamento>();
        List<Cliente> clientes = new List<Cliente>();
        Thread xmlThread;
        string caminho = "orcamentos.xml";
        Orcamento orcamentoAtual = new Orcamento();

        BinaryWriter binaryWriter;

        public TelaOrcamento(BinaryWriter binaryWriter)
        {
            InitializeComponent();
            this.popularComboBoxClientes();
            this.popularComboBoxSituacao();
            this.binaryWriter = binaryWriter;
        }

        private void TelaOrcamento_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            xmlThread = new Thread(new ThreadStart(SalvarXml));

            if (File.Exists(caminho))
            {
                doc.Load(caminho);
                richTextBoxDescricao.Text = doc.SelectSingleNode("orcamentos/orcamento/descricao").InnerText;
            }

            xmlThread.Start();
        }

        private void TelaOrcamento_FormClosed(object sender, FormClosedEventArgs e)
        {
            xmlThread.Abort();
        }

        #region Dados no XML
        private void SalvarXml()
        {
            while (Visible)
            {
                CarregarXml();

                XmlDocument doc = new XmlDocument();
                doc.Load(caminho);
                XmlNode no = doc.SelectSingleNode("/orcamentos/orcamento");

                if (no.SelectSingleNode("./descricao").InnerText.Equals(this.orcamentoAtual.Descricao) == false)
                {
                    no.SelectSingleNode("./descricao").InnerText = this.orcamentoAtual.Descricao;
                }

                doc.Save(caminho);
                Thread.Sleep(1500);
            }
        }

        private void CarregarXml()
        {
            Invoke(new MethodInvoker(delegate {
                this.orcamentoAtual.Descricao = richTextBoxDescricao.Text;
            }));
        }
        #endregion

        private void popularComboBoxSituacao()
        {
            comboBoxSituacao.Items.Clear();
            comboBoxSituacao.Items.Add("Aberto");
            comboBoxSituacao.Items.Add("Aprovado");
            comboBoxSituacao.Items.Add("Revisão");
            comboBoxSituacao.Items.Add("Cancelado");
        }

        private void popularComboBoxClientes()
        {
            try
            {
                Cliente c = new Cliente();
                Service1 ws = new Service1();
                this.clientes = ws.Listar(c).ToList();
                foreach (Cliente cliente in this.clientes)
                {
                    comboBoxClientes.Items.Add(cliente.Nome + " | " + cliente.Email);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pos = comboBoxClientes.SelectedIndex;
            Cliente c = this.clientes.ElementAt(pos);
            MessageBox.Show(c.Nome);
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            int posicao = comboBoxClientes.SelectedIndex;
            if(posicao >= 0)
            {
                try
                {
                    Orcamento o = new Orcamento();
                    if (string.IsNullOrEmpty(richTextBoxDescricao.Text)) throw new Exception("Informar descrição");
                    o.Cliente = this.clientes.ElementAt(posicao);
                    o.Descricao = richTextBoxDescricao.Text;
                    o.Situacao = comboBoxSituacao.SelectedIndex >= 0 ? Int32.Parse(comboBoxSituacao.SelectedIndex.ToString()) : 0;
                    o.Observacao = string.IsNullOrEmpty(richTextBoxObservacao.Text) ? "" : richTextBoxObservacao.Text;

                    Service1 ws = new Service1();
                    ws.CadastrarOrcamento(o);
                    this.binaryWriter.Write("Novo orçamento do cliente: " + o.Cliente.Nome);
                    this.LimparForm();
                    this.ListViewOrcamentosShow();
                    MessageBox.Show("Orçamento cadastrado com sucesso", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione o cliente", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparForm()
        {
            comboBoxClientes.SelectedIndex = -1;
            richTextBoxDescricao.Text = "";
            comboBoxSituacao.SelectedIndex = -1;
            richTextBoxObservacao.Text = "";
        }

        private void ListViewOrcamentosShow()
        {
            try
            {
                Orcamento o = new Orcamento();
                int posicao = comboBoxClientes.SelectedIndex;
                o.Cliente = posicao >= 0 ? this.clientes.ElementAt(posicao) : new Cliente();
                Service1 ws = new Service1();
                this.orcamentos = ws.ListarOrcamento(o).ToList();
                listViewOrcamentos.Items.Clear();
                foreach (Orcamento orcamento in this.orcamentos)
                {
                    ListViewItem item = listViewOrcamentos.Items.Add(orcamento.Orcamento_id.ToString());
                    item.SubItems.Add(orcamento.Cliente.Nome.ToString());
                    item.SubItems.Add(orcamento.Cliente.Email.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            this.ListViewOrcamentosShow();
        }

        private void listViewOrcamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int posicao = listViewOrcamentos.FocusedItem.Index;
            Orcamento o = this.orcamentos.ElementAt(posicao);
            comboBoxClientes.SelectedIndex = comboBoxClientes.FindString(o.Cliente.Nome + " | " + o.Cliente.Email);
            richTextBoxDescricao.Text = o.Descricao;
            comboBoxSituacao.SelectedIndex = o.Situacao;
            richTextBoxObservacao.Text = o.Observacao;
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            int posicao = comboBoxClientes.SelectedIndex;
            if (posicao >= 0)
            {
                try
                {
                    Orcamento o = this.orcamentos.ElementAt(listViewOrcamentos.FocusedItem.Index);
                    if (string.IsNullOrEmpty(richTextBoxDescricao.Text)) throw new Exception("Informar descrição");
                    o.Cliente = this.clientes.ElementAt(posicao);
                    o.Descricao = richTextBoxDescricao.Text;
                    o.Situacao = comboBoxSituacao.SelectedIndex >= 0 ? Int32.Parse(comboBoxSituacao.SelectedIndex.ToString()) : 0;
                    o.Observacao = string.IsNullOrEmpty(richTextBoxObservacao.Text) ? "" : richTextBoxObservacao.Text;

                    Service1 ws = new Service1();
                    ws.AtualizarOrcamento(o);
                    this.LimparForm();
                    this.ListViewOrcamentosShow();
                    MessageBox.Show("Orçamento atualizado com sucesso", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione o cliente", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja realmente remover?", "ATENÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) != DialogResult.OK)
                {
                    throw new Exception("Operação cancelada pelo operador");
                }
                int posicao = listViewOrcamentos.FocusedItem.Index;
                Orcamento c = this.orcamentos.ElementAt(posicao);

                Service1 ws = new Service1();
                ws.RemoverOrcamento(c);
                LimparForm();
                this.ListViewOrcamentosShow();
                MessageBox.Show("Orçamento removido com sucesso", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            this.LimparForm();
        }
    }
}
