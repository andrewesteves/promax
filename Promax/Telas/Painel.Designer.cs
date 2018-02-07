namespace Telas
{
    partial class Painel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Painel));
            this.menuStripPainel = new System.Windows.Forms.MenuStrip();
            this.orçamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propostasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelNotificacao = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pictureBoxNotificacao = new System.Windows.Forms.PictureBox();
            this.menuStripPainel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotificacao)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripPainel
            // 
            this.menuStripPainel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStripPainel.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripPainel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orçamentosToolStripMenuItem,
            this.propostasToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.serviçosToolStripMenuItem});
            this.menuStripPainel.Location = new System.Drawing.Point(0, 0);
            this.menuStripPainel.Name = "menuStripPainel";
            this.menuStripPainel.Size = new System.Drawing.Size(684, 26);
            this.menuStripPainel.TabIndex = 1;
            this.menuStripPainel.Text = "menuStripPainel";
            // 
            // orçamentosToolStripMenuItem
            // 
            this.orçamentosToolStripMenuItem.Name = "orçamentosToolStripMenuItem";
            this.orçamentosToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.orçamentosToolStripMenuItem.Text = "Orçamentos";
            this.orçamentosToolStripMenuItem.Click += new System.EventHandler(this.orçamentosToolStripMenuItem_Click);
            // 
            // propostasToolStripMenuItem
            // 
            this.propostasToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.propostasToolStripMenuItem.Name = "propostasToolStripMenuItem";
            this.propostasToolStripMenuItem.Size = new System.Drawing.Size(81, 22);
            this.propostasToolStripMenuItem.Text = "Propostas";
            this.propostasToolStripMenuItem.Click += new System.EventHandler(this.propostasToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // serviçosToolStripMenuItem
            // 
            this.serviçosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.serviçosToolStripMenuItem.Name = "serviçosToolStripMenuItem";
            this.serviçosToolStripMenuItem.Size = new System.Drawing.Size(69, 22);
            this.serviçosToolStripMenuItem.Text = "Serviços";
            this.serviçosToolStripMenuItem.Click += new System.EventHandler(this.serviçosToolStripMenuItem_Click);
            // 
            // labelNotificacao
            // 
            this.labelNotificacao.Location = new System.Drawing.Point(271, 31);
            this.labelNotificacao.Name = "labelNotificacao";
            this.labelNotificacao.Size = new System.Drawing.Size(387, 14);
            this.labelNotificacao.TabIndex = 3;
            this.labelNotificacao.Text = "Notificações";
            this.labelNotificacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(150, 125);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(382, 150);
            this.pictureBoxLogo.TabIndex = 2;
            this.pictureBoxLogo.TabStop = false;
            // 
            // pictureBoxNotificacao
            // 
            this.pictureBoxNotificacao.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNotificacao.Image")));
            this.pictureBoxNotificacao.Location = new System.Drawing.Point(662, 31);
            this.pictureBoxNotificacao.Name = "pictureBoxNotificacao";
            this.pictureBoxNotificacao.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxNotificacao.TabIndex = 4;
            this.pictureBoxNotificacao.TabStop = false;
            // 
            // Painel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.Controls.Add(this.pictureBoxNotificacao);
            this.Controls.Add(this.labelNotificacao);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.menuStripPainel);
            this.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripPainel;
            this.MaximizeBox = false;
            this.Name = "Painel";
            this.Text = "Promax | Propostas ágeis";
            this.menuStripPainel.ResumeLayout(false);
            this.menuStripPainel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotificacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStripPainel;
        private System.Windows.Forms.ToolStripMenuItem propostasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviçosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orçamentosToolStripMenuItem;
        private System.Windows.Forms.Label labelNotificacao;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.PictureBox pictureBoxNotificacao;
    }
}

