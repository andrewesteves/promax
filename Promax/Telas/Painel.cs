using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Telas
{
    public partial class Painel : Form
    {
        private NetworkStream networkStream;
        private BinaryWriter binaryWriter;
        private BinaryReader binaryReader;
        private TcpClient tcpClient;

        private Thread thread;

        public Painel()
        {
            InitializeComponent();
            thread = new Thread(new ThreadStart(RunClient));
            thread.Start();
        }

        private void RunClient()
        {
            try
            {
                tcpClient = new TcpClient();
                //tcpClient.Connect("172.16.1.245", 2001);
                tcpClient.Connect("127.0.0.1", 2001);

                networkStream = tcpClient.GetStream();
                binaryWriter = new BinaryWriter(networkStream);
                binaryReader = new BinaryReader(networkStream);

                string message = "";

                do
                {
                    try
                    {
                        message = binaryReader.ReadString();
                        Invoke(new MethodInvoker(delegate { labelNotificacao.Text = message; } ));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        message = "FIM";
                    }
                } while (message != "FIM");

                binaryWriter.Close();
                binaryReader.Close();
                networkStream.Close();
                tcpClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCliente telaCliente = new TelaCliente();
            this.AddOwnedForm(telaCliente);
            telaCliente.Show();
        }

        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaServico telaServico = new TelaServico();
            this.AddOwnedForm(telaServico);
            telaServico.Show();
        }

        private void orçamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaOrcamento telaOrcamento = new TelaOrcamento(this.binaryWriter);
            this.AddOwnedForm(telaOrcamento);
            telaOrcamento.Show();
        }

        private void propostasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaProposta telaProposta = new TelaProposta(this.binaryWriter);
            this.AddOwnedForm(telaProposta);
            telaProposta.Show();
        }
    }
}
