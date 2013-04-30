namespace SubRen
{
    partial class frmPrincipal
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
            this.lblCaminhoVideos = new System.Windows.Forms.Label();
            this.txtVideo = new System.Windows.Forms.TextBox();
            this.btnSelecionarVideo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtLegendas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkMesmoVideo = new System.Windows.Forms.CheckBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.btnProcessaVideo = new System.Windows.Forms.Button();
            this.fbdSelecionarDiretorios = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // lblCaminhoVideos
            // 
            this.lblCaminhoVideos.AutoSize = true;
            this.lblCaminhoVideos.Location = new System.Drawing.Point(13, 13);
            this.lblCaminhoVideos.Name = "lblCaminhoVideos";
            this.lblCaminhoVideos.Size = new System.Drawing.Size(70, 13);
            this.lblCaminhoVideos.TabIndex = 0;
            this.lblCaminhoVideos.Text = "Local Vídeos";
            // 
            // txtVideo
            // 
            this.txtVideo.Location = new System.Drawing.Point(102, 10);
            this.txtVideo.Name = "txtVideo";
            this.txtVideo.Size = new System.Drawing.Size(431, 20);
            this.txtVideo.TabIndex = 1;
            this.txtVideo.TextChanged += new System.EventHandler(this.txtVideo_TextChanged);
            // 
            // btnSelecionarVideo
            // 
            this.btnSelecionarVideo.Location = new System.Drawing.Point(539, 8);
            this.btnSelecionarVideo.Name = "btnSelecionarVideo";
            this.btnSelecionarVideo.Size = new System.Drawing.Size(75, 23);
            this.btnSelecionarVideo.TabIndex = 2;
            this.btnSelecionarVideo.Text = "&Selecionar";
            this.btnSelecionarVideo.UseVisualStyleBackColor = true;
            this.btnSelecionarVideo.Click += new System.EventHandler(this.btnSelecionarVideo_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(539, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Se&lecionar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtLegendas
            // 
            this.txtLegendas.Location = new System.Drawing.Point(102, 44);
            this.txtLegendas.Name = "txtLegendas";
            this.txtLegendas.Size = new System.Drawing.Size(431, 20);
            this.txtLegendas.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Local Legendas";
            // 
            // chkMesmoVideo
            // 
            this.chkMesmoVideo.AutoSize = true;
            this.chkMesmoVideo.Checked = true;
            this.chkMesmoVideo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMesmoVideo.Location = new System.Drawing.Point(621, 46);
            this.chkMesmoVideo.Name = "chkMesmoVideo";
            this.chkMesmoVideo.Size = new System.Drawing.Size(115, 17);
            this.chkMesmoVideo.TabIndex = 6;
            this.chkMesmoVideo.Text = "&Mesmo dos Videos";
            this.chkMesmoVideo.UseVisualStyleBackColor = true;
            this.chkMesmoVideo.CheckedChanged += new System.EventHandler(this.chkMesmoVideo_CheckedChanged);
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(13, 73);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(713, 335);
            this.txtResultado.TabIndex = 7;
            // 
            // btnProcessaVideo
            // 
            this.btnProcessaVideo.BackColor = System.Drawing.Color.DarkGreen;
            this.btnProcessaVideo.ForeColor = System.Drawing.Color.LightGreen;
            this.btnProcessaVideo.Location = new System.Drawing.Point(621, 8);
            this.btnProcessaVideo.Name = "btnProcessaVideo";
            this.btnProcessaVideo.Size = new System.Drawing.Size(105, 23);
            this.btnProcessaVideo.TabIndex = 8;
            this.btnProcessaVideo.Text = "&Iniciar";
            this.btnProcessaVideo.UseVisualStyleBackColor = false;
            this.btnProcessaVideo.Click += new System.EventHandler(this.button2_Click);
            // 
            // fbdSelecionarDiretorios
            // 
            this.fbdSelecionarDiretorios.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 420);
            this.Controls.Add(this.btnProcessaVideo);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.chkMesmoVideo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLegendas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelecionarVideo);
            this.Controls.Add(this.txtVideo);
            this.Controls.Add(this.lblCaminhoVideos);
            this.Name = "frmPrincipal";
            this.Text = "SubRen - Subtitle Renamer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaminhoVideos;
        private System.Windows.Forms.TextBox txtVideo;
        private System.Windows.Forms.Button btnSelecionarVideo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtLegendas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkMesmoVideo;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Button btnProcessaVideo;
        private System.Windows.Forms.FolderBrowserDialog fbdSelecionarDiretorios;
    }
}

