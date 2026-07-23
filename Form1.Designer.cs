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
            this.lblpprompt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picEscena)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbHistoria
            // 
            this.rtbHistoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbHistoria.BackColor = System.Drawing.Color.Black;
            this.rtbHistoria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbHistoria.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbHistoria.ForeColor = System.Drawing.Color.White;
            this.rtbHistoria.Location = new System.Drawing.Point(12, 45);
            this.rtbHistoria.Name = "rtbHistoria";
            this.rtbHistoria.ReadOnly = true;
            this.rtbHistoria.Size = new System.Drawing.Size(257, 362);
            this.rtbHistoria.TabIndex = 1;
            this.rtbHistoria.TabStop = false;
            this.rtbHistoria.Text = "";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnviar.BackColor = System.Drawing.Color.Black;
            this.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(12, 454);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(257, 25);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.BackColor = System.Drawing.Color.Black;
            this.lblUbicacion.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUbicacion.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblUbicacion.Location = new System.Drawing.Point(282, 19);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(49, 15);
            this.lblUbicacion.TabIndex = 3;
            this.lblUbicacion.Text = "label1";
            this.lblUbicacion.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtComando
            // 
            this.txtComando.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtComando.BackColor = System.Drawing.Color.Black;
            this.txtComando.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComando.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComando.ForeColor = System.Drawing.Color.White;
            this.txtComando.Location = new System.Drawing.Point(12, 423);
            this.txtComando.Name = "txtComando";
            this.txtComando.Size = new System.Drawing.Size(257, 25);
            this.txtComando.TabIndex = 4;
            // 
            // picEscena
            // 
            this.picEscena.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picEscena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEscena.Location = new System.Drawing.Point(275, 45);
            this.picEscena.Name = "picEscena";
            this.picEscena.Size = new System.Drawing.Size(510, 434);
            this.picEscena.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEscena.TabIndex = 5;
            this.picEscena.TabStop = false;
            this.picEscena.Click += new System.EventHandler(this.picEscena_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "La Casa Del Bosque";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lblpprompt
            // 
            this.lblpprompt.AutoSize = true;
            this.lblpprompt.BackColor = System.Drawing.Color.Black;
            this.lblpprompt.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpprompt.ForeColor = System.Drawing.Color.White;
            this.lblpprompt.Location = new System.Drawing.Point(8, 436);
            this.lblpprompt.Name = "lblpprompt";
            this.lblpprompt.Size = new System.Drawing.Size(0, 19);
            this.lblpprompt.TabIndex = 7;
            this.lblpprompt.Click += new System.EventHandler(this.lblpprompt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(797, 500);
            this.Controls.Add(this.lblpprompt);
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
        private System.Windows.Forms.Label lblpprompt;
    }
}

