namespace Recepcion_MP
{
    partial class FrmClasifi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblProv = new System.Windows.Forms.Label();
            this.PBbtnsalir = new System.Windows.Forms.PictureBox();
            this.LblFolio = new System.Windows.Forms.Label();
            this.LblCveProd = new System.Windows.Forms.Label();
            this.LblProd = new System.Windows.Forms.Label();
            this.DGDatos = new System.Windows.Forms.DataGridView();
            this.txtprod = new System.Windows.Forms.ComboBox();
            this.txtprod_clave = new System.Windows.Forms.TextBox();
            this.lbprod = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtUtil = new System.Windows.Forms.TextBox();
            this.BtnGraba = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtKg = new System.Windows.Forms.TextBox();
            this.TxtTotCan = new System.Windows.Forms.TextBox();
            this.TxtTotKg = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CVEMP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMPROD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANASTILLAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KGS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBbtnsalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.LblProv);
            this.panel1.Controls.Add(this.PBbtnsalir);
            this.panel1.Controls.Add(this.LblFolio);
            this.panel1.Controls.Add(this.LblCveProd);
            this.panel1.Controls.Add(this.LblProd);
            this.panel1.Location = new System.Drawing.Point(14, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 100);
            this.panel1.TabIndex = 1;
            // 
            // LblProv
            // 
            this.LblProv.BackColor = System.Drawing.Color.Transparent;
            this.LblProv.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProv.ForeColor = System.Drawing.Color.White;
            this.LblProv.Location = new System.Drawing.Point(12, 38);
            this.LblProv.Name = "LblProv";
            this.LblProv.Size = new System.Drawing.Size(398, 55);
            this.LblProv.TabIndex = 422;
            this.LblProv.Text = "Proveedor";
            // 
            // PBbtnsalir
            // 
            this.PBbtnsalir.BackColor = System.Drawing.Color.Transparent;
            this.PBbtnsalir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PBbtnsalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBbtnsalir.Image = global::Recepcion_MP.Properties.Resources.BtnSalir_Mini;
            this.PBbtnsalir.Location = new System.Drawing.Point(694, 27);
            this.PBbtnsalir.Name = "PBbtnsalir";
            this.PBbtnsalir.Size = new System.Drawing.Size(40, 41);
            this.PBbtnsalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PBbtnsalir.TabIndex = 421;
            this.PBbtnsalir.TabStop = false;
            this.toolTip1.SetToolTip(this.PBbtnsalir, "Salir");
            this.PBbtnsalir.Click += new System.EventHandler(this.PBbtnsalir_Click);
            // 
            // LblFolio
            // 
            this.LblFolio.AutoSize = true;
            this.LblFolio.BackColor = System.Drawing.Color.Transparent;
            this.LblFolio.Font = new System.Drawing.Font("Lucida Sans Unicode", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFolio.ForeColor = System.Drawing.Color.Yellow;
            this.LblFolio.Location = new System.Drawing.Point(12, 11);
            this.LblFolio.Name = "LblFolio";
            this.LblFolio.Size = new System.Drawing.Size(56, 23);
            this.LblFolio.TabIndex = 420;
            this.LblFolio.Text = "Folio";
            // 
            // LblCveProd
            // 
            this.LblCveProd.AutoSize = true;
            this.LblCveProd.BackColor = System.Drawing.Color.Transparent;
            this.LblCveProd.Font = new System.Drawing.Font("Lucida Sans Unicode", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCveProd.ForeColor = System.Drawing.Color.Yellow;
            this.LblCveProd.Location = new System.Drawing.Point(84, 14);
            this.LblCveProd.Name = "LblCveProd";
            this.LblCveProd.Size = new System.Drawing.Size(36, 18);
            this.LblCveProd.TabIndex = 419;
            this.LblCveProd.Text = "Cve";
            // 
            // LblProd
            // 
            this.LblProd.AutoSize = true;
            this.LblProd.BackColor = System.Drawing.Color.Transparent;
            this.LblProd.Font = new System.Drawing.Font("Lucida Sans Unicode", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProd.ForeColor = System.Drawing.Color.Yellow;
            this.LblProd.Location = new System.Drawing.Point(133, 14);
            this.LblProd.Name = "LblProd";
            this.LblProd.Size = new System.Drawing.Size(81, 18);
            this.LblProd.TabIndex = 418;
            this.LblProd.Text = "Producto:";
            // 
            // DGDatos
            // 
            this.DGDatos.AllowUserToAddRows = false;
            this.DGDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CVEMP,
            this.NOMPROD,
            this.CANASTILLAS,
            this.KGS});
            this.DGDatos.Location = new System.Drawing.Point(12, 214);
            this.DGDatos.Name = "DGDatos";
            this.DGDatos.Size = new System.Drawing.Size(736, 256);
            this.DGDatos.TabIndex = 3;
            this.DGDatos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGDatos_CellEndEdit);
            // 
            // txtprod
            // 
            this.txtprod.DropDownHeight = 100;
            this.txtprod.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txtprod.FormattingEnabled = true;
            this.txtprod.IntegralHeight = false;
            this.txtprod.Location = new System.Drawing.Point(338, 187);
            this.txtprod.Name = "txtprod";
            this.txtprod.Size = new System.Drawing.Size(260, 24);
            this.txtprod.TabIndex = 2;
            this.txtprod.SelectionChangeCommitted += new System.EventHandler(this.txtprod_SelectionChangeCommitted);
            // 
            // txtprod_clave
            // 
            this.txtprod_clave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtprod_clave.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprod_clave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txtprod_clave.Location = new System.Drawing.Point(269, 185);
            this.txtprod_clave.MaxLength = 10;
            this.txtprod_clave.Name = "txtprod_clave";
            this.txtprod_clave.Size = new System.Drawing.Size(65, 27);
            this.txtprod_clave.TabIndex = 1;
            this.txtprod_clave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtprod_clave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprod_clave_KeyPress);
            // 
            // lbprod
            // 
            this.lbprod.AutoSize = true;
            this.lbprod.BackColor = System.Drawing.Color.Transparent;
            this.lbprod.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbprod.ForeColor = System.Drawing.Color.Black;
            this.lbprod.Location = new System.Drawing.Point(337, 167);
            this.lbprod.Name = "lbprod";
            this.lbprod.Size = new System.Drawing.Size(68, 16);
            this.lbprod.TabIndex = 552;
            this.lbprod.Text = "Producto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 553;
            this.label1.Text = "Unidades Disponibles:";
            // 
            // TxtCan
            // 
            this.TxtCan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCan.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.TxtCan.Location = new System.Drawing.Point(169, 118);
            this.TxtCan.MaxLength = 10;
            this.TxtCan.Name = "TxtCan";
            this.TxtCan.ReadOnly = true;
            this.TxtCan.Size = new System.Drawing.Size(72, 27);
            this.TxtCan.TabIndex = 554;
            this.TxtCan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 16);
            this.label2.TabIndex = 555;
            this.label2.Text = "Unidades A Clasificar:";
            // 
            // TxtUtil
            // 
            this.TxtUtil.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtUtil.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUtil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.TxtUtil.Location = new System.Drawing.Point(166, 185);
            this.TxtUtil.MaxLength = 10;
            this.TxtUtil.Name = "TxtUtil";
            this.TxtUtil.Size = new System.Drawing.Size(92, 27);
            this.TxtUtil.TabIndex = 0;
            this.TxtUtil.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtUtil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUtil_KeyPress);
            // 
            // BtnGraba
            // 
            this.BtnGraba.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGraba.Image = global::Recepcion_MP.Properties.Resources.save;
            this.BtnGraba.Location = new System.Drawing.Point(673, 142);
            this.BtnGraba.Name = "BtnGraba";
            this.BtnGraba.Size = new System.Drawing.Size(75, 67);
            this.BtnGraba.TabIndex = 557;
            this.toolTip1.SetToolTip(this.BtnGraba, "Guardar Informacion");
            this.BtnGraba.UseVisualStyleBackColor = true;
            this.BtnGraba.Visible = false;
            this.BtnGraba.Click += new System.EventHandler(this.BtnGraba_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 558;
            this.label3.Text = "Kilos Disponibles:";
            // 
            // TxtKg
            // 
            this.TxtKg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtKg.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtKg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.TxtKg.Location = new System.Drawing.Point(169, 151);
            this.TxtKg.MaxLength = 10;
            this.TxtKg.Name = "TxtKg";
            this.TxtKg.ReadOnly = true;
            this.TxtKg.Size = new System.Drawing.Size(88, 27);
            this.TxtKg.TabIndex = 559;
            this.TxtKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtTotCan
            // 
            this.TxtTotCan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTotCan.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotCan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.TxtTotCan.Location = new System.Drawing.Point(402, 473);
            this.TxtTotCan.MaxLength = 10;
            this.TxtTotCan.Name = "TxtTotCan";
            this.TxtTotCan.ReadOnly = true;
            this.TxtTotCan.Size = new System.Drawing.Size(88, 27);
            this.TxtTotCan.TabIndex = 560;
            this.TxtTotCan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtTotKg
            // 
            this.TxtTotKg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTotKg.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotKg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.TxtTotKg.Location = new System.Drawing.Point(496, 473);
            this.TxtTotKg.MaxLength = 10;
            this.TxtTotKg.Name = "TxtTotKg";
            this.TxtTotKg.ReadOnly = true;
            this.TxtTotKg.Size = new System.Drawing.Size(100, 27);
            this.TxtTotKg.TabIndex = 561;
            this.TxtTotKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CVEMP
            // 
            this.CVEMP.HeaderText = "CLAVE";
            this.CVEMP.Name = "CVEMP";
            this.CVEMP.ReadOnly = true;
            // 
            // NOMPROD
            // 
            this.NOMPROD.HeaderText = "NOMBRE";
            this.NOMPROD.Name = "NOMPROD";
            this.NOMPROD.ReadOnly = true;
            this.NOMPROD.Width = 250;
            // 
            // CANASTILLAS
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CANASTILLAS.DefaultCellStyle = dataGridViewCellStyle1;
            this.CANASTILLAS.HeaderText = "CANASTILLAS";
            this.CANASTILLAS.Name = "CANASTILLAS";
            // 
            // KGS
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.KGS.DefaultCellStyle = dataGridViewCellStyle2;
            this.KGS.HeaderText = "KILOS";
            this.KGS.Name = "KGS";
            // 
            // FrmClasifi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 525);
            this.ControlBox = false;
            this.Controls.Add(this.TxtTotKg);
            this.Controls.Add(this.TxtTotCan);
            this.Controls.Add(this.TxtKg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnGraba);
            this.Controls.Add(this.TxtUtil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtCan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbprod);
            this.Controls.Add(this.txtprod);
            this.Controls.Add(this.txtprod_clave);
            this.Controls.Add(this.DGDatos);
            this.Controls.Add(this.panel1);
            this.Name = "FrmClasifi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CLASIFICACION DE LA MATERIA PRIMA";
            this.Load += new System.EventHandler(this.FrmClasifi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBbtnsalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox PBbtnsalir;
        private System.Windows.Forms.Label LblFolio;
        private System.Windows.Forms.Label LblCveProd;
        private System.Windows.Forms.Label LblProd;
        private System.Windows.Forms.DataGridView DGDatos;
        private System.Windows.Forms.ComboBox txtprod;
        private System.Windows.Forms.TextBox txtprod_clave;
        private System.Windows.Forms.Label lbprod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtCan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtUtil;
        private System.Windows.Forms.Button BtnGraba;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtKg;
        private System.Windows.Forms.TextBox TxtTotCan;
        private System.Windows.Forms.TextBox TxtTotKg;
        private System.Windows.Forms.Label LblProv;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CVEMP;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMPROD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANASTILLAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn KGS;
    }
}