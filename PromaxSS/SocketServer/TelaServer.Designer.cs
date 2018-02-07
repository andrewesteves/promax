namespace SocketServer
{
    partial class TelaServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaServer));
            this.groupBoxAcoes = new System.Windows.Forms.GroupBox();
            this.buttonIniciar = new System.Windows.Forms.Button();
            this.groupBoxAtividades = new System.Windows.Forms.GroupBox();
            this.listBoxAtividades = new System.Windows.Forms.ListBox();
            this.groupBoxAcoes.SuspendLayout();
            this.groupBoxAtividades.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAcoes
            // 
            this.groupBoxAcoes.Controls.Add(this.buttonIniciar);
            this.groupBoxAcoes.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAcoes.Name = "groupBoxAcoes";
            this.groupBoxAcoes.Size = new System.Drawing.Size(180, 54);
            this.groupBoxAcoes.TabIndex = 0;
            this.groupBoxAcoes.TabStop = false;
            this.groupBoxAcoes.Text = "Ações";
            // 
            // buttonIniciar
            // 
            this.buttonIniciar.Location = new System.Drawing.Point(6, 19);
            this.buttonIniciar.Name = "buttonIniciar";
            this.buttonIniciar.Size = new System.Drawing.Size(165, 23);
            this.buttonIniciar.TabIndex = 1;
            this.buttonIniciar.Text = "Iniciar";
            this.buttonIniciar.UseVisualStyleBackColor = true;
            this.buttonIniciar.Visible = false;
            this.buttonIniciar.Click += new System.EventHandler(this.buttonIniciar_Click);
            // 
            // groupBoxAtividades
            // 
            this.groupBoxAtividades.Controls.Add(this.listBoxAtividades);
            this.groupBoxAtividades.Location = new System.Drawing.Point(207, 13);
            this.groupBoxAtividades.Name = "groupBoxAtividades";
            this.groupBoxAtividades.Size = new System.Drawing.Size(465, 386);
            this.groupBoxAtividades.TabIndex = 1;
            this.groupBoxAtividades.TabStop = false;
            this.groupBoxAtividades.Text = "Atividades";
            // 
            // listBoxAtividades
            // 
            this.listBoxAtividades.FormattingEnabled = true;
            this.listBoxAtividades.Location = new System.Drawing.Point(6, 19);
            this.listBoxAtividades.Name = "listBoxAtividades";
            this.listBoxAtividades.Size = new System.Drawing.Size(453, 355);
            this.listBoxAtividades.TabIndex = 0;
            // 
            // TelaServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.Controls.Add(this.groupBoxAtividades);
            this.Controls.Add(this.groupBoxAcoes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaServer";
            this.Text = "Servidor Socket";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaServer_FormClosing);
            this.groupBoxAcoes.ResumeLayout(false);
            this.groupBoxAtividades.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAcoes;
        private System.Windows.Forms.Button buttonIniciar;
        private System.Windows.Forms.GroupBox groupBoxAtividades;
        private System.Windows.Forms.ListBox listBoxAtividades;
    }
}

