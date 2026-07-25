namespace Recepcion_MP
{
    partial class Imprimir_etiqueta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Imprimir_etiqueta));
            this.Etiqueta = new System.Drawing.Printing.PrintDocument();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.lbrecibo = new System.Windows.Forms.Label();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.lbtext2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.txt5 = new System.Windows.Forms.TextBox();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.txt6 = new System.Windows.Forms.TextBox();
            this.txt10 = new System.Windows.Forms.TextBox();
            this.txt8 = new System.Windows.Forms.TextBox();
            this.txt9 = new System.Windows.Forms.TextBox();
            this.txt7 = new System.Windows.Forms.TextBox();
            this.btnsalir = new System.Windows.Forms.Button();
            this.btnimp = new System.Windows.Forms.Button();
            this.lbimpreti = new System.Windows.Forms.Label();
            this.Cbimp = new System.Windows.Forms.ComboBox();
            this.ChkEti = new System.Windows.Forms.CheckBox();
            this.LblTar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Etiqueta
            // 
            this.Etiqueta.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.Etiqueta_PrintPage);
            // 
            // txt1
            // 
            this.txt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt1.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txt1.Location = new System.Drawing.Point(135, 34);
            this.txt1.MaxLength = 50;
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(371, 27);
            this.txt1.TabIndex = 437;
            // 
            // lbrecibo
            // 
            this.lbrecibo.AutoSize = true;
            this.lbrecibo.BackColor = System.Drawing.Color.Transparent;
            this.lbrecibo.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbrecibo.ForeColor = System.Drawing.Color.White;
            this.lbrecibo.Location = new System.Drawing.Point(69, 37);
            this.lbrecibo.Name = "lbrecibo";
            this.lbrecibo.Size = new System.Drawing.Size(60, 16);
            this.lbrecibo.TabIndex = 436;
            this.lbrecibo.Text = "Texto 1:";
            // 
            // txt2
            // 
            this.txt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt2.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txt2.Location = new System.Drawing.Point(135, 69);
            this.txt2.MaxLength = 50;
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(371, 27);
            this.txt2.TabIndex = 439;
            // 
            // lbtext2
            // 
            this.lbtext2.AutoSize = true;
            this.lbtext2.BackColor = System.Drawing.Color.Transparent;
            this.lbtext2.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtext2.ForeColor = System.Drawing.Color.White;
            this.lbtext2.Location = new System.Drawing.Point(69, 72);
            this.lbtext2.Name = "lbtext2";
            this.lbtext2.Size = new System.Drawing.Size(60, 16);
            this.lbtext2.TabIndex = 438;
            this.lbtext2.Text = "Texto 2:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(72, 115);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(130, 21);
            this.checkBox1.TabIndex = 440;
            this.checkBox1.Text = "Mostrar detalle";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txt3
            // 
            this.txt3.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txt3.Location = new System.Drawing.Point(135, 142);
            this.txt3.MaxLength = 10;
            this.txt3.Name = "txt3";
            this.txt3.ReadOnly = true;
            this.txt3.Size = new System.Drawing.Size(200, 27);
            this.txt3.TabIndex = 441;
            this.txt3.Text = "Tipo de Corte Ens.";
            // 
            // txt5
            // 
            this.txt5.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txt5.Location = new System.Drawing.Point(135, 209);
            this.txt5.MaxLength = 10;
            this.txt5.Name = "txt5";
            this.txt5.ReadOnly = true;
            this.txt5.Size = new System.Drawing.Size(200, 27);
            this.txt5.TabIndex = 442;
            this.txt5.Text = "%G1 Fresco";
            // 
            // txt4
            // 
            this.txt4.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txt4.Location = new System.Drawing.Point(135, 176);
            this.txt4.MaxLength = 10;
            this.txt4.Name = "txt4";
            this.txt4.ReadOnly = true;
            this.txt4.Size = new System.Drawing.Size(200, 27);
            this.txt4.TabIndex = 442;
            this.txt4.Text = "Diametro Std. de Fresco";
            // 
            // txt6
            // 
            this.txt6.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txt6.Location = new System.Drawing.Point(135, 242);
            this.txt6.MaxLength = 10;
            this.txt6.Name = "txt6";
            this.txt6.ReadOnly = true;
            this.txt6.Size = new System.Drawing.Size(200, 27);
            this.txt6.TabIndex = 443;
            this.txt6.Text = "%G1 Ensaladas";
            // 
            // txt10
            // 
            this.txt10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt10.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txt10.Location = new System.Drawing.Point(341, 242);
            this.txt10.MaxLength = 50;
            this.txt10.Name = "txt10";
            this.txt10.Size = new System.Drawing.Size(165, 27);
            this.txt10.TabIndex = 447;
            // 
            // txt8
            // 
            this.txt8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt8.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txt8.Location = new System.Drawing.Point(341, 176);
            this.txt8.MaxLength = 50;
            this.txt8.Name = "txt8";
            this.txt8.Size = new System.Drawing.Size(165, 27);
            this.txt8.TabIndex = 446;
            // 
            // txt9
            // 
            this.txt9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt9.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txt9.Location = new System.Drawing.Point(341, 209);
            this.txt9.MaxLength = 50;
            this.txt9.Name = "txt9";
            this.txt9.Size = new System.Drawing.Size(165, 27);
            this.txt9.TabIndex = 445;
            // 
            // txt7
            // 
            this.txt7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt7.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txt7.Location = new System.Drawing.Point(341, 142);
            this.txt7.MaxLength = 50;
            this.txt7.Name = "txt7";
            this.txt7.Size = new System.Drawing.Size(165, 27);
            this.txt7.TabIndex = 444;
            // 
            // btnsalir
            // 
            this.btnsalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnsalir.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsalir.ForeColor = System.Drawing.Color.Black;
            this.btnsalir.Location = new System.Drawing.Point(406, 275);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(100, 27);
            this.btnsalir.TabIndex = 449;
            this.btnsalir.Text = "SALIR";
            this.btnsalir.UseVisualStyleBackColor = false;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // btnimp
            // 
            this.btnimp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnimp.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnimp.ForeColor = System.Drawing.Color.Black;
            this.btnimp.Location = new System.Drawing.Point(135, 277);
            this.btnimp.Name = "btnimp";
            this.btnimp.Size = new System.Drawing.Size(98, 27);
            this.btnimp.TabIndex = 448;
            this.btnimp.Text = "IMPRIMIR";
            this.btnimp.UseVisualStyleBackColor = false;
            this.btnimp.Click += new System.EventHandler(this.btnimp_Click);
            // 
            // lbimpreti
            // 
            this.lbimpreti.AutoSize = true;
            this.lbimpreti.BackColor = System.Drawing.Color.Transparent;
            this.lbimpreti.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbimpreti.ForeColor = System.Drawing.Color.White;
            this.lbimpreti.Location = new System.Drawing.Point(240, 116);
            this.lbimpreti.Name = "lbimpreti";
            this.lbimpreti.Size = new System.Drawing.Size(156, 16);
            this.lbimpreti.TabIndex = 450;
            this.lbimpreti.Text = "Impresión de etiquetas:";
            // 
            // Cbimp
            // 
            this.Cbimp.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbimp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.Cbimp.FormattingEnabled = true;
            this.Cbimp.Items.AddRange(new object[] {
            "Detalle",
            "Tarima"});
            this.Cbimp.Location = new System.Drawing.Point(392, 113);
            this.Cbimp.Name = "Cbimp";
            this.Cbimp.Size = new System.Drawing.Size(114, 24);
            this.Cbimp.TabIndex = 548;
            this.Cbimp.SelectionChangeCommitted += new System.EventHandler(this.Cbimp_SelectionChangeCommitted);
            this.Cbimp.TextChanged += new System.EventHandler(this.Cbimp_TextChanged);
            // 
            // ChkEti
            // 
            this.ChkEti.AutoSize = true;
            this.ChkEti.BackColor = System.Drawing.Color.Transparent;
            this.ChkEti.Location = new System.Drawing.Point(12, 179);
            this.ChkEti.Name = "ChkEti";
            this.ChkEti.Size = new System.Drawing.Size(54, 19);
            this.ChkEti.TabIndex = 549;
            this.ChkEti.Text = "Papel";
            this.ChkEti.UseVisualStyleBackColor = false;
            // 
            // LblTar
            // 
            this.LblTar.AutoSize = true;
            this.LblTar.BackColor = System.Drawing.Color.Transparent;
            this.LblTar.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTar.ForeColor = System.Drawing.Color.White;
            this.LblTar.Location = new System.Drawing.Point(512, 121);
            this.LblTar.Name = "LblTar";
            this.LblTar.Size = new System.Drawing.Size(16, 16);
            this.LblTar.TabIndex = 550;
            this.LblTar.Text = "0";
            // 
            // Imprimir_etiqueta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(600, 316);
            this.Controls.Add(this.LblTar);
            this.Controls.Add(this.ChkEti);
            this.Controls.Add(this.Cbimp);
            this.Controls.Add(this.lbimpreti);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.btnimp);
            this.Controls.Add(this.txt10);
            this.Controls.Add(this.txt8);
            this.Controls.Add(this.txt9);
            this.Controls.Add(this.txt7);
            this.Controls.Add(this.txt6);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.txt5);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.lbtext2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.lbrecibo);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Imprimir_etiqueta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir etiqueta";
            this.Load += new System.EventHandler(this.Imprimir_etiqueta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Drawing.Printing.PrintDocument Etiqueta;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Label lbrecibo;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.Label lbtext2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.TextBox txt5;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.TextBox txt6;
        private System.Windows.Forms.TextBox txt10;
        private System.Windows.Forms.TextBox txt8;
        private System.Windows.Forms.TextBox txt9;
        private System.Windows.Forms.TextBox txt7;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.Button btnimp;
        private System.Windows.Forms.Label lbimpreti;
        private System.Windows.Forms.ComboBox Cbimp;
        private System.Windows.Forms.CheckBox ChkEti;
        private System.Windows.Forms.Label LblTar;
    }
}