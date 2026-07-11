namespace LaCasaDelBosqueApp
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbHistoria = new System.Windows.Forms.RichTextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.txtComando = new System.Windows.Forms.TextBox();
            this.picEscena = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picEscena)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbHistoria
            // 
            this.rtbHistoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbHistoria.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rtbHistoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbHistoria.ForeColor = System.Drawing.SystemColors.Info;
            this.rtbHistoria.Location = new System.Drawing.Point(12, 45);
            this.rtbHistoria.Name = "rtbHistoria";
            this.rtbHistoria.ReadOnly = true;
            this.rtbHistoria.Size = new System.Drawing.Size(195, 388);
            this.rtbHistoria.TabIndex = 1;
            this.rtbHistoria.TabStop = false;
            this.rtbHistoria.Text = "";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnviar.Location = new System.Drawing.Point(12, 465);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(195, 23);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.Text = "Continuar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUbicacion.ForeColor = System.Drawing.Color.White;
            this.lblUbicacion.Location = new System.Drawing.Point(247, 18);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(51, 20);
            this.lblUbicacion.TabIndex = 3;
            this.lblUbicacion.Text = "label1";
            this.lblUbicacion.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtComando
            // 
            this.txtComando.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtComando.Location = new System.Drawing.Point(12, 439);
            this.txtComando.Name = "txtComando";
            this.txtComando.Size = new System.Drawing.Size(195, 20);
            this.txtComando.TabIndex = 4;
            // 
            // picEscena
            // 
            this.picEscena.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picEscena.Location = new System.Drawing.Point(213, 45);
            this.picEscena.Name = "picEscena";
            this.picEscena.Size = new System.Drawing.Size(447, 443);
            this.picEscena.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEscena.TabIndex = 5;
            this.picEscena.TabStop = false;
            this.picEscena.Click += new System.EventHandler(this.picEscena_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Historia";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(664, 500);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picEscena);
            this.Controls.Add(this.txtComando);
            this.Controls.Add(this.lblUbicacion);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.rtbHistoria);
            this.Name = "Form1";
            this.Text = "La casa del bosque";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picEscena)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbHistoria;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.TextBox txtComando;
        private System.Windows.Forms.PictureBox picEscena;
        private System.Windows.Forms.Label label1;
    }
}

