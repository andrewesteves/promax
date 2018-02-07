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
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketServer
{
    public partial class TelaServer : Form
    {
        private Socket socket;
        private Thread thread;

        private NetworkStream networkStream;
        private BinaryWriter binaryWriter;
        private BinaryReader binaryReader;

        TcpListener tcpListener;

        public TelaServer()
        {
            InitializeComponent();
            thread = new Thread(new ThreadStart(RunServer));
            thread.Start();
        }

        public void RunServer()
        {
            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2001);
                tcpListener = new TcpListener(ipEndPoint);
                tcpListener.Start();

                this.AddToListBox("Conexão estabelecida em endereço e porta: 127.0.0.1:2001");

                socket = tcpListener.AcceptSocket();
                networkStream = new NetworkStream(socket);
                binaryWriter = new BinaryWriter(networkStream);
                binaryReader = new BinaryReader(networkStream);

                binaryWriter.Write("Conexão estabelecida");

                string messageReceived = "";
                do
                {
                    messageReceived = binaryReader.ReadString();
                    this.AddToListBox(messageReceived);
                    this.Transmitir(messageReceived);
                } while (socket.Connected);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (binaryReader != null)
                {
                    binaryReader.Close();
                }
                if (binaryWriter != null)
                {
                    binaryWriter.Close();
                }
                if (networkStream != null)
                {
                    networkStream.Close();
                }
                if (socket != null)
                {
                    socket.Close();
                }
                MessageBox.Show("Conexão finalizada", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddToListBox(object oo)
        {
            Invoke(new MethodInvoker(delegate { listBoxAtividades.Items.Add(oo); }));
        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(RunServer));
            thread.Start();
        }

        private void Transmitir(string mensagem)
        {
            try
            {
                binaryWriter.Write(mensagem);
            }
            catch (SocketException socketEx)
            {
                MessageBox.Show(socketEx.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TelaServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            tcpListener.Stop();
            Environment.Exit(0);
        }
    }
}
