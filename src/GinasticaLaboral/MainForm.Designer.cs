namespace GinasticaLaboral
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.defaultTimer = new System.Windows.Forms.Timer(this.components);
            this.agoraNaoButton = new System.Windows.Forms.Button();
            this.defaultNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exibirAgoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exibicaoAutomaticaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.naoExibirCampanhaLinkLabel = new System.Windows.Forms.LinkLabel();
            this.iniciarPictureBox = new System.Windows.Forms.PictureBox();
            this.agoraNaoPictureBox = new System.Windows.Forms.PictureBox();
            this.trayContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iniciarPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agoraNaoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultTimer
            // 
            this.defaultTimer.Interval = 1000;
            this.defaultTimer.Tick += new System.EventHandler(this.defaultTimer_Tick);
            // 
            // agoraNaoButton
            // 
            this.agoraNaoButton.Location = new System.Drawing.Point(139, 61);
            this.agoraNaoButton.Name = "agoraNaoButton";
            this.agoraNaoButton.Size = new System.Drawing.Size(75, 23);
            this.agoraNaoButton.TabIndex = 1;
            this.agoraNaoButton.Text = "Agora não.";
            this.agoraNaoButton.UseVisualStyleBackColor = true;
            this.agoraNaoButton.Visible = false;
            // 
            // defaultNotifyIcon
            // 
            this.defaultNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.defaultNotifyIcon.ContextMenuStrip = this.trayContextMenuStrip;
            this.defaultNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("defaultNotifyIcon.Icon")));
            this.defaultNotifyIcon.Tag = "0";
            this.defaultNotifyIcon.Text = "Ginástica Laboral";
            this.defaultNotifyIcon.Visible = true;
            // 
            // trayContextMenuStrip
            // 
            this.trayContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exibirAgoraToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exibicaoAutomaticaToolStripMenuItem});
            this.trayContextMenuStrip.Name = "trayContextMenuStrip";
            this.trayContextMenuStrip.Size = new System.Drawing.Size(196, 76);
            // 
            // exibirAgoraToolStripMenuItem
            // 
            this.exibirAgoraToolStripMenuItem.Name = "exibirAgoraToolStripMenuItem";
            this.exibirAgoraToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exibirAgoraToolStripMenuItem.Text = "Iniciar ginástica laboral";
            this.exibirAgoraToolStripMenuItem.Click += new System.EventHandler(this.exibirAgoraToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 6);
            // 
            // exibicaoAutomaticaToolStripMenuItem
            // 
            this.exibicaoAutomaticaToolStripMenuItem.Checked = true;
            this.exibicaoAutomaticaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.exibicaoAutomaticaToolStripMenuItem.Name = "exibicaoAutomaticaToolStripMenuItem";
            this.exibicaoAutomaticaToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exibicaoAutomaticaToolStripMenuItem.Text = "Campanha ativa";
            this.exibicaoAutomaticaToolStripMenuItem.Click += new System.EventHandler(this.exibicaoAutomaticaToolStripMenuItem_Click);
            // 
            // iniciarButton
            // 
            this.iniciarButton.Location = new System.Drawing.Point(139, 16);
            this.iniciarButton.Name = "iniciarButton";
            this.iniciarButton.Size = new System.Drawing.Size(75, 23);
            this.iniciarButton.TabIndex = 3;
            this.iniciarButton.Text = "Começar!";
            this.iniciarButton.UseVisualStyleBackColor = true;
            this.iniciarButton.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GinasticaLaboral.Properties.Resources.f1245e02452875273d49c3eb5328336f5454b9a3;
            this.pictureBox2.Location = new System.Drawing.Point(280, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(135, 83);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // naoExibirCampanhaLinkLabel
            // 
            this.naoExibirCampanhaLinkLabel.AutoSize = true;
            this.naoExibirCampanhaLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.naoExibirCampanhaLinkLabel.LinkColor = System.Drawing.Color.SteelBlue;
            this.naoExibirCampanhaLinkLabel.Location = new System.Drawing.Point(12, 78);
            this.naoExibirCampanhaLinkLabel.Name = "naoExibirCampanhaLinkLabel";
            this.naoExibirCampanhaLinkLabel.Size = new System.Drawing.Size(186, 13);
            this.naoExibirCampanhaLinkLabel.TabIndex = 8;
            this.naoExibirCampanhaLinkLabel.TabStop = true;
            this.naoExibirCampanhaLinkLabel.Text = "Não exibir esta campanha novamente";
            this.naoExibirCampanhaLinkLabel.Click += new System.EventHandler(this.naoExibirCampanhaLinkLabel_Click);
            // 
            // iniciarPictureBox
            // 
            this.iniciarPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iniciarPictureBox.Image = global::GinasticaLaboral.Properties.Resources.BotaoIniciar;
            this.iniciarPictureBox.Location = new System.Drawing.Point(423, 16);
            this.iniciarPictureBox.Name = "iniciarPictureBox";
            this.iniciarPictureBox.Size = new System.Drawing.Size(103, 31);
            this.iniciarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iniciarPictureBox.TabIndex = 9;
            this.iniciarPictureBox.TabStop = false;
            this.iniciarPictureBox.Click += new System.EventHandler(this.iniciarPictureBox_Click);
            // 
            // agoraNaoPictureBox
            // 
            this.agoraNaoPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.agoraNaoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("agoraNaoPictureBox.Image")));
            this.agoraNaoPictureBox.Location = new System.Drawing.Point(423, 53);
            this.agoraNaoPictureBox.Name = "agoraNaoPictureBox";
            this.agoraNaoPictureBox.Size = new System.Drawing.Size(103, 31);
            this.agoraNaoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.agoraNaoPictureBox.TabIndex = 10;
            this.agoraNaoPictureBox.TabStop = false;
            this.agoraNaoPictureBox.Click += new System.EventHandler(this.agoraNaoPictureBox_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::GinasticaLaboral.Properties.Resources.FundoAlerta;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(541, 100);
            this.Controls.Add(this.agoraNaoPictureBox);
            this.Controls.Add(this.iniciarPictureBox);
            this.Controls.Add(this.iniciarButton);
            this.Controls.Add(this.agoraNaoButton);
            this.Controls.Add(this.naoExibirCampanhaLinkLabel);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Projeto Saúde Plena";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.trayContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iniciarPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agoraNaoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer defaultTimer;
        private System.Windows.Forms.Button agoraNaoButton;
        private System.Windows.Forms.NotifyIcon defaultNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip trayContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exibirAgoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exibicaoAutomaticaToolStripMenuItem;
        private System.Windows.Forms.Button iniciarButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel naoExibirCampanhaLinkLabel;
        private System.Windows.Forms.PictureBox iniciarPictureBox;
        private System.Windows.Forms.PictureBox agoraNaoPictureBox;
    }
}

