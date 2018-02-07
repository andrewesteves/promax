namespace Telas
{
    partial class TelaOrcamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaOrcamento));
            this.groupBoxFiltro = new System.Windows.Forms.GroupBox();
            this.buttonLimpar = new System.Windows.Forms.Button();
            this.buttonRemover = new System.Windows.Forms.Button();
            this.buttonAtualizar = new System.Windows.Forms.Button();
            this.buttonCadastrar = new System.Windows.Forms.Button();
            this.buttonListar = new System.Windows.Forms.Button();
            this.richTextBoxDescricao = new System.Windows.Forms.RichTextBox();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.comboBoxClientes = new System.Windows.Forms.ComboBox();
            this.labelCliente = new System.Windows.Forms.Label();
            this.groupBoxOrcamentos = new System.Windows.Forms.GroupBox();
            this.listViewOrcamentos = new System.Windows.Forms.ListView();
            this.columnHeaderOrcamento_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderClienteNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderClienteEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelSituacao = new System.Windows.Forms.Label();
            this.labelObservacao = new System.Windows.Forms.Label();
            this.richTextBoxObservacao = new System.Windows.Forms.RichTextBox();
            this.comboBoxSituacao = new System.Windows.Forms.ComboBox();
            this.groupBoxFiltro.SuspendLayout();
            this.groupBoxOrcamentos.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFiltro
            // 
            this.groupBoxFiltro.Controls.Add(this.comboBoxSituacao);
            this.groupBoxFiltro.Controls.Add(this.richTextBoxObservacao);
            this.groupBoxFiltro.Controls.Add(this.labelObservacao);
            this.groupBoxFiltro.Controls.Add(this.labelSituacao);
            this.groupBoxFiltro.Controls.Add(this.buttonLimpar);
            this.groupBoxFiltro.Controls.Add(this.buttonRemover);
            this.groupBoxFiltro.Controls.Add(this.buttonAtualizar);
            this.groupBoxFiltro.Controls.Add(this.buttonCadastrar);
            this.groupBoxFiltro.Controls.Add(this.buttonListar);
            this.groupBoxFiltro.Controls.Add(this.richTextBoxDescricao);
            this.groupBoxFiltro.Controls.Add(this.labelDescricao);
            this.groupBoxFiltro.Controls.Add(this.comboBoxClientes);
            this.groupBoxFiltro.Controls.Add(this.labelCliente);
            this.groupBoxFiltro.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFiltro.Name = "groupBoxFiltro";
            this.groupBoxFiltro.Size = new System.Drawing.Size(564, 202);
            this.groupBoxFiltro.TabIndex = 0;
            this.groupBoxFiltro.TabStop = false;
            this.groupBoxFiltro.Text = "Filtro";
            // 
            // buttonLimpar
            // 
            this.buttonLimpar.Location = new System.Drawing.Point(333, 164);
            this.buttonLimpar.Name = "buttonLimpar";
            this.buttonLimpar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpar.TabIndex = 8;
            this.buttonLimpar.Text = "Limpar";
            this.buttonLimpar.UseVisualStyleBackColor = true;
            this.buttonLimpar.Click += new System.EventHandler(this.buttonLimpar_Click);
            // 
            // buttonRemover
            // 
            this.buttonRemover.Location = new System.Drawing.Point(252, 164);
            this.buttonRemover.Name = "buttonRemover";
            this.buttonRemover.Size = new System.Drawing.Size(75, 23);
            this.buttonRemover.TabIndex = 7;
            this.buttonRemover.Text = "Remover";
            this.buttonRemover.UseVisualStyleBackColor = true;
            this.buttonRemover.Click += new System.EventHandler(this.buttonRemover_Click);
            // 
            // buttonAtualizar
            // 
            this.buttonAtualizar.Location = new System.Drawing.Point(171, 164);
            this.buttonAtualizar.Name = "buttonAtualizar";
            this.buttonAtualizar.Size = new System.Drawing.Size(75, 23);
            this.buttonAtualizar.TabIndex = 6;
            this.buttonAtualizar.Text = "Atualizar";
            this.buttonAtualizar.UseVisualStyleBackColor = true;
            this.buttonAtualizar.Click += new System.EventHandler(this.buttonAtualizar_Click);
            // 
            // buttonCadastrar
            // 
            this.buttonCadastrar.Location = new System.Drawing.Point(90, 164);
            this.buttonCadastrar.Name = "buttonCadastrar";
            this.buttonCadastrar.Size = new System.Drawing.Size(75, 23);
            this.buttonCadastrar.TabIndex = 5;
            this.buttonCadastrar.Text = "Cadastrar";
            this.buttonCadastrar.UseVisualStyleBackColor = true;
            this.buttonCadastrar.Click += new System.EventHandler(this.buttonCadastrar_Click);
            // 
            // buttonListar
            // 
            this.buttonListar.Location = new System.Drawing.Point(9, 164);
            this.buttonListar.Name = "buttonListar";
            this.buttonListar.Size = new System.Drawing.Size(75, 23);
            this.buttonListar.TabIndex = 4;
            this.buttonListar.Text = "Listar";
            this.buttonListar.UseVisualStyleBackColor = true;
            this.buttonListar.Click += new System.EventHandler(this.buttonListar_Click);
            // 
            // richTextBoxDescricao
            // 
            this.richTextBoxDescricao.Location = new System.Drawing.Point(9, 74);
            this.richTextBoxDescricao.Name = "richTextBoxDescricao";
            this.richTextBoxDescricao.Size = new System.Drawing.Size(318, 82);
            this.richTextBoxDescricao.TabIndex = 3;
            this.richTextBoxDescricao.Text = "";
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.Location = new System.Drawing.Point(9, 58);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(58, 13);
            this.labelDescricao.TabIndex = 2;
            this.labelDescricao.Text = "Descrição:";
            // 
            // comboBoxClientes
            // 
            this.comboBoxClientes.FormattingEnabled = true;
            this.comboBoxClientes.Location = new System.Drawing.Point(9, 34);
            this.comboBoxClientes.Name = "comboBoxClientes";
            this.comboBoxClientes.Size = new System.Drawing.Size(318, 21);
            this.comboBoxClientes.TabIndex = 1;
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(9, 16);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(42, 13);
            this.labelCliente.TabIndex = 0;
            this.labelCliente.Text = "Cliente:";
            // 
            // groupBoxOrcamentos
            // 
            this.groupBoxOrcamentos.Controls.Add(this.listViewOrcamentos);
            this.groupBoxOrcamentos.Location = new System.Drawing.Point(12, 220);
            this.groupBoxOrcamentos.Name = "groupBoxOrcamentos";
            this.groupBoxOrcamentos.Size = new System.Drawing.Size(564, 215);
            this.groupBoxOrcamentos.TabIndex = 1;
            this.groupBoxOrcamentos.TabStop = false;
            this.groupBoxOrcamentos.Text = "Orçamentos";
            // 
            // listViewOrcamentos
            // 
            this.listViewOrcamentos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderOrcamento_id,
            this.columnHeaderClienteNome,
            this.columnHeaderClienteEmail});
            this.listViewOrcamentos.FullRowSelect = true;
            this.listViewOrcamentos.GridLines = true;
            this.listViewOrcamentos.Location = new System.Drawing.Point(9, 19);
            this.listViewOrcamentos.Name = "listViewOrcamentos";
            this.listViewOrcamentos.Size = new System.Drawing.Size(549, 181);
            this.listViewOrcamentos.TabIndex = 0;
            this.listViewOrcamentos.UseCompatibleStateImageBehavior = false;
            this.listViewOrcamentos.View = System.Windows.Forms.View.Details;
            this.listViewOrcamentos.SelectedIndexChanged += new System.EventHandler(this.listViewOrcamentos_SelectedIndexChanged);
            // 
            // columnHeaderOrcamento_id
            // 
            this.columnHeaderOrcamento_id.Text = "Orçamento";
            this.columnHeaderOrcamento_id.Width = 78;
            // 
            // columnHeaderClienteNome
            // 
            this.columnHeaderClienteNome.Text = "Nome";
            this.columnHeaderClienteNome.Width = 263;
            // 
            // columnHeaderClienteEmail
            // 
            this.columnHeaderClienteEmail.Text = "E-mail";
            this.columnHeaderClienteEmail.Width = 204;
            // 
            // labelSituacao
            // 
            this.labelSituacao.AutoSize = true;
            this.labelSituacao.Location = new System.Drawing.Point(333, 16);
            this.labelSituacao.Name = "labelSituacao";
            this.labelSituacao.Size = new System.Drawing.Size(52, 13);
            this.labelSituacao.TabIndex = 9;
            this.labelSituacao.Text = "Situação:";
            // 
            // labelObservacao
            // 
            this.labelObservacao.AutoSize = true;
            this.labelObservacao.Location = new System.Drawing.Point(333, 58);
            this.labelObservacao.Name = "labelObservacao";
            this.labelObservacao.Size = new System.Drawing.Size(68, 13);
            this.labelObservacao.TabIndex = 11;
            this.labelObservacao.Text = "Observação:";
            // 
            // richTextBoxObservacao
            // 
            this.richTextBoxObservacao.Location = new System.Drawing.Point(333, 74);
            this.richTextBoxObservacao.Name = "richTextBoxObservacao";
            this.richTextBoxObservacao.Size = new System.Drawing.Size(225, 82);
            this.richTextBoxObservacao.TabIndex = 12;
            this.richTextBoxObservacao.Text = "";
            // 
            // comboBoxSituacao
            // 
            this.comboBoxSituacao.FormattingEnabled = true;
            this.comboBoxSituacao.Location = new System.Drawing.Point(336, 34);
            this.comboBoxSituacao.Name = "comboBoxSituacao";
            this.comboBoxSituacao.Size = new System.Drawing.Size(222, 21);
            this.comboBoxSituacao.TabIndex = 13;
            // 
            // TelaOrcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 447);
            this.Controls.Add(this.groupBoxOrcamentos);
            this.Controls.Add(this.groupBoxFiltro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaOrcamento";
            this.Text = "Orçamentos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TelaOrcamento_FormClosed);
            this.Load += new System.EventHandler(this.TelaOrcamento_Load);
            this.groupBoxFiltro.ResumeLayout(false);
            this.groupBoxFiltro.PerformLayout();
            this.groupBoxOrcamentos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFiltro;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.ComboBox comboBoxClientes;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.RichTextBox richTextBoxDescricao;
        private System.Windows.Forms.Button buttonListar;
        private System.Windows.Forms.Button buttonCadastrar;
        private System.Windows.Forms.GroupBox groupBoxOrcamentos;
        private System.Windows.Forms.ListView listViewOrcamentos;
        private System.Windows.Forms.ColumnHeader columnHeaderOrcamento_id;
        private System.Windows.Forms.ColumnHeader columnHeaderClienteNome;
        private System.Windows.Forms.ColumnHeader columnHeaderClienteEmail;
        private System.Windows.Forms.Button buttonAtualizar;
        private System.Windows.Forms.Button buttonRemover;
        private System.Windows.Forms.Button buttonLimpar;
        private System.Windows.Forms.Label labelSituacao;
        private System.Windows.Forms.Label labelObservacao;
        private System.Windows.Forms.RichTextBox richTextBoxObservacao;
        private System.Windows.Forms.ComboBox comboBoxSituacao;
    }
}