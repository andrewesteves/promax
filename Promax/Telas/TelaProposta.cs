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
    public partial class TelaProposta : Form
    {
        List<Proposta> propostas = new List<Proposta>();
        List<Orcamento> orcamentos = new List<Orcamento>();
        List<Servico> servicos = new List<Servico>();
        List<Item> carrinho = new List<Item>();
        List<Item> items = new List<Item>();

        Thread xmlThread;
        string caminho = "propostas.xml";
        Proposta propostaAtual = new Proposta();

        BinaryWriter binaryWriter;

        public TelaProposta(BinaryWriter binaryWriter)
        {
            InitializeComponent();
            this.popularComboBoxOrcamentos();
            this.popularComboBoxServicos();
            this.binaryWriter = binaryWriter;
        }

        private void TelaProposta_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            xmlThread = new Thread(new ThreadStart(SalvarXml));

            if (File.Exists(caminho))
            {
                doc.Load(caminho);
                textBoxTitulo.Text = doc.SelectSingleNode("propostas/proposta/titulo").InnerText;
            }

            xmlThread.Start();
        }

        private void TelaProposta_FormClosed(object sender, FormClosedEventArgs e)
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
                XmlNode no = doc.SelectSingleNode("/propostas/proposta");

                if (no.SelectSingleNode("./titulo").InnerText.Equals(this.propostaAtual.Titulo) == false)
                {
                    no.SelectSingleNode("./titulo").InnerText = this.propostaAtual.Titulo;
                }

                doc.Save(caminho);
                Thread.Sleep(1500);
            }
        }

        private void CarregarXml()
        {
            Invoke(new MethodInvoker(delegate {
                this.propostaAtual.Titulo = textBoxTitulo.Text;
            }));
        }
        #endregion

        private void popularComboBoxOrcamentos()
        {
            try
            {
                Orcamento o = new Orcamento();
                o.Cliente = new Cliente();
                Service1 ws = new Service1();
                this.orcamentos = ws.ListarOrcamento(o).ToList();
                foreach (Orcamento orcamento in this.orcamentos)
                {
                    comboBoxOrcamentos.Items.Add(orcamento.Orcamento_id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void popularComboBoxServicos()
        {
            try
            {
                Servico s = new Servico();
                Service1 ws = new Service1();
                this.servicos = ws.ListarServico(s).ToList();
                foreach (Servico servico in this.servicos)
                {
                    comboBoxServicos.Items.Add(servico.Servico_id + " | " + servico.Titulo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCarrinhoAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                Item i = new Item();
                Service1 f = new Service1();

                int posicao = comboBoxServicos.SelectedIndex;
                if (posicao < 0) throw new Exception("Selecione um serviço");
                Servico s = this.servicos.ElementAt(posicao);

                i.Servico = s;
                i.Quantidade = int.Parse(textBoxQtd.Text);
                i.Preco = s.Preco;

                if (this.carrinho.Any(c => c.Servico.Servico_id == s.Servico_id))
                {
                    MessageBox.Show("Este item já foi adicionado", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                this.carrinho.Add(i);
                this.popularListViewCarrinho();
                comboBoxServicos.SelectedIndex = -1;
                textBoxQtd.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCarrinhoRemover_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewCarrinho.FocusedItem != null)
                {
                    int posicao = listViewCarrinho.FocusedItem.Index;
                    this.carrinho.RemoveAt(posicao);
                    this.popularListViewCarrinho();
                    MessageBox.Show("Item removido com sucesso", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Selecione o item a ser removido", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void popularListViewCarrinho()
        {
            listViewCarrinho.Items.Clear();
            foreach (Item c in this.carrinho)
            {
                float total = c.Preco * c.Quantidade;
                ListViewItem item = listViewCarrinho.Items.Add(c.Servico.Titulo);
                item.SubItems.Add(c.Quantidade.ToString());
                item.SubItems.Add(c.Preco.ToString());
                item.SubItems.Add(total.ToString());
            }
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Proposta p = new Proposta();
                Service1 ws = new Service1();

                int posicao = comboBoxOrcamentos.SelectedIndex;
                if (posicao < 0) throw new Exception("Selecione um orçamento");
                Orcamento o = this.orcamentos.ElementAt(posicao);

                if (string.IsNullOrEmpty(textBoxTitulo.Text)) throw new Exception("Informar título");

                if (this.carrinho.Count == 0)
                {
                    throw new Exception("Selecione ao menos um serviço");
                }

                p.Orcamento = o;
                p.Titulo = textBoxTitulo.Text;
                p.Items = this.carrinho.ToArray();

                ws.CadastrarProposta(p);
                this.binaryWriter.Write("Proposta do orcamento de identificação: [" + o.Orcamento_id + "] e cliente: " + o.Cliente.Nome);
                this.LimparForm();
                this.LimparCarrinho();
                MessageBox.Show("Proposta cadastrado com sucesso", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            this.ListViewPropostasShow();
        }

        private void ListViewPropostasShow()
        {
            try
            {
                Proposta p = new Proposta();
                p.Orcamento = new Orcamento();
                p.Items = new List<Item>().ToArray();

                int posicao = comboBoxOrcamentos.SelectedIndex;
                if (posicao > 0) p.Orcamento.Orcamento_id = posicao;

                p.Titulo = textBoxTitulo.Text;

                Service1 ws = new Service1();
                this.propostas = ws.ListarProposta(p).ToList();
                listViewPropostas.Items.Clear();
                foreach(Proposta proposta in this.propostas)
                {
                    ListViewItem item = listViewPropostas.Items.Add(proposta.Orcamento.Orcamento_id.ToString());
                    item.SubItems.Add(proposta.Titulo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewPropostas_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                int posicao = listViewPropostas.FocusedItem.Index;
                Proposta p = this.propostas.ElementAt(posicao);
                comboBoxOrcamentos.SelectedIndex = comboBoxOrcamentos.FindString(p.Orcamento.Orcamento_id.ToString());
                textBoxTitulo.Text = p.Titulo;

                Service1 ws = new Service1();
                listViewItems.Items.Clear();
                p.Items = ws.ListarItemsProposta(p);

                foreach (Item i in p.Items)
                {
                    ListViewItem item = listViewItems.Items.Add(i.Servico.Titulo);
                    item.SubItems.Add(i.Quantidade.ToString());
                    item.SubItems.Add(i.Preco.ToString());
                    double total = i.Quantidade * i.Preco;
                    item.SubItems.Add(total.ToString());
                }

                this.carrinho = p.Items.ToList();
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

        private void LimparForm()
        {
            comboBoxOrcamentos.SelectedIndex = -1;
            textBoxTitulo.Text = "";
            comboBoxServicos.SelectedIndex = -1;
            textBoxQtd.Text = "";
        }

        private void LimparListItems()
        {
            listViewItems.Items.Clear();
        }

        private void LimparListPropostas()
        {
            listViewPropostas.Items.Clear();
        }

        private void LimparCarrinho()
        {
            listViewCarrinho.Items.Clear();
            this.carrinho = new List<Item>();
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja realmente remover?", "ATENÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) != DialogResult.OK)
                {
                    throw new Exception("Operação cancelada pelo operador");
                }
                int posicao = listViewPropostas.FocusedItem.Index;
                Proposta p = this.propostas.ElementAt(posicao);

                Service1 ws = new Service1();

                p.Items = ws.ListarItemsProposta(p);
                foreach (Item i in p.Items)
                {
                    ws.RemoverItem(i);
                }

                ws.RemoverProposta(p);

                this.LimparForm();
                this.LimparListItems();
                this.LimparListPropostas();
                MessageBox.Show("Proposta removida com sucesso", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Service1 ws = new Service1();

                int posicaoP = listViewPropostas.FocusedItem.Index;
                if (posicaoP < 0) throw new Exception("Selecione uma proposta");
                Proposta p = this.propostas.ElementAt(posicaoP);

                p.Orcamento = new Orcamento();
                if (string.IsNullOrEmpty(textBoxTitulo.Text)) throw new Exception("Informar título");
                p.Titulo = textBoxTitulo.Text;

                p.Items = ws.ListarItemsProposta(p);
                foreach (Item i in p.Items)
                {
                    ws.RemoverItem(i);
                }

                p.Items = this.carrinho.ToArray();
                ws.AtualizarProposta(p);

                this.carrinho = new List<Item>();
                listViewCarrinho.Items.Clear();
                MessageBox.Show("Proposta atualizada com sucesso", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
