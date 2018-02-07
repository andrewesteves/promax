namespace Telas
{
    partial class TelaProposta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaProposta));
            this.groupBoxFiltro = new System.Windows.Forms.GroupBox();
            this.labelQtd = new System.Windows.Forms.Label();
            this.textBoxQtd = new System.Windows.Forms.TextBox();
            this.buttonLimpar = new System.Windows.Forms.Button();
            this.buttonRemover = new System.Windows.Forms.Button();
            this.buttonAtualizar = new System.Windows.Forms.Button();
            this.buttonCarrinhoAdicionar = new System.Windows.Forms.Button();
            this.comboBoxServicos = new System.Windows.Forms.ComboBox();
            this.labelServicos = new System.Windows.Forms.Label();
            this.buttonCadastrar = new System.Windows.Forms.Button();
            this.buttonListar = new System.Windows.Forms.Button();
            this.textBoxTitulo = new System.Windows.Forms.TextBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.comboBoxOrcamentos = new System.Windows.Forms.ComboBox();
            this.labelOrcamento = new System.Windows.Forms.Label();
            this.groupBoxCarrinho = new System.Windows.Forms.GroupBox();
            this.buttonCarrinhoRemover = new System.Windows.Forms.Button();
            this.listViewCarrinho = new System.Windows.Forms.ListView();
            this.ColumnHeaderTitulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderQtd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderPreco = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxPropostas = new System.Windows.Forms.GroupBox();
            this.listViewPropostas = new System.Windows.Forms.ListView();
            this.columnHeaderPropostaOrcamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPropostaTitulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxServicos = new System.Windows.Forms.GroupBox();
            this.listViewItems = new System.Windows.Forms.ListView();
            this.columnHeaderServicoTitulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServicoQtd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServicoPreco = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServicoTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxFiltro.SuspendLayout();
            this.groupBoxCarrinho.SuspendLayout();
            this.groupBoxPropostas.SuspendLayout();
            this.groupBoxServicos.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFiltro
            // 
            this.groupBoxFiltro.Controls.Add(this.labelQtd);
            this.groupBoxFiltro.Controls.Add(this.textBoxQtd);
            this.groupBoxFiltro.Controls.Add(this.buttonLimpar);
            this.groupBoxFiltro.Controls.Add(this.buttonRemover);
            this.groupBoxFiltro.Controls.Add(this.buttonAtualizar);
            this.groupBoxFiltro.Controls.Add(this.buttonCarrinhoAdicionar);
            this.groupBoxFiltro.Controls.Add(this.comboBoxServicos);
            this.groupBoxFiltro.Controls.Add(this.labelServicos);
            this.groupBoxFiltro.Controls.Add(this.buttonCadastrar);
            this.groupBoxFiltro.Controls.Add(this.buttonListar);
            this.groupBoxFiltro.Controls.Add(this.textBoxTitulo);
            this.groupBoxFiltro.Controls.Add(this.labelTitulo);
            this.groupBoxFiltro.Controls.Add(this.comboBoxOrcamentos);
            this.groupBoxFiltro.Controls.Add(this.labelOrcamento);
            this.groupBoxFiltro.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFiltro.Name = "groupBoxFiltro";
            this.groupBoxFiltro.Size = new System.Drawing.Size(420, 182);
            this.groupBoxFiltro.TabIndex = 0;
            this.groupBoxFiltro.TabStop = false;
            this.groupBoxFiltro.Text = "Filtro";
            // 
            // labelQtd
            // 
            this.labelQtd.AutoSize = true;
            this.labelQtd.Location = new System.Drawing.Point(246, 101);
            this.labelQtd.Name = "labelQtd";
            this.labelQtd.Size = new System.Drawing.Size(27, 13);
            this.labelQtd.TabIndex = 13;
            this.labelQtd.Text = "Qtd:";
            // 
            // textBoxQtd
            // 
            this.textBoxQtd.Location = new System.Drawing.Point(249, 120);
            this.textBoxQtd.Name = "textBoxQtd";
            this.textBoxQtd.Size = new System.Drawing.Size(75, 20);
            this.textBoxQtd.TabIndex = 12;
            // 
            // buttonLimpar
            // 
            this.buttonLimpar.Location = new System.Drawing.Point(330, 146);
            this.buttonLimpar.Name = "buttonLimpar";
            this.buttonLimpar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpar.TabIndex = 11;
            this.buttonLimpar.Text = "Limpar";
            this.buttonLimpar.UseVisualStyleBackColor = true;
            this.buttonLimpar.Click += new System.EventHandler(this.buttonLimpar_Click);
            // 
            // buttonRemover
            // 
            this.buttonRemover.Location = new System.Drawing.Point(249, 146);
            this.buttonRemover.Name = "buttonRemover";
            this.buttonRemover.Size = new System.Drawing.Size(75, 23);
            this.buttonRemover.TabIndex = 10;
            this.buttonRemover.Text = "Remover";
            this.buttonRemover.UseVisualStyleBackColor = true;
            this.buttonRemover.Click += new System.EventHandler(this.buttonRemover_Click);
            // 
            // buttonAtualizar
            // 
            this.buttonAtualizar.Location = new System.Drawing.Point(168, 146);
            this.buttonAtualizar.Name = "buttonAtualizar";
            this.buttonAtualizar.Size = new System.Drawing.Size(75, 23);
            this.buttonAtualizar.TabIndex = 9;
            this.buttonAtualizar.Text = "Atualizar";
            this.buttonAtualizar.UseVisualStyleBackColor = true;
            this.buttonAtualizar.Click += new System.EventHandler(this.buttonAtualizar_Click);
            // 
            // buttonCarrinhoAdicionar
            // 
            this.buttonCarrinhoAdicionar.Location = new System.Drawing.Point(330, 117);
            this.buttonCarrinhoAdicionar.Name = "buttonCarrinhoAdicionar";
            this.buttonCarrinhoAdicionar.Size = new System.Drawing.Size(75, 23);
            this.buttonCarrinhoAdicionar.TabIndex = 8;
            this.buttonCarrinhoAdicionar.Text = "Adicionar";
            this.buttonCarrinhoAdicionar.UseVisualStyleBackColor = true;
            this.buttonCarrinhoAdicionar.Click += new System.EventHandler(this.buttonCarrinhoAdicionar_Click);
            // 
            // comboBoxServicos
            // 
            this.comboBoxServicos.FormattingEnabled = true;
            this.comboBoxServicos.Location = new System.Drawing.Point(6, 119);
            this.comboBoxServicos.Name = "comboBoxServicos";
            this.comboBoxServicos.Size = new System.Drawing.Size(237, 21);
            this.comboBoxServicos.TabIndex = 7;
            // 
            // labelServicos
            // 
            this.labelServicos.AutoSize = true;
            this.labelServicos.Location = new System.Drawing.Point(6, 103);
            this.labelServicos.Name = "labelServicos";
            this.labelServicos.Size = new System.Drawing.Size(51, 13);
            this.labelServicos.TabIndex = 6;
            this.labelServicos.Text = "Serviços:";
            // 
            // buttonCadastrar
            // 
            this.buttonCadastrar.Location = new System.Drawing.Point(87, 146);
            this.buttonCadastrar.Name = "buttonCadastrar";
            this.buttonCadastrar.Size = new System.Drawing.Size(75, 23);
            this.buttonCadastrar.TabIndex = 5;
            this.buttonCadastrar.Text = "Cadastrar";
            this.buttonCadastrar.UseVisualStyleBackColor = true;
            this.buttonCadastrar.Click += new System.EventHandler(this.buttonCadastrar_Click);
            // 
            // buttonListar
            // 
            this.buttonListar.Location = new System.Drawing.Point(6, 146);
            this.buttonListar.Name = "buttonListar";
            this.buttonListar.Size = new System.Drawing.Size(75, 23);
            this.buttonListar.TabIndex = 4;
            this.buttonListar.Text = "Listar";
            this.buttonListar.UseVisualStyleBackColor = true;
            this.buttonListar.Click += new System.EventHandler(this.buttonListar_Click);
            // 
            // textBoxTitulo
            // 
            this.textBoxTitulo.Location = new System.Drawing.Point(6, 78);
            this.textBoxTitulo.Name = "textBoxTitulo";
            this.textBoxTitulo.Size = new System.Drawing.Size(399, 20);
            this.textBoxTitulo.TabIndex = 3;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Location = new System.Drawing.Point(6, 62);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(38, 13);
            this.labelTitulo.TabIndex = 2;
            this.labelTitulo.Text = "Título:";
            // 
            // comboBoxOrcamentos
            // 
            this.comboBoxOrcamentos.FormattingEnabled = true;
            this.comboBoxOrcamentos.Location = new System.Drawing.Point(6, 35);
            this.comboBoxOrcamentos.Name = "comboBoxOrcamentos";
            this.comboBoxOrcamentos.Size = new System.Drawing.Size(399, 21);
            this.comboBoxOrcamentos.TabIndex = 1;
            // 
            // labelOrcamento
            // 
            this.labelOrcamento.AutoSize = true;
            this.labelOrcamento.Location = new System.Drawing.Point(6, 16);
            this.labelOrcamento.Name = "labelOrcamento";
            this.labelOrcamento.Size = new System.Drawing.Size(62, 13);
            this.labelOrcamento.TabIndex = 0;
            this.labelOrcamento.Text = "Orçamento:";
            // 
            // groupBoxCarrinho
            // 
            this.groupBoxCarrinho.Controls.Add(this.buttonCarrinhoRemover);
            this.groupBoxCarrinho.Controls.Add(this.listViewCarrinho);
            this.groupBoxCarrinho.Location = new System.Drawing.Point(438, 12);
            this.groupBoxCarrinho.Name = "groupBoxCarrinho";
            this.groupBoxCarrinho.Size = new System.Drawing.Size(395, 182);
            this.groupBoxCarrinho.TabIndex = 1;
            this.groupBoxCarrinho.TabStop = false;
            this.groupBoxCarrinho.Text = "Carrinho";
            // 
            // buttonCarrinhoRemover
            // 
            this.buttonCarrinhoRemover.Location = new System.Drawing.Point(314, 146);
            this.buttonCarrinhoRemover.Name = "buttonCarrinhoRemover";
            this.buttonCarrinhoRemover.Size = new System.Drawing.Size(75, 23);
            this.buttonCarrinhoRemover.TabIndex = 1;
            this.buttonCarrinhoRemover.Text = "Remover";
            this.buttonCarrinhoRemover.UseVisualStyleBackColor = true;
            this.buttonCarrinhoRemover.Click += new System.EventHandler(this.buttonCarrinhoRemover_Click);
            // 
            // listViewCarrinho
            // 
            this.listViewCarrinho.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderTitulo,
            this.ColumnHeaderQtd,
            this.ColumnHeaderPreco,
            this.ColumnHeaderTotal});
            this.listViewCarrinho.FullRowSelect = true;
            this.listViewCarrinho.GridLines = true;
            this.listViewCarrinho.Location = new System.Drawing.Point(6, 19);
            this.listViewCarrinho.Name = "listViewCarrinho";
            this.listViewCarrinho.Size = new System.Drawing.Size(383, 121);
            this.listViewCarrinho.TabIndex = 0;
            this.listViewCarrinho.UseCompatibleStateImageBehavior = false;
            this.listViewCarrinho.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeaderTitulo
            // 
            this.ColumnHeaderTitulo.Text = "Título";
            this.ColumnHeaderTitulo.Width = 205;
            // 
            // ColumnHeaderQtd
            // 
            this.ColumnHeaderQtd.Text = "Qtd";
            // 
            // ColumnHeaderPreco
            // 
            this.ColumnHeaderPreco.Text = "Preço";
            this.ColumnHeaderPreco.Width = 49;
            // 
            // ColumnHeaderTotal
            // 
            this.ColumnHeaderTotal.Text = "Total";
            this.ColumnHeaderTotal.Width = 54;
            // 
            // groupBoxPropostas
            // 
            this.groupBoxPropostas.Controls.Add(this.listViewPropostas);
            this.groupBoxPropostas.Location = new System.Drawing.Point(12, 200);
            this.groupBoxPropostas.Name = "groupBoxPropostas";
            this.groupBoxPropostas.Size = new System.Drawing.Size(420, 235);
            this.groupBoxPropostas.TabIndex = 2;
            this.groupBoxPropostas.TabStop = false;
            this.groupBoxPropostas.Text = "Propostas";
            // 
            // listViewPropostas
            // 
            this.listViewPropostas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPropostaOrcamento,
            this.columnHeaderPropostaTitulo});
            this.listViewPropostas.FullRowSelect = true;
            this.listViewPropostas.GridLines = true;
            this.listViewPropostas.Location = new System.Drawing.Point(6, 19);
            this.listViewPropostas.Name = "listViewPropostas";
            this.listViewPropostas.Size = new System.Drawing.Size(399, 210);
            this.listViewPropostas.TabIndex = 0;
            this.listViewPropostas.UseCompatibleStateImageBehavior = false;
            this.listViewPropostas.View = System.Windows.Forms.View.Details;
            this.listViewPropostas.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewPropostas_ItemSelectionChanged);
            // 
            // columnHeaderPropostaOrcamento
            // 
            this.columnHeaderPropostaOrcamento.Text = "Orçamento";
            this.columnHeaderPropostaOrcamento.Width = 73;
            // 
            // columnHeaderPropostaTitulo
            // 
            this.columnHeaderPropostaTitulo.Text = "Título";
            this.columnHeaderPropostaTitulo.Width = 282;
            // 
            // groupBoxServicos
            // 
            this.groupBoxServicos.Controls.Add(this.listViewItems);
            this.groupBoxServicos.Location = new System.Drawing.Point(438, 200);
            this.groupBoxServicos.Name = "groupBoxServicos";
            this.groupBoxServicos.Size = new System.Drawing.Size(395, 235);
            this.groupBoxServicos.TabIndex = 3;
            this.groupBoxServicos.TabStop = false;
            this.groupBoxServicos.Text = "Items";
            // 
            // listViewItems
            // 
            this.listViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderServicoTitulo,
            this.columnHeaderServicoQtd,
            this.columnHeaderServicoPreco,
            this.columnHeaderServicoTotal});
            this.listViewItems.FullRowSelect = true;
            this.listViewItems.GridLines = true;
            this.listViewItems.Location = new System.Drawing.Point(6, 19);
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(383, 210);
            this.listViewItems.TabIndex = 0;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderServicoTitulo
            // 
            this.columnHeaderServicoTitulo.Text = "Título";
            this.columnHeaderServicoTitulo.Width = 197;
            // 
            // columnHeaderServicoQtd
            // 
            this.columnHeaderServicoQtd.Text = "Qtd";
            // 
            // columnHeaderServicoPreco
            // 
            this.columnHeaderServicoPreco.Text = "Preço";
            // 
            // columnHeaderServicoTotal
            // 
            this.columnHeaderServicoTotal.Text = "Total";
            this.columnHeaderServicoTotal.Width = 56;
            // 
            // TelaProposta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 447);
            this.Controls.Add(this.groupBoxServicos);
            this.Controls.Add(this.groupBoxPropostas);
            this.Controls.Add(this.groupBoxCarrinho);
            this.Controls.Add(this.groupBoxFiltro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaProposta";
            this.Text = "Propostas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TelaProposta_FormClosed);
            this.Load += new System.EventHandler(this.TelaProposta_Load);
            this.groupBoxFiltro.ResumeLayout(false);
            this.groupBoxFiltro.PerformLayout();
            this.groupBoxCarrinho.ResumeLayout(false);
            this.groupBoxPropostas.ResumeLayout(false);
            this.groupBoxServicos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFiltro;
        private System.Windows.Forms.Label labelOrcamento;
        private System.Windows.Forms.ComboBox comboBoxOrcamentos;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox textBoxTitulo;
        private System.Windows.Forms.Button buttonListar;
        private System.Windows.Forms.Button buttonCadastrar;
        private System.Windows.Forms.Label labelServicos;
        private System.Windows.Forms.Button buttonCarrinhoAdicionar;
        private System.Windows.Forms.ComboBox comboBoxServicos;
        private System.Windows.Forms.Button buttonAtualizar;
        private System.Windows.Forms.Button buttonRemover;
        private System.Windows.Forms.Button buttonLimpar;
        private System.Windows.Forms.GroupBox groupBoxCarrinho;
        private System.Windows.Forms.ListView listViewCarrinho;
        private System.Windows.Forms.ColumnHeader ColumnHeaderTitulo;
        private System.Windows.Forms.ColumnHeader ColumnHeaderQtd;
        private System.Windows.Forms.ColumnHeader ColumnHeaderPreco;
        private System.Windows.Forms.ColumnHeader ColumnHeaderTotal;
        private System.Windows.Forms.Button buttonCarrinhoRemover;
        private System.Windows.Forms.GroupBox groupBoxPropostas;
        private System.Windows.Forms.GroupBox groupBoxServicos;
        private System.Windows.Forms.ListView listViewItems;
        private System.Windows.Forms.ColumnHeader columnHeaderServicoTitulo;
        private System.Windows.Forms.ColumnHeader columnHeaderServicoQtd;
        private System.Windows.Forms.ColumnHeader columnHeaderServicoPreco;
        private System.Windows.Forms.ColumnHeader columnHeaderServicoTotal;
        private System.Windows.Forms.ListView listViewPropostas;
        private System.Windows.Forms.ColumnHeader columnHeaderPropostaTitulo;
        private System.Windows.Forms.ColumnHeader columnHeaderPropostaOrcamento;
        private System.Windows.Forms.Label labelQtd;
        private System.Windows.Forms.TextBox textBoxQtd;
    }
}