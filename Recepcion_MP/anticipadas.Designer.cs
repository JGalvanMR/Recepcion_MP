namespace Recepcion_MP
{
    partial class anticipadas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbtil = new System.Windows.Forms.Label();
            this.dtgGrado1 = new System.Windows.Forms.DataGridView();
            this.dtgGrado2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGrado1 = new System.Windows.Forms.TextBox();
            this.txtGrado2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOrdenCompra = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSurtido = new System.Windows.Forms.Label();
            this.lblSurtido2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCantidad2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblFecha2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblOrdenCompra2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRecibo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCveProd = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCveProv = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCosto = new System.Windows.Forms.Label();
            this.lblCosto2 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.PBbtnsalir = new System.Windows.Forms.PictureBox();
            this.numero_oc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_oc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_oc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surtido_oc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_oc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_oc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_oc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surtido_oc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrado1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrado2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBbtnsalir)).BeginInit();
            this.SuspendLayout();
            // 
            // lbtil
            // 
            this.lbtil.AutoSize = true;
            this.lbtil.BackColor = System.Drawing.Color.Transparent;
            this.lbtil.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtil.ForeColor = System.Drawing.Color.White;
            this.lbtil.Location = new System.Drawing.Point(231, 9);
            this.lbtil.Name = "lbtil";
            this.lbtil.Size = new System.Drawing.Size(382, 20);
            this.lbtil.TabIndex = 102;
            this.lbtil.Text = "SELECCION DE ORDEN DE COMPRA ANTICIPADA";
            // 
            // dtgGrado1
            // 
            this.dtgGrado1.AllowUserToAddRows = false;
            this.dtgGrado1.AllowUserToDeleteRows = false;
            this.dtgGrado1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgGrado1.BackgroundColor = System.Drawing.Color.White;
            this.dtgGrado1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrado1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero_oc,
            this.fecha_oc,
            this.cantidad_oc,
            this.surtido_oc,
            this.costo});
            this.dtgGrado1.GridColor = System.Drawing.Color.Black;
            this.dtgGrado1.Location = new System.Drawing.Point(12, 102);
            this.dtgGrado1.Name = "dtgGrado1";
            this.dtgGrado1.ReadOnly = true;
            this.dtgGrado1.RowHeadersVisible = false;
            this.dtgGrado1.Size = new System.Drawing.Size(407, 162);
            this.dtgGrado1.TabIndex = 103;
            this.dtgGrado1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGrado1_CellClick);
            // 
            // dtgGrado2
            // 
            this.dtgGrado2.AllowUserToAddRows = false;
            this.dtgGrado2.AllowUserToDeleteRows = false;
            this.dtgGrado2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgGrado2.BackgroundColor = System.Drawing.Color.White;
            this.dtgGrado2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrado2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero_oc2,
            this.fecha_oc2,
            this.cantidad_oc2,
            this.surtido_oc2,
            this.costo2});
            this.dtgGrado2.GridColor = System.Drawing.Color.Black;
            this.dtgGrado2.Location = new System.Drawing.Point(425, 102);
            this.dtgGrado2.Name = "dtgGrado2";
            this.dtgGrado2.ReadOnly = true;
            this.dtgGrado2.RowHeadersVisible = false;
            this.dtgGrado2.Size = new System.Drawing.Size(407, 162);
            this.dtgGrado2.TabIndex = 104;
            this.dtgGrado2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGrado2_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 105;
            this.label1.Text = "Grado 1:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(422, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 106;
            this.label2.Text = "Grado 2:";
            this.label2.Visible = false;
            // 
            // txtGrado1
            // 
            this.txtGrado1.Location = new System.Drawing.Point(68, 71);
            this.txtGrado1.Name = "txtGrado1";
            this.txtGrado1.Size = new System.Drawing.Size(100, 24);
            this.txtGrado1.TabIndex = 107;
            this.txtGrado1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGrado1.Visible = false;
            // 
            // txtGrado2
            // 
            this.txtGrado2.Location = new System.Drawing.Point(481, 71);
            this.txtGrado2.Name = "txtGrado2";
            this.txtGrado2.Size = new System.Drawing.Size(100, 24);
            this.txtGrado2.TabIndex = 108;
            this.txtGrado2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGrado2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 109;
            this.label3.Text = "Orden Cmp:";
            // 
            // lblOrdenCompra
            // 
            this.lblOrdenCompra.AutoSize = true;
            this.lblOrdenCompra.BackColor = System.Drawing.Color.Transparent;
            this.lblOrdenCompra.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenCompra.ForeColor = System.Drawing.Color.Black;
            this.lblOrdenCompra.Location = new System.Drawing.Point(88, 276);
            this.lblOrdenCompra.Name = "lblOrdenCompra";
            this.lblOrdenCompra.Size = new System.Drawing.Size(13, 15);
            this.lblOrdenCompra.TabIndex = 110;
            this.lblOrdenCompra.Text = "-";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Black;
            this.lblFecha.Location = new System.Drawing.Point(88, 302);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(13, 15);
            this.lblFecha.TabIndex = 112;
            this.lblFecha.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(9, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 111;
            this.label5.Text = "Fecha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 113;
            this.label4.Text = "Cantidad:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidad.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.Black;
            this.lblCantidad.Location = new System.Drawing.Point(88, 331);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(13, 15);
            this.lblCantidad.TabIndex = 114;
            this.lblCantidad.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(9, 360);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 115;
            this.label6.Text = "Surtido:";
            // 
            // lblSurtido
            // 
            this.lblSurtido.AutoSize = true;
            this.lblSurtido.BackColor = System.Drawing.Color.Transparent;
            this.lblSurtido.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurtido.ForeColor = System.Drawing.Color.Black;
            this.lblSurtido.Location = new System.Drawing.Point(88, 360);
            this.lblSurtido.Name = "lblSurtido";
            this.lblSurtido.Size = new System.Drawing.Size(13, 15);
            this.lblSurtido.TabIndex = 116;
            this.lblSurtido.Text = "-";
            // 
            // lblSurtido2
            // 
            this.lblSurtido2.AutoSize = true;
            this.lblSurtido2.BackColor = System.Drawing.Color.Transparent;
            this.lblSurtido2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurtido2.ForeColor = System.Drawing.Color.Black;
            this.lblSurtido2.Location = new System.Drawing.Point(501, 360);
            this.lblSurtido2.Name = "lblSurtido2";
            this.lblSurtido2.Size = new System.Drawing.Size(13, 15);
            this.lblSurtido2.TabIndex = 124;
            this.lblSurtido2.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(422, 360);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 15);
            this.label8.TabIndex = 123;
            this.label8.Text = "Surtido:";
            // 
            // lblCantidad2
            // 
            this.lblCantidad2.AutoSize = true;
            this.lblCantidad2.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidad2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad2.ForeColor = System.Drawing.Color.Black;
            this.lblCantidad2.Location = new System.Drawing.Point(501, 331);
            this.lblCantidad2.Name = "lblCantidad2";
            this.lblCantidad2.Size = new System.Drawing.Size(13, 15);
            this.lblCantidad2.TabIndex = 122;
            this.lblCantidad2.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(422, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 15);
            this.label10.TabIndex = 121;
            this.label10.Text = "Cantidad:";
            // 
            // lblFecha2
            // 
            this.lblFecha2.AutoSize = true;
            this.lblFecha2.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha2.ForeColor = System.Drawing.Color.Black;
            this.lblFecha2.Location = new System.Drawing.Point(501, 302);
            this.lblFecha2.Name = "lblFecha2";
            this.lblFecha2.Size = new System.Drawing.Size(13, 15);
            this.lblFecha2.TabIndex = 120;
            this.lblFecha2.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(422, 302);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 15);
            this.label12.TabIndex = 119;
            this.label12.Text = "Fecha:";
            // 
            // lblOrdenCompra2
            // 
            this.lblOrdenCompra2.AutoSize = true;
            this.lblOrdenCompra2.BackColor = System.Drawing.Color.Transparent;
            this.lblOrdenCompra2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenCompra2.ForeColor = System.Drawing.Color.Black;
            this.lblOrdenCompra2.Location = new System.Drawing.Point(501, 276);
            this.lblOrdenCompra2.Name = "lblOrdenCompra2";
            this.lblOrdenCompra2.Size = new System.Drawing.Size(13, 15);
            this.lblOrdenCompra2.TabIndex = 118;
            this.lblOrdenCompra2.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(422, 276);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 15);
            this.label14.TabIndex = 117;
            this.label14.Text = "Orden Cmp:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnGuardar.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(378, 410);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(88, 27);
            this.btnGuardar.TabIndex = 125;
            this.btnGuardar.Text = "ACEPTAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 126;
            this.label7.Text = "Recibo:";
            // 
            // lblRecibo
            // 
            this.lblRecibo.AutoSize = true;
            this.lblRecibo.BackColor = System.Drawing.Color.Transparent;
            this.lblRecibo.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecibo.ForeColor = System.Drawing.Color.White;
            this.lblRecibo.Location = new System.Drawing.Point(64, 43);
            this.lblRecibo.Name = "lblRecibo";
            this.lblRecibo.Size = new System.Drawing.Size(13, 15);
            this.lblRecibo.TabIndex = 127;
            this.lblRecibo.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(138, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 15);
            this.label9.TabIndex = 128;
            this.label9.Text = "Producto:";
            // 
            // lblCveProd
            // 
            this.lblCveProd.AutoSize = true;
            this.lblCveProd.BackColor = System.Drawing.Color.Transparent;
            this.lblCveProd.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCveProd.ForeColor = System.Drawing.Color.White;
            this.lblCveProd.Location = new System.Drawing.Point(203, 43);
            this.lblCveProd.Name = "lblCveProd";
            this.lblCveProd.Size = new System.Drawing.Size(13, 15);
            this.lblCveProd.TabIndex = 129;
            this.lblCveProd.Text = "-";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.BackColor = System.Drawing.Color.Transparent;
            this.lblProducto.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.ForeColor = System.Drawing.Color.White;
            this.lblProducto.Location = new System.Drawing.Point(246, 43);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(13, 15);
            this.lblProducto.TabIndex = 130;
            this.lblProducto.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(422, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 15);
            this.label11.TabIndex = 131;
            this.label11.Text = "Proveedor:";
            // 
            // lblCveProv
            // 
            this.lblCveProv.AutoSize = true;
            this.lblCveProv.BackColor = System.Drawing.Color.Transparent;
            this.lblCveProv.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCveProv.ForeColor = System.Drawing.Color.White;
            this.lblCveProv.Location = new System.Drawing.Point(493, 43);
            this.lblCveProv.Name = "lblCveProv";
            this.lblCveProv.Size = new System.Drawing.Size(13, 15);
            this.lblCveProv.TabIndex = 132;
            this.lblCveProv.Text = "-";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.BackColor = System.Drawing.Color.Transparent;
            this.lblProveedor.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.ForeColor = System.Drawing.Color.White;
            this.lblProveedor.Location = new System.Drawing.Point(536, 43);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(13, 15);
            this.lblProveedor.TabIndex = 133;
            this.lblProveedor.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(9, 389);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 15);
            this.label13.TabIndex = 134;
            this.label13.Text = "Costo:";
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.BackColor = System.Drawing.Color.Transparent;
            this.lblCosto.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosto.ForeColor = System.Drawing.Color.Black;
            this.lblCosto.Location = new System.Drawing.Point(88, 389);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(13, 15);
            this.lblCosto.TabIndex = 135;
            this.lblCosto.Text = "-";
            // 
            // lblCosto2
            // 
            this.lblCosto2.AutoSize = true;
            this.lblCosto2.BackColor = System.Drawing.Color.Transparent;
            this.lblCosto2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosto2.ForeColor = System.Drawing.Color.Black;
            this.lblCosto2.Location = new System.Drawing.Point(501, 389);
            this.lblCosto2.Name = "lblCosto2";
            this.lblCosto2.Size = new System.Drawing.Size(13, 15);
            this.lblCosto2.TabIndex = 137;
            this.lblCosto2.Text = "-";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(422, 389);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 15);
            this.label17.TabIndex = 136;
            this.label17.Text = "Costo:";
            // 
            // PBbtnsalir
            // 
            this.PBbtnsalir.Image = global::Recepcion_MP.Properties.Resources.salir;
            this.PBbtnsalir.Location = new System.Drawing.Point(800, 12);
            this.PBbtnsalir.Name = "PBbtnsalir";
            this.PBbtnsalir.Size = new System.Drawing.Size(32, 32);
            this.PBbtnsalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PBbtnsalir.TabIndex = 101;
            this.PBbtnsalir.TabStop = false;
            this.PBbtnsalir.Visible = false;
            // 
            // numero_oc
            // 
            this.numero_oc.HeaderText = "Ord Cmp";
            this.numero_oc.Name = "numero_oc";
            this.numero_oc.ReadOnly = true;
            this.numero_oc.Width = 82;
            // 
            // fecha_oc
            // 
            this.fecha_oc.HeaderText = "Fecha";
            this.fecha_oc.Name = "fecha_oc";
            this.fecha_oc.ReadOnly = true;
            this.fecha_oc.Width = 63;
            // 
            // cantidad_oc
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cantidad_oc.DefaultCellStyle = dataGridViewCellStyle1;
            this.cantidad_oc.HeaderText = "Cantidad";
            this.cantidad_oc.Name = "cantidad_oc";
            this.cantidad_oc.ReadOnly = true;
            this.cantidad_oc.Width = 80;
            // 
            // surtido_oc
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.surtido_oc.DefaultCellStyle = dataGridViewCellStyle2;
            this.surtido_oc.HeaderText = "Surtido";
            this.surtido_oc.Name = "surtido_oc";
            this.surtido_oc.ReadOnly = true;
            this.surtido_oc.Width = 71;
            // 
            // costo
            // 
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            this.costo.Width = 64;
            // 
            // numero_oc2
            // 
            this.numero_oc2.HeaderText = "Ord Cmp";
            this.numero_oc2.Name = "numero_oc2";
            this.numero_oc2.ReadOnly = true;
            this.numero_oc2.Width = 82;
            // 
            // fecha_oc2
            // 
            this.fecha_oc2.HeaderText = "Fecha";
            this.fecha_oc2.Name = "fecha_oc2";
            this.fecha_oc2.ReadOnly = true;
            this.fecha_oc2.Width = 63;
            // 
            // cantidad_oc2
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cantidad_oc2.DefaultCellStyle = dataGridViewCellStyle3;
            this.cantidad_oc2.HeaderText = "Cantidad";
            this.cantidad_oc2.Name = "cantidad_oc2";
            this.cantidad_oc2.ReadOnly = true;
            this.cantidad_oc2.Width = 80;
            // 
            // surtido_oc2
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.surtido_oc2.DefaultCellStyle = dataGridViewCellStyle4;
            this.surtido_oc2.HeaderText = "Surtido";
            this.surtido_oc2.Name = "surtido_oc2";
            this.surtido_oc2.ReadOnly = true;
            this.surtido_oc2.Width = 71;
            // 
            // costo2
            // 
            this.costo2.HeaderText = "Costo";
            this.costo2.Name = "costo2";
            this.costo2.ReadOnly = true;
            this.costo2.Width = 64;
            // 
            // anticipadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(844, 457);
            this.ControlBox = false;
            this.Controls.Add(this.lblCosto2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.lblCveProv);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.lblCveProd);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblRecibo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblSurtido2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblCantidad2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblFecha2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblOrdenCompra2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblSurtido);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblOrdenCompra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGrado2);
            this.Controls.Add(this.txtGrado1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgGrado2);
            this.Controls.Add(this.dtgGrado1);
            this.Controls.Add(this.lbtil);
            this.Controls.Add(this.PBbtnsalir);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "anticipadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenes de Compra Anticipadas";
            this.Load += new System.EventHandler(this.anticipadas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrado1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrado2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBbtnsalir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PBbtnsalir;
        private System.Windows.Forms.Label lbtil;
        private System.Windows.Forms.DataGridView dtgGrado1;
        private System.Windows.Forms.DataGridView dtgGrado2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGrado1;
        private System.Windows.Forms.TextBox txtGrado2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOrdenCompra;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSurtido;
        private System.Windows.Forms.Label lblSurtido2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCantidad2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblFecha2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblOrdenCompra2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblRecibo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCveProd;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCveProv;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Label lblCosto2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_oc;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_oc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_oc;
        private System.Windows.Forms.DataGridViewTextBoxColumn surtido_oc;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_oc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_oc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_oc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn surtido_oc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo2;
    }
}