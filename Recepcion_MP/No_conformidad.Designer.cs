namespace Recepcion_MP
{
    partial class No_conformidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(No_conformidad));
            this.btnselall = new System.Windows.Forms.Button();
            this.ListProd = new System.Windows.Forms.CheckedListBox();
            this.txtnomprov = new System.Windows.Forms.TextBox();
            this.lbprov = new System.Windows.Forms.Label();
            this.btnsalir = new System.Windows.Forms.Button();
            this.txtcontacto = new System.Windows.Forms.TextBox();
            this.lbcontacto = new System.Windows.Forms.Label();
            this.DTPFecNot = new System.Windows.Forms.DateTimePicker();
            this.txtcom = new System.Windows.Forms.TextBox();
            this.lbcom = new System.Windows.Forms.Label();
            this.txtnumemp = new System.Windows.Forms.TextBox();
            this.lbnumemp = new System.Windows.Forms.Label();
            this.lbfot3 = new System.Windows.Forms.Label();
            this.lbfot2 = new System.Windows.Forms.Label();
            this.lbfot1 = new System.Windows.Forms.Label();
            this.txtenc = new System.Windows.Forms.TextBox();
            this.lbenc = new System.Windows.Forms.Label();
            this.txtesp = new System.Windows.Forms.TextBox();
            this.lbesp = new System.Windows.Forms.Label();
            this.lbprod = new System.Windows.Forms.Label();
            this.NUDCanti = new System.Windows.Forms.NumericUpDown();
            this.lbcant = new System.Windows.Forms.Label();
            this.cbturno = new System.Windows.Forms.ComboBox();
            this.lbturno = new System.Windows.Forms.Label();
            this.DTPFec = new System.Windows.Forms.DateTimePicker();
            this.lbfecha = new System.Windows.Forms.Label();
            this.txtfolio = new System.Windows.Forms.TextBox();
            this.lbfolio = new System.Windows.Forms.Label();
            this.txtrecibo = new System.Windows.Forms.TextBox();
            this.lbrecibo = new System.Windows.Forms.Label();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btnfot3 = new System.Windows.Forms.Button();
            this.btnfot2 = new System.Windows.Forms.Button();
            this.btnfot1 = new System.Windows.Forms.Button();
            this.Foto2 = new System.Windows.Forms.OpenFileDialog();
            this.Foto1 = new System.Windows.Forms.OpenFileDialog();
            this.Foto3 = new System.Windows.Forms.OpenFileDialog();
            this.pbfoto1 = new System.Windows.Forms.PictureBox();
            this.pbfoto2 = new System.Windows.Forms.PictureBox();
            this.pbfoto3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCanti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfoto1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfoto2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfoto3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnselall
            // 
            this.btnselall.Location = new System.Drawing.Point(288, 90);
            this.btnselall.Name = "btnselall";
            this.btnselall.Size = new System.Drawing.Size(111, 23);
            this.btnselall.TabIndex = 507;
            this.btnselall.Text = "Seleccionar todo";
            this.btnselall.UseVisualStyleBackColor = true;
            this.btnselall.Click += new System.EventHandler(this.btnselall_Click);
            // 
            // ListProd
            // 
            this.ListProd.FormattingEnabled = true;
            this.ListProd.Location = new System.Drawing.Point(112, 119);
            this.ListProd.Name = "ListProd";
            this.ListProd.Size = new System.Drawing.Size(491, 42);
            this.ListProd.TabIndex = 506;
            this.ListProd.ThreeDCheckBoxes = true;
            // 
            // txtnomprov
            // 
            this.txtnomprov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnomprov.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnomprov.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txtnomprov.Location = new System.Drawing.Point(103, 414);
            this.txtnomprov.MaxLength = 20;
            this.txtnomprov.Name = "txtnomprov";
            this.txtnomprov.Size = new System.Drawing.Size(392, 27);
            this.txtnomprov.TabIndex = 505;
            // 
            // lbprov
            // 
            this.lbprov.AutoSize = true;
            this.lbprov.BackColor = System.Drawing.Color.Transparent;
            this.lbprov.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbprov.ForeColor = System.Drawing.Color.Black;
            this.lbprov.Location = new System.Drawing.Point(23, 417);
            this.lbprov.Name = "lbprov";
            this.lbprov.Size = new System.Drawing.Size(74, 16);
            this.lbprov.TabIndex = 504;
            this.lbprov.Text = "Proveedor:";
            // 
            // btnsalir
            // 
            this.btnsalir.BackgroundImage = global::Recepcion_MP.Properties.Resources.salir;
            this.btnsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsalir.Location = new System.Drawing.Point(552, 465);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(48, 41);
            this.btnsalir.TabIndex = 503;
            this.btnsalir.UseVisualStyleBackColor = true;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // txtcontacto
            // 
            this.txtcontacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcontacto.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcontacto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txtcontacto.Location = new System.Drawing.Point(103, 479);
            this.txtcontacto.MaxLength = 20;
            this.txtcontacto.Name = "txtcontacto";
            this.txtcontacto.Size = new System.Drawing.Size(389, 27);
            this.txtcontacto.TabIndex = 501;
            // 
            // lbcontacto
            // 
            this.lbcontacto.AutoSize = true;
            this.lbcontacto.BackColor = System.Drawing.Color.Transparent;
            this.lbcontacto.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcontacto.ForeColor = System.Drawing.Color.Black;
            this.lbcontacto.Location = new System.Drawing.Point(23, 482);
            this.lbcontacto.Name = "lbcontacto";
            this.lbcontacto.Size = new System.Drawing.Size(69, 16);
            this.lbcontacto.TabIndex = 500;
            this.lbcontacto.Text = "Contacto:";
            // 
            // DTPFecNot
            // 
            this.DTPFecNot.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFecNot.Location = new System.Drawing.Point(175, 447);
            this.DTPFecNot.Name = "DTPFecNot";
            this.DTPFecNot.Size = new System.Drawing.Size(117, 24);
            this.DTPFecNot.TabIndex = 499;
            // 
            // txtcom
            // 
            this.txtcom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcom.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txtcom.Location = new System.Drawing.Point(120, 340);
            this.txtcom.MaxLength = 200;
            this.txtcom.Multiline = true;
            this.txtcom.Name = "txtcom";
            this.txtcom.Size = new System.Drawing.Size(480, 68);
            this.txtcom.TabIndex = 498;
            // 
            // lbcom
            // 
            this.lbcom.AutoSize = true;
            this.lbcom.BackColor = System.Drawing.Color.Transparent;
            this.lbcom.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcom.ForeColor = System.Drawing.Color.Black;
            this.lbcom.Location = new System.Drawing.Point(25, 343);
            this.lbcom.Name = "lbcom";
            this.lbcom.Size = new System.Drawing.Size(92, 16);
            this.lbcom.TabIndex = 497;
            this.lbcom.Text = "Comentarios:";
            // 
            // txtnumemp
            // 
            this.txtnumemp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnumemp.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnumemp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txtnumemp.Location = new System.Drawing.Point(112, 302);
            this.txtnumemp.MaxLength = 50;
            this.txtnumemp.Name = "txtnumemp";
            this.txtnumemp.Size = new System.Drawing.Size(149, 27);
            this.txtnumemp.TabIndex = 496;
            // 
            // lbnumemp
            // 
            this.lbnumemp.AutoSize = true;
            this.lbnumemp.BackColor = System.Drawing.Color.Transparent;
            this.lbnumemp.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnumemp.ForeColor = System.Drawing.Color.Black;
            this.lbnumemp.Location = new System.Drawing.Point(25, 305);
            this.lbnumemp.Name = "lbnumemp";
            this.lbnumemp.Size = new System.Drawing.Size(81, 16);
            this.lbnumemp.TabIndex = 495;
            this.lbnumemp.Text = "# Empaque:";
            // 
            // lbfot3
            // 
            this.lbfot3.AutoSize = true;
            this.lbfot3.BackColor = System.Drawing.Color.Transparent;
            this.lbfot3.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfot3.ForeColor = System.Drawing.Color.Black;
            this.lbfot3.Location = new System.Drawing.Point(444, 255);
            this.lbfot3.Name = "lbfot3";
            this.lbfot3.Size = new System.Drawing.Size(52, 16);
            this.lbfot3.TabIndex = 493;
            this.lbfot3.Text = "Foto 3:";
            // 
            // lbfot2
            // 
            this.lbfot2.AutoSize = true;
            this.lbfot2.BackColor = System.Drawing.Color.Transparent;
            this.lbfot2.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfot2.ForeColor = System.Drawing.Color.Black;
            this.lbfot2.Location = new System.Drawing.Point(220, 252);
            this.lbfot2.Name = "lbfot2";
            this.lbfot2.Size = new System.Drawing.Size(52, 16);
            this.lbfot2.TabIndex = 491;
            this.lbfot2.Text = "Foto 2:";
            // 
            // lbfot1
            // 
            this.lbfot1.AutoSize = true;
            this.lbfot1.BackColor = System.Drawing.Color.Transparent;
            this.lbfot1.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfot1.ForeColor = System.Drawing.Color.Black;
            this.lbfot1.Location = new System.Drawing.Point(23, 252);
            this.lbfot1.Name = "lbfot1";
            this.lbfot1.Size = new System.Drawing.Size(52, 16);
            this.lbfot1.TabIndex = 489;
            this.lbfot1.Text = "Foto 1:";
            // 
            // txtenc
            // 
            this.txtenc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtenc.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtenc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txtenc.Location = new System.Drawing.Point(420, 177);
            this.txtenc.MaxLength = 100;
            this.txtenc.Multiline = true;
            this.txtenc.Name = "txtenc";
            this.txtenc.Size = new System.Drawing.Size(180, 61);
            this.txtenc.TabIndex = 488;
            // 
            // lbenc
            // 
            this.lbenc.AutoSize = true;
            this.lbenc.BackColor = System.Drawing.Color.Transparent;
            this.lbenc.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbenc.ForeColor = System.Drawing.Color.White;
            this.lbenc.Location = new System.Drawing.Point(331, 180);
            this.lbenc.Name = "lbenc";
            this.lbenc.Size = new System.Drawing.Size(83, 16);
            this.lbenc.TabIndex = 487;
            this.lbenc.Text = "Encontrado:";
            // 
            // txtesp
            // 
            this.txtesp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtesp.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtesp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txtesp.Location = new System.Drawing.Point(120, 177);
            this.txtesp.MaxLength = 100;
            this.txtesp.Multiline = true;
            this.txtesp.Name = "txtesp";
            this.txtesp.Size = new System.Drawing.Size(172, 61);
            this.txtesp.TabIndex = 486;
            // 
            // lbesp
            // 
            this.lbesp.AutoSize = true;
            this.lbesp.BackColor = System.Drawing.Color.Transparent;
            this.lbesp.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbesp.ForeColor = System.Drawing.Color.White;
            this.lbesp.Location = new System.Drawing.Point(23, 176);
            this.lbesp.Name = "lbesp";
            this.lbesp.Size = new System.Drawing.Size(91, 16);
            this.lbesp.TabIndex = 485;
            this.lbesp.Text = "Especificado:";
            // 
            // lbprod
            // 
            this.lbprod.AutoSize = true;
            this.lbprod.BackColor = System.Drawing.Color.Transparent;
            this.lbprod.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbprod.ForeColor = System.Drawing.Color.White;
            this.lbprod.Location = new System.Drawing.Point(23, 122);
            this.lbprod.Name = "lbprod";
            this.lbprod.Size = new System.Drawing.Size(83, 16);
            this.lbprod.TabIndex = 484;
            this.lbprod.Text = "Producto(s):";
            // 
            // NUDCanti
            // 
            this.NUDCanti.Location = new System.Drawing.Point(501, 92);
            this.NUDCanti.Name = "NUDCanti";
            this.NUDCanti.Size = new System.Drawing.Size(102, 24);
            this.NUDCanti.TabIndex = 483;
            // 
            // lbcant
            // 
            this.lbcant.AutoSize = true;
            this.lbcant.BackColor = System.Drawing.Color.Transparent;
            this.lbcant.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcant.ForeColor = System.Drawing.Color.White;
            this.lbcant.Location = new System.Drawing.Point(427, 93);
            this.lbcant.Name = "lbcant";
            this.lbcant.Size = new System.Drawing.Size(68, 16);
            this.lbcant.TabIndex = 482;
            this.lbcant.Text = "Cantidad:";
            // 
            // cbturno
            // 
            this.cbturno.FormattingEnabled = true;
            this.cbturno.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbturno.Location = new System.Drawing.Point(482, 55);
            this.cbturno.Name = "cbturno";
            this.cbturno.Size = new System.Drawing.Size(121, 23);
            this.cbturno.TabIndex = 481;
            // 
            // lbturno
            // 
            this.lbturno.AutoSize = true;
            this.lbturno.BackColor = System.Drawing.Color.Transparent;
            this.lbturno.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbturno.ForeColor = System.Drawing.Color.White;
            this.lbturno.Location = new System.Drawing.Point(427, 57);
            this.lbturno.Name = "lbturno";
            this.lbturno.Size = new System.Drawing.Size(49, 16);
            this.lbturno.TabIndex = 480;
            this.lbturno.Text = "Turno:";
            // 
            // DTPFec
            // 
            this.DTPFec.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFec.Location = new System.Drawing.Point(103, 87);
            this.DTPFec.Name = "DTPFec";
            this.DTPFec.Size = new System.Drawing.Size(149, 24);
            this.DTPFec.TabIndex = 479;
            // 
            // lbfecha
            // 
            this.lbfecha.AutoSize = true;
            this.lbfecha.BackColor = System.Drawing.Color.Transparent;
            this.lbfecha.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfecha.ForeColor = System.Drawing.Color.White;
            this.lbfecha.Location = new System.Drawing.Point(23, 93);
            this.lbfecha.Name = "lbfecha";
            this.lbfecha.Size = new System.Drawing.Size(48, 16);
            this.lbfecha.TabIndex = 478;
            this.lbfecha.Text = "Fecha:";
            // 
            // txtfolio
            // 
            this.txtfolio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtfolio.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfolio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txtfolio.Location = new System.Drawing.Point(103, 21);
            this.txtfolio.MaxLength = 10;
            this.txtfolio.Name = "txtfolio";
            this.txtfolio.ReadOnly = true;
            this.txtfolio.Size = new System.Drawing.Size(149, 27);
            this.txtfolio.TabIndex = 477;
            // 
            // lbfolio
            // 
            this.lbfolio.AutoSize = true;
            this.lbfolio.BackColor = System.Drawing.Color.Transparent;
            this.lbfolio.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfolio.ForeColor = System.Drawing.Color.White;
            this.lbfolio.Location = new System.Drawing.Point(23, 24);
            this.lbfolio.Name = "lbfolio";
            this.lbfolio.Size = new System.Drawing.Size(43, 16);
            this.lbfolio.TabIndex = 476;
            this.lbfolio.Text = "Folio:";
            // 
            // txtrecibo
            // 
            this.txtrecibo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtrecibo.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrecibo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(136)))));
            this.txtrecibo.Location = new System.Drawing.Point(103, 54);
            this.txtrecibo.MaxLength = 10;
            this.txtrecibo.Name = "txtrecibo";
            this.txtrecibo.Size = new System.Drawing.Size(149, 27);
            this.txtrecibo.TabIndex = 475;
            // 
            // lbrecibo
            // 
            this.lbrecibo.AutoSize = true;
            this.lbrecibo.BackColor = System.Drawing.Color.Transparent;
            this.lbrecibo.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbrecibo.ForeColor = System.Drawing.Color.White;
            this.lbrecibo.Location = new System.Drawing.Point(23, 57);
            this.lbrecibo.Name = "lbrecibo";
            this.lbrecibo.Size = new System.Drawing.Size(54, 16);
            this.lbrecibo.TabIndex = 474;
            this.lbrecibo.Text = "Recibo:";
            // 
            // btnguardar
            // 
            this.btnguardar.BackgroundImage = global::Recepcion_MP.Properties.Resources.save;
            this.btnguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnguardar.Location = new System.Drawing.Point(498, 465);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(48, 41);
            this.btnguardar.TabIndex = 502;
            this.btnguardar.UseVisualStyleBackColor = true;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // btnfot3
            // 
            this.btnfot3.BackgroundImage = global::Recepcion_MP.Properties.Resources.Buscar;
            this.btnfot3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnfot3.Location = new System.Drawing.Point(498, 252);
            this.btnfot3.Name = "btnfot3";
            this.btnfot3.Size = new System.Drawing.Size(48, 41);
            this.btnfot3.TabIndex = 494;
            this.btnfot3.UseVisualStyleBackColor = true;
            this.btnfot3.Click += new System.EventHandler(this.btnfot3_Click);
            // 
            // btnfot2
            // 
            this.btnfot2.BackgroundImage = global::Recepcion_MP.Properties.Resources.Buscar;
            this.btnfot2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnfot2.Location = new System.Drawing.Point(274, 249);
            this.btnfot2.Name = "btnfot2";
            this.btnfot2.Size = new System.Drawing.Size(48, 41);
            this.btnfot2.TabIndex = 492;
            this.btnfot2.UseVisualStyleBackColor = true;
            this.btnfot2.Click += new System.EventHandler(this.btnfot2_Click);
            // 
            // btnfot1
            // 
            this.btnfot1.BackgroundImage = global::Recepcion_MP.Properties.Resources.Buscar;
            this.btnfot1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnfot1.Location = new System.Drawing.Point(77, 249);
            this.btnfot1.Name = "btnfot1";
            this.btnfot1.Size = new System.Drawing.Size(48, 41);
            this.btnfot1.TabIndex = 490;
            this.btnfot1.UseVisualStyleBackColor = true;
            this.btnfot1.Click += new System.EventHandler(this.btnfot1_Click);
            // 
            // Foto2
            // 
            this.Foto2.FileName = "openFileDialog1";
            // 
            // Foto1
            // 
            this.Foto1.FileName = "openFileDialog1";
            // 
            // Foto3
            // 
            this.Foto3.FileName = "openFileDialog1";
            // 
            // pbfoto1
            // 
            this.pbfoto1.Location = new System.Drawing.Point(131, 249);
            this.pbfoto1.Name = "pbfoto1";
            this.pbfoto1.Size = new System.Drawing.Size(48, 41);
            this.pbfoto1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbfoto1.TabIndex = 508;
            this.pbfoto1.TabStop = false;
            this.pbfoto1.Click += new System.EventHandler(this.pbfoto1_Click);
            // 
            // pbfoto2
            // 
            this.pbfoto2.Location = new System.Drawing.Point(328, 249);
            this.pbfoto2.Name = "pbfoto2";
            this.pbfoto2.Size = new System.Drawing.Size(48, 41);
            this.pbfoto2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbfoto2.TabIndex = 509;
            this.pbfoto2.TabStop = false;
            this.pbfoto2.Click += new System.EventHandler(this.pbfoto2_Click);
            // 
            // pbfoto3
            // 
            this.pbfoto3.Location = new System.Drawing.Point(552, 252);
            this.pbfoto3.Name = "pbfoto3";
            this.pbfoto3.Size = new System.Drawing.Size(48, 41);
            this.pbfoto3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbfoto3.TabIndex = 510;
            this.pbfoto3.TabStop = false;
            this.pbfoto3.Click += new System.EventHandler(this.pbfoto3_Click);
            // 
            // No_conformidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(626, 527);
            this.ControlBox = false;
            this.Controls.Add(this.pbfoto3);
            this.Controls.Add(this.pbfoto2);
            this.Controls.Add(this.pbfoto1);
            this.Controls.Add(this.btnselall);
            this.Controls.Add(this.ListProd);
            this.Controls.Add(this.txtnomprov);
            this.Controls.Add(this.lbprov);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.txtcontacto);
            this.Controls.Add(this.lbcontacto);
            this.Controls.Add(this.DTPFecNot);
            this.Controls.Add(this.txtcom);
            this.Controls.Add(this.lbcom);
            this.Controls.Add(this.txtnumemp);
            this.Controls.Add(this.lbnumemp);
            this.Controls.Add(this.btnfot3);
            this.Controls.Add(this.lbfot3);
            this.Controls.Add(this.btnfot2);
            this.Controls.Add(this.lbfot2);
            this.Controls.Add(this.btnfot1);
            this.Controls.Add(this.lbfot1);
            this.Controls.Add(this.txtenc);
            this.Controls.Add(this.lbenc);
            this.Controls.Add(this.txtesp);
            this.Controls.Add(this.lbesp);
            this.Controls.Add(this.lbprod);
            this.Controls.Add(this.NUDCanti);
            this.Controls.Add(this.lbcant);
            this.Controls.Add(this.cbturno);
            this.Controls.Add(this.lbturno);
            this.Controls.Add(this.DTPFec);
            this.Controls.Add(this.lbfecha);
            this.Controls.Add(this.txtfolio);
            this.Controls.Add(this.lbfolio);
            this.Controls.Add(this.txtrecibo);
            this.Controls.Add(this.lbrecibo);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "No_conformidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "No conformidad";
            this.Load += new System.EventHandler(this.No_conformidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUDCanti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfoto1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfoto2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfoto3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnselall;
        private System.Windows.Forms.CheckedListBox ListProd;
        private System.Windows.Forms.TextBox txtnomprov;
        private System.Windows.Forms.Label lbprov;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.TextBox txtcontacto;
        private System.Windows.Forms.Label lbcontacto;
        private System.Windows.Forms.DateTimePicker DTPFecNot;
        private System.Windows.Forms.TextBox txtcom;
        private System.Windows.Forms.Label lbcom;
        private System.Windows.Forms.TextBox txtnumemp;
        private System.Windows.Forms.Label lbnumemp;
        private System.Windows.Forms.Button btnfot3;
        private System.Windows.Forms.Label lbfot3;
        private System.Windows.Forms.Button btnfot2;
        private System.Windows.Forms.Label lbfot2;
        private System.Windows.Forms.Button btnfot1;
        private System.Windows.Forms.Label lbfot1;
        private System.Windows.Forms.TextBox txtenc;
        private System.Windows.Forms.Label lbenc;
        private System.Windows.Forms.TextBox txtesp;
        private System.Windows.Forms.Label lbesp;
        private System.Windows.Forms.Label lbprod;
        private System.Windows.Forms.NumericUpDown NUDCanti;
        private System.Windows.Forms.Label lbcant;
        private System.Windows.Forms.ComboBox cbturno;
        private System.Windows.Forms.Label lbturno;
        private System.Windows.Forms.DateTimePicker DTPFec;
        private System.Windows.Forms.Label lbfecha;
        private System.Windows.Forms.TextBox txtfolio;
        private System.Windows.Forms.Label lbfolio;
        private System.Windows.Forms.TextBox txtrecibo;
        private System.Windows.Forms.Label lbrecibo;
        private System.Windows.Forms.OpenFileDialog Foto2;
        private System.Windows.Forms.OpenFileDialog Foto1;
        private System.Windows.Forms.OpenFileDialog Foto3;
        private System.Windows.Forms.PictureBox pbfoto1;
        private System.Windows.Forms.PictureBox pbfoto2;
        private System.Windows.Forms.PictureBox pbfoto3;
    }
}