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
    public partial class TelaServico : Form
    {
        List<Servico> servicos = new List<Servico>();
        Thread xmlThread;
        string caminho = "servicos.xml";
        Servico servicoAtual = new Servico();

        public TelaServico()
        {
            InitializeComponent();
        }

        private void TelaServico_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            xmlThread = new Thread(new ThreadStart(SalvarXml));

            if (File.Exists(caminho))
            {
                doc.Load(caminho);
                textBoxTitulo.Text = doc.SelectSingleNode("servicos/servico/titulo").InnerText;
                richTextBoxDescricao.Text = doc.SelectSingleNode("servicos/servico/descricao").InnerText;
                textBoxPreco.Text = doc.SelectSingleNode("servicos/servico/preco").InnerText;
            }

            xmlThread.Start();
        }

        private void TelaServico_FormClosed(object sender, FormClosedEventArgs e)
        {
            xmlThread.Abort();
        }

        private void SalvarXml()
        {
            while(Visible)
            {
                CarregarXml();

                XmlDocument doc = new XmlDocument();
                doc.Load(caminho);
                XmlNode no = doc.SelectSingleNode("/servicos/servico");

                if(no.SelectSingleNode("./titulo").InnerText.Equals(this.servicoAtual.Titulo) == false || 
                    no.SelectSingleNode("./descricao").InnerText.Equals(this.servicoAtual.Descricao) == false ||
                    no.SelectSingleNode("./preco").InnerText.Equals(this.servicoAtual.Preco.ToString()) == false)
                {
                    no.SelectSingleNode("./titulo").InnerText = this.servicoAtual.Titulo;
                    no.SelectSingleNode("./descricao").InnerText = this.servicoAtual.Descricao;
                    no.SelectSingleNode("./preco").InnerText = this.servicoAtual.Preco.ToString();
                }

                doc.Save(caminho);
                Thread.Sleep(1500);
            }
        }

        private void CarregarXml()
        {
            Invoke(new MethodInvoker(delegate {
                this.servicoAtual.Titulo = textBoxTitulo.Text;
                this.servicoAtual.Descricao = richTextBoxDescricao.Text;
                this.servicoAtual.Preco = string.IsNullOrEmpty(textBoxPreco.Text) ? 0 : float.Parse(textBoxPreco.Text);
            }));
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            this.ListViewServicosShow();
        }

        private void ListViewServicosShow()
        {
            try
            {
                Servico servico = new Servico();
                servico.Titulo = textBoxTitulo.Text;
                servico.Descricao = richTextBoxDescricao.Text;
                servico.Preco = !string.IsNullOrEmpty(textBoxPreco.Text) ? float.Parse(textBoxPreco.Text) : 0;

                Service1 ws = new Service1();
                this.servicos = ws.ListarServico(servico).ToList();

                listViewServicos.Items.Clear();
                foreach (Servico s in this.servicos)
                {
                    ListViewItem item = listViewServicos.Items.Add(s.Servico_id.ToString());
                    item.SubItems.Add(s.Titulo);
                    item.SubItems.Add(s.Preco.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewServicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int posicao = listViewServicos.FocusedItem.Index;
            Servico s = this.servicos.ElementAt(posicao);
            textBoxTitulo.Text = s.Titulo;
            richTextBoxDescricao.Text = s.Descricao;
            textBoxPreco.Text = s.Preco.ToString();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Servico s = new Servico();
                if (string.IsNullOrEmpty(textBoxTitulo.Text)) throw new Exception("Informar título");
                if (string.IsNullOrEmpty(richTextBoxDescricao.Text)) throw new Exception("Informar descrição");
                if (string.IsNullOrEmpty(textBoxPreco.Text)) throw new Exception("Informar preço");
                s.Titulo = textBoxTitulo.Text;
                s.Descricao = richTextBoxDescricao.Text;
                s.Preco = !string.IsNullOrEmpty(textBoxPreco.Text) ? float.Parse(textBoxPreco.Text) : 0;

                Service1 ws = new Service1();
                ws.CadastrarServico(s);
                this.LimparForm();
                this.ListViewServicosShow();
                MessageBox.Show("Serviço cadastrado com sucesso", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparForm()
        {
            textBoxTitulo.Text = "";
            richTextBoxDescricao.Text = "";
            textBoxPreco.Text = "";
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            this.LimparForm();
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxTitulo.Text)) throw new Exception("Informar título");
                if (string.IsNullOrEmpty(richTextBoxDescricao.Text)) throw new Exception("Informar descrição");
                if (string.IsNullOrEmpty(textBoxPreco.Text)) throw new Exception("Informar preço");
                int posicao = listViewServicos.FocusedItem.Index;
                if (posicao < 0) throw new Exception("Informar serviço");
                Servico s = this.servicos.ElementAt(posicao);
                s.Titulo = textBoxTitulo.Text;
                s.Descricao = richTextBoxDescricao.Text;
                s.Preco = !string.IsNullOrEmpty(textBoxPreco.Text) ? float.Parse(textBoxPreco.Text) : 0;

                Service1 ws = new Service1();
                ws.AtualizarServico(s);
                this.LimparForm();
                this.ListViewServicosShow();
                MessageBox.Show("Serviço atualizado com sucesso", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int posicao = listViewServicos.FocusedItem.Index;
                Servico s = this.servicos.ElementAt(posicao);

                Service1 ws = new Service1();
                ws.RemoverServico(s);
                LimparForm();
                this.ListViewServicosShow();
                MessageBox.Show("Serviço removido com sucesso", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
