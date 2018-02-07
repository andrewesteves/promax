using System; using System.Collections.Generic;
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
    public partial class TelaCliente : Form
    {
        List<Cliente> clientes = new List<Cliente>();
        Thread xmlThread;
        string caminho = "clientes.xml";
        Cliente clienteAtual = new Cliente();

        public TelaCliente()
        {
            InitializeComponent();
        }

        private void TelaCliente_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            xmlThread = new Thread(new ThreadStart(SalvarXml));

            if (File.Exists(caminho))
            {
                doc.Load(caminho);
                textBoxNome.Text = doc.SelectSingleNode("clientes/cliente/nome").InnerText;
                textBoxEmail.Text = doc.SelectSingleNode("clientes/cliente/email").InnerText;
                textBoxTelefone.Text = doc.SelectSingleNode("clientes/cliente/telefone").InnerText;
            }

            xmlThread.Start();
        }

        private void TelaCliente_FormClosed(object sender, FormClosedEventArgs e)
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
                XmlNode no = doc.SelectSingleNode("/clientes/cliente");

                if (no.SelectSingleNode("./nome").InnerText.Equals(this.clienteAtual.Nome) == false ||
                    no.SelectSingleNode("./email").InnerText.Equals(this.clienteAtual.Email) == false ||
                    no.SelectSingleNode("./telefone").InnerText.Equals(this.clienteAtual.Telefone) == false)
                {
                    no.SelectSingleNode("./nome").InnerText = this.clienteAtual.Nome;
                    no.SelectSingleNode("./email").InnerText = this.clienteAtual.Email;
                    no.SelectSingleNode("./telefone").InnerText = this.clienteAtual.Telefone;
                }

                doc.Save(caminho);
                Thread.Sleep(1500);
            }
        }

        private void CarregarXml()
        {
            Invoke(new MethodInvoker(delegate {
                this.clienteAtual.Nome = textBoxNome.Text;
                this.clienteAtual.Email = textBoxEmail.Text;
                this.clienteAtual.Telefone = textBoxTelefone.Text;
            }));
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            this.ListViewClientesShow();
        }

        private void ListViewClientesShow()
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.Nome = textBoxNome.Text;
                cliente.Email = textBoxEmail.Text;
                cliente.Telefone = textBoxTelefone.Text;

                Service1 f = new Service1();
                this.clientes = f.Listar(cliente).ToList();

                listViewClientes.Items.Clear();
                foreach(Cliente c in this.clientes)
                {
                    ListViewItem item = listViewClientes.Items.Add(c.Cliente_id.ToString());
                    item.SubItems.Add(c.Nome);
                    item.SubItems.Add(c.Email);
                    item.SubItems.Add(c.Telefone);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewClientes_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            int posicao = listViewClientes.FocusedItem.Index;
            Cliente c = this.clientes.ElementAt(posicao);
            textBoxNome.Text = c.Nome;
            textBoxEmail.Text = c.Email;
            textBoxTelefone.Text = c.Telefone;
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente c = new Cliente();
                if (string.IsNullOrEmpty(textBoxNome.Text)) throw new Exception("Informar nome");
                if (string.IsNullOrEmpty(textBoxEmail.Text)) throw new Exception("Informar e-mail");
                if (string.IsNullOrEmpty(textBoxTelefone.Text)) throw new Exception("Informar telefone");
                c.Nome = textBoxNome.Text;
                c.Email = textBoxEmail.Text;
                c.Telefone = textBoxTelefone.Text;

                Service1 f = new Service1();
                f.Cadastrar(c);
                LimparForm();
                this.ListViewClientesShow();
                
                MessageBox.Show("Cliente cadastrado com sucesso", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparForm()
        {
            textBoxNome.Text = "";
            textBoxEmail.Text = "";
            textBoxTelefone.Text = "";
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxNome.Text)) throw new Exception("Informar nome");
                if (string.IsNullOrEmpty(textBoxEmail.Text)) throw new Exception("Informar e-mail");
                if (string.IsNullOrEmpty(textBoxTelefone.Text)) throw new Exception("Informar telefone");
                int posicao = listViewClientes.FocusedItem.Index;
                if (posicao < 0) throw new Exception("Informar cliente");
                Cliente c = this.clientes.ElementAt(posicao);
                c.Nome = textBoxNome.Text;
                c.Email = textBoxEmail.Text;
                c.Telefone = textBoxTelefone.Text;

                Service1 f = new Service1();
                f.Atualizar(c);
                LimparForm();
                this.ListViewClientesShow();
                MessageBox.Show("Cliente atualizado com sucesso", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if(MessageBox.Show("Deseja realmente remover?", "ATENÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) != DialogResult.OK)
                {
                    throw new Exception("Operação cancelada pelo operador");
                }
                int posicao = listViewClientes.FocusedItem.Index;
                Cliente c = this.clientes.ElementAt(posicao);

                Service1 f = new Service1();
                f.Remover(c);
                LimparForm();
                this.ListViewClientesShow();
                MessageBox.Show("Cliente removido com sucesso", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
