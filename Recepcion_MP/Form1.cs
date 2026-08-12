using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using System.Net.Mail;
using System.Net;
using System.Diagnostics;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Recepcion_MP
{
    public partial class Recepcion_mp : Form
    {
        SqlConnection thisConnection = new SqlConnection(Utilerias.Class1.ConnectionString);
        //OleDbConnection MyConnection = new OleDbConnection(@"Provider= VFPOLEDB.1;Data Source=c:\mr_lucky\base_de_datos;Collating Sequence=general;");
        //OleDbConnection MyConnection = new OleDbConnection(Utilerias.Class1.ConnectionStringFox);
        MySqlConnection mySqlConn = new MySqlConnection("server=gab.mrlucky.com.mx;userid=www1166;password=taQ17Zm;database=campo");
        SqlConnection thisConnectionTomate = new SqlConnection(Utilerias.Class1.ConnectionAgui); 
        SqlCommand cmnd1 = new SqlCommand();
        SqlCommand cmnd11 = new SqlCommand();
        SqlCommand cmnd21 = new SqlCommand();
        //OleDbCommand cmd1 = new OleDbCommand();        
        SqlDataReader reader1, reader11, reader21;
        //OleDbDataReader read1;
        MySqlCommand cmnd = new MySqlCommand();
        MySqlDataReader reader;
        public static bool consulta = false;
        public static int opcion = 0, recibo = 0, num_prod, insectos = 0;
        public static string linea = "", env_clave, existe = "", num_tarima = "", consul = "N", estatus, ajuste = "", sobre_insp = "", query = "", contrato = "", tipomon = "";
        string cletiqueta = "", email = "", ruta_pdf = "";
        public static decimal prod_muestra = 0, calhoja = 0, calpata = 0, defectos = 0, peso_recipiente = 0, pesorecipientetxt = 0;
        public static decimal invmp_entradas_kg = 0, invmp_entradas_un = 0, invmp_salidas_kg = 0, invmp_salidas_un = 0, invmp_inicial_kg = 0, invmp_inicial_un = 0;
        public static decimal var_dec_inv_inicial_kg = 0, var_dec_inv_inicial_un = 0, folio_anterior, m_SIG, var_dec_inv_salidas_kg = 0, var_dec_inv_salidas_un = 0;
        public static decimal hrp_num_unidades = 0, hrp_reman_unidades = 0, seconvirtio = 0;
        string Actualizar = "N";
        
        ComboBox ticket = new ComboBox();
        ComboBox prod_clave = new ComboBox();
        ComboBox variedad = new ComboBox();
        ComboBox prod_num = new ComboBox();
        TextBox txt1 = new TextBox();

        DataTable productos = new DataTable("productos");
        DataTable proveedor = new DataTable("proveedor");
        DataTable ranchos = new DataTable("ranchos");
        DataTable tablas = new DataTable("tablas");
        DataTable subtablas = new DataTable("subtablas");
        DataTable variedades = new DataTable("variedades");
        DataTable envases = new DataTable("envases");
        DataTable daños = new DataTable("daños");
        DataTable TipoCam = new DataTable();
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        public Recepcion_mp()
        {
            InitializeComponent();
            string ruta = @"C:\SisGabWeb\fondo_formularios.jpg";
            this.BackgroundImage = System.Drawing.Bitmap.FromFile(ruta);
            //this.BackgroundImageLayout = ImageLayout.Stretch;
            string carpeta = @"C:\\no_conformidad";
            if (!(Directory.Exists(carpeta)))
            {
                Directory.CreateDirectory(carpeta);
            }

            //MessageBox.Show(DateTime.Now.ToString("s"));
        }

        //método que limpia todo
        private void limpiarTextBoxes(Control parent)
        {
            //consulta = false;
            //opcion = 0; recibo = 0; num_prod = 0;
            linea = ""; env_clave=""; existe = ""; num_tarima = "";
            //prod_muestra = 0; calhoja = 0; calpata = 0; defectos = 0; peso_recipiente = 0; pesorecipientetxt = 0;
            //invmp_entradas_kg = 0; invmp_entradas_un = 0; invmp_salidas_kg = 0; invmp_salidas_un = 0; invmp_inicial_kg = 0; invmp_inicial_un = 0;
            //var_dec_inv_inicial_kg = 0; var_dec_inv_inicial_un = 0; folio_anterior = 0; m_SIG = 0; var_dec_inv_salidas_kg = 0; var_dec_inv_salidas_un = 0;

            //Limpiar de manera rapida
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                {
                    TextBox txt = (TextBox)c;
                    txt.Text = "";
                    txt.ReadOnly = true;
                }
                if (c.Controls.Count > 0)
                {
                    limpiarTextBoxes(c);
                }
            }
                     
            DGV1.Rows.Clear();
            DGV2.Rows.Clear();
            txtpesobruto.Text = "0.00";
            txttaracamion.Text = "0.00";
            txthoja.Text = "0.00";
            txtcalhoja.Text = "0.00";
            txtpata.Text = "0.00";
            txtcalpata.Text = "0.00";
            txtrmpnumenvase.Text = "0";
            txtnumviaje.Text = "0";
            txtpesorecipiente.Text = "0.00";
            txtpesoneto.Text = "0.00";
            txtpesoutil.Text = "0.00";
            txtmuestrakg.Text = "0.00";
            txtpreciogrado1.Text = "0.00";
            txtpreciogrado2.Text = "0.00";
            txtgrado1.Text = "0.00";
            txtgrado2.Text = "0.00";
            txtdefectos.Text = "0.00";
            txtporgrado1.Text = "0.00";
            txtporgrado2.Text = "0.00";
            txtpordef.Text = "0.00";
            txttotalgrado1.Text = "0.00";
            txttotalgrado2.Text = "0.00";
            txttotaldef.Text = "0.00";
            txttotal.Text = "0.00";
            txttotalpor.Text = "0.00";
            txttotalkg.Text = "0.00";
            lbpretotgrado1.Text = "0.00";
            lbpretotgrado2.Text = "0.00";
            txtnumins.Text = "0";
            txtpzsmenor5.Text = "0.00";
            txtpzsxmuestra.Text = "0";
            txtpzsxcana.Text = "0";
            TxtTipoCam.Text = "0";
            LblFecTC.Text = "";
            seconvirtio = 0;
            TxtPaisOrigen.Text = "";
            DGV1.ReadOnly = false;
            DGV1.Columns[0].ReadOnly = true;
            DGV1.Columns[2].ReadOnly = true;
            DGV2.ReadOnly = false;
            DGV2.Columns[0].ReadOnly = true;
            //DGV1.Columns[2].ReadOnly = true;
            lbestatus.Text = "";
            CBAjuste.Checked = false;
            consulta = false;
            cbcontrato.Enabled = false;
            opcion = 0; num_prod = 0;
            linea = ""; env_clave = ""; existe = ""; num_tarima = ""; consul = "N"; estatus = ""; ajuste = ""; contrato = "";
            prod_muestra = 0; calhoja = 0; calpata = 0; defectos = 0; peso_recipiente = 0; pesorecipientetxt = 0;
            invmp_entradas_kg = 0; invmp_entradas_un = 0; invmp_salidas_kg = 0; invmp_salidas_un = 0; invmp_inicial_kg = 0; invmp_inicial_un = 0;
            var_dec_inv_inicial_kg = 0; var_dec_inv_inicial_un = 0; folio_anterior=0; m_SIG=0; var_dec_inv_salidas_kg = 0; var_dec_inv_salidas_un = 0;
            hrp_num_unidades = 0; hrp_reman_unidades = 0;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {                        
            try
            {
                if (ValidaActualizacion() == "S")
                {
                    Actualizar = "S";
                    this.Close();
                }
                thisConnection.Open();
                query = "select * from tb_cat_danos where dno_tipo = 'MP' and dno_estatus = 'ACTIVO' order by dno_clave";
                da = new SqlDataAdapter(query, thisConnection);
                da.Fill(ds, "daños");
                daños = ds.Tables["daños"];

                opcion = 1;
                //trae el consecutivo de la tb_mstr_recepcion_mp
                cmnd1 = thisConnection.CreateCommand();
                cmnd1.CommandText = "SELECT max(rmp_recibo) FROM tb_mstr_recepcion_mp";
                reader1 = cmnd1.ExecuteReader();
                while (reader1.Read())
                {
                    recibo = Convert.ToInt32(reader1.GetValue(0).ToString()) + 1;
                }
                reader1.Dispose();
                txtrecibo.Text = recibo.ToString();
                cmnd1 = thisConnection.CreateCommand();
                cmnd1.CommandText = "SELECT A.id_ticket, B.prod_nombre, A.prod_clave, A.variedad, A.cantidad, C.hora_peso, A.num_prod FROM tb_det_recepcion_bascula A, tb_cat_producto B, tb_mstr_recepcion_bascula C WHERE A.tipo_prod = 'MP' AND " +
                                    "A.lin_clave <> '08' AND A.estatus = 'P' AND B.prod_clave = a.prod_clave AND A.prod_clave <> '' and C.id_ticket = A.id_ticket ORDER BY A.id_ticket DESC";
                reader1 = cmnd1.ExecuteReader();
                while (reader1.Read())
                {
                    cbticket.Items.Add(reader1.GetValue(0).ToString().Trim() + " -> " + reader1.GetValue(1).ToString().Trim() + " -> " + reader1.GetValue(4).ToString().Trim() + " -> " + reader1.GetValue(5).ToString().Trim());
                    ticket.Items.Add(reader1.GetValue(0).ToString().Trim());
                    prod_clave.Items.Add(reader1.GetValue(2).ToString().Trim());
                    variedad.Items.Add(reader1.GetValue(3).ToString().Trim());
                    prod_num.Items.Add(reader1.GetValue(6).ToString().Trim());
                }
                reader1.Dispose();                
                thisConnection.Close();
                cbticket.Enabled = true;
                cbticket.Focus();
                btnAlta.Enabled = false;
                btnConsulta.Enabled = false;
                btnCancel.Enabled = true;
                btnGuardar.Enabled = true;
            }
            catch (SqlException ex)
            {
                thisConnection.Close();
                Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex.ToString());
                MessageBox.Show(ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception ex1)
            {
                thisConnection.Close();
                Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex1.ToString());
                MessageBox.Show(ex1.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }              
        }

        private void Recepcion_mp_Load(object sender, EventArgs e)
        {
            if (ValidaActualizacion() == "S")
            {
                Actualizar = "S";
                this.Close();
            }
            lbfecha.Text = DateTime.Now.ToShortDateString();
            thisConnection.Open();
            cmnd1 = thisConnection.CreateCommand();
            cmnd1.CommandText = "select semana from tb_cat_semanas WHERE fecha1 <= '" + lbfecha.Text + "' AND fecha2 >= '" + lbfecha.Text + "'";
            reader1 = cmnd1.ExecuteReader();
            while (reader1.Read())
            {
                DateTime dateValue = new DateTime(lbfecha.Value.Year, lbfecha.Value.Month, lbfecha.Value.Day);
                lbcletiqueta.Text = reader1.GetValue(0).ToString() + "-" + dateValue.ToString("ddd").ToUpper();
                cletiqueta = lbcletiqueta.Text.Substring(0, 5);
                if (cletiqueta.Trim().Contains("Á"))
                    cletiqueta = cletiqueta.Replace('Á', 'A');

                if (cletiqueta.Trim().Contains("É"))
                    cletiqueta = cletiqueta.Replace('É', 'E');
                lbcletiqueta.Text = cletiqueta;
            }
            reader1.Dispose();

            query = "SELECT * FROM tb_cat_producto WHERE prod_tipo = 'MP' ORDER BY prod_nombre";
            da = new SqlDataAdapter(query, thisConnection);
            da.Fill(ds, "productos");
            productos = ds.Tables["productos"];

            foreach (DataRow row in productos.Rows)
                txtprod.Items.Add(Convert.ToString(row["prod_nombre"].ToString().Trim()));

            query = "select * from tb_cat_proveedor WHERE prov_estatus <> 'B' order by prov_nombre";
            da = new SqlDataAdapter(query, thisConnection);
            da.Fill(ds, "proveedor");
            proveedor = ds.Tables["proveedor"];

            query = "select * from tb_cat_ranchos order by rch_nombre";
            da = new SqlDataAdapter(query, thisConnection);
            da.Fill(ds, "ranchos");
            ranchos = ds.Tables["ranchos"];

            query = "select * from tb_cat_tablas order by tbl_nombre";
            da = new SqlDataAdapter(query, thisConnection);
            da.Fill(ds, "tablas");
            tablas = ds.Tables["tablas"];

            query = "select * from tb_cat_subtablas order by tbl_codigo";
            da = new SqlDataAdapter(query, thisConnection);
            da.Fill(ds, "subtablas");
            subtablas = ds.Tables["subtablas"];

            query = "select * from tb_cat_variedad order by vari_nombre";
            da = new SqlDataAdapter(query, thisConnection);
            da.Fill(ds, "variedades");
            variedades = ds.Tables["variedades"];

            query = "select * from tb_cat_envases order by env_nombre";
            da = new SqlDataAdapter(query, thisConnection);
            da.Fill(ds, "envases");
            envases = ds.Tables["envases"];

            //query = "select * from tb_cat_danos where dno_tipo = 'MP' and dno_estatus = 'ACTIVO' order by dno_clave";
            //da = new SqlDataAdapter(query, thisConnection);
            //da.Fill(ds, "daños");
            //daños = ds.Tables["daños"];


            //cmnd1 = thisConnection.CreateCommand();
            //cmnd1.CommandText = "SELECT prod_nombre FROM tb_cat_producto WHERE prod_tipo = 'MP' ORDER BY prod_nombre";
            //reader1 = cmnd1.ExecuteReader();
            //while (reader1.Read())
            //{
            //    txtprod.Items.Add(reader1.GetValue(0).ToString().Trim());
            //}
            //reader1.Dispose();
            thisConnection.Close();
            cbevaluacion.SelectedIndex = 0;
            LblVer.Text = File.GetLastWriteTime("C:\\SisGabWeb\\Recepcion_MP.exe").ToString();
        }

        private void CBLinIni_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {                
                limpiarTextBoxes(this);
                opcion = 1;
                txtevaluador.ReadOnly = false;
                txthoja.ReadOnly = false;
                txtpata.ReadOnly = false;
                txtobs.ReadOnly = false;
                txtmuestrakg.ReadOnly = false;
                txtpreciogrado1.ReadOnly = false;
                txtpreciogrado2.ReadOnly = false;
                txtgrado1.ReadOnly = false;
                txtgrado2.ReadOnly = false;
                txthoja.ReadOnly = true;
                //txtprov_clave.ReadOnly = false;inhabilitado por cambios al proveedor sin razon 14/07/2021
                txtrch_clave.ReadOnly = false;
                txttbl_clave.ReadOnly = false;
                //txtrmpnumenvase.ReadOnly = false;
                txtpesoneto.ReadOnly = false;
                txtpesobruto.ReadOnly = false;
                txtpesorecipiente.ReadOnly = false;
                txtpesoutil.ReadOnly = false;
                txttaracamion.ReadOnly = false;
                txtflete.ReadOnly = false;
                txtrecibo.ReadOnly = false;
                txtnumins.ReadOnly = false;
                txtpzsmenor5.ReadOnly = false;
                //txtdescrip.ReadOnly = false;
                txtpzsxmuestra.ReadOnly = false;
                CBAjuste.Enabled = true;
                cbsobinsp.Enabled = true;
                cbcontrato.Enabled = true;
                txtnumped.ReadOnly = false;
                ChkImport.Enabled = true;
                TxtTar.Enabled = true;
                TxtTar.ReadOnly = false;
                txtrecibo.Text = recibo.ToString();
                ticket.SelectedIndex = cbticket.SelectedIndex;
                prod_clave.SelectedIndex = cbticket.SelectedIndex;
                variedad.SelectedIndex = cbticket.SelectedIndex;
                prod_num.SelectedIndex = cbticket.SelectedIndex;

                thisConnection.Open();
                cmnd1 = thisConnection.CreateCommand();
                cmnd1.CommandText = "select A.prod_clave, A.cantidad, A.envase, A.tara, A.peso_bruto, A.peso_neto, A.id_tabla, A.tabla, A.variedad, B.prod_nombre, A.lin_clave, A.cantidad, A.num_tarimas, A.prov_clave, A.rch_clave, A.num_prod " +
                                    "from tb_det_recepcion_bascula A, tb_cat_producto B where A.prod_clave = '" + prod_clave.SelectedItem.ToString() + "' and A.id_ticket = " + ticket.SelectedItem.ToString() + " AND " +
                                    "B.prod_clave = A.prod_clave and A.variedad = '" + variedad.SelectedItem.ToString().Trim() + "' and A.estatus = 'P' and A.num_prod = '" + prod_num.SelectedItem.ToString() + "'";
                reader1 = cmnd1.ExecuteReader();
                while (reader1.Read())
                {
                    txtprod_clave.Text = reader1.GetValue(0).ToString().Trim();
                    txtprod.SelectedItem = reader1.GetValue(9).ToString().Trim();
                    txttbl_clave.Text = reader1.GetValue(6).ToString().Trim();
                    txttabla.Text = reader1.GetValue(7).ToString().Trim();
                    linea = reader1.GetValue(10).ToString().Trim();
                    txtenv.Text = reader1.GetValue(2).ToString().Trim();
                    txttaracamion.Text = reader1.GetValue(3).ToString().Trim();
                    txtpesobruto.Text = reader1.GetValue(4).ToString().Trim();
                    txtpesoneto.Text = reader1.GetValue(5).ToString().Trim();
                    txtrmpnumenvase.Text = reader1.GetValue(11).ToString().Trim();
                    num_tarima = reader1.GetValue(12).ToString().Trim();
                    txtprov_clave.Text = reader1.GetValue(13).ToString().Trim();
                    txtrch_clave.Text = reader1.GetValue(14).ToString().Trim();
                    num_prod = Convert.ToInt32(reader1.GetValue(15).ToString());
                    //txtflete.Text = reader1.GetValue(16).ToString().Trim();

                    //trae nombre del proveedor
                    foreach (DataRow row in proveedor.Select("prov_clave = '" + txtprov_clave.Text + "'"))
                    {
                        txtprov.Text = Convert.ToString(row["prov_nombre"].ToString().Trim());
                        email = Convert.ToString(row["prov_email"].ToString().Trim());
                    }
                    /*cmnd11 = thisConnection.CreateCommand();
                    cmnd11.CommandText = "select prov_nombre from tb_cat_proveedor where prov_clave = '" + txtprov_clave.Text.Trim() + "'";
                    reader11 = cmnd11.ExecuteReader();
                    while (reader11.Read())
                        txtprov.Text = reader11.GetValue(0).ToString().Trim();

                    reader11.Dispose();*/

                    //trae el nombre del rancho
                    foreach (DataRow row in ranchos.Select("prov_clave = '" + txtprov_clave.Text + "' and rch_clave = '" + txtrch_clave.Text + "'"))
                        txtrancho.Text = Convert.ToString(row["rch_nombre"].ToString().Trim());

                    if (txtrch_clave.Text.Trim() == "")
                        txtrancho.Text = "";
                    /*cmnd11 = thisConnection.CreateCommand();
                    cmnd11.CommandText = "select rch_nombre from tb_cat_ranchos where prov_clave = '" + txtprov_clave.Text.Trim() + "' and rch_clave = '" + txtrch_clave.Text.Trim() + "'";
                    reader11 = cmnd11.ExecuteReader();
                    while (reader11.Read())
                        txtrancho.Text = reader11.GetValue(0).ToString().Trim();

                    reader11.Dispose();*/
                    
                    //trae el nombre de la tabla
                    foreach (DataRow row in tablas.Select("prov_clave = '" + txtprov_clave.Text + "' and rch_clave = '" + txtrch_clave.Text + "' and tbl_nombre ='" + txttabla.Text + "'"))
                        txttbl_clave.Text = Convert.ToString(row["tbl_clave"].ToString().Trim());

                    if (txttbl_clave.Text.Trim() == "")
                        txttabla.Text = "";
                        //txttabla.Text = Convert.ToString(row["tbl_nombre"].ToString().Trim());
                   
                    /*cmnd11 = thisConnection.CreateCommand();
                    cmnd11.CommandText = "select tbl_nombre, tbl_clave from tb_cat_tablas where prov_clave = '" + txtprov_clave.Text.Trim() + "' and rch_clave = '" + txtrch_clave.Text.Trim() + "' and (tbl_clave = '" + txttbl_clave.Text + "' OR tbl_nombre ='" + txttabla.Text + "') order by tbl_nombre";
                    reader11 = cmnd11.ExecuteReader();
                    if (reader11.HasRows)
                    {
                        while (reader11.Read())
                        {
                            txttabla.Text = reader11.GetValue(0).ToString().Trim();
                            txttbl_clave.Text = reader11.GetValue(1).ToString().Trim();
                        }
                        reader11.Dispose();
                    }
                    else
                    {
                        cmnd21 = thisConnection.CreateCommand();
                        cmnd21.CommandText = "SELECT tbl_clave, rch_clave FROM TB_CAT_TABLAS WHERE TBL_NOMBRE ='" + txttabla.Text + "'";
                        reader21 = cmnd21.ExecuteReader();
                        while (reader21.Read())
                        {
                            txttbl_clave.Text = reader21.GetValue(0).ToString().Trim();
                            txtrch_clave.Text = reader21.GetValue(1).ToString().Trim();
                        }
                        reader21.Dispose();
                    }
                    reader11.Dispose();*/


                    //trae el proveedor y el rancho de acuerdo a la tabla
                    //cmnd11 = thisConnection.CreateCommand();
                    //cmnd11.CommandText = "SELECT A.prov_clave, B.prov_nombre, A.rch_clave, C.rch_nombre FROM tb_cat_tablas A, tb_cat_proveedor B, tb_cat_ranchos C " +
                    //                   "WHERE A.tbl_clave = '" + reader1.GetValue(6).ToString() + "' AND B.prov_clave = a.prov_clave AND C.rch_clave = A.rch_clave";
                    //reader11 = cmnd11.ExecuteReader();
                    //while (reader11.Read())
                    //{
                    //    txtprov_clave.Text = reader11.GetValue(0).ToString().Trim();
                    //    txtprov.Text = reader11.GetValue(1).ToString().Trim();
                    //    txtrch_clave.Text = reader11.GetValue(2).ToString().Trim();
                    //    txtrancho.Text = reader11.GetValue(3).ToString().Trim();
                    //}
                    //reader11.Dispose();

                    //trae las subtablas de acuerdo al proveedor, rancho y tabla
                    foreach (DataRow row in subtablas.Select("prov_clave = '" + txtprov_clave.Text + "' and rch_clave = '" + txtrch_clave.Text + "' and tbl_clave = '" + txttbl_clave.Text + "'"))
                        CBcodigo.Items.Add(Convert.ToString(row["tbl_codigo"].ToString().Trim()));

                    /*cmnd11 = thisConnection.CreateCommand();
                    cmnd11.CommandText = "SELECT * FROM tb_cat_subtablas WHERE prov_clave = '" + txtprov_clave.Text + "' AND rch_clave='" + txtrch_clave.Text + "' ORDER BY tbl_clave";
                    reader11 = cmnd11.ExecuteReader();
                    while (reader11.Read())
                    {
                        CBcodigo.Items.Add(reader11.GetValue(3).ToString().Trim());
                    }
                    reader11.Dispose();                                        */

                    //trae las variedades de acuerdo a la linea del producto
                    foreach(DataRow row in variedades.Select("lin_clave = '"+linea.Trim()+"'"))
                        CBvariedad.Items.Add(Convert.ToString(row["vari_nombre"].ToString().Trim()));

                    /*cmnd11 = thisConnection.CreateCommand();
                    cmnd11.CommandText = "SELECT * FROM tb_cat_variedad WHERE lin_clave = '" + linea.Trim() + "' order by vari_nombre";
                    reader11 = cmnd11.ExecuteReader();
                    while (reader11.Read())
                    {
                        CBvariedad.Items.Add(reader11.GetValue(2).ToString().Trim());
                    }
                    reader11.Dispose();*/

                    //trae el peso del envase de acuerdo al nombre del mismo
                    foreach(DataRow row in envases.Select("env_nombre = '"+txtenv.Text.Trim()+"'"))
                    {
                        peso_recipiente = Convert.ToDecimal(row["env_peso"].ToString());
                        env_clave=Convert.ToString(row["env_clave"].ToString().Trim());
                    }

                    /*cmnd11 = thisConnection.CreateCommand();
                    cmnd11.CommandText = "SELECT * FROM tb_cat_envases WHERE env_nombre = '" + txtenv.Text + "'";
                    reader11 = cmnd11.ExecuteReader();
                    while (reader11.Read())
                    {
                        peso_recipiente = Convert.ToDecimal(reader11.GetValue(2).ToString());
                        env_clave = reader11.GetValue(0).ToString().Trim();
                    }
                    reader11.Dispose();                    */

                    // trae el tipo de cambio de acuerdo a la fecha del movimiento
                    TraeTipoCam();

                    CBcodigo.Enabled = true;
                    CBvariedad.Enabled = true;
                    txtvar_clave.ReadOnly = false;
                    txtcodigo_clave.ReadOnly = false;
                    txtnumviaje.ReadOnly = false;
                }//while
                reader1.Dispose();
                // se puso esta validacion para que no tomen los recibos que estan pendiendes por desglosar la Tara y Pesos de los Productos
                // RCC 12 Agosto 2024
                if (Convert.ToDecimal(txttaracamion.Text) == 1 || Convert.ToDecimal(txtpesobruto.Text) == 1)
                {
                    MessageBox.Show("Todavia NO se Captura la Informacion del Peso y Tara por Parte de Bascula, avise o espere a que se capture la Información", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    thisConnection.Close();
                    btnCancel_Click(sender, e);
                    return;
                }
                cmnd1 = thisConnection.CreateCommand();
                cmnd1.CommandText = " select folio, recibio_bascula, hora_peso, folio from tb_mstr_recepcion_bascula where id_ticket = " + ticket.SelectedItem.ToString().Trim();
                reader1 = cmnd1.ExecuteReader();
                while (reader1.Read())
                {
                    txtflete.Text = reader1.GetValue(3).ToString();//.Replace(",", "");
                    txtpesador.Text = reader1.GetValue(1).ToString().Trim();
                    txthora.Text = reader1.GetValue(2).ToString().Trim();
                    cmnd11 = thisConnection.CreateCommand();
                    cmnd11.CommandText = "select bas_nombre from tb_cat_basculeros where bas_clave = " + txtpesador.Text;
                    reader11 = cmnd11.ExecuteReader();
                    while (reader11.Read())
                    {
                        txtpesador.Text = reader11.GetValue(0).ToString().Trim();
                    }
                    reader11.Dispose();

                    //trae las subtablas de acuerdo al proveedor, rancho y tabla
                    //cmnd11 = thisConnection.CreateCommand();
                    //cmnd11.CommandText = "SELECT * FROM tb_cat_subtablas WHERE prov_clave = '" + txtprov_clave.Text + "' AND rch_clave='" + txtrch_clave.Text + "' ORDER BY tbl_clave";
                    //reader11 = cmnd11.ExecuteReader();
                    //while (reader11.Read())
                    //{
                    //    CBcodigo.Items.Add(reader11.GetValue(3).ToString().Trim());
                    //}
                    //reader11.Dispose();  
                    //cmnd11 = thisConnection.CreateCommand();
                    //cmnd11.CommandText = "SELECT A.prov_clave, A.prov_nombre, B.rch_clave FROM tb_cat_proveedor A, tb_cat_ranchos B " +
                    //                     "WHERE B.rch_nombre = '" + txtrancho.Text.Trim() + "' and A.prov_clave = B.prov_clave";
                    //reader11 = cmnd11.ExecuteReader();
                    //while (reader11.Read())
                    //{
                    //    txtprov_clave.Text = reader11.GetValue(0).ToString().Trim();
                    //    txtprov.Text = reader11.GetValue(1).ToString().Trim();
                    //    txtrch_clave.Text = reader11.GetValue(2).ToString().Trim();
                    //}
                    //reader11.Dispose();
                }
                reader1.Dispose();

                //trae el catalogo de daños de acuerdo a la linea
                foreach (DataRow row in daños.Select("lin_clave = '" + linea + "'"))
                    DGV1.Rows.Add(Convert.ToString(row["dno_nombre"].ToString().Trim()), "0.00", "0.00", Convert.ToString(row["dno_clave"].ToString().Trim()));


                cmnd1 = thisConnection.CreateCommand();
                cmnd1.CommandText = "select ins_nombre, ins_clave from tb_cat_insectos order by ins_nombre";
                reader1 = cmnd1.ExecuteReader();
                while (reader1.Read())
                {
                    DGV2.Rows.Add(reader1.GetValue(0).ToString().Trim(), "0", reader1.GetValue(1).ToString().Trim());
                }
                /*cmnd1 = thisConnection.CreateCommand();
                cmnd1.CommandText = "select dno_nombre, dno_clave from tb_cat_danos where dno_tipo = 'MP' and lin_clave = '" + linea + "' order by dno_clave";
                reader1 = cmnd1.ExecuteReader();
                while (reader1.Read())
                {
                    DGV1.Rows.Add(reader1.GetValue(0).ToString().Trim(), "0.00", "0.00", reader1.GetValue(1).ToString().Trim());
                }
                reader1.Dispose();*/


                cmnd1 = thisConnection.CreateCommand();
                cmnd1.CommandText = "select top 1 rmp_precio_grado1, rmp_precio_grado2 from tb_mstr_recepcion_mp where prov_clave= '" + txtprov_clave.Text + "' " +
                                  "and prod_clave = '" + txtprod_clave.Text + "' order by rmp_fecha desc";
                reader1 = cmnd1.ExecuteReader();
                while (reader1.Read())
                {
                    txtpreciogrado1.Text = Convert.ToDecimal(reader1.GetValue(0).ToString()).ToString("###,###,##0.0000");
                    txtpreciogrado2.Text = Convert.ToDecimal(reader1.GetValue(1).ToString()).ToString("###,###,##0.0000");
                }
                reader1.Dispose();

                cbcontrato.Items.Clear();
                cmnd1 = thisConnection.CreateCommand();
                cmnd1.CommandText = "select distinct a.cont_folio from tb_mstr_contratos a, tb_det_contratos b where a.prov_clave = '"+txtprov_clave.Text+"' "+
                                    "and a.cont_status = 'A' and a.cult_folio = '"+txtprod_clave.Text+ "' and b.cont_folio = a.cont_folio "+
                                    "and b.rch_clave = '"+txtrch_clave.Text+"' and b.tbl_clave = '"+txttbl_clave.Text+"'";
                reader1 = cmnd1.ExecuteReader();
                while (reader1.Read())
                    cbcontrato.Items.Add(reader1.GetValue(0).ToString().Trim());

                reader1.Dispose();
                thisConnection.Close();

                //Verificar ordenes de compra anticipadas 24/05/2021
                btnVerificar_Click(null, null);

                DGV1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                DGV2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                pesorecipientetxt = peso_recipiente * Convert.ToDecimal(txtrmpnumenvase.Text);
                txtpesorecipiente.Text = pesorecipientetxt.ToString("###,###,###.00");
                txtpesoneto.Text = (Convert.ToDecimal(txtpesobruto.Text) - Convert.ToDecimal(txttaracamion.Text) - Convert.ToDecimal(txtpesorecipiente.Text)).ToString("###,###,###,###.##");
                txtpesoutil.Text = txtpesoneto.Text;

                txthoja.ReadOnly = false;
                txtpata.ReadOnly = false;
                txtobs.ReadOnly = false;
                txtmuestrakg.ReadOnly = false;
                txtpreciogrado1.ReadOnly = false;
                txtpreciogrado2.ReadOnly = false;
                txtgrado1.ReadOnly = false;
                txtgrado2.ReadOnly = false;
                DGV1.ReadOnly = false;
                DGV1.Columns[0].ReadOnly = true;
                DGV1.Columns[2].ReadOnly = true;
                DGV2.ReadOnly = false;
                DGV2.Columns[0].ReadOnly = true;
                //DGV2.Columns[2].ReadOnly = true;
                txtprod.Enabled = false;//inhabilitado por error en captura de producto el cual depende de la recepcion de bascula 14/07/2021
                txtprod_clave.ReadOnly = true;//inhabilitado por error en captura de producto el cual depende de la recepcion de bascula 14/07/2021
                // se puso una validacion para la MP 09014 para que pida si es ENTERO Y VARA RCC 28 MAY 2024 
                LblApio.Visible = false;
                CmbApio.Visible = false;
                if (txtprod_clave.Text.Trim() == "09014") // APIO P/ENSALADAS
                {
                    LblApio.Visible = true;
                    CmbApio.Visible = true;
                    CmbApio.SelectedIndex = -1;
                }
                CBMoneda.SelectedIndex = 0;
                CBMoneda.Enabled = true;
                cbevaluacion.Enabled = true;
                cbevaluacion.SelectedIndex = 0;
            }
            catch (SqlException ex)
            {
                thisConnection.Close();
                Utilerias.Class1.SendMail("sistemas@mrlucky.com.mx", "sistemas", "Sistem@s2026$", ex.ToString());
                MessageBox.Show(ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception ex1)
            {
                thisConnection.Close();
                Utilerias.Class1.SendMail("sistemas@mrlucky.com.mx", "sistemas", "Sistem@s2026$", ex1.ToString());
                MessageBox.Show(ex1.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
        }
      
        private void txthoja_Click(object sender, EventArgs e)
        {
            txthoja.SelectAll();
        }

        private void txtpata_Click(object sender, EventArgs e)
        {
            txtpata.SelectAll();
        }

        private void txtpata_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if(txtpata.Text.Length > 0)
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }

                bool IsDec = false;
                int nroDec = 0;

                for (int i = 0; i < txtpata.Text.Length; i++)
                {
                    if (txtpata.Text[i] == '.')
                        IsDec = true;

                    if (IsDec && nroDec++ >= 3)
                    {
                        e.Handled = true;
                        return;
                    }
                }

                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;                
            }
        }

        private void txthoja_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txthoja.Text.Length > 0)
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }

                bool IsDec = false;
                int nroDec = 0;

                for (int i = 0; i < txthoja.Text.Length; i++)
                {
                    if (txthoja.Text[i] == '.')
                        IsDec = true;

                    if (IsDec && nroDec++ >= 3)
                    {
                        e.Handled = true;
                        return;
                    }


                }

                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;                
            }
        }

        private void txtmuestrakg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtmuestrakg.Text.Length; i++)
            {
                if (txtmuestrakg.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 3)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;           
        }

        private void txtmuestrakg_Click(object sender, EventArgs e)
        {
            txtmuestrakg.SelectAll();           
        }

        private void DGV1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DGV1.CurrentCell.ColumnIndex == 1)
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }

                bool IsDec = false;
                int nroDec = 0;

                for (int i = 0; i < txt1.Text.Length; i++)
                {
                    if (txt1.Text[i] == '.')
                        IsDec = true;

                    if (IsDec && nroDec++ >= 3)
                    {
                        e.Handled = true;
                        return;
                    }
                }

                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }
        }

        private void DGV1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DGV1.CurrentCell.ColumnIndex == 1)
            {
                //if (DGV1.CurrentRow.Cells[1].Value.ToString().Length > 0)
                //{
                    txt1 = e.Control as TextBox;
                    if (txt1 != null)
                    {
                        txt1.KeyPress -= new KeyPressEventHandler(DGV1_KeyPress);
                        txt1.KeyPress += new KeyPressEventHandler(DGV1_KeyPress);
                    }
                //}
            }
        }

        private void DGV1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV1.CurrentCell.ColumnIndex == 1)
            {
                if (consulta != true)
                {
                    defectos = 0;
                    decimal porcentaje = (Convert.ToDecimal(DGV1.CurrentRow.Cells[1].Value) * 100) / Convert.ToDecimal(txtmuestrakg.Text);
                    DGV1.CurrentRow.Cells[2].Value = porcentaje;

                    for (int i = 0; i < DGV1.Rows.Count; i++)
                    {
                        defectos = defectos + Convert.ToDecimal(DGV1.Rows[i].Cells[1].Value);
                    }

                    txtdefectos.Text = defectos.ToString("###,###,###.00");
                    txtporgrado1.Text = ((Convert.ToDecimal(txtgrado1.Text) * 100) / Convert.ToDecimal(txtmuestrakg.Text)).ToString("###,###,###.0000");
                    txttotalgrado1.Text = ((Convert.ToDecimal(txtporgrado1.Text) / 100) * Convert.ToDecimal(txtpesoutil.Text)).ToString("###,###,###.0000");

                    txtporgrado2.Text = ((Convert.ToDecimal(txtgrado2.Text) * 100) / Convert.ToDecimal(txtmuestrakg.Text)).ToString("###,###,###.0000");
                    txttotalgrado2.Text = ((Convert.ToDecimal(txtporgrado2.Text) / 100) * Convert.ToDecimal(txtpesoutil.Text)).ToString("###,###,###.0000");

                    txtpordef.Text = ((Convert.ToDecimal(txtdefectos.Text) * 100) / Convert.ToDecimal(txtmuestrakg.Text)).ToString("###,###,###.0000");
                    txttotaldef.Text = ((Convert.ToDecimal(txtpordef.Text) / 100) * Convert.ToDecimal(txtpesoutil.Text)).ToString("###,###,###.0000");

                    txttotal.Text = (Convert.ToDecimal(txtgrado1.Text) + Convert.ToDecimal(txtgrado2.Text) + Convert.ToDecimal(txtdefectos.Text)).ToString("###,###,###.00");
                    txttotalpor.Text = (Convert.ToDecimal(txtporgrado1.Text) + Convert.ToDecimal(txtporgrado2.Text) + Convert.ToDecimal(txtpordef.Text)).ToString("###,###,###.00");
                    txttotalkg.Text = (Convert.ToDecimal(txttotalgrado1.Text) + Convert.ToDecimal(txttotalgrado2.Text) + Convert.ToDecimal(txttotaldef.Text)).ToString("###,###,###.00");
                    DGV1.Update();
                }
                DGV1.Columns[2].DefaultCellStyle.Format = "0.00";
            }
        }

        private void txtmuestrakg_TextChanged(object sender, EventArgs e)
        {
            if (consulta != true)
            {
                if (txtmuestrakg.Text.Trim() == "")
                    txtmuestrakg.Text = "0.00";

                if (txtmuestrakg.Text != "0.00")
                {
                    if (Convert.ToDecimal(txtmuestrakg.Text) <= Convert.ToDecimal(txtpesobruto.Text))
                    {
                        if (Convert.ToDecimal(txtmuestrakg.Text) > 0)
                        {
                            //txtdefectos.Text = "0.00";
                            defectos = 0;
                            for (int i = 0; i < DGV1.Rows.Count; i++)
                            {
                                decimal porcentaje = (Convert.ToDecimal(DGV1.Rows[i].Cells[1].Value) * 100) / Convert.ToDecimal(txtmuestrakg.Text);
                                DGV1.Rows[i].Cells[2].Value = porcentaje;

                                defectos = defectos + Convert.ToDecimal(DGV1.Rows[i].Cells[1].Value);
                            }
                            DGV1.Columns[2].DefaultCellStyle.Format = "0.00";
                            txtdefectos.Text = defectos.ToString("###,###,###.00");

                            txtporgrado1.Text = ((Convert.ToDecimal(txtgrado1.Text) * 100) / Convert.ToDecimal(txtmuestrakg.Text)).ToString("###,###,###.0000");
                            txttotalgrado1.Text = ((Convert.ToDecimal(txtporgrado1.Text) / 100) * Convert.ToDecimal(txtpesoutil.Text)).ToString("###,###,###.0000");

                            txtporgrado2.Text = ((Convert.ToDecimal(txtgrado2.Text) * 100) / Convert.ToDecimal(txtmuestrakg.Text)).ToString("###,###,###.0000");
                            txttotalgrado2.Text = ((Convert.ToDecimal(txtporgrado2.Text) / 100) * Convert.ToDecimal(txtpesoutil.Text)).ToString("###,###,###.0000");

                            txtpordef.Text = ((Convert.ToDecimal(txtdefectos.Text) * 100) / Convert.ToDecimal(txtmuestrakg.Text)).ToString("###,###,###.0000");
                            txttotaldef.Text = ((Convert.ToDecimal(txtpordef.Text) / 100) * Convert.ToDecimal(txtpesoutil.Text)).ToString("###,###,###.0000");

                            txttotal.Text = (Convert.ToDecimal(txtgrado1.Text) + Convert.ToDecimal(txtgrado2.Text) + Convert.ToDecimal(txtdefectos.Text)).ToString("###,###,###.0000");
                            txttotalpor.Text = (Convert.ToDecimal(txtporgrado1.Text) + Convert.ToDecimal(txtporgrado2.Text) + Convert.ToDecimal(txtpordef.Text)).ToString("###,###,###.0000");
                            txttotalkg.Text = (Convert.ToDecimal(txttotalgrado1.Text) + Convert.ToDecimal(txttotalgrado2.Text) + Convert.ToDecimal(txttotaldef.Text)).ToString("###,###,###.0000");
                        }
                    }
                }
            }
        }

        private void txtgrado1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtgrado1.Text.Length; i++)
            {
                if (txtgrado1.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 4)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void txtgrado1_TextChanged(object sender, EventArgs e)
        {
            if (consulta != true)
            {
                if (txtgrado1.Text.Trim() == "")                
                    txtgrado1.Text = "0.00";                    
                
                if (txtmuestrakg.Text != "0.00")
                {
                    txtporgrado1.Text = ((Convert.ToDecimal(txtgrado1.Text) * 100) / Convert.ToDecimal(txtmuestrakg.Text)).ToString("###,###,###.0000");
                    txttotalgrado1.Text = ((Convert.ToDecimal(txtporgrado1.Text) / 100) * Convert.ToDecimal(txtpesoutil.Text)).ToString("###,###,###.0000");

                    txtporgrado2.Text = ((Convert.ToDecimal(txtgrado2.Text) * 100) / Convert.ToDecimal(txtmuestrakg.Text)).ToString("###,###,###.0000");
                    txttotalgrado2.Text = ((Convert.ToDecimal(txtporgrado2.Text) / 100) * Convert.ToDecimal(txtpesoutil.Text)).ToString("###,###,###.0000");

                    txtpordef.Text = ((Convert.ToDecimal(txtdefectos.Text) * 100) / Convert.ToDecimal(txtmuestrakg.Text)).ToString("###,###,###.0000");
                    txttotaldef.Text = ((Convert.ToDecimal(txtpordef.Text) / 100) * Convert.ToDecimal(txtpesoutil.Text)).ToString("###,###,###.0000");

                    txttotal.Text = (Convert.ToDecimal(txtgrado1.Text) + Convert.ToDecimal(txtgrado2.Text) + Convert.ToDecimal(txtdefectos.Text)).ToString("###,###,###.0000");
                    txttotalpor.Text = (Convert.ToDecimal(txtporgrado1.Text) + Convert.ToDecimal(txtporgrado2.Text) + Convert.ToDecimal(txtpordef.Text)).ToString("###,###,###.0000");
                    txttotalkg.Text = (Convert.ToDecimal(txttotalgrado1.Text) + Convert.ToDecimal(txttotalgrado2.Text) + Convert.ToDecimal(txttotaldef.Text)).ToString("###,###,###.0000");                    
                }                
            }
        }

        private void txtgrado1_Click(object sender, EventArgs e)
        {
            txtgrado1.SelectAll();
        }

        private void txtgrado2_Click(object sender, EventArgs e)
        {
            txtgrado2.SelectAll();
        }

        private void txtgrado2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtgrado2.Text.Length; i++)
            {
                if (txtgrado2.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 4)
                {
                    e.Handled = true;
                    return;
                }
            }
            
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void txtgrado2_TextChanged(object sender, EventArgs e)
        {
            if (consulta != true)
            {
                if (txtgrado2.Text.Trim() == "")                
                    txtgrado2.Text = "0.00";                    ;
               
                if (txtdefectos.Text.Trim() == "")               
                    txtdefectos.Text = "0.00";                                   

                if (txtmuestrakg.Text != "0.00")
                {
                    txtporgrado1.Text = ((Convert.ToDecimal(txtgrado1.Text) * 100) / Convert.ToDecimal(txtmuestrakg.Text)).ToString("###,###,###.0000");
                    txttotalgrado1.Text = ((Convert.ToDecimal(txtporgrado1.Text) / 100) * Convert.ToDecimal(txtpesoutil.Text)).ToString("###,###,###.0000");

                    txtporgrado2.Text = ((Convert.ToDecimal(txtgrado2.Text) * 100) / Convert.ToDecimal(txtmuestrakg.Text)).ToString("###,###,###.0000");
                    txttotalgrado2.Text = ((Convert.ToDecimal(txtporgrado2.Text) / 100) * Convert.ToDecimal(txtpesoutil.Text)).ToString("###,###,###.0000");

                    txtpordef.Text = ((Convert.ToDecimal(txtdefectos.Text) * 100) / Convert.ToDecimal(txtmuestrakg.Text)).ToString("###,###,###.0000");
                    txttotaldef.Text = ((Convert.ToDecimal(txtpordef.Text) / 100) * Convert.ToDecimal(txtpesoutil.Text)).ToString("###,###,###.0000");

                    txttotal.Text = (Convert.ToDecimal(txtgrado1.Text) + Convert.ToDecimal(txtgrado2.Text) + Convert.ToDecimal(txtdefectos.Text)).ToString("###,###,###.0000");
                    txttotalpor.Text = (Convert.ToDecimal(txtporgrado1.Text) + Convert.ToDecimal(txtporgrado2.Text) + Convert.ToDecimal(txtpordef.Text)).ToString("###,###,###.0000");
                    txttotalkg.Text = (Convert.ToDecimal(txttotalgrado1.Text) + Convert.ToDecimal(txttotalgrado2.Text) + Convert.ToDecimal(txttotaldef.Text)).ToString("###,###,###.0000");
                }                
            }
        }

        public void registro_movimiento(string f, string nc, string nu, string tm, string oc, string fo, string d, string s, string mf, string As, string ua, string m, string o)
        {
            thisConnection.Open();
            cmnd1 = thisConnection.CreateCommand();
            cmnd1.CommandText = "INSERT INTO tb_registro_movimientos(fecha, nom_compu, nom_usu, tipo_mov, op_clave, folio, detalle, sistema, mov_folio, Arm_solicita, usuario_autoriza, motivo, obs) " +
                "VALUES('" + Convert.ToDateTime(f).ToString("dd-MM-yyyy HH:mm:ss") + "', '" + nc + "', '" + nu + "', '" + tm + "', '" + oc + "', '" + fo + "', '" + d + "', '" + s + "', '" + mf + "', '" + As + "', '" + ua + "', '" + m + "', '" + o + "')";
            cmnd1.ExecuteNonQuery();
            cmnd1.Dispose();
            thisConnection.Close();
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {            
            #region opción 1 guardar
            string ActuBascu = "";
            if (opcion == 1)
            {
                int Ntar = 0;
                if (!int.TryParse(TxtTar.Text, out Ntar) || TxtTar.Text.Trim() == "0")
                {
                    MessageBox.Show("Falta Capturar La Cantidad de Tarimas Recibidas", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtTar.Focus();
                    return;
                }

                if (txtevaluador.Text.Trim() == "")
                {
                    MessageBox.Show("Favor de escribir el nombre del evaluador", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtevaluador.Focus();
                    return;
                }
                if (txtprov_clave.Text == "AJUSTE")
                {
                    MessageBox.Show("Favor de seleccionar el ajuste", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CBAjuste.Focus();
                    return;
                }

                if ((txtflete.Text.Trim() == "") || (txtflete.Text.Trim() == "0"))
                {
                    if (MessageBox.Show("Falta por capturar el flete a este recibo\r\n¿Desea continuar guardando la información?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }


                if ((txtprov_clave.Text.Trim() == "") || (txtrch_clave.Text.Trim() == "") || (txttbl_clave.Text.Trim() == "") || (txtprov.Text.Trim() == "") || (txtrancho.Text.Trim() == "") || (txttabla.Text.Trim() == ""))
                {
                    MessageBox.Show("Falta por capturar alguno de los siguientes datos proveedor, rancho y/o tabla", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (txtvar_clave.Text.Trim() == "" || CBvariedad.Text.Trim() == "")
                {
                    MessageBox.Show("Falta por capturar la Variedad, Favor de Verificar la Información ", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //MessageBox.Show(Convert.ToDouble(txtpata.Text).ToString());
                //se valida que la muestra no este en 0
                if (Convert.ToDecimal(txtmuestrakg.Text) == 0)
                {
                    MessageBox.Show("La muestra no debe ser igual a cero", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmuestrakg.Focus();
                    return;
                }

                //valida campos que sean mayores o iguales a 0
                if (Convert.ToDecimal(txtpesobruto.Text) <= 0)
                {
                    MessageBox.Show("El peso bruto no puede ser menor a 0", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtpesobruto.Focus();
                    return;
                }

                if (Convert.ToDecimal(txttaracamion.Text) <= 0)
                {
                    MessageBox.Show("La tara no puede ser menor a 0", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttaracamion.Focus();
                    return;
                }

                //if (txtprod_clave.Text.Trim() == "09014") // APIO P/ENSALADAS
                //{
                //    if (txtobs.Text.Substring(0, 6) != "ENTERO" || txtobs.Text.Substring(0, 4) != "VARA" || CmbApio.SelectedIndex < 0)
                //    {
                //        MessageBox.Show("La Obs no Trae la Palabra ENTERO O VARA o NO SE HA SELECCIONADO EL TIPO, FAVOR DE AGREGARLA AL INICIO Y UN ESPACIO", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //      txtobs.Focus();
                //        return;
                //  }
                //}
                //if (Convert.ToDouble(txthoja.Text) <= 0.00)
                //{
                //    MessageBox.Show("La hoja no puede ser menor a 0", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txthoja.Focus();
                //    return;
                //}

                //if (Convert.ToDouble(txtpata.Text) <= 0.00)
                //{
                //    MessageBox.Show("La pata no puede ser menor a 0", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtpata.Focus();
                //    return;
                //}
                if (Convert.ToInt32(txtnumins.Text) > 0)
                {
                    if (Convert.ToInt32(txtpzsxmuestra.Text) == 0)
                    {
                        MessageBox.Show("Favor de capturar el número de piezas muestra", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtpzsxmuestra.Focus();
                        txtpzsxmuestra.SelectAll();
                        return;
                    }
                }

                if (Convert.ToInt32(txtnumviaje.Text) < 0)
                {
                    MessageBox.Show("El viaje no puede ser 0", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtnumviaje.Focus();
                    return;
                }

                if (Convert.ToDecimal(txtpesorecipiente.Text) < 0)
                {
                    MessageBox.Show("El peso del recipiente no puede ser menor a 0", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtpesorecipiente.Focus();
                    return;
                }

                if (Convert.ToDecimal(txtpesoutil.Text) <= 0)
                {
                    MessageBox.Show("El peso util no puede ser menor a 0", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtpesoutil.Focus();
                    return;
                }

                if (Convert.ToDecimal(txtpesoneto.Text) <= 0)
                {
                    MessageBox.Show("El peso neto no puede ser menor a 0", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtpesoneto.Focus();
                    return;
                }

                if (Convert.ToDecimal(txtpzsxmuestra.Text) < 0)
                {
                    MessageBox.Show("El número de piezas muestra no puede ser menor a 0", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtpzsxmuestra.Focus();
                    return;
                }
                if (txtvar_clave.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Favor de Capturar la Variedad en caso de que no tenga Agragar una Clave que diga No Aplica", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtvar_clave.Focus();
                    return;
                }
                //validación de la muestra
                decimal total = Convert.ToDecimal(txttotal.Text);
                decimal muestra = Convert.ToDecimal(txtmuestrakg.Text);
                if (total != muestra)
                {
                    MessageBox.Show("El resultado de la muestra no coincide\r\nMuestra: " + txtmuestrakg.Text + " \r\nTotal: " + txttotal.Text, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    label7.Visible = false;
                    return;
                }

                if (Convert.ToDecimal(txtnumins.Text) != 0)
                {
                    if (txtdescrip.Text.Trim() == "")
                    {
                        MessageBox.Show("Favor de poner la descripción de los insectos que se encontraron", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtdescrip.Focus();
                        return;
                    }
                }

                if (Convert.ToDecimal(txttotalgrado1.Text) > Convert.ToDecimal(txtpesoutil.Text))
                {
                    MessageBox.Show("El Grado 1 no puede ser mayor al peso util, favor de verificar la información", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtgrado1.Focus();
                    return;
                }
                if (Convert.ToDecimal(txttotalgrado2.Text) > Convert.ToDecimal(txtpesoutil.Text))
                {
                    MessageBox.Show("El Grado 2 no puede ser mayor al peso util, favor de verificar la información", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtgrado1.Focus();
                    return;
                }

                if (Convert.ToDecimal(txtpreciogrado1.Text) == 0 && Convert.ToDecimal(txtpreciogrado2.Text) == 0)
                {
                    MessageBox.Show("El Precio del Grado 1 o Grado 2 no puede ser 0, favor de verificar la información", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtpreciogrado1.Focus();
                    return;
                }

                if (ChkImport.Checked) // EL RECIBO ES DE MP IMPORTADA
                {
                    if (Convert.ToDecimal(TxtTipoCam.Text) == 0)
                    {
                        MessageBox.Show("LA MP ES IMPORTADA Y NO TRAE TIPO DE CAMBIO, favor de verificar la información", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtTipoCam.Focus();
                        return;
                    }
                    if (TxtPaisOrigen.Text.Trim().Length < 5)
                    {
                        MessageBox.Show("LA MP ES IMPORTADA Y NO TRAE TIPO PAIS DE ORIGEN, favor de verificar la información", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtPaisOrigen.Focus();
                        return;
                    }
                }

                //27/05/2021
                //Validar que si se selecciono orden grado 1 o 2 esta tenga un valor para los campos de totalgrado 1 y 2
                if (lblEstado.Text == "1")
                {
                    //validacion sobre precio de g1 yo g2

                    if (lblCostoOCG1.Text != "0" && lblCostoOCG2.Text == "0")
                    {
                        if (Convert.ToDecimal(lblCostoOCG1.Text) != Convert.ToDecimal(txtpreciogrado1.Text))
                        {
                            if (MessageBox.Show("El precio ingresado para Grado 1 es: " + txtpreciogrado1.Text + ".\nEl precio de la Orden de Compra es: " + lblCostoOCG1.Text + ".\n¿Desea continuar con el precio ingresado?",
                                "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                            {
                                return;
                            }
                            registro_movimiento(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), Environment.MachineName.ToString(), Utilerias.Class1.Usu_login.ToString().Trim(),
                                "P", "2.1", "", "Aviso por diferencia de precio paso por alto clic SI (Costo G1) Precio usuario: " + txtpreciogrado1.Text + " - Costo OC: " + lblCostoOCG1.Text, 
                                "SIPGAB", "", "", "", "", "");
                        }

                    }

                    if (lblCostoOCG1.Text == "0" && lblCostoOCG2.Text != "0")
                    {
                        if (Convert.ToDecimal(lblCostoOCG2.Text) != Convert.ToDecimal(txtpreciogrado2.Text))
                        {
                            if (MessageBox.Show("El precio ingresado para Grado 2 es: " + txtpreciogrado2.Text + ".\nEl precio de la Orden de Compra es: " + lblCostoOCG2.Text + ".\n¿Desea continuar con el precio ingresado?",
                                "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                            {
                                return;
                            }
                            registro_movimiento(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), Environment.MachineName.ToString(), Utilerias.Class1.Usu_login.ToString().Trim(),
                                "P", "2.1", "", "Aviso por diferencia de precio paso por alto clic SI (Costo G2) Precio usuario: " + txtpreciogrado2.Text + " - Costo OC: " + lblCostoOCG2.Text,
                                "SIPGAB", "", "", "", "", "");
                        }
                    }

                    if (lblCostoOCG1.Text != "0" && lblCostoOCG2.Text != "0")
                    {
                        string mensaje = "";
                        if (Convert.ToDecimal(lblCostoOCG1.Text) != Convert.ToDecimal(txtpreciogrado1.Text))
                        {
                            mensaje += "El precio ingresado para Grado 1 es: " + txtpreciogrado1.Text + ".\nEl precio de la Orden de Compra es: " + lblCostoOCG1.Text + ".\n";
                        }

                        if (Convert.ToDecimal(lblCostoOCG2.Text) != Convert.ToDecimal(txtpreciogrado2.Text))
                        {
                            mensaje += "El precio ingresado para Grado 2 es: " + txtpreciogrado2.Text + ".\nEl precio de la Orden de Compra es: " + lblCostoOCG2.Text + ".\n";
                        }
                        mensaje += "¿Desea continuar con el(los) precio(s) ingresado(s)?";

                        if (MessageBox.Show(mensaje,
                                "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {
                            return;
                        }

                        registro_movimiento(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), Environment.MachineName.ToString(), Utilerias.Class1.Usu_login.ToString().Trim(),
                                "P", "2.1", "", "Aviso por diferencia de precio paso por alto clic SI (Costo G1 y G2) Precio usuario G1: " + txtpreciogrado1.Text + " - Costo OC G1: " + lblCostoOCG1.Text +
                                "Precio usuario G2: " + txtpreciogrado2.Text + " - Costo OC G2: " + lblCostoOCG2.Text,
                                "SIPGAB", "", "", "", "", "");
                    }



                    if (lblOrdenG1.Text != "0")
                    {
                        if (Convert.ToDecimal(txttotalgrado1.Text) == 0)
                        {
                            MessageBox.Show("NO HAY RECEPCION GRADO 1, se removerá orden de compra, volver a guardar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblOrdenG1.Text = "0";
                            return;
                        }
                        //if (txtFechaRecoleccion.Text == "")
                        //{
                        //    MessageBox.Show("SELECCIONAR LA FECHA DE RECOLECCION, favor de verificar la información", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}
                        //if (txtFechaRecepcion.Text == "")
                        //{
                        //    MessageBox.Show("SELECCIONAR LA FECHA DE RECEPCION, favor de verificar la información", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}
                    }
                    else
                    {
                        if (Convert.ToDecimal(txttotalgrado1.Text) > 0)
                        {
                            MessageBox.Show("HAY RECEPCION GRADO 1, favor de seleccionar la orden de compra anticipada\n'Enter en clave de producto o seleccione el producto para abrir la ventana de ordenes anticipadas y vuelva a seleccionarlas'", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblOrdenG1.Text = "0";
                            txtprod_clave.Focus();
                            return;
                        }
                    }

                    if (lblOrdenG2.Text != "0")
                    {
                        if (Convert.ToDecimal(txttotalgrado2.Text) == 0)
                        {
                            MessageBox.Show("NO HAY RECEPCION GRADO 2, se removerá orden de compra, volver a guardar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblOrdenG2.Text = "0";
                            return;
                        }
                        //if (txtFechaRecoleccion.Text == "")
                        //{
                        //    MessageBox.Show("SELECCIONAR LA FECHA DE RECOLECCION, favor de verificar la información", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}
                        //if (txtFechaRecepcion.Text == "")
                        //{
                        //    MessageBox.Show("SELECCIONAR LA FECHA DE RECEPCION, favor de verificar la información", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}
                    }
                    else
                    {
                        if (Convert.ToDecimal(txttotalgrado2.Text) > 0)
                        {
                            MessageBox.Show("HAY RECEPCION GRADO 2, favor de seleccionar la orden de compra anticipada\n'Enter en clave de producto o seleccione el producto para abrir la ventana de ordenes anticipadas y vuelva a seleccionarlas'", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblOrdenG2.Text = "0";
                            txtprod_clave.Focus();
                            return;
                        }
                    }
                }
                //Fin validar que si se selecciono orden grado 1 o 2 esta tenga un valor para los campos de totalgrado 1 y 2

                if (cbsobinsp.Checked == true)
                    sobre_insp = "S";
                else
                    sobre_insp = "N";
                btnGuardar.Enabled = false;
                

                if (Convert.ToDecimal(txtpesobruto.Text) > 0 && (Convert.ToDecimal(txtpesoutil.Text) >= Convert.ToDecimal(txttotalkg.Text) || Convert.ToDecimal(txtpesoutil.Text) <= Convert.ToDecimal(txttotalkg.Text)))
                {
                    label7.Visible = true;
                    label7.Update();
                    

                    lbpretotgrado1.Text = (Convert.ToDecimal(txtpreciogrado1.Text) * Convert.ToDecimal(txttotalgrado1.Text)).ToString("###,###,###.00000");
                    lbpretotgrado2.Text = (Convert.ToDecimal(txtpreciogrado2.Text) * Convert.ToDecimal(txttotalgrado2.Text)).ToString("###,###,###.00000");

                    decimal num_pzs = 0;
                    double pesoxpza = Convert.ToDouble(txtmuestrakg.Text) / Convert.ToDouble(txtpzsxmuestra.Text);
                    double pesoxpza1 = Convert.ToDouble(txtpesoneto.Text) / pesoxpza;
                    num_pzs = Math.Round(Convert.ToDecimal(pesoxpza1 / Convert.ToDouble(txtrmpnumenvase.Text)), MidpointRounding.AwayFromZero);
                    txtpzsxcana.Text = Convert.ToString(Math.Truncate(num_pzs));

                    #region SQL
                    try
                    {
                        if (CBAjuste.Checked == true)
                            ajuste = "TR";

                        if (cbcontrato.SelectedIndex == -1)
                            contrato = "";
                        else
                            contrato = cbcontrato.SelectedItem.ToString().Trim();

                        thisConnection.Open();

                        #region guarda en la tb_mstr_recepcion_mp
                        cmnd1 = thisConnection.CreateCommand();
                        /*cmnd1.CommandText = "INSERT INTO tb_mstr_recepcion_mp (rmp_recibo, rmp_fecha, rmp_ticket, rmp_flete, prov_clave, rch_clave, tbl_clave, " +
                                          "mp_codigo, prod_clave, lin_clave, vari_clave, rmp_peso_bruto, rmp_tara, env_clave, rmp_num_envase, rmp_hoja, rmp_pata, " +
                                          "rmp_muestra, rmp_clase1, rmp_clase2, rmp_defectos, rmp_observaciones, rmp_pesador, rmp_evaluador, rmp_precio_grado1, " +
                                          "rmp_precio_grado2, rmp_pretot_grado1, rmp_pretot_grado2, mp_cve_fecha, mp_viaje, rmp_estatus, tbl_vieja, rmp_hora, inicio_captura, " +
                                          "rmp_campo_insectos, rmp_campo_descripcion, rmp_campo_pza_menor5) values (" + txtrecibo.Text + ", '" + lbfecha.Text + "', " +
                                          "'" + ticket.SelectedItem.ToString().Trim() + "', '" + txtflete.Text + "', '" + txtprov_clave.Text + "', '" + txtrch_clave.Text + "', '" + txttbl_clave.Text + "', " +
                                          "'" + txtcodigo_clave.Text + "', '" + txtprod_clave.Text + "', '" + linea + "', '" + txtvar_clave.Text + "', " + Convert.ToDecimal(txtpesobruto.Text) + ", " +
                                          "" + Convert.ToDecimal(txttaracamion.Text) + ", '" + env_clave + "', " + Convert.ToDecimal(txtrmpnumenvase.Text) + ", " + Convert.ToDecimal(txthoja.Text) + ", " +
                                          "" + Convert.ToDecimal(txtpata.Text) + ", " + Convert.ToDecimal(txtmuestrakg.Text) + ", " + Convert.ToDecimal(txtgrado1.Text) + ", " + Convert.ToDecimal(txtgrado2.Text) + ", " +
                                          "" + Convert.ToDecimal(txtdefectos.Text) + ", '" + txtobs.Text + "', '" + txtpesador.Text + "', '" + txtevaluador.Text + "', " + Convert.ToDecimal(txtpreciogrado1.Text) + ", " +
                                          "" + Convert.ToDecimal(txtpreciogrado2.Text) + ", " + Convert.ToDecimal(lbpretotgrado1.Text) + ", " + Convert.ToDecimal(lbpretotgrado2.Text) + ", " +
                                          "'" + lbcletiqueta.Text.Substring(0, 5) + "', " + Convert.ToDecimal(txtnumviaje.Text) + ", ' ', ' ', '" + txthora.Text + "', " +
                                          "'" + DateTime.Now.ToString() + "', " + Convert.ToInt32(txtnumins.Text) + ", '" + txtdescrip.Text.Trim() + "', " + Convert.ToInt32(txtpzsmenor5.Text) + ")";
                        reader1 = cmnd1.ExecuteReader();
                        reader1.Dispose();*/
                        // MP IMPORTADA
                        string mImport = (ChkImport.Checked) ? "1" : "0";

                        cmnd1.CommandText = "INSERT INTO tb_mstr_recepcion_mp (rmp_fecha, rmp_ticket, rmp_flete, prov_clave, rch_clave, tbl_clave, " +
                                          "mp_codigo, prod_clave, lin_clave, vari_clave, rmp_peso_bruto, rmp_tara, env_clave, rmp_num_envase, rmp_hoja, rmp_pata, " +
                                          "rmp_muestra, rmp_clase1, rmp_clase2, rmp_defectos, rmp_observaciones, rmp_pesador, rmp_evaluador, rmp_precio_grado1, " +
                                          "rmp_precio_grado2, rmp_pretot_grado1, rmp_pretot_grado2, mp_cve_fecha, mp_viaje, rmp_estatus, tbl_vieja, rmp_hora, inicio_captura, " +
                                          "rmp_campo_insectos, rmp_campo_descripcion, rmp_campo_pza_menor5, rmp_pzas_muestra, rmp_tipo, rmp_sobre_insp, um_clave, rmp_evaluacion, " +
                                          "folio_no_conformidad,  rmp_pzs_x_canastillas, contrato_proveedor, rmp_importada, rmp_tc, rmp_fechatc, rmp_paisorigen, rmp_numtar, rmp_pedimento) values ('" + lbfecha.Text + "', " +
                                          "'" + ticket.SelectedItem.ToString().Trim() + "', '" + txtflete.Text + "', '" + txtprov_clave.Text + "', '" + txtrch_clave.Text + "', '" + txttbl_clave.Text + "', " +
                                          "'" + txtcodigo_clave.Text + "', '" + txtprod_clave.Text + "', '" + linea + "', '" + txtvar_clave.Text + "', " + Convert.ToDecimal(txtpesobruto.Text) + ", " +
                                          "" + Convert.ToDecimal(txttaracamion.Text) + ", '" + env_clave + "', " + Convert.ToDecimal(txtrmpnumenvase.Text) + ", " + Convert.ToDecimal(txthoja.Text) + ", " +
                                          "" + Convert.ToDecimal(txtpata.Text) + ", " + Convert.ToDecimal(txtmuestrakg.Text) + ", " + Convert.ToDecimal(txtgrado1.Text) + ", " + Convert.ToDecimal(txtgrado2.Text) + ", " +
                                          "" + Convert.ToDecimal(txtdefectos.Text) + ", '" + txtobs.Text + "', '" + txtpesador.Text + "', '" + txtevaluador.Text + "', " + Convert.ToDecimal(txtpreciogrado1.Text) + ", " +
                                          "" + Convert.ToDecimal(txtpreciogrado2.Text) + ", " + Convert.ToDecimal(lbpretotgrado1.Text) + ", " + Convert.ToDecimal(lbpretotgrado2.Text) + ", " +
                                          "'" + lbcletiqueta.Text.Substring(0, 5) + "', " + Convert.ToDecimal(txtnumviaje.Text) + ", ' ', ' ', '" + txthora.Text + "', " +
                                          "'" + DateTime.Now.ToString() + "', " + Convert.ToInt32(txtnumins.Text) + ", '" + txtdescrip.Text.Trim() + "', " +
                                          "" + Convert.ToDecimal(txtpzsmenor5.Text) + ", " + Convert.ToInt32(txtpzsxmuestra.Text) + ", '" + ajuste + "', '" + sobre_insp + "', " +
                                          "'" + CBMoneda.SelectedItem.ToString().Trim() + "', '" + cbevaluacion.SelectedItem.ToString() + "', '" + txtfolnocon.Text + "', " +
                                          "'" + txtpzsxcana.Text + "', '" + contrato + "','" + mImport + "','" + TxtTipoCam.Text + "','" + LblFecTC.Text + "','" + TxtPaisOrigen.Text + "','" + TxtTar.Text  +"','"+ txtnumped.Text.Trim()+"') select scope_identity()";
                        txtrecibo.Text = Convert.ToString(cmnd1.ExecuteScalar());
                        #endregion

                        #region guarda en tb_mstr_danos
                        for (int i = 0; i < DGV1.Rows.Count; i++)
                        {
                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "insert into tb_mstr_danos (rmp_recibo, lin_clave, dno_clave, dnm_peso, dnm_tipo, dnm_cantidad) values ('" + txtrecibo.Text + "', '" + linea + "', '" + Convert.ToString(DGV1.Rows[i].Cells[3].Value) + "', " + Convert.ToDecimal(DGV1.Rows[i].Cells[1].Value) + ", 'MP', 0)";
                            reader1 = cmnd1.ExecuteReader();
                            reader1.Dispose();
                        }
                        #endregion

                        #region guarda tb_mstr_insectos
                        for (int i = 0; i < DGV2.Rows.Count; i++)
                        {
                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "insert into tb_mstr_insectos (rmp_recibo, ins_clave, cantidad) values ('" + txtrecibo.Text + "', '" + Convert.ToString(DGV2.Rows[i].Cells[2].Value) + "', '" + Convert.ToString(DGV2.Rows[i].Cells[1].Value) + "')";
                            reader1 = cmnd1.ExecuteReader();
                            reader1.Dispose();
                        }
                        #endregion

                        #region verifica que no haya otro recibo en el tb_hist_recibo
                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "select * from tb_hist_recepcion where hrp_tipo_recepcion = 'MP' and hrp_recibo = " + Convert.ToInt32(txtrecibo.Text);
                        reader1 = cmnd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            if (Convert.ToInt32(txtrmpnumenvase.Text) == 0)
                                txtrmpnumenvase.Text = "1";
                        }
                        reader1.Dispose();
                        #endregion

                        #region graba en el tb_hist_recepcion
                        
                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "insert into tb_hist_recepcion (hrp_recibo, hrp_fecha, hrp_ticket, hrp_tipo_recepcion, lin_clave, prod_clave, " +
                                                "hrp_peso_util, hrp_peso_neto, hrp_num_unidades, hrp_reman_unidades, hrp_clase1, hrp_clase2, hrp_estatus, hrp_reman_kg, " +
                                                "hrp_proceso, hrp_peso_linea, hrp_un_linea, hrp_situacion, hrp_liquidado, hrp_afect_costo, hrp_numliq, liquidado, " +
                                                "hrp_cvepro, hrp_numoc, hrp_recref, hrp_surtido, hrp_estatus_sur) values (" + Convert.ToInt32(txtrecibo.Text) + ", " +
                                                "'" + lbfecha.Text + "', '" + ticket.SelectedItem.ToString().Trim() + "', 'MP', '" + linea + "', '" + txtprod_clave.Text + "', " +
                                                "" + Convert.ToDecimal(txtpesoutil.Text) + ", " + Convert.ToDecimal(txtpesoneto.Text) + ", " + Convert.ToDecimal(txtrmpnumenvase.Text) + ", " +
                                                "" + Convert.ToDecimal(txtrmpnumenvase.Text) + ", " + Convert.ToDecimal(txttotalgrado1.Text) + ", " + Convert.ToDecimal(txttotalgrado2.Text) + ", " +
                                                "'T', " + Convert.ToDecimal(txtpesoneto.Text) + ", 0, 0, 0, '" + ajuste + "', '', 'F', ' ', 'F', ' ', ' ', ' ', 0, ' ')";
                            reader1 = cmnd1.ExecuteReader();
                            reader1.Dispose();
                        #endregion

                        #region Guardo el Recibo en la Tabla de Aguilares RCC 19 de Abril 2022
                            string Replica = "N";
                            foreach (DataRow row in productos.Select("prod_clave = '" + txtprod_clave.Text + "'"))
                                if (row["prog_grupo"].ToString().Trim() == "Aguilares")
                                    Replica = "S";
                            if (Replica == "S")
                            {
                                thisConnectionTomate.Open();
                                // guarda en la tb_mstr_recepcion_mp
                                cmnd1 = thisConnectionTomate.CreateCommand();
                                mImport = (ChkImport.Checked) ? "1" : "0";

                                cmnd1.CommandText = "INSERT INTO tb_mstr_recepcion_mp (rmp_fecha, rmp_ticket, rmp_flete, prov_clave, rch_clave, tbl_clave, " +
                                                  "mp_codigo, prod_clave, lin_clave, vari_clave, rmp_peso_bruto, rmp_tara, env_clave, rmp_num_envase, rmp_hoja, rmp_pata, " +
                                                  "rmp_muestra, rmp_clase1, rmp_clase2, rmp_defectos, rmp_observaciones, rmp_pesador, rmp_evaluador, rmp_precio_grado1, " +
                                                  "rmp_precio_grado2, rmp_pretot_grado1, rmp_pretot_grado2, mp_cve_fecha, mp_viaje, rmp_estatus, tbl_vieja, rmp_hora, inicio_captura, " +
                                                  "rmp_campo_insectos, rmp_campo_descripcion, rmp_campo_pza_menor5, rmp_pzas_muestra, rmp_tipo, rmp_sobre_insp, um_clave, rmp_evaluacion, " +
                                                  "folio_no_conformidad,  rmp_pzs_x_canastillas, contrato_proveedor, rmp_importada, rmp_tc, rmp_fechatc, rmp_paisorigen, rmp_tarimas) values ('" + lbfecha.Text + "', " +
                                                  "'" + ticket.SelectedItem.ToString().Trim() + "', '" + txtflete.Text + "', '" + txtprov_clave.Text + "', '" + txtrch_clave.Text + "', '" + txttbl_clave.Text + "', " +
                                                  "'" + txtcodigo_clave.Text + "', '" + txtprod_clave.Text + "', '" + linea + "', '" + txtvar_clave.Text + "', " + Convert.ToDecimal(txtpesobruto.Text) + ", " +
                                                  "" + Convert.ToDecimal(txttaracamion.Text) + ", '" + env_clave + "', " + Convert.ToDecimal(txtrmpnumenvase.Text) + ", " + Convert.ToDecimal(txthoja.Text) + ", " +
                                                  "" + Convert.ToDecimal(txtpata.Text) + ", " + Convert.ToDecimal(txtmuestrakg.Text) + ", " + Convert.ToDecimal(txtgrado1.Text) + ", " + Convert.ToDecimal(txtgrado2.Text) + ", " +
                                                  "" + Convert.ToDecimal(txtdefectos.Text) + ", '" + txtobs.Text + "', '" + txtpesador.Text + "', '" + txtevaluador.Text + "', " + Convert.ToDecimal(txtpreciogrado1.Text) + ", " +
                                                  "" + Convert.ToDecimal(txtpreciogrado2.Text) + ", " + Convert.ToDecimal(lbpretotgrado1.Text) + ", " + Convert.ToDecimal(lbpretotgrado2.Text) + ", " +
                                                  "'" + lbcletiqueta.Text.Substring(0, 5) + "', " + Convert.ToDecimal(txtnumviaje.Text) + ", ' ', ' ', '" + txthora.Text + "', " +
                                                  "'" + DateTime.Now.ToString() + "', " + Convert.ToInt32(txtnumins.Text) + ", '" + txtdescrip.Text.Trim() + "', " +
                                                  "" + Convert.ToDecimal(txtpzsmenor5.Text) + ", " + Convert.ToInt32(txtpzsxmuestra.Text) + ", '" + ajuste + "', '" + sobre_insp + "', " +
                                                  "'" + CBMoneda.SelectedItem.ToString().Trim() + "', '" + cbevaluacion.SelectedItem.ToString() + "', '" + txtfolnocon.Text + "', " +
                                                  "'" + txtpzsxcana.Text + "', '" + contrato + "','" + mImport + "','" + TxtTipoCam.Text + "','" + LblFecTC.Text + "','" + TxtPaisOrigen.Text + "','0') select scope_identity()";
                                string ReciboAgui = Convert.ToString(cmnd1.ExecuteScalar());
                                //guarda en tb_mstr_danos
                                for (int i = 0; i < DGV1.Rows.Count; i++)
                                {
                                    cmnd1 = thisConnectionTomate.CreateCommand();
                                    cmnd1.CommandText = "insert into tb_mstr_danos (rmp_recibo, lin_clave, dno_clave, dnm_peso, dnm_tipo, dnm_cantidad) values ('" + ReciboAgui + "', '" + linea + "', '" + Convert.ToString(DGV1.Rows[i].Cells[3].Value) + "', " + Convert.ToDecimal(DGV1.Rows[i].Cells[1].Value) + ", 'MP', 0)";
                                    reader1 = cmnd1.ExecuteReader();
                                    reader1.Dispose();
                                }
                                // guarda tb_mstr_insectos
                                for (int i = 0; i < DGV2.Rows.Count; i++)
                                {
                                    cmnd1 = thisConnectionTomate.CreateCommand();
                                    cmnd1.CommandText = "insert into tb_mstr_insectos (rmp_recibo, ins_clave, cantidad) values ('" + ReciboAgui + "', '" + Convert.ToString(DGV2.Rows[i].Cells[2].Value) + "', '" + Convert.ToString(DGV2.Rows[i].Cells[1].Value) + "')";
                                    reader1 = cmnd1.ExecuteReader();
                                    reader1.Dispose();
                                }
                                //graba en el tb_hist_recepcion
                                cmnd1 = thisConnectionTomate.CreateCommand();
                                cmnd1.CommandText = "insert into tb_hist_recepcion (hrp_recibo, hrp_fecha, hrp_ticket, hrp_tipo_recepcion, lin_clave, prod_clave, " +
                                                    "hrp_peso_util, hrp_peso_neto, hrp_num_unidades, hrp_reman_unidades, hrp_clase1, hrp_clase2, hrp_estatus, hrp_reman_kg, " +
                                                    "hrp_proceso, hrp_peso_linea, hrp_un_linea, hrp_situacion, hrp_liquidado, hrp_afect_costo, hrp_numliq, liquidado, " +
                                                    "hrp_cvepro, hrp_numoc, hrp_recref, hrp_surtido, hrp_estatus_sur) values (" + Convert.ToInt32(ReciboAgui) + ", " +
                                                    "'" + lbfecha.Text + "', '" + ticket.SelectedItem.ToString().Trim() + "', 'MP', '" + linea + "', '" + txtprod_clave.Text + "', " +
                                                    "" + Convert.ToDecimal(txtpesoutil.Text) + ", " + Convert.ToDecimal(txtpesoneto.Text) + ", " + Convert.ToDecimal(txtrmpnumenvase.Text) + ", " +
                                                    "" + Convert.ToDecimal(txtrmpnumenvase.Text) + ", " + Convert.ToDecimal(txttotalgrado1.Text) + ", " + Convert.ToDecimal(txttotalgrado2.Text) + ", " +
                                                    "'T', " + Convert.ToDecimal(txtpesoneto.Text) + ", 0, 0, 0, '" + ajuste + "', '', 'F', ' ', 'F', ' ', ' ', ' ', 0, ' ')";
                                reader1 = cmnd1.ExecuteReader();
                                reader1.Dispose();
                                thisConnectionTomate.Close();
                                MessageBox.Show("Se Grabo el Recibo En la Tabla de Aguilares No. " + ReciboAgui, "Alta de MP en Aguilares", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Utilerias.Class1.registrar_movimiento(DateTime.Now, Environment.MachineName, Utilerias.Class1.Usu_login, "A", "2.1", ReciboAgui, "Se Grabo el Registro en la Tabla de Aguilares " + ReciboAgui, "SIPGAB");
                                // Se envia la Informacion por Correo Notificando a Aguilares
                                label7.Text = "ENVIANDO CORREO . . .";
                                label7.Visible = true;
                                label7.Update();

                                string body = string.Format("Hola Buen día" + "<br><br>" + "Envio información del detalle del recibo Capturado en Planta " + txtrecibo.Text + "<br><br>" +
                                            "El Cual Fue Registrado En Aguilares con el Folio: " + ReciboAgui + "<br><br>" +
                                            "Del Día " + lbfecha.Text + "<br><br>" +
                                            "Atentamente, " + "<br><br>" +
                                            "Comercializadora GAB S.A. de C.V." + "<br>" +
                                            "www.mrlucky.com.mx");

                                PrintDocument printdocu = new PrintDocument();
                                printdocu.PrintPage += new PrintPageEventHandler(this.Genera_PDF_PrintPage);
                                printdocu.PrinterSettings.PrinterName = "Foxit Reader PDF Printer";
                                printdocu.Print();
                                var inv_pt1 = @"C:\\Reportes\document.pdf";
                                if (Utilerias.Class1.ConnectionString.Contains("GABIRASQL"))
                                {
                                    var inv_pt2 = @"\\gabira1\Recibos_proveedores\MP_" + txtrecibo.Text + ".pdf";
                                    //var inv_pt2 = @"\\gabira1\ConEmbNa\prueba.pdf";
                                    if (!File.Exists(inv_pt1))
                                    {
                                        using (FileStream fs = File.Create(inv_pt1)) { }
                                    }
                                    if (File.Exists(inv_pt2))
                                        File.Delete(inv_pt2);

                                    File.Move(inv_pt1, inv_pt2);
                                    if (email.Trim() != "")
                                        SendMail(email, inv_pt2.ToString(), body, "Envio información del recibo " + txtrecibo.Text);
                                }
                                else
                                {
                                    var inv_pt3 = @"C:\\Reportes\MP_" + txtrecibo.Text + ".pdf";
                                    if (File.Exists(inv_pt3))
                                        File.Delete(inv_pt3);

                                    File.Move(inv_pt1, inv_pt3);
                                    email = "cmoreno@mrlucky.com.mx;ricardo.cortes@mrlucky.com.mx;comprasmp@mrlucky.com.mx;karinay@grupou.mx;matprimaempaque@grupou.mx";
                                    //if (email.Trim() != "")
                                    SendMail(email, inv_pt3.ToString(), body, "Envio información del recibo " + txtrecibo.Text);
                                }
                                //MessageBox.Show("El archivo ha sido enviado al proveedor", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                label7.Visible = false;
                            }
                        
                        #endregion

                        #region afecta inventario
                        //va y hace una consulta para saber si hay un registro con la fecha actual
                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "select invmp_entradas_kg, invmp_entradas_un from tb_mstr_inventario_mp where invmp_fecha = '" + System.DateTime.Now.ToShortDateString() + "' and lin_clave = '" + linea + "' and prod_clave = '" + txtprod_clave.Text + "'";
                        reader1 = cmnd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            invmp_entradas_kg = reader1.GetSqlDecimal(0).Value;
                            invmp_entradas_un = reader1.GetSqlDecimal(1).Value;

                            invmp_entradas_kg = invmp_entradas_kg + Convert.ToDecimal(txttotalgrado1.Text);
                            invmp_entradas_un = invmp_entradas_un + Convert.ToDecimal(txtrmpnumenvase.Text);

                            cmnd11 = thisConnection.CreateCommand();
                            cmnd11.CommandText = "update tb_mstr_inventario_mp set invmp_entradas_kg = " + invmp_entradas_kg + ", invmp_entradas_un = " + invmp_entradas_un + " where lin_clave = '" + linea + "' and prod_clave = '" + txtprod_clave.Text + "'";
                            reader11 = cmnd11.ExecuteReader();
                            reader11.Dispose();
                        }
                        if (reader1.HasRows == false)
                        {
                            cmnd11 = thisConnection.CreateCommand();
                            cmnd11.CommandText = "select top 1 invmp_inicial_kg, invmp_inicial_un, ISNULL(invmp_entradas_kg,0) AS invmp_entradas_kg, ISNULL(invmp_entradas_un,0) AS invmp_entradas_un, invmp_salidas_kg, invmp_salidas_un from tb_mstr_inventario_mp where lin_clave ='" + linea + "' and prod_clave ='" + txtprod_clave.Text + "' order BY invmp_fecha desc";
                            reader11 = cmnd11.ExecuteReader();
                            while (reader11.Read())
                            {
                                invmp_inicial_kg = reader11.GetSqlDecimal(0).Value;
                                invmp_inicial_un = reader11.GetSqlDecimal(1).Value;
                                invmp_entradas_kg = reader11.GetSqlDecimal(2).Value;
                                invmp_entradas_un = reader11.GetSqlDecimal(3).Value;
                                invmp_salidas_kg = reader11.GetSqlDecimal(4).Value;
                                invmp_salidas_un = reader11.GetSqlDecimal(5).Value;

                                var_dec_inv_inicial_kg = invmp_inicial_kg + invmp_entradas_kg - invmp_salidas_kg;
                                var_dec_inv_inicial_un = invmp_inicial_un + invmp_entradas_un - invmp_salidas_un;

                                //inserto un nuevo registro
                                cmnd21 = thisConnection.CreateCommand();
                                cmnd21.CommandText = "insert into tb_mstr_inventario_mp (invmp_fecha, lin_clave, prod_clave, invmp_inicial_un, invmp_inicial_kg, invmp_entradas_un, invmp_entradas_kg, invmp_salidas_un, invmp_salidas_kg) " +
                                                   "values ('" + System.DateTime.Now.ToShortDateString() + "', '" + linea + "', '" + txtprod_clave.Text + "', " + var_dec_inv_inicial_un + ", " + var_dec_inv_inicial_kg + ", " + Convert.ToDecimal(txtrmpnumenvase.Text) + ", " + Convert.ToDecimal(txttotalgrado1.Text) + ", 0, 0)";
                                reader21 = cmnd21.ExecuteReader();
                                reader21.Dispose();
                            }
                            if (reader11.HasRows == false)
                            {
                                cmnd21 = thisConnection.CreateCommand();
                                cmnd21.CommandText = "insert into tb_mstr_inventario_mp (invmp_fecha, lin_clave, prod_clave, invmp_inicial_kg, invmp_inicial_un, invmp_entradas_kg, invmp_entradas_un, invmp_salidas_kg, invmp_salidas_un) " +
                                                    "values ('" + System.DateTime.Now.ToShortDateString() + "', '" + linea.Trim() + "', '" + txtprod_clave.Text + "', 0, 0, " + Convert.ToDecimal(txttotalgrado1.Text) + ", " + Convert.ToDecimal(txtrmpnumenvase.Text) + ", 0, 0)";
                                reader21 = cmnd21.ExecuteReader();
                                reader21.Dispose();
                            }
                            reader11.Dispose();
                        }
                        reader1.Dispose();
                        #endregion

                        #region envases
                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "select prod_muestra from tb_cat_producto where prod_tipo = 'MP' and prod_clave = '" + txtprod_clave.Text + "'";
                        reader1 = cmnd1.ExecuteReader();
                        if (reader1.HasRows)
                        {
                            while (reader1.Read())
                            {
                                prod_muestra = Convert.ToDecimal(reader1.GetValue(0).ToString());
                            }
                        }
                        else
                            prod_muestra = 1;

                        reader1.Dispose();

                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "select max(folio) as m_SIG from tb_entradas_envases";
                        reader1 = cmnd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            folio_anterior = Convert.ToDecimal(reader1.GetValue(0).ToString());
                        }
                        reader1.Dispose();

                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "insert into tb_entradas_envases (fecha, prov_clave, prov_nombre, rch_clave, rch_nombre, tbl_clave, tbl_nombre, " +
                                          "nom_chofer, nom_operador, rmp_folio, ent_status, ALTA_REAL) values ('" + lbfecha.Text + "', '" + txtprov_clave.Text + "', '" + txtprov.Text + "', " +
                                          "'" + txtrch_clave.Text + "', '" + txtrancho.Text + "', '" + txttbl_clave.Text + "', '" + txttabla.Text + "', ' ', '" + txtevaluador.Text + "', " +
                                          "'" + txtrecibo.Text + "', 'T', GETDATE())";
                        reader1 = cmnd1.ExecuteReader();

                        reader1.Dispose();

                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "select max(folio) as m_SIG from tb_entradas_envases";
                        reader1 = cmnd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            m_SIG = reader1.GetSqlDecimal(0).Value;
                        }
                        reader1.Dispose();

                        if (m_SIG <= folio_anterior)
                            MessageBox.Show("ERROR EN LOS CONSECUTIVOS DE TB_ENTRADAS_ENVASES");
                        else
                        {
                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "insert into tb_detentradas_envases (folio, env_clave, env_nombre, cantidad, prod_clave, prod_nombre) " +
                                              "values (" + m_SIG + ", '" + env_clave + "', '" + txtenv.Text + "', '" + Convert.ToDecimal(txtrmpnumenvase.Text) + "', " +
                                              "'" + txtprod_clave.Text + "', '" + txtprod.Text + "')";
                            reader1 = cmnd1.ExecuteReader();
                            reader1.Dispose();

                            existe = "N";

                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "select * from tb_mstr_envases where prov_clave = '" + txtprov_clave.Text + "' and rch_clave = '" + txtrch_clave.Text + "' and tbl_clave = '" + txttbl_clave.Text + "' and env_clave = '" + env_clave + "'";
                            reader1 = cmnd1.ExecuteReader();
                            if (reader1.HasRows)
                                existe = "S";

                            reader1.Dispose();

                            if (existe.Trim() == "S")
                            {
                                cmnd1 = thisConnection.CreateCommand();
                                cmnd1.CommandText = "update tb_mstr_envases set cant_entradas = cant_entradas + " + Convert.ToDecimal(txtrmpnumenvase.Text) + " where prov_clave = '" + txtprov_clave.Text + "' and rch_clave = '" + txtrch_clave.Text + "' and tbl_clave = '" + txttbl_clave.Text + "' and env_clave ='" + env_clave + "'";
                                reader1 = cmnd1.ExecuteReader();
                            }
                            else
                            {
                                cmnd1 = thisConnection.CreateCommand();
                                cmnd1.CommandText = "insert into tb_mstr_envases (prov_clave, rch_clave, tbl_clave, cant_entradas, env_clave, cant_salidas) " +
                                                  "values ('" + txtprov_clave.Text + "', '" + txtrch_clave.Text + "', '" + txttbl_clave.Text + "', " + Convert.ToDecimal(txtrmpnumenvase.Text) + ", " +
                                                  "'" + env_clave + "', 0)";
                                reader1 = cmnd1.ExecuteReader();
                            }
                            reader1.Dispose();

                            //VOY A AGREGAR LA EXISTENCIA DEL INVENTARIO POR ENVASE EN EL MAESTRO DE INV DE ENVASES
                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "update tb_mstr_inv_envases set env_inv_cant = env_inv_cant + " + Convert.ToDecimal(txtrmpnumenvase.Text) + " where env_clave = '" + env_clave + "'";
                            reader1 = cmnd1.ExecuteReader();
                            reader1.Dispose();
                        }
                        #endregion

                        #region actualiza el estatus en tb_det_recepcion_bascula
                        
                        if (CBvariedad.SelectedIndex != -1)
                        {
                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "update tb_det_recepcion_bascula set estatus = 'R', cantidad = " + Convert.ToDecimal(txtrmpnumenvase.Text) + ", " +
                                                "flete = " + txtrecibo.Text + ", prov_clave = '" + txtprov_clave.Text + "', rch_clave ='" + txtrch_clave.Text + "', " +
                                                "id_tabla ='" + txttbl_clave.Text + "', tabla = '" + txttabla.Text + "' where " +
                                                "variedad = ' " + CBvariedad.SelectedText.ToString().Trim() + "' and id_ticket = " + ticket.SelectedItem.ToString() + " and " +
                                                "num_prod = " + num_prod + " and flete = '" + txtflete.Text + "'";
                            reader1 = cmnd1.ExecuteReader();
                            ActuBascu = cmnd1.CommandText.ToString().Replace("'", "");
                            reader1.Dispose();
                        }
                        else
                        {
                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "update tb_det_recepcion_bascula set estatus = 'R', cantidad = " + Convert.ToDecimal(txtrmpnumenvase.Text) + ", " +
                                                "flete = " + txtrecibo.Text + ", prov_clave = '" + txtprov_clave.Text + "', rch_clave ='" + txtrch_clave.Text + "', " +
                                                "id_tabla ='" + txttbl_clave.Text + "', tabla = '" + txttabla.Text + "' where id_ticket = " + ticket.SelectedItem.ToString() + " " +
                                                "and num_prod = " + num_prod + " and flete = '" + txtflete.Text + "'";
                            reader1 = cmnd1.ExecuteReader();
                            ActuBascu += System.Environment.NewLine + cmnd1.CommandText.ToString().Replace("'", "");
                            reader1.Dispose();
                        }
                        #endregion

                        #region verifica que se haya registrado en tb_hist_recepcion
                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "select * from tb_hist_recepcion where hrp_recibo = '" + txtrecibo.Text + "' and hrp_tipo_recepcion = 'MP'";
                        reader1 = cmnd1.ExecuteReader();
                        if (reader1.HasRows == false)
                        {
                            reader1.Dispose();
                            #region graba en el tb_hist_recepcion
                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "insert into tb_hist_recepcion (hrp_recibo, hrp_fecha, hrp_ticket, hrp_tipo_recepcion, lin_clave, prod_clave, " +
                                                "hrp_peso_util, hrp_peso_neto, hrp_num_unidades, hrp_reman_unidades, hrp_clase1, hrp_clase2, hrp_estatus, hrp_reman_kg, " +
                                                "hrp_proceso, hrp_peso_linea, hrp_un_linea, hrp_situacion, hrp_liquidado, hrp_afect_costo, hrp_numliq, liquidado, " +
                                                "hrp_cvepro, hrp_numoc, hrp_recref, hrp_surtido, hrp_estatus_sur) values (" + Convert.ToInt32(txtrecibo.Text) + ", " +
                                                "'" + lbfecha.Text + "', '" + ticket.SelectedItem.ToString().Trim() + "', 'MP', '" + linea + "', '" + txtprod_clave.Text + "', " +
                                                "" + Convert.ToDecimal(txtpesoutil.Text) + ", " + Convert.ToDecimal(txtpesoneto.Text) + ", " + Convert.ToDecimal(txtrmpnumenvase.Text) + ", " +
                                                "" + Convert.ToDecimal(txtrmpnumenvase.Text) + ", " + Convert.ToDecimal(txttotalgrado1.Text) + ", " + Convert.ToDecimal(txttotalgrado2.Text) + ", " +
                                                "'T', " + Convert.ToDecimal(txtpesoneto.Text) + ", 0, 0, 0, '" + ajuste + "', '', 'F', ' ', 'F', ' ', ' ', ' ', 0, ' ')";
                            reader1 = cmnd1.ExecuteReader();
                            reader1.Dispose();
                            #endregion

                            #region afecta inventario
                            //va y hace una consulta para saber si hay un registro con la fecha actual
                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "select invmp_entradas_kg, invmp_entradas_un from tb_mstr_inventario_mp where invmp_fecha = '" + System.DateTime.Now.ToShortDateString() + "' and lin_clave = '" + linea + "' and prod_clave = '" + txtprod_clave.Text + "'";
                            reader1 = cmnd1.ExecuteReader();
                            while (reader1.Read())
                            {
                                invmp_entradas_kg = reader1.GetSqlDecimal(0).Value;
                                invmp_entradas_un = reader1.GetSqlDecimal(1).Value;

                                invmp_entradas_kg = invmp_entradas_kg + Convert.ToDecimal(txttotalgrado1.Text);
                                invmp_entradas_un = invmp_entradas_un + Convert.ToDecimal(txtrmpnumenvase.Text);

                                cmnd11 = thisConnection.CreateCommand();
                                cmnd11.CommandText = "update tb_mstr_inventario_mp set invmp_entradas_kg = " + invmp_entradas_kg + ", invmp_entradas_un = " + invmp_entradas_un + " where lin_clave = '" + linea + "' and prod_clave = '" + txtprod_clave.Text + "'";
                                reader11 = cmnd11.ExecuteReader();
                                reader11.Dispose();
                            }
                            if (reader1.HasRows == false)
                            {
                                cmnd11 = thisConnection.CreateCommand();
                                cmnd11.CommandText = "select top 1 invmp_inicial_kg, invmp_inicial_un, invmp_entradas_kg, invmp_entradas_un, invmp_salidas_kg, invmp_salidas_un from tb_mstr_inventario_mp where lin_clave ='" + linea + "' and prod_clave ='" + txtprod_clave.Text + "' order BY invmp_fecha desc";
                                reader11 = cmnd11.ExecuteReader();
                                while (reader11.Read())
                                {
                                    invmp_inicial_kg = reader11.GetSqlDecimal(0).Value;
                                    invmp_inicial_un = reader11.GetSqlDecimal(1).Value;
                                    invmp_entradas_kg = reader11.GetSqlDecimal(2).Value;
                                    invmp_entradas_un = reader11.GetSqlDecimal(3).Value;
                                    invmp_salidas_kg = reader11.GetSqlDecimal(4).Value;
                                    invmp_salidas_un = reader11.GetSqlDecimal(5).Value;

                                    var_dec_inv_inicial_kg = invmp_inicial_kg + invmp_entradas_kg - invmp_salidas_kg;
                                    var_dec_inv_inicial_un = invmp_inicial_un + invmp_entradas_un - invmp_salidas_un;

                                    //inserto un nuevo registro
                                    cmnd21 = thisConnection.CreateCommand();
                                    cmnd21.CommandText = "insert into tb_mstr_inventario_mp (invmp_fecha, lin_clave, prod_clave, invmp_inicial_un, invmp_inicial_kg, invmp_entradas_un, invmp_entradas_kg, invmp_salidas_un, invmp_salidas_kg) " +
                                                       "values ('" + System.DateTime.Now.ToShortDateString() + "', '" + linea + "', '" + txtprod_clave.Text + "', " + var_dec_inv_inicial_un + ", " + var_dec_inv_inicial_kg + ", " + Convert.ToDecimal(txtrmpnumenvase.Text) + ", " + Convert.ToDecimal(txttotalgrado1.Text) + ", 0, 0)";
                                    reader21 = cmnd21.ExecuteReader();
                                    reader21.Dispose();
                                }
                                if (reader11.HasRows == false)
                                {
                                    cmnd21 = thisConnection.CreateCommand();
                                    cmnd21.CommandText = "insert into tb_mstr_inventario_mp (invmp_fecha, lin_clave, prod_clave, invmp_inicial_kg, invmp_inicial_un, invmp_entradas_kg, invmp_entradas_un, invmp_salidas_kg, invmp_salidas_un) " +
                                                        "values ('" + System.DateTime.Now.ToShortDateString() + "', '" + linea.Trim() + "', '" + txtprod_clave.Text + "', 0, 0, " + Convert.ToDecimal(txttotalgrado1.Text) + ", " + Convert.ToDecimal(txtrmpnumenvase.Text) + ", 0, 0)";
                                    reader21 = cmnd21.ExecuteReader();
                                    reader21.Dispose();
                                }
                                reader11.Dispose();
                            }
                            reader1.Dispose();
                            #endregion
                        }
                        reader1.Dispose();
                        #endregion
                        thisConnection.Close();

                        if (lblEstado.Text == "1")
                            btnGuardaOCA_Click(null, null);

                        #region actualiza en Internet en tb_det_flete
                        if (txtflete.Text.Trim() != "")
                        {
                            mySqlConn.Open();
                            string qry = "";
                            try
                            {
                                qry = "select count(*) from tb_det_flete where id_flete = " + Convert.ToInt32(txtflete.Text) + " and id_proveedor = '" + txtprov_clave.Text + "' " +
                                                   "and id_rancho = '" + txtrch_clave.Text + "' and id_tabla = '" + txttbl_clave.Text + "'";
                                cmnd = mySqlConn.CreateCommand();
                                cmnd.CommandText = qry;
                                int hay = Convert.ToInt32(cmnd.ExecuteScalar());

                                if (hay != 0)
                                {
                                    qry = "update tb_det_flete set grado1 =" + Convert.ToDecimal(txttotalgrado1.Text) + ", num_sipgab = " + txtrecibo.Text + ", estatus= 'R' " +
                                                       "where id_flete = " + Convert.ToInt32(txtflete.Text) + " and cantidad = '" + float.Parse(txtrmpnumenvase.Text) + "' and " +
                                                       "id_proveedor = '" + txtprov_clave.Text + "' and id_rancho = '" + txtrch_clave.Text + "' and id_tabla = '" + txttbl_clave.Text + "'";
                                    cmnd.CommandText = qry;
                                    reader = cmnd.ExecuteReader();
                                    reader.Dispose();
                                }
                            }
                            catch (MySqlException exmysql)
                            {
                                Utilerias.Class1.registrar_movimiento3(DateTime.Now, Environment.MachineName, Utilerias.Class1.Usu_login, "A", "2.1", txtrecibo.Text, "ACTUALIZACION RECIBO DE MP INTERNET " + txtrecibo.Text, "SIPGAB", "", qry);
                            }
                            mySqlConn.Close();
                        }
                        #endregion

                        

                        
                    }
                    catch (SqlException ex)
                    {
                        thisConnection.Close();
                        Utilerias.Class1.SendMail("sistemas@mrlucky.com.mx", "sistemas", "Sistem@s2026$", ex.ToString());
                        Utilerias.Class1.registro_errores(DateTime.Now, Utilerias.Class1.Usu_login, Environment.MachineName, "2.1", ex.ToString().Trim(), "SIPGAB");
                        MessageBox.Show(ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    catch (Exception ex1)
                    {
                        thisConnection.Close();
                        Utilerias.Class1.SendMail("sistemas@mrlucky.com.mx", "sistemas", "Sistem@s2026$", ex1.ToString());
                        MessageBox.Show(ex1.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    #endregion

                    label7.ForeColor = Color.Blue;
                    label7.Update();


                    #region FOX
                    /*
                    try 
                    {                       
                        MyConnection.Open();
                        OleDbCommand dbCmdNull1 = MyConnection.CreateCommand();
                        dbCmdNull1.CommandText = "SET NULL OFF";
                        dbCmdNull1.ExecuteNonQuery();
                        dbCmdNull1.Dispose();

                        if (txtrecibo.Text.Length < 6)
                            txtrecibo.Text = "0" + txtrecibo.Text;

                        //guarda en tb_mstr_recepcion_mp
                        cmd1 = MyConnection.CreateCommand();
                        cmd1.CommandText = "insert into tb_mstr_recepcion_mp ([rmp_recibo], [rmp_fecha], [rmp_ticket], [rmp_flete], [prov_clave], [rch_clave], [tbl_clave], [mp_codigo], [prod_clave], [lin_clave], [vari_clave], [rmp_peso_bruto], [rmp_tara], [env_clave], [rmp_num_envase], [rmp_hoja], [rmp_pata], [rmp_muestra], [rmp_clase1], [rmp_clase2], [rmp_defectos], [rmp_observaciones], [rmp_pesador], [rmp_evaluador], [rmp_precio_grado1], [rmp_precio_grado2], [rmp_pretot_grado1], [rmp_pretot_grado2], [mp_cve_fecha], [mp_viaje], [rmp_estatus], [tbl_vieja]) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                        cmd1.Parameters.Add("@Nombre1", OleDbType.Char).Value = txtrecibo.Text;
                        cmd1.Parameters.Add("@Nombre2", OleDbType.Date).Value = Convert.ToDateTime(lbfecha.Text);
                        cmd1.Parameters.Add("@Nombre3", OleDbType.Char).Value = ticket.SelectedItem.ToString().Trim();
                        cmd1.Parameters.Add("@Nombre4", OleDbType.Char).Value = txtflete.Text;
                        cmd1.Parameters.Add("@Nombre5", OleDbType.Char).Value = txtprov_clave.Text;
                        cmd1.Parameters.Add("@Nombre6", OleDbType.Char).Value = txtrch_clave.Text;
                        cmd1.Parameters.Add("@Nombre7", OleDbType.Char).Value = txttbl_clave.Text;
                        cmd1.Parameters.Add("@Nombre8", OleDbType.Char).Value = txtcodigo_clave.Text;
                        cmd1.Parameters.Add("@Nombre9", OleDbType.Char).Value = txtprod_clave.Text;
                        cmd1.Parameters.Add("@Nombre10", OleDbType.Char).Value = linea;
                        cmd1.Parameters.Add("@Nombre11", OleDbType.Char).Value = txtvar_clave.Text;
                        cmd1.Parameters.Add("@Nombre12", OleDbType.Numeric).Value = float.Parse(txtpesobruto.Text);
                        cmd1.Parameters.Add("@Nombre13", OleDbType.Numeric).Value = float.Parse(txttaracamion.Text);
                        cmd1.Parameters.Add("@Nombre14", OleDbType.Char).Value = env_clave;
                        cmd1.Parameters.Add("@Nombre15", OleDbType.Numeric).Value = float.Parse(txtrmpnumenvase.Text);
                        cmd1.Parameters.Add("@Nombre16", OleDbType.Numeric).Value = float.Parse(txthoja.Text);
                        cmd1.Parameters.Add("@Nombre17", OleDbType.Numeric).Value = float.Parse(txtpata.Text);
                        cmd1.Parameters.Add("@Nombre18", OleDbType.Numeric).Value = float.Parse(txtmuestrakg.Text);
                        cmd1.Parameters.Add("@Nombre19", OleDbType.Numeric).Value = float.Parse(txtgrado1.Text);
                        cmd1.Parameters.Add("@Nombre20", OleDbType.Numeric).Value = float.Parse(txtgrado2.Text);
                        cmd1.Parameters.Add("@Nombre21", OleDbType.Numeric).Value = float.Parse(txtdefectos.Text);
                        cmd1.Parameters.Add("@Nombre22", OleDbType.Char).Value = txtobs.Text;
                        cmd1.Parameters.Add("@Nombre23", OleDbType.Char).Value = txtpesador.Text;
                        cmd1.Parameters.Add("@Nombre24", OleDbType.Char).Value = txtevaluador.Text;
                        cmd1.Parameters.Add("@Nombre25", OleDbType.Numeric).Value = float.Parse(txtpreciogrado1.Text);
                        cmd1.Parameters.Add("@Nombre26", OleDbType.Numeric).Value = float.Parse(txtpreciogrado2.Text);
                        cmd1.Parameters.Add("@Nombre27", OleDbType.Numeric).Value = float.Parse(lbpretotgrado1.Text);
                        cmd1.Parameters.Add("@Nombre28", OleDbType.Numeric).Value = float.Parse(lbpretotgrado2.Text);
                        cmd1.Parameters.Add("@Nombre29.", OleDbType.Char).Value = lbcletiqueta.Text.Substring(0, 5);
                        cmd1.Parameters.Add("@Nombre30", OleDbType.Numeric).Value = float.Parse(txtnumviaje.Text);
                        cmd1.Parameters.Add("@Nombre31", OleDbType.Char).Value = " ";
                        cmd1.Parameters.Add("@Nombre32", OleDbType.Char).Value = " ";
                        cmd1.Connection = MyConnection;
                        cmd1.ExecuteNonQuery();
                        cmd1.Dispose();

                        //guarda en tb_mstr_danos
                        for (int i = 0; i < DGV1.Rows.Count; i++)
                        {
                            cmd1 = MyConnection.CreateCommand();
                            cmd1.CommandText = "insert into tb_mstr_danos ([rmp_recibo], [lin_clave], [dno_clave], [dnm_peso], [dnm_tipo]) values (?, ?, ?, ?, ?)";
                            cmd1.Parameters.Add("@Nombre1", OleDbType.Char).Value = txtrecibo.Text;
                            cmd1.Parameters.Add("@Nombre2", OleDbType.Char).Value = linea;
                            cmd1.Parameters.Add("@Nombre3", OleDbType.Char).Value = Convert.ToString(DGV1.Rows[i].Cells[3].Value);
                            cmd1.Parameters.Add("@Nombre4", OleDbType.Numeric).Value = float.Parse(Convert.ToString(DGV1.Rows[i].Cells[1].Value));
                            cmd1.Parameters.Add("@Nombre5", OleDbType.Char).Value = "MP";
                            cmd1.Connection = MyConnection;
                            cmd1.ExecuteNonQuery();
                            cmd1.Dispose();
                        }

                        //guarda en tb_hist_recepcion
                        cmd1 = MyConnection.CreateCommand();
                        cmd1.CommandText = "insert into tb_hist_recepcion ([hrp_recibo], [hrp_fecha], [hrp_ticket], [hrp_tipo_recepcion], [lin_clave], [prod_clave], [hrp_peso_util], [hrp_peso_neto], [hrp_num_unidades], [hrp_reman_unidades], [hrp_clase1], [hrp_clase2], [hrp_estatus], [hrp_reman_kg], [hrp_situacion]) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                        cmd1.Parameters.Add("@Nombre1", OleDbType.Char).Value = txtrecibo.Text.Trim();
                        cmd1.Parameters.Add("@Nombre2", OleDbType.Date).Value = Convert.ToDateTime(lbfecha.Text);
                        cmd1.Parameters.Add("@Nombre3", OleDbType.Char).Value = ticket.SelectedItem.ToString().Trim();
                        cmd1.Parameters.Add("@Nombre4", OleDbType.Char).Value = "MP";
                        cmd1.Parameters.Add("@Nombre5", OleDbType.Char).Value = linea.Trim();
                        cmd1.Parameters.Add("@Nombre6", OleDbType.Char).Value = txtprod_clave.Text.Trim();
                        cmd1.Parameters.Add("@Nombre7", OleDbType.Numeric).Value = float.Parse(txtpesoutil.Text);
                        cmd1.Parameters.Add("@Nombre8", OleDbType.Numeric).Value = float.Parse(txtpesoneto.Text);
                        cmd1.Parameters.Add("@Nombre9", OleDbType.Numeric).Value = float.Parse(txtrmpnumenvase.Text);
                        cmd1.Parameters.Add("@Nombre10", OleDbType.Numeric).Value = float.Parse(txtrmpnumenvase.Text);
                        cmd1.Parameters.Add("@Nombre11", OleDbType.Numeric).Value = float.Parse(txttotalgrado1.Text);
                        cmd1.Parameters.Add("@Nombre12", OleDbType.Numeric).Value = float.Parse(txttotalgrado2.Text);
                        cmd1.Parameters.Add("@Nombre13", OleDbType.Char).Value = "T";
                        cmd1.Parameters.Add("@Nombre14", OleDbType.Numeric).Value = float.Parse(txtpesoneto.Text);
                        cmd1.Parameters.Add("@Nombre15", OleDbType.Char).Value = ajuste;
                        cmd1.Connection = MyConnection;
                        cmd1.ExecuteNonQuery();
                        cmd1.Dispose();

                        //afecta inventario
                        //va y hace una consulta para saber si hay un registro con la fecha actual   
                        cmd1 = MyConnection.CreateCommand();
                        cmd1.CommandText = "select invmp_entradas_kg, invmp_entradas_un from tb_mstr_inventario_mp where invmp_fecha = ? and lin_clave = ? and prod_clave = ?";                        
                        cmd1.Parameters.Add("@Nombre1", OleDbType.Date).Value = System.DateTime.Now.ToShortDateString();                        
                        cmd1.Parameters.Add("@Nombre2", OleDbType.Char).Value = linea;
                        cmd1.Parameters.Add("@Nombre3", OleDbType.Char).Value = txtprod_clave.Text;
                        cmd1.Connection = MyConnection; 
                        read1 = cmd1.ExecuteReader();
                        //cmd1.ExecuteNonQuery();
                        if (read1.HasRows)
                        {
                            while (read1.Read())
                            {
                                invmp_entradas_kg = Convert.ToDecimal(read1.GetValue(0).ToString());
                                invmp_entradas_un = Convert.ToDecimal(read1.GetValue(1).ToString());
                            }

                            
                            invmp_entradas_kg = invmp_entradas_kg + Convert.ToDecimal(txttotalgrado1.Text);
                            invmp_entradas_un = invmp_entradas_un + Convert.ToDecimal(txtrmpnumenvase.Text);

                            cmd1.Dispose();
                            read1.Dispose();

                            dbCmdNull1 = MyConnection.CreateCommand();
                            dbCmdNull1.CommandText = "SET NULL OFF";
                            dbCmdNull1.ExecuteNonQuery();
                            dbCmdNull1.Dispose();

                            dbCmdNull1 = MyConnection.CreateCommand();
                            dbCmdNull1.CommandText = "update tb_mstr_inventario_mp set invmp_entradas_kg = " + invmp_entradas_kg + ", invmp_entradas_un = " + invmp_entradas_un + " where lin_clave = '" + linea + "' and prod_clave = '" + txtprod_clave.Text + "'";
                            //dbCmdNull1.Parameters.Add("@Nombre1", OleDbType.Numeric).Value = invmp_entradas_kg;
                            //dbCmdNull1.Parameters.Add("@Nombre2", OleDbType.Numeric).Value = invmp_entradas_un;
                            dbCmdNull1.Connection = MyConnection;
                            read1 = dbCmdNull1.ExecuteReader();
                            cmd1.Dispose();
                            read1.Dispose();
                            dbCmdNull1.Dispose();
                        }
                        else
                        {
                            read1.Dispose();
                            cmd1.Dispose();
                            cmd1 = MyConnection.CreateCommand();
                            cmd1.CommandText = "select top 1 invmp_inicial_kg, invmp_inicial_un, invmp_entradas_kg, invmp_entradas_un, invmp_salidas_kg, invmp_salidas_un from tb_mstr_inventario_mp where lin_clave = ? and prod_clave = ? order BY invmp_fecha desc";
                            cmd1.Parameters.Add("@Nombre1", OleDbType.Char).Value = linea;
                            cmd1.Parameters.Add("@nombre2", OleDbType.Char).Value = txtprod_clave.Text;
                            cmd1.Connection = MyConnection;
                            read1 = cmd1.ExecuteReader();
                            if (read1.HasRows)
                            {
                                while (read1.Read())
                                {
                                    invmp_entradas_kg = Convert.ToDecimal(read1.GetValue(0).ToString());
                                    invmp_entradas_un = Convert.ToDecimal(read1.GetValue(1).ToString());
                                    invmp_entradas_kg = Convert.ToDecimal(read1.GetValue(2).ToString());
                                    invmp_entradas_un = Convert.ToDecimal(read1.GetValue(3).ToString());
                                    invmp_salidas_kg = Convert.ToDecimal(read1.GetValue(4).ToString());
                                    invmp_salidas_un = Convert.ToDecimal(read1.GetValue(5).ToString());
                                }

                                var_dec_inv_inicial_kg = invmp_inicial_kg + invmp_entradas_kg - invmp_salidas_kg;
                                var_dec_inv_inicial_un = invmp_inicial_un + invmp_entradas_un - invmp_salidas_un;

                                read1.Dispose();
                                cmd1.Dispose();
                                cmd1 = MyConnection.CreateCommand();
                                cmd1.CommandText = "insert into tb_mstr_inventario_mp ([invmp_fecha], [lin_clave], [prod_clave], [invmp_inicial_un], [invmp_inicial_kg], [invmp_entradas_un], [invmp_entradas_kg], [invmp_salidas_un], [invmp_salidas_kg]) values (?, ?, ?, ?, ?, ?, ?, ?, ?)";
                                cmd1.Parameters.Add("@Nombre1", OleDbType.Date).Value = System.DateTime.Now.ToShortDateString();
                                cmd1.Parameters.Add("@Nombre2", OleDbType.Char).Value = linea;
                                cmd1.Parameters.Add("@Nombre3", OleDbType.Char).Value = txtprod_clave.Text;
                                cmd1.Parameters.Add("@Nombre4", OleDbType.Numeric).Value = var_dec_inv_inicial_un;
                                cmd1.Parameters.Add("@Nombre5", OleDbType.Numeric).Value = var_dec_inv_inicial_kg;
                                cmd1.Parameters.Add("@Nombre6", OleDbType.Numeric).Value = float.Parse(txtrmpnumenvase.Text);
                                cmd1.Parameters.Add("@Nombre7", OleDbType.Numeric).Value = float.Parse(txttotalgrado1.Text);
                                cmd1.Parameters.Add("@Nombre8", OleDbType.Numeric).Value = 0;
                                cmd1.Parameters.Add("@Nombre9", OleDbType.Numeric).Value = 0;
                                cmd1.Connection = MyConnection;
                                cmd1.ExecuteNonQuery();
                                cmd1.Dispose();
                                read1.Dispose();
                            }
                            else
                            {
                                cmd1.Dispose();
                                read1.Dispose();
                                cmd1 = MyConnection.CreateCommand();
                                cmd1.CommandText = "insert into tb_mstr_inventario_mp ([invmp_fecha], [lin_clave], [prod_clave], [invmp_inicial_un], [invmp_inicial_kg], [invmp_entradas_un], [invmp_entradas_kg], [invmp_salidas_un], [invmp_salidas_kg]) values (?, ?, ?, ?, ?, ?, ?, ?, ?)";
                                cmd1.Parameters.Add("@Nombre1", OleDbType.Date).Value = System.DateTime.Now.ToShortDateString();
                                cmd1.Parameters.Add("@Nombre2", OleDbType.Char).Value = linea;
                                cmd1.Parameters.Add("@Nombre3", OleDbType.Char).Value = txtprod_clave.Text;
                                cmd1.Parameters.Add("@Nombre4", OleDbType.Numeric).Value = 0;
                                cmd1.Parameters.Add("@Nombre5", OleDbType.Numeric).Value = 0;
                                cmd1.Parameters.Add("@Nombre6", OleDbType.Numeric).Value = float.Parse(txtrmpnumenvase.Text);
                                cmd1.Parameters.Add("@Nombre7", OleDbType.Numeric).Value = float.Parse(txttotalgrado1.Text);
                                cmd1.Parameters.Add("@Nombre8", OleDbType.Numeric).Value = 0;
                                cmd1.Parameters.Add("@Nombre9", OleDbType.Numeric).Value = 0;
                                cmd1.Connection = MyConnection;
                                cmd1.ExecuteNonQuery();
                                cmd1.Dispose();
                                read1.Dispose();
                            }
                        }                                                                              
                        read1.Dispose();
                        cmd1.Dispose();


                        //bool save_fox = false;
                        //cmd1.CommandText = "select * from tb_mstr_recepcion_mp where rmp_recibo = '" + txtrecibo.Text + "'";
                        //cmd1.Connection = MyConnection;
                        //read1 = cmd1.ExecuteReader();
                        //if (read1.HasRows)
                        //    save_fox = true;

                        //read1.Dispose();
                        //save_fox = false;

                        //cmd1.CommandText = "select * tb_hist_recepcion where hrp_tipo_recepcion = 'MP' and hrp_recibo = '"+txtrecibo.Text+"'";
                        //cmd1.Connection=MyConnection;
                        //read1=cmd1.ExecuteReader();
                        //if(read1.HasRows)
                        //    save_fox=true;

                        //read1.Dispose();
                        //save_fox = false;
                        MyConnection.Close();
                    }
                    catch (OleDbException ex)
                    {
                        MyConnection.Close();
                        //Utilerias.Class1.registrar_movimiento(DateTime.Now, Utilerias.Class1.Nombre_equipo, Utilerias.Class1.Usuario, "errorFOX", Utilerias.Class1.Formulario, txtrecibo.Text, ex.ToString());
                        Utilerias.Class1.registro_errores(DateTime.Now, Utilerias.Class1.Usu_login, Environment.MachineName, "2.1", ex.ToString().Trim(), "MPFOX");
                        Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex.ToString().Trim());
                        MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }*/
                    #endregion

                    Utilerias.Class1.registrar_movimiento(DateTime.Now, Environment.MachineName, Utilerias.Class1.Usu_login, "A", "2.1", txtrecibo.Text, "NUEVO RECIBO DE MP " + txtrecibo.Text, "SIPGAB");
                    Utilerias.Class1.registrar_movimiento3(DateTime.Now, Environment.MachineName, Utilerias.Class1.Usu_login, "A", "2.1", txtrecibo.Text, "Afecto al Ticket de Bascula " + ticket.SelectedItem.ToString(), "SIPGAB", ticket.SelectedItem.ToString(), ActuBascu);

                    if (MessageBox.Show("¿Desea imprimir la recepción?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                        pd.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
                        pd.Print();
                        //PrintPreviewDialog VistaPrevia = new PrintPreviewDialog();
                        //VistaPrevia.Document = printDocument1;
                        //VistaPrevia.Show();                     
                    }

                    btnemail_Click(sender, e);

                    //abre la ventana para la impresión de etiquetas
                    Imprimir_etiqueta impeti = new Imprimir_etiqueta();
                    Imprimir_etiqueta.recibo = txtrecibo.Text;
                    Imprimir_etiqueta.fecha = lbfecha.Text;
                    Imprimir_etiqueta.numenvase = txtrmpnumenvase.Text;
                    Imprimir_etiqueta.producto = txtprod.Text;
                    Imprimir_etiqueta.proveedor = txtprov.Text;
                    Imprimir_etiqueta.rancho = txtrancho.Text;
                    Imprimir_etiqueta.tabla = txttabla.Text;
                    Imprimir_etiqueta.evaluador = txtevaluador.Text;
                    if (CBvariedad.SelectedIndex != -1)
                        Imprimir_etiqueta.variedad = CBvariedad.SelectedItem.ToString();

                    Imprimir_etiqueta.observa = txtobs.Text;
                    Imprimir_etiqueta.num_viaje = txtnumviaje.Text;
                    Imprimir_etiqueta.num_tar = num_tarima;
                    impeti.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Existen errores en el muestreo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                //string conteo = "";
                //thisConnection.Open();
                //cmnd1 = thisConnection.CreateCommand();
                //cmnd1.CommandText = "SELECT count(numero_oc) AS cantidad FROM tb_mstr_ordencompra A JOIN tb_det_ordenescompra B JOIN A.numero_oc = B.numero_oc " +
                //    "WHERE A.cveprov_oc = '" + txtprov_clave.Text + "' AND B.prod_clave  = '" + txtprod_clave.Text + "' AND A.status_oc = 'A' AND factura_oc = 'MATERIAP' " +
                //    "AND B.surtido < B.cantidad_oc";
                //reader1 = cmnd1.ExecuteReader();
                //reader1.Read();
                //conteo = reader1["cantidad"].ToString().Trim();
                //reader1.Close();
                //reader1.Dispose();
                //cmnd1.Dispose();
                //thisConnection.Close();

                //if (Convert.ToInt32(conteo) > 0)
                //{
                //    string cv = txtrecibo.Text;
                //    string pv = txtprov_clave.Text;
                //    string pd = txtprod_clave.Text;
                //    string g1 = txttotalgrado1.Text;
                //    string g2 = txttotalgrado2.Text;
                //    string npv = txtprov.Text;
                //    string npd = txtprod.Text;
                //    anticipadas dlg = new anticipadas(cv, pv, pd, g1, g2, npv, npd);
                //    dlg.ShowDialog();
                //}
                //Verificar ordenes de compra anticipadas 24/05/2021
            }
            #endregion

            Utilerias.Class1.registrar_movimiento(DateTime.Now, Environment.MachineName, Utilerias.Class1.Usu_login, "A", "2.1", txtrecibo.Text, "NUEVO RECIBO DE MP " + txtrecibo.Text, "SIPGAB");
            Utilerias.Class1.registrar_movimiento3(DateTime.Now, Environment.MachineName, Utilerias.Class1.Usu_login, "A", "2.1", txtrecibo.Text, "Afecto al Ticket de Bascula " + ticket.SelectedItem.ToString(), "SIPGAB", ticket.SelectedItem.ToString(), ActuBascu);

            limpiarTextBoxes(this);

            cbticket.SelectedIndex = -1;
            ticket.SelectedIndex = -1;
            CBcodigo.SelectedIndex = -1;
            txtprod.SelectedIndex = -1;
            CBvariedad.SelectedIndex = -1;
            CBvariedad.Items.Clear();
            cbticket.Items.Clear();
            ticket.Items.Clear();
            CBcodigo.Items.Clear();
            cbticket.Enabled = false;
            CBcodigo.Enabled = false;
            txtprod.Enabled = false;
            CBvariedad.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancel.Enabled = false;
            btnAlta.Enabled = true;
            btnConsulta.Enabled = true;
            label7.Visible = false;
            CBMoneda.Enabled = false;
            CBMoneda.SelectedIndex = 0;
            recibo = 0;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {            
            SolidBrush color = new SolidBrush(Color.Black);         
            Font fuente = new Font("Courier", 10);

            //recibo
            Point recib = new Point(650, 113);
            e.Graphics.DrawString(txtrecibo.Text, fuente, color, recib);
            
            //lugar
            Point lug = new Point(650, 149);
            e.Graphics.DrawString("IRAPUATO GTO.", fuente, color, lug);
            
            //flete
            Point fle = new Point(693, 172);
            e.Graphics.DrawString(txtflete.Text, fuente, color, fle);
            
            //ticket
            Point tic = new Point(670, 200);
            e.Graphics.DrawString(ticket.SelectedItem.ToString().Trim(), fuente, color, tic);

            //proveedor            
            Point prov = new Point(17, 180);
            e.Graphics.DrawString(txtprov.Text, fuente, color, prov);
            
            //producto
            Point prod = new Point(290, 180);
            e.Graphics.DrawString(txtprod.Text, fuente, color, prod);

            //rancho
            Point rch = new Point(25, 260);
            e.Graphics.DrawString(txtrancho.Text, fuente, color, rch);

            //tabla
            Point tabl = new Point(303, 260);
            e.Graphics.DrawString(txttabla.Text, fuente, color, tabl);
          
            //subtabla o postura
            Point subtbl = new Point(303, 273);
            e.Graphics.DrawString(txtcodigo_clave.Text, fuente, color, subtbl);


            //fecha
            Point day = new Point(630, 260);
            e.Graphics.DrawString(lbfecha.Text, fuente, color, day);

            //peso bruto
            Point pb = new Point(630, 320);
            e.Graphics.DrawString(txtpesobruto.Text, fuente, color, pb);

            //tara 
            Point tc = new Point(630, 350);
            e.Graphics.DrawString(txttaracamion.Text, fuente, color, tc);

            //diferencia de peso bruto - tara
            Point dif = new Point(630, 380);
            e.Graphics.DrawString((Convert.ToDecimal(txtpesobruto.Text) - Convert.ToDecimal(txttaracamion.Text)).ToString(), fuente, color, dif);
            
            //peso envase con nombre y clave
            if (txtenv.Text.Length > 7)
                txtenv.Text.Substring(0, 7);

            Point pr = new Point(540, 410);
            e.Graphics.DrawString(txtenv.Text + "    " + txtrmpnumenvase.Text , fuente, color, pr);
            Point pr1 = new Point(630, 423);
            e.Graphics.DrawString(txtpesorecipiente.Text, fuente,color, pr1);

            //peso neto
            Point pn = new Point(630, 445);
            e.Graphics.DrawString(txtpesoneto.Text, fuente, color, pn);            

            //hoja            
            if (Convert.ToDecimal(txthoja.Text) != 0)
            {
                if (prod_muestra > 0)
                {
                    decimal hoja = Convert.ToDecimal(txthoja.Text) / (prod_muestra / 100);
                    Point hoj = new Point(630, 480);
                    e.Graphics.DrawString(hoja.ToString("00.00"), fuente, color, hoj);
                }
                else
                {
                    Point hoj = new Point(630, 480);
                    e.Graphics.DrawString(txthoja.Text, fuente, color, hoj);
                }
            }
            else
            {
                Point hoj = new Point(630, 480);
                e.Graphics.DrawString(txthoja.Text, fuente, color, hoj);
            }

            //pata porcentaje
            if (Convert.ToDecimal(txtpata.Text) != 0)
            {
                if (prod_muestra > 0)
                {
                    decimal pata = Convert.ToDecimal(txtpata.Text) / (prod_muestra / 100);
                    Point pat = new Point(630, 515);
                    e.Graphics.DrawString(pata.ToString("00.00"), fuente, color, pat);
                }
                else
                {
                    Point pat = new Point(630, 515);
                    e.Graphics.DrawString(txtpata.Text, fuente, color, pat);
                }
            }
            else
            {
                Point pat = new Point(630, 515);
                e.Graphics.DrawString(txtpata.Text, fuente, color, pat);
            }

            //peso útil
            Point pu = new Point(630, 550);
            e.Graphics.DrawString(txtpesoutil.Text, fuente, color, pu);

            //muestra
            Point mue = new Point(100, 335);
            e.Graphics.DrawString(txtmuestrakg.Text, fuente, color, mue);


            if(DGV1.Rows.Count > 20)
                fuente = new Font("Courier", 9);

            //grid
            int con = 370;
            for (int i = 0; i < DGV1.Rows.Count; i++)
            {
                if (Convert.ToDecimal(DGV1.Rows[i].Cells[1].Value.ToString()) > 0)
                {
                    Point nom = new Point(25, con);
                    e.Graphics.DrawString(DGV1.Rows[i].Cells[0].Value.ToString(), fuente, color, nom);

                    Point kgs = new Point(200, con);
                    e.Graphics.DrawString(DGV1.Rows[i].Cells[1].Value.ToString(), fuente, color, kgs);

                    Point por = new Point(325, con);
                    e.Graphics.DrawString(Convert.ToDecimal(DGV1.Rows[i].Cells[2].Value).ToString("#0.00"), fuente, color, por);

                    con = con + 13;
                }
            }


            fuente = new Font("Courier", 9);

            //total kgs defectos
            Point defec = new Point(200, con + 26);
            e.Graphics.DrawString(txtdefectos.Text, fuente, color, defec);

            //total porcentaje defectos
            Point defecpor = new Point(325, con + 26);
            e.Graphics.DrawString(txtpordef.Text, fuente, color, defecpor);

            //grado1
            Point grad1 = new Point(510, 663);
            e.Graphics.DrawString(txtgrado1.Text, fuente, color, grad1);

            //porcentaje grado 1
            Point porgrad1 = new Point(610, 663);
            e.Graphics.DrawString(txtporgrado1.Text, fuente, color, porgrad1);

            //kg grado 1
            Point kggrad1 = new Point(680, 663);
            e.Graphics.DrawString(txttotalgrado1.Text, fuente, color, kggrad1);

            //grado2
            Point grad2 = new Point(510, 710);
            e.Graphics.DrawString(txtgrado2.Text, fuente, color, grad2);

            //porcentaje grado 1
            Point porgrad2 = new Point(610, 710);
            e.Graphics.DrawString(txtporgrado2.Text, fuente, color, porgrad2);

            //kg grado 1
            Point kggrad2 = new Point(680, 710);
            e.Graphics.DrawString(txttotalgrado2.Text, fuente, color, kggrad2);

            //defectos
            Point def = new Point(510, 800);
            e.Graphics.DrawString(txtdefectos.Text, fuente, color, def);

            //porcentaje defectos
            Point pordef = new Point(610, 800);
            e.Graphics.DrawString(txtpordef.Text, fuente, color, pordef);

            //kg defectos
            Point kgdef = new Point(680, 800);
            e.Graphics.DrawString(txttotaldef.Text, fuente, color, kgdef);

            //total grado1
            Point totgrad1 = new Point(510, 870);
            e.Graphics.DrawString(txttotal.Text, fuente, color, totgrad1);

            //total por
            Point totpor = new Point(610, 870);
            e.Graphics.DrawString(txttotalpor.Text, fuente, color, totpor);

            //total kg
            Point totkg = new Point(680, 870);
            e.Graphics.DrawString(txttotalkg.Text, fuente, color, totkg);

            //sobre inspeccion            
            //if (sobre_insp == "N")
            if (cbevaluacion.SelectedIndex == 0)
            {
                Point sob_insp_N = new Point(20, 792);
                e.Graphics.DrawString("X", fuente, color, sob_insp_N);
            }
            //else
            if (cbevaluacion.SelectedIndex == 1)
            {
                Point sob_insp_S = new Point(20, 810);
                e.Graphics.DrawString("X", fuente, color, sob_insp_S);
            }
            if (cbevaluacion.SelectedIndex == 2)
            {
                Point sob_insp_S = new Point(20, 828);
                e.Graphics.DrawString("X", fuente, color, sob_insp_S);
            }

            //pesador
            if(txtpesador.Text.Trim().Length > 8)
                txtpesador.Text = txtpesador.Text.Substring(0, 9);

            Point pesa = new Point(25, 870);
            e.Graphics.DrawString(txtpesador.Text, fuente, color, pesa);

            //evaluador
            if (txtevaluador.Text.Trim().Length > 8)
                txtevaluador.Text = txtevaluador.Text.Substring(0, 9);
            Point evalu = new Point(200, 870);
            e.Graphics.DrawString(txtevaluador.Text, fuente, color, evalu);

            //variedad
            if (CBvariedad.SelectedIndex != -1)
            {
                Point vari = new Point(25, 930);
                e.Graphics.DrawString(CBvariedad.SelectedItem.ToString(), fuente, color, vari);
            }

            //observaciones
            Point obs = new Point(25, 950);
            if (estatus.Trim() != "F")
                e.Graphics.DrawString(txtobs.Text, fuente, color, obs);
            else
                e.Graphics.DrawString(txtobs.Text + "\r\nEL RECIBO ESTÁ CANCELADO", fuente, color, obs);
        }

        private void PBbtnsalir_Click(object sender, EventArgs e)
        {
            //PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            //pd.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
            //pd.Print();  

            //Imprimir_etiqueta impeti = new Imprimir_etiqueta();
            //Imprimir_etiqueta.recibo = txtrecibo.Text;
            //Imprimir_etiqueta.fecha = lbfecha.Text;
            //Imprimir_etiqueta.numenvase = txtrmpnumenvase.Text;
            //Imprimir_etiqueta.producto = txtprod.Text;
            //Imprimir_etiqueta.proveedor = txtprov.Text;
            //Imprimir_etiqueta.rancho = txtrancho.Text;
            //Imprimir_etiqueta.tabla = txttabla.Text;
            //Imprimir_etiqueta.evaluador = txtevaluador.Text;
            //if (CBvariedad.SelectedIndex != -1)
            //    Imprimir_etiqueta.variedad = CBvariedad.SelectedItem.ToString();

            //Imprimir_etiqueta.observa = txtobs.Text;
            //Imprimir_etiqueta.num_viaje = txtnumviaje.Text;
            //Imprimir_etiqueta.num_tar = num_tarima;
            //impeti.ShowDialog(); 

            try
            {
                thisConnection.Open();
                cmnd1 = thisConnection.CreateCommand();
                cmnd1.CommandText = "SELECT TOP 1 inicio_sesion, usu_login FROM tb_cat_historial_dia where nombre_maquina = '" + Environment.MachineName + "' and sistema = 'SIPGAB' ORDER BY inicio_sesion desc";
                reader1 = cmnd1.ExecuteReader();
                while (reader1.Read())
                {
                    Utilerias.Class1.Inicio_sesion = reader1.GetSqlDateTime(0).Value;
                    Utilerias.Class1.Usu_login = reader1.GetSqlString(1).ToString();
                    Utilerias.Class1.Nombre_equipo = Environment.MachineName;
                }
                reader1.Close();

                cmnd1 = thisConnection.CreateCommand();
                cmnd1.CommandText = "update tb_cat_historial_dia set formulario = ' ' where nombre_maquina ='" + Utilerias.Class1.Nombre_equipo + "' and usu_login = '" + Utilerias.Class1.Usu_login + "' and inicio_sesion = '" + Utilerias.Class1.Inicio_sesion.ToString("s") + "' AND sistema = 'SIPGAB'";
                reader1 = cmnd1.ExecuteReader();
                reader1.Close();
                thisConnection.Close();
                Application.Exit();
            }
            catch (SqlException ex)
            {
                thisConnection.Close();
                Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex.ToString());
                MessageBox.Show(ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception ex1)
            {
                thisConnection.Close();
                Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex1.ToString());
                MessageBox.Show(ex1.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }          
        }

        private void txtprod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow row in productos.Select("prod_nombre = '" + txtprod.SelectedItem.ToString().Trim() + "'"))
                {
                    linea = Convert.ToString(row["lin_clave"].ToString().Trim());
                    txtprod_clave.Text = Convert.ToString(row["prod_clave"].ToString().Trim());
                }

                CBvariedad.Items.Clear();
                foreach (DataRow row in variedades.Select("lin_clave = '" + linea + "'"))
                    CBvariedad.Items.Add(Convert.ToString(row["vari_nombre"].ToString().Trim()));


                DGV1.Rows.Clear();
                DGV1.Update();
                foreach(DataRow row in daños.Select("lin_clave = '"+linea+"'"))
                    DGV1.Rows.Add(Convert.ToString(row["dno_nombre"].ToString().Trim()), "0.00", "0.00", Convert.ToString(row["dno_clave"].ToString().Trim()));

                btnVerificar_Click(null, null);

                /*thisConnection.Open();
                string producto = txtprod.SelectedItem.ToString().Trim();
                producto = producto.Replace("'", "''");
                cmnd1 = thisConnection.CreateCommand();
                cmnd1.CommandText = "select lin_clave, prod_clave from tb_cat_producto where prod_nombre = '" + producto + "'";
                reader1 = cmnd1.ExecuteReader();
                while (reader1.Read())
                {
                    linea = reader1.GetValue(0).ToString().Trim();
                    txtprod_clave.Text = reader1.GetValue(1).ToString().Trim();
                }
                reader1.Dispose();

                //variedad
                CBvariedad.Items.Clear();
                cmnd1 = thisConnection.CreateCommand();
                cmnd1.CommandText = "SELECT * FROM tb_cat_variedad WHERE lin_clave = '" + linea.Trim() + "' order by vari_nombre";
                reader1 = cmnd1.ExecuteReader();
                while (reader1.Read())
                {
                    CBvariedad.Items.Add(reader1.GetValue(2).ToString().Trim());
                }
                reader1.Dispose();

                //trae el catalogo de daños de acuerdo a la linea 
                DGV1.Rows.Clear();
                DGV1.Update();
                cmnd1 = thisConnection.CreateCommand();
                cmnd1.CommandText = "select dno_nombre, dno_clave from tb_cat_danos where dno_tipo = 'MP' and lin_clave = '" + linea + "' order by dno_clave";
                reader1 = cmnd1.ExecuteReader();
                while (reader1.Read())
                {
                    DGV1.Rows.Add(reader1.GetValue(0).ToString().Trim(), "0.00", "0.00", reader1.GetValue(1).ToString().Trim());
                }
                reader1.Dispose();
                thisConnection.Close();*/
            }
            catch (SqlException ex)
            {
                thisConnection.Close();
                Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex.ToString());
                MessageBox.Show(ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception ex1)
            {
                thisConnection.Close();
                Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex1.ToString());
                MessageBox.Show(ex1.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
        }

        private void CBvariedad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try 
            {
                foreach (DataRow row in variedades.Select("vari_nombre = '" + CBvariedad.SelectedItem.ToString().Trim() + "' and lin_clave = '" + linea + "'"))
                    txtvar_clave.Text = Convert.ToString(row["vari_clave"].ToString().Trim());
                
                /*thisConnection.Open();
                cmnd1 = thisConnection.CreateCommand();
                cmnd1.CommandText = "select vari_clave from tb_cat_variedad where vari_nombre = '" + CBvariedad.SelectedItem.ToString() + "' and lin_clave = '" + linea + "'";
                reader1 = cmnd1.ExecuteReader();
                while (reader1.Read())
                {
                    txtvar_clave.Text = reader1.GetValue(0).ToString().Trim();
                }
                reader1.Dispose();                
                thisConnection.Close();*/
            }
            catch (SqlException ex)
            {
                thisConnection.Close();
                Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex.ToString());
                MessageBox.Show(ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception ex1)
            {
                thisConnection.Close();
                Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex1.ToString());
                MessageBox.Show(ex1.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
        }

        private void txtvar_clave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                if (txtvar_clave.Text.Trim().Length > 0)
                {
                    try
                    {
                        foreach (DataRow row in variedades.Select("vari_clave = '" + txtvar_clave.Text + "' and lin_clave = '" + linea + "'"))
                            CBvariedad.SelectedItem = Convert.ToString(row["vari_nombre"].ToString().Trim());

                        if (CBvariedad.SelectedIndex == -1)
                        {
                            MessageBox.Show("No existe ninguna variedad con esa clave, favor de intentar con otra clave", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtvar_clave.SelectAll();
                            return;
                        }
                        /*thisConnection.Open();
                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "select vari_nombre from tb_cat_variedad where vari_clave = '" + txtvar_clave.Text + "' and lin_clave = '" + linea + "'";
                        reader1 = cmnd1.ExecuteReader();
                        if (reader1.HasRows)
                        {
                            while (reader1.Read())
                            {
                                CBvariedad.SelectedItem = reader1.GetValue(0).ToString().Trim();
                            }
                        }
                        else
                        {
                            thisConnection.Close();
                            MessageBox.Show("No existe ninguna variedad con esa clave, favor de intentar con otra clave", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtvar_clave.SelectAll();
                            return;
                        }
                        reader1.Dispose();
                        thisConnection.Close();*/
                    }
                    catch (SqlException ex)
                    {
                        thisConnection.Close();
                        Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex.ToString());
                        MessageBox.Show(ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    catch (Exception ex1)
                    {
                        thisConnection.Close();
                        Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex1.ToString());
                        MessageBox.Show(ex1.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }    
                }
            }
        }

        private void CBcodigo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtcodigo_clave.Text = CBcodigo.SelectedItem.ToString().Trim();
        }

        private void txtcodigo_clave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtcodigo_clave.Text.Length > 0)
                {
                    CBcodigo.SelectedItem = txtcodigo_clave.Text.Trim();
                }
            }
        }

        private void txtpreciogrado1_Click(object sender, EventArgs e)
        {
            txtpreciogrado1.SelectAll();
        }

        private void txtpreciogrado2_Click(object sender, EventArgs e)
        {
            txtpreciogrado2.SelectAll();
        }
      
        private void Etiqueta_PrintPage(object sender, PrintPageEventArgs e)
        {
            SolidBrush color = new SolidBrush(Color.Black);
            Font fuente = new Font("Courier", 8);

            //recibo
            Point recib = new Point(10, 10);
            e.Graphics.DrawString(txtrecibo.Text, fuente, color, recib);

            //fecha
            Point day = new Point(60, 10);
            e.Graphics.DrawString(lbfecha.Text, fuente, color, day);

            //cantidad
            Point canti = new Point(130, 10);
            e.Graphics.DrawString("Cantidad " + txtrmpnumenvase.Text, fuente, color, canti);

            //producto
            Point produc = new Point(10, 23);
            e.Graphics.DrawString("Producto\t" + txtprod.Text, fuente, color, produc);

            //proveedor
            Point prove = new Point(10, 36);
            e.Graphics.DrawString("Proveedor\t" + txtprov.Text, fuente, color, prove);

            //rancho
            Point rchtbl = new Point(10, 49);
            e.Graphics.DrawString("Rancho   \t" + txtrancho.Text + " -> " + txttabla.Text, fuente, color, rchtbl);

            //evaluador
            Point eva = new Point(10, 62);
            e.Graphics.DrawString("Evaluador\t" + txtevaluador.Text, fuente, color, eva);

            //variedad
            if (CBvariedad.SelectedIndex != -1)
            {
                Point vari = new Point(20, 88);
                e.Graphics.DrawString(CBvariedad.SelectedItem.ToString(), fuente, color, vari);
            }

            //observaciones
            Point obs = new Point(200, 88);
            e.Graphics.DrawString(txtobs.Text, fuente, color, obs);
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            btnConsulta.Enabled = false;
            btnAlta.Enabled = false;
            btnCancel.Enabled = true;            
            txtrecibo.ReadOnly = false;
            txtrecibo.Focus();
            //txtpata.ReadOnly = false;
            consul = "S";
        }

        private void txtrecibo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtrecibo.Text.Trim().Length > 0)
                {
                    
                    CBvariedad.SelectedIndex = -1;
                    CBvariedad.Items.Clear();
                    cbticket.Items.Clear();
                    ticket.Items.Clear();
                    consulta = true;
                    try
                    {
                        //if (txtrecibo.Text.Trim().Length < 6)
                        //    txtrecibo.Text = "0" + txtrecibo.Text;
                        DGV1.Rows.Clear();
                        thisConnection.Open();
                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "select rmp_fecha, rmp_ticket, rmp_flete, prov_clave, mp_cve_fecha, rch_clave, tbl_clave, lin_clave, prod_clave, vari_clave, rmp_peso_bruto, " +
                                            "rmp_tara, env_clave, rmp_num_envase, rmp_hoja, rmp_pata, rmp_muestra, rmp_observaciones, rmp_pesador, rmp_evaluador, rmp_clase1, rmp_clase2, " +
                                            "rmp_precio_grado1, rmp_precio_grado2, rmp_pretot_grado1, rmp_pretot_grado2, mp_viaje, mp_codigo, rmp_defectos, rmp_estatus, rmp_hora, "+
                                            "rmp_campo_insectos, rmp_campo_descripcion, rmp_campo_pza_menor5, rmp_pzas_muestra, rmp_tipo, rmp_sobre_insp, um_clave, "+
                                            "folio_no_conformidad, rmp_pzs_x_canastillas, contrato_proveedor, rmp_importada, rmp_tc, rmp_fechatc, rmp_paisorigen, rmp_numtar, rmp_pedimento from tb_mstr_recepcion_mp where rmp_recibo = '" + txtrecibo.Text + "'";
                        reader1=cmnd1.ExecuteReader();
                        if (reader1.HasRows)
                        {
                            while (reader1.Read())
                            {
                                lbfecha.Text = reader1.GetValue(0).ToString().Substring(0, 10);
                                cbticket.Items.Add(reader1.GetValue(1).ToString());
                                cbticket.SelectedIndex = 0;
                                ticket.Items.Add(reader1.GetValue(1).ToString());
                                ticket.SelectedIndex = 0;
                                txtflete.Text = reader1.GetValue(2).ToString().Trim();
                                lbcletiqueta.Text = reader1.GetValue(4).ToString().Trim();
                                txtprov_clave.Text = reader1.GetValue(3).ToString().Trim();
                                txtrch_clave.Text = reader1.GetValue(5).ToString().Trim();
                                txttbl_clave.Text = reader1.GetValue(6).ToString().Trim();
                                linea = reader1.GetValue(7).ToString().Trim();
                                txtprod_clave.Text = reader1.GetValue(8).ToString().Trim();
                                txtvar_clave.Text = reader1.GetValue(9).ToString().Trim();
                                txtpesobruto.Text = reader1.GetValue(10).ToString().Trim();
                                txttaracamion.Text = reader1.GetValue(11).ToString().Trim();
                                env_clave = reader1.GetValue(12).ToString().Trim();
                                txtrmpnumenvase.Text = reader1.GetValue(13).ToString().Trim().Replace(".00","");
                                txthoja.Text = reader1.GetValue(14).ToString().Trim();
                                txtpata.Text = reader1.GetValue(15).ToString().Trim();
                                txtmuestrakg.Text = reader1.GetValue(16).ToString().Trim();
                                txtobs.Text = reader1.GetValue(17).ToString().Trim();
                                txtpesador.Text = reader1.GetValue(18).ToString().Trim();
                                txtevaluador.Text = reader1.GetValue(19).ToString().Trim();
                                txtgrado1.Text = reader1.GetValue(20).ToString().Trim();
                                txtgrado2.Text = reader1.GetValue(21).ToString().Trim();
                                txtpreciogrado1.Text = reader1.GetValue(22).ToString().Trim();
                                txtpreciogrado2.Text = reader1.GetValue(23).ToString().Trim();
                                lbpretotgrado1.Text = reader1.GetValue(24).ToString().Trim();
                                lbpretotgrado2.Text = reader1.GetValue(25).ToString().Trim();
                                txtnumviaje.Text = reader1.GetValue(26).ToString().Trim();
                                txtcodigo_clave.Text = reader1.GetValue(27).ToString().Trim();
                                CBcodigo.Items.Add(reader1.GetValue(27).ToString().Trim());
                                CBcodigo.SelectedIndex = 0;
                                txtdefectos.Text = reader1.GetValue(28).ToString().Trim();
                                estatus = reader1.GetValue(29).ToString().Trim();
                                txthora.Text = reader1.GetValue(30).ToString().Trim();
                                txtnumins.Text = reader1.GetValue(31).ToString().Trim();
                                txtdescrip.Text = reader1.GetValue(32).ToString().Trim();
                                txtpzsmenor5.Text = reader1.GetValue(33).ToString().Trim();
                                txtpzsxmuestra.Text = reader1.GetValue(34).ToString().Trim();
                                ChkImport.Checked = false;
                                TxtTipoCam.Text = "";
                                LblFecTC.Text = "";
                                TxtPaisOrigen.Text = "";
                                if (reader1["rmp_importada"].ToString() == "1")
                                {
                                    ChkImport.Checked = true;
                                    TxtTipoCam.Text = reader1["rmp_tc"].ToString();
                                    LblFecTC.Text = Convert.ToDateTime(reader1["rmp_fechatc"]).ToShortDateString();
                                    TxtPaisOrigen.Text = reader1["rmp_paisorigen"].ToString().Trim();
                                    TxtPaisOrigen.ReadOnly = true;
                                }
                                if (reader1.GetValue(35).ToString().Trim().Contains("TR"))
                                    CBAjuste.Checked = true;
                                else
                                    CBAjuste.Checked = false;

                                if (reader1.GetValue(36).ToString().Trim().Contains("S"))
                                {
                                    cbsobinsp.Checked = true;
                                    sobre_insp = reader1.GetValue(36).ToString().Trim();
                                }
                                else
                                {
                                    cbsobinsp.Checked = false;
                                    sobre_insp = reader1.GetValue(36).ToString().Trim();
                                }

                                if (reader1.GetValue(37).ToString().Contains("PESOS"))
                                    CBMoneda.SelectedIndex = 0;
                                else
                                    CBMoneda.SelectedIndex = 1;

                                txtfolnocon.Text = reader1.GetValue(38).ToString().Trim();
                                txtpzsxcana.Text = reader1.GetValue(39).ToString().Trim();
                                contrato = reader1.GetValue(40).ToString().Trim();
                                TxtTar.Text = Convert.ToString(reader1["rmp_numtar"]);
                                txtnumped.Text = reader1["rmp_pedimento"].ToString();
                            }

                            reader1.Dispose();
                            cbcontrato.Items.Clear();
                            cbcontrato.Items.Add(contrato);
                            cbcontrato.SelectedIndex = 0;
                            reader1.Dispose();

                            //nombre del proveedor
                            foreach (DataRow row in proveedor.Select("prov_clave = '" + txtprov_clave.Text + "'"))
                            {
                                txtprov.Text = Convert.ToString(row["prov_nombre"].ToString().Trim());
                                email = Convert.ToString(row["prov_email"].ToString()).Trim();
                            }
                            /*cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "select prov_nombre from tb_cat_proveedor where prov_clave = '" + txtprov_clave.Text + "'";
                            reader1 = cmnd1.ExecuteReader();
                            while (reader1.Read())
                            {
                                txtprov.Text = reader1.GetValue(0).ToString().Trim();
                            }
                            reader1.Dispose();*/

                            //nombre del rancho
                            foreach (DataRow row in ranchos.Select("prov_clave = '" + txtprov_clave.Text + "' and rch_clave = '" + txtrch_clave.Text + "'"))
                                txtrancho.Text = Convert.ToString(row["rch_nombre"].ToString().Trim());

                            if (txtrancho.Text.Trim() == "")
                                txtrch_clave.Text = "";
                            /*cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "select rch_nombre from tb_cat_ranchos where rch_clave = '" + txtrch_clave.Text + "' and prov_clave = '" + txtprov_clave.Text + "'";
                            reader1 = cmnd1.ExecuteReader();
                            while (reader1.Read())
                            {
                                txtrancho.Text = reader1.GetValue(0).ToString().Trim();
                            }
                            reader1.Dispose();*/

                            //nombre de la tabla
                            foreach (DataRow row in tablas.Select("prov_clave = '" + txtprov_clave.Text + "' and rch_clave = '" + txtrch_clave.Text + "' and tbl_clave ='" + txttbl_clave.Text + "'"))
                                txttabla.Text = Convert.ToString(row["tbl_nombre"].ToString().Trim());

                            if (txttabla.Text.Trim() == "")
                                txttbl_clave.Text = "";

                            /*cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "select tbl_nombre from tb_cat_tablas where tbl_clave = '" + txttbl_clave.Text + "' and rch_clave = '" + txtrch_clave.Text + "' and prov_clave = '" + txtprov_clave.Text + "'";
                            reader1 = cmnd1.ExecuteReader();
                            while (reader1.Read())
                            {
                                txttabla.Text = reader1.GetValue(0).ToString().Trim();                                
                            }
                            reader1.Dispose();*/

                            //nombre del producto
                            foreach (DataRow row in productos.Select("prod_clave = '" + txtprod_clave.Text + "'"))
                            {
                                txtprod.SelectedItem = Convert.ToString(row["prod_nombre"].ToString().Trim());
                                prod_muestra = Convert.ToDecimal(row["prod_muestra"].ToString());
                            }

                            /*cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "select prod_nombre, prod_muestra from tb_cat_producto where prod_clave = '" + txtprod_clave.Text + "' and lin_clave = '" + linea + "' and prod_tipo = 'MP'";
                            reader1 = cmnd1.ExecuteReader();
                            while (reader1.Read())
                            {
                                txtprod.SelectedItem = reader1.GetValue(0).ToString().Trim();
                                prod_muestra = Convert.ToDecimal(reader1.GetValue(1).ToString().Trim());                                
                            }
                            reader1.Dispose();*/

                            //nombre de la variedad
                            foreach (DataRow row in variedades.Select("vari_clave = '" + txtvar_clave.Text + "' and lin_clave = '" + linea + "'"))
                            {
                                CBvariedad.Items.Add(Convert.ToString(row["vari_nombre"].ToString().Trim()));
                                CBvariedad.SelectedIndex = 0;
                            }
                            
                            /*cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "select vari_nombre from tb_cat_variedad where vari_clave = '" + txtvar_clave.Text + "' and lin_clave = '" + linea + "'";
                            reader1 = cmnd1.ExecuteReader();
                            while (reader1.Read())
                            {
                                CBvariedad.Items.Add(reader1.GetValue(0).ToString().Trim());
                                CBvariedad.SelectedIndex = 0;
                            }
                            reader1.Dispose();*/

                            //nombre y peso del envase
                            foreach (DataRow row in envases.Select("env_clave = '" + env_clave + "'"))
                            {
                                txtenv.Text = Convert.ToString(row["env_nombre"].ToString().Trim());
                                peso_recipiente = Convert.ToDecimal(row["env_peso"].ToString());
                            }

                            /*cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "select env_nombre, env_peso from tb_cat_envases where env_clave = '" + env_clave + "'";
                            reader1 = cmnd1.ExecuteReader();
                            while (reader1.Read())
                            {
                                txtenv.Text = reader1.GetValue(0).ToString().Trim();
                                peso_recipiente = Convert.ToDecimal(reader1.GetValue(1).ToString().Trim());
                            }
                            reader1.Dispose();**/

                            txtpesorecipiente.Text = (peso_recipiente * Convert.ToDecimal(txtrmpnumenvase.Text)).ToString("###,###,###.00");
                            txtpesoneto.Text = (Convert.ToDecimal(txtpesobruto.Text) - Convert.ToDecimal(txttaracamion.Text) - Convert.ToDecimal(txtpesorecipiente.Text)).ToString("###,###,###.00");

                            if (prod_muestra > 0)
                            {
                                if (Convert.ToDecimal(txthoja.Text) == 0 && Convert.ToDecimal(txtpata.Text) == 0)
                                {
                                    txtpesoutil.Text = (Convert.ToDecimal(txtpesoneto.Text) - (Convert.ToDecimal(txtcalpata.Text) + Convert.ToDecimal(txtcalhoja.Text))).ToString("###,###,###.00");
                                }
                                else
                                {
                                    calhoja = Convert.ToDecimal(txtpesoneto.Text) * (Convert.ToDecimal(txthoja.Text) / prod_muestra);
                                    calpata = Convert.ToDecimal(txtpesoneto.Text) * (Convert.ToDecimal(txtpata.Text) / prod_muestra);
                                    txtcalhoja.Text = calhoja.ToString("###,###,###.00");
                                    txtcalpata.Text = calpata.ToString("###,###,###.00");
                                    txtpesoutil.Text = (Convert.ToDecimal(txtpesoneto.Text) - (Convert.ToDecimal(txtcalpata.Text) + Convert.ToDecimal(txtcalhoja.Text))).ToString("###,###,###.00");
                                }
                            }
                            else
                            {
                                txtpesoutil.Text = (Convert.ToDecimal(txtpesoneto.Text) - (Convert.ToDecimal(txtcalpata.Text) + Convert.ToDecimal(txtcalhoja.Text))).ToString("###,###,###.00");
                            }

                            //datagrid daños
                            //defectos = 0;
                            cmnd1 = thisConnection.CreateCommand();
                            //cmnd1.CommandText = "SELECT A.rmp_recibo, A.lin_clave, A.dno_clave, B.dno_nombre, A.dnm_peso, A.dnm_cantidad, A.dnm_tipo " +
                            //                  "FROM tb_mstr_danos A, tb_cat_danos B WHERE A.rmp_recibo='" + txtrecibo.Text + "' AND A.dnm_tipo='MP' " +
                            //                  "AND B.lin_clave = '" + linea + "' AND B.dno_clave=a.dno_clave " +
                            //                  "GROUP BY A.dno_clave, A.rmp_recibo, A.lin_clave, B.dno_nombre, A.dnm_peso, A.dnm_cantidad, A.dnm_tipo";
                            cmnd1.CommandText = "SELECT A.rmp_recibo, A.lin_clave, A.dno_clave, B.dno_nombre, A.dnm_peso, A.dnm_cantidad FROM tb_mstr_danos A, tb_cat_danos B " +
                                             "WHERE A.rmp_recibo = " + txtrecibo.Text + " AND A.dnm_tipo='MP' AND A.lin_clave='" + linea + "' AND B.dno_tipo=A.dnm_tipo AND B.lin_clave = A.lin_clave " +
                                             "AND B.dno_clave=A.dno_clave ORDER BY A.dno_clave";                            
                            reader1 = cmnd1.ExecuteReader();
                            while (reader1.Read())
                            {
                                DGV1.Rows.Add(reader1.GetValue(3).ToString().Trim(), reader1.GetValue(4).ToString().Trim(), (Convert.ToDecimal(reader1.GetValue(4).ToString()) * 100) / Convert.ToDecimal(txtmuestrakg.Text));
                                //defectos = defectos + Convert.ToDecimal(reader1.GetValue(4).ToString());
                            }
                            reader1.Dispose();
                            //txtdefectos.Text = defectos.ToString("###,###,###.00");
                            DGV1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            DGV1.Update();


                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "select A.ins_nombre, B.cantidad, a.ins_clave from tb_cat_insectos a, tb_mstr_insectos B where b.ins_clave = a.ins_clave and " +
                                              "b.rmp_recibo = '" + txtrecibo.Text + "' order by A.ins_nombre";
                            reader1 = cmnd1.ExecuteReader();
                            while (reader1.Read())
                            {
                                DGV2.Rows.Add(reader1.GetValue(0).ToString().Trim(), reader1.GetValue(1).ToString().Trim(), reader1.GetValue(2).ToString().Trim());
                            }
                            reader1.Dispose();



                            //número de tarima
                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "select A.prod_clave, A.cantidad, A.envase, A.tara, A.peso_bruto, A.peso_neto, A.id_tabla, A.tabla, A.variedad, B.prod_nombre, A.lin_clave, A.cantidad, A.num_tarimas " +
                                                "from tb_det_recepcion_bascula A, tb_cat_producto B where A.id_ticket = " + ticket.SelectedItem.ToString() + " " +
                                                "and B.prod_clave = A.prod_clave "; //AND A.tara = " + Convert.ToDecimal(txttaracamion.Text) + "";
                            reader1 = cmnd1.ExecuteReader();
                            while (reader1.Read())                            
                                num_tarima = reader1.GetValue(12).ToString().Trim();
                            
                            reader1.Dispose();

                            txtpesorecipiente.Text = (peso_recipiente * Convert.ToDecimal(txtrmpnumenvase.Text)).ToString("###,###,###.00");
                            txtpesoneto.Text = (Convert.ToDecimal(txtpesobruto.Text) - Convert.ToDecimal(txttaracamion.Text) - Convert.ToDecimal(txtpesorecipiente.Text)).ToString("###,###,###.00");
                            txtpesorecipiente.Text = (peso_recipiente * Convert.ToDecimal(txtrmpnumenvase.Text)).ToString("###,###,###.00");
                            txtpesoneto.Text = (Convert.ToDecimal(txtpesobruto.Text) - Convert.ToDecimal(txttaracamion.Text) - Convert.ToDecimal(txtpesorecipiente.Text)).ToString("###,###,###.00");

                            if (prod_muestra > 0)
                            {
                                if (Convert.ToDecimal(txthoja.Text) == 0 && Convert.ToDecimal(txtpata.Text) == 0)
                                {
                                    txtpesoutil.Text = (Convert.ToDecimal(txtpesoneto.Text) - (Convert.ToDecimal(txtcalpata.Text) + Convert.ToDecimal(txtcalhoja.Text))).ToString("###,###,###.00");
                                }
                                else
                                {
                                    calhoja = Convert.ToDecimal(txtpesoneto.Text) * (Convert.ToDecimal(txthoja.Text) / prod_muestra);
                                    calpata = Convert.ToDecimal(txtpesoneto.Text) * (Convert.ToDecimal(txtpata.Text) / prod_muestra);
                                    txtcalhoja.Text = calhoja.ToString("###,###,###.00");
                                    txtcalpata.Text = calpata.ToString("###,###,###.00");
                                    txtpesoutil.Text = (Convert.ToDecimal(txtpesoneto.Text) - (Convert.ToDecimal(txtcalpata.Text) + Convert.ToDecimal(txtcalhoja.Text))).ToString("###,###,###.00");
                                }
                            }
                            else
                            {
                                txtpesoutil.Text = (Convert.ToDecimal(txtpesoneto.Text) - (Convert.ToDecimal(txtcalpata.Text) + Convert.ToDecimal(txtcalhoja.Text))).ToString("###,###,###.00");
                            }

                            txtporgrado1.Text = ((Convert.ToDecimal(txtgrado1.Text) * 100) / Convert.ToDecimal(txtmuestrakg.Text)).ToString("###,###,###.00");
                            txttotalgrado1.Text = ((Convert.ToDecimal(txtporgrado1.Text) / 100) * Convert.ToDecimal(txtpesoutil.Text)).ToString("###,###,###.00");

                            txtporgrado2.Text = ((Convert.ToDecimal(txtgrado2.Text) * 100) / Convert.ToDecimal(txtmuestrakg.Text)).ToString("###,###,###.00");
                            txttotalgrado2.Text = ((Convert.ToDecimal(txtporgrado2.Text) / 100) * Convert.ToDecimal(txtpesoutil.Text)).ToString("###,###,###.00");

                            txtpordef.Text = ((Convert.ToDecimal(txtdefectos.Text) * 100) / Convert.ToDecimal(txtmuestrakg.Text)).ToString("###,###,###.00");
                            txttotaldef.Text = ((Convert.ToDecimal(txtpordef.Text) / 100) * Convert.ToDecimal(txtpesoutil.Text)).ToString("###,###,###.00");

                            txttotal.Text = (Convert.ToDecimal(txtgrado1.Text) + Convert.ToDecimal(txtgrado2.Text) + Convert.ToDecimal(txtdefectos.Text)).ToString("###,###,###.00");
                            txttotalpor.Text = (Convert.ToDecimal(txtporgrado1.Text) + Convert.ToDecimal(txtporgrado2.Text) + Convert.ToDecimal(txtpordef.Text)).ToString("###,###,###.00");
                            txttotalkg.Text = (Convert.ToDecimal(txttotalgrado1.Text) + Convert.ToDecimal(txttotalgrado2.Text) + Convert.ToDecimal(txttotaldef.Text)).ToString("###,###,###.00");

                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "select * from tb_hist_recepcion where hrp_recibo = '" + txtrecibo.Text + "' and hrp_tipo_recepcion = 'MP'";
                            reader1 = cmnd1.ExecuteReader();
                            if (reader1.HasRows)
                            {
                                lbestatus.Text = "COMPLETA";

                                reader1.Read();
                                lblOrdenG1.Text = reader1["hrp_numoc"].ToString();
                                lblOrdenG2.Text = reader1["hrp_numoc_g2"].ToString();
                            }
                            else
                            {
                                lbestatus.Text = "";
                            }
                                

                            
                            reader1.Dispose();
                            thisConnection.Close();

                            //decimal num_pzs = 0;
                            //double pesoxpza = Convert.ToDouble(txtmuestrakg.Text) / Convert.ToDouble(txtpzsxmuestra.Text);
                            //double pesoxpza1 = Convert.ToDouble(txtpesoneto.Text) / pesoxpza;
                            //num_pzs = Math.Round(Convert.ToDecimal(pesoxpza1 / Convert.ToDouble(txtrmpnumenvase.Text)), MidpointRounding.AwayFromZero);
                            //txtpzsxcana.Text = Convert.ToString(Math.Truncate(num_pzs));
                            if (estatus.Equals("F"))
                            {
                                MessageBox.Show("El recibo: " + txtrecibo.Text + " está cancelado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btncancelrecibo.Enabled = false;
                                //btnimpre.Visible = false;
                                btnimpre.Visible = true;
                                btnemail.Visible = false;
                            }
                            else
                            {
                                btncancelrecibo.Enabled = true;
                                btnimpre.Visible = true;
                                btnemail.Visible = true;
                                btneva.Enabled = true;
                                BtnGenPDF.Visible = true;
                            }
                        }
                        else
                        {
                            thisConnection.Close();
                            MessageBox.Show("El recibo no existe, favor de verificar que el recibo este bien", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        consulta = false;
                        btnaddfile.Visible = true;
                        btnpdf.Visible = true;                        
                    }
                    catch (SqlException ex)
                    {
                        thisConnection.Close();
                        Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex.ToString());
                        MessageBox.Show(ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    catch (Exception ex1)
                    {
                        thisConnection.Close();
                        Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex1.ToString());
                        MessageBox.Show(ex1.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }    
                }//if mayor a 0
            }//if tecla enter
        }

        private void btnimpre_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea imprimir la recepción?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //PrintPreviewDialog pr = new PrintPreviewDialog();
                //pr.Document = printDocument1;
                //DialogResult re = pr.ShowDialog();
                //if (re == DialogResult.OK)
                    //printDocument1.Print();

                //PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                //if
                //pd.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
                //pd.Print();
                PrintDialog printDialog1 = new PrintDialog();
                printDialog1.Document = printDocument1;
                DialogResult result = printDialog1.ShowDialog();
                if (result == DialogResult.OK)
                    printDocument1.Print();                

                //PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                //pd.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
                //pd.Print();
                //PrintPreviewDialog VistaPrevia = new PrintPreviewDialog();
                //VistaPrevia.Document = printDocument1;
                //VistaPrevia.Show();                     
            }
            if (estatus.Trim() != "F")
            {
                if (MessageBox.Show("¿Desea imprimir las etiquetas?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //abre la ventana para la impresión de etiquetas
                    Imprimir_etiqueta impeti = new Imprimir_etiqueta();
                    Imprimir_etiqueta.recibo = txtrecibo.Text.Trim();
                    Imprimir_etiqueta.fecha = lbfecha.Text;
                    Imprimir_etiqueta.numenvase = txtrmpnumenvase.Text;
                    Imprimir_etiqueta.producto = txtprod.Text;
                    Imprimir_etiqueta.proveedor = txtprov.Text;
                    Imprimir_etiqueta.rancho = txtrancho.Text;
                    Imprimir_etiqueta.tabla = txttabla.Text;
                    Imprimir_etiqueta.evaluador = txtevaluador.Text;
                    if (CBvariedad.SelectedIndex != -1)
                        Imprimir_etiqueta.variedad = CBvariedad.SelectedItem.ToString();

                    Imprimir_etiqueta.observa = txtobs.Text;
                    Imprimir_etiqueta.num_viaje = txtnumviaje.Text;
                    Imprimir_etiqueta.num_tar = num_tarima;
                    impeti.ShowDialog();
                }
            }
            limpiarTextBoxes(this);
            btnAlta.Enabled = true;
            btnConsulta.Enabled = true;
            btncancelrecibo.Enabled = false;
            btnCancel.Enabled = false;
            btnimpre.Visible = false;
            btnAlta.Focus();
            cbticket.SelectedIndex = -1;
            txtprod.SelectedIndex = -1;
            CBvariedad.SelectedIndex = -1;
        }

        private void btncancelrecibo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea cancelar esta recepción?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                #region SQL
                try
                {
                    thisConnection.Open();

                    //verifica que no se haya tomado producto de ese recibo de materia prima
                    //FOX
                    //if (txtrecibo.Text.Trim().Length < 6)
                    //    txtrecibo.Text = "0" + txtrecibo.Text;
                    //MyConnection.Open();
                    //cmd1 = MyConnection.CreateCommand();
                    //cmd1.CommandText = "select hrp_num_unidades, hrp_reman_unidades from tb_hist_recepcion where hrp_tipo_recepcion ='MP' and hrp_recibo = '" + txtrecibo.Text + "'";
                    //read1 = cmd1.ExecuteReader();
                    //while (read1.Read())
                    //{
                    //    hrp_num_unidades = Convert.ToDecimal(read1.GetValue(0).ToString());
                    //    hrp_reman_unidades = Convert.ToDecimal(read1.GetValue(1).ToString());
                    //}
                    //read1.Dispose();
                    //MyConnection.Close();

                    string cls1 = "0";
                    string cls2 = "0";
                    string ocg1 = "";
                    string ocg2 = "";

                    //SQL
                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "select hrp_num_unidades, hrp_reman_unidades, hrp_clase1, hrp_clase2, hrp_numoc, hrp_numoc_g2 from tb_hist_recepcion where hrp_tipo_recepcion ='MP' and hrp_recibo = '" + txtrecibo.Text + "'";
                    reader1=cmnd1.ExecuteReader();
                    while(reader1.Read())
                    {
                        hrp_num_unidades = Convert.ToDecimal(reader1.GetValue(0).ToString());
                        hrp_reman_unidades =Convert.ToDecimal(reader1.GetValue(1).ToString());

                        cls1 = reader1["hrp_clase1"].ToString().Trim();
                        cls2 = reader1["hrp_clase2"].ToString().Trim();
                        ocg1 = reader1["hrp_numoc"].ToString().Trim();
                        ocg2 = reader1["hrp_numoc_g2"].ToString().Trim();
                    }
                    reader1.Dispose();

                    if (hrp_num_unidades != hrp_reman_unidades)
                    {
                        MessageBox.Show("El recibo " + txtrecibo.Text + " no se puede cancelar porque producción ya tomo producto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        thisConnection.Close();
                        return;
                    }
                     


                    //cambia el estatus a F en tb_mstr_recepcion_mp
                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "update tb_mstr_recepcion_mp set rmp_estatus = 'F' where rmp_recibo = '" + txtrecibo.Text + "'";
                    reader1 = cmnd1.ExecuteReader();
                    reader1.Dispose();

                    //cambia el estatus a C en tb_hist_recepcion
                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "update tb_hist_recepcion set hrp_estatus = 'C' where hrp_recibo = '" + txtrecibo.Text + "' and hrp_tipo_recepcion ='MP'";
                    reader1 = cmnd1.ExecuteReader();
                    reader1.Dispose();

                    //afecta inventarios en la tb_mstr_inventario_mp
                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "select invmp_salidas_kg, invmp_salidas_un from tb_mstr_inventario_mp where invmp_fecha = '" + System.DateTime.Now.ToShortDateString() + "' and lin_clave = '" + linea + "' and prod_clave = '" + txtprod_clave.Text + "'";
                    reader1 = cmnd1.ExecuteReader();
                    while (reader1.Read())
                    {
                        invmp_salidas_kg = reader1.GetSqlDecimal(0).Value;
                        invmp_salidas_un = reader1.GetSqlDecimal(1).Value;

                        invmp_salidas_kg = invmp_salidas_kg + Convert.ToDecimal(txttotalgrado1.Text);
                        invmp_salidas_un = invmp_salidas_un + Convert.ToDecimal(txtrmpnumenvase.Text);

                        cmnd11 = thisConnection.CreateCommand();
                        cmnd11.CommandText = "update tb_mstr_inventario_mp set invmp_salidas_kg = " + invmp_salidas_kg + ", invmp_salidas_un = " + invmp_salidas_un + " where lin_clave = '" + linea + "' and prod_clave = '" + txtprod_clave.Text + "'";
                        reader11 = cmnd11.ExecuteReader();
                        reader11.Dispose();
                    }
                    if (reader1.HasRows == false)
                    {
                        cmnd11 = thisConnection.CreateCommand();
                        cmnd11.CommandText = "select top 1 invmp_inicial_kg, invmp_inicial_un, ISNULL (invmp_entradas_kg,0) AS invmp_entradas_kg, ISNULL(invmp_entradas_un,0) as invmp_entradas_un, invmp_salidas_kg, invmp_salidas_un from tb_mstr_inventario_mp where lin_clave ='" + linea + "' and prod_clave ='" + txtprod_clave.Text + "' order BY invmp_fecha desc";                        
                        reader11 = cmnd11.ExecuteReader();
                        while (reader11.Read())
                        {
                            invmp_inicial_kg = reader11.GetSqlDecimal(0).Value;
                            invmp_inicial_un = reader11.GetSqlDecimal(1).Value;
                            invmp_entradas_kg = reader11.GetSqlDecimal(2).Value;
                            invmp_entradas_un = reader11.GetSqlDecimal(3).Value;
                            invmp_salidas_kg = reader11.GetSqlDecimal(4).Value;
                            invmp_salidas_un = reader11.GetSqlDecimal(5).Value;

                            var_dec_inv_inicial_kg = invmp_inicial_kg + invmp_entradas_kg - invmp_salidas_kg;
                            var_dec_inv_inicial_un = invmp_inicial_un + invmp_entradas_un - invmp_salidas_un;

                            //inserto un nuevo registro
                            cmnd21 = thisConnection.CreateCommand();
                            cmnd21.CommandText = "insert into tb_mstr_inventario_mp (invmp_fecha, lin_clave, prod_clave, invmp_inicial_un, invmp_inicial_kg, invmp_entradas_un, invmp_entradas_kg, invmp_salidas_un, invmp_salidas_kg) " +
                                               "values ('" + System.DateTime.Now.ToShortDateString() + "', '" + linea + "', '" + txtprod_clave.Text + "', " + var_dec_inv_inicial_un + ", " + var_dec_inv_inicial_kg + ", " + (Convert.ToDecimal(txtrmpnumenvase.Text) + invmp_salidas_un) + ", " + (Convert.ToDecimal(txttotalgrado1.Text) + invmp_salidas_kg) + ", 0, 0)";
                            reader21 = cmnd21.ExecuteReader();
                            reader21.Dispose();
                        }
                        if (reader11.HasRows == false)
                        {
                            cmnd21 = thisConnection.CreateCommand();
                            cmnd21.CommandText = "insert into tb_mstr_inventario_mp (invmp_fecha, lin_clave, prod_clave, invmp_inicial_kg, invmp_inicial_un, invmp_entradas_kg, invmp_entradas_un, invmp_salidas_kg, invmp_salidas_un) " +
                                                "values ('" + System.DateTime.Now.ToShortDateString() + "', '" + linea.Trim() + "', '" + txtprod_clave.Text + "', 0, 0, " + (Convert.ToDecimal(txttotalgrado1.Text) + invmp_salidas_kg) + ", " + (Convert.ToDecimal(txtrmpnumenvase.Text) + invmp_salidas_un) + ", 0, 0)";
                            reader21 = cmnd21.ExecuteReader();
                            reader21.Dispose();
                        }
                        reader11.Dispose();
                    }
                    reader1.Dispose();


                    //afecta envases
                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "update tb_entradas_envases set ent_status ='C' where rmp_folio = '" + txtrecibo.Text + "'";
                    reader1 = cmnd1.ExecuteReader();
                    reader1.Dispose();

                    existe = "N";

                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "select * from tb_mstr_envases where prov_clave = '" + txtprov_clave.Text + "' and rch_clave = '" + txtrch_clave.Text + "' and tbl_clave = '" + txttbl_clave.Text + "' and env_clave ='" + env_clave + "'";
                    reader1 = cmnd1.ExecuteReader();
                    if (reader1.HasRows)
                        existe = "S";

                    reader1.Dispose();

                    if (existe == "S")
                    {
                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "update tb_mstr_envases set cant_entradas = cant_entradas - " + Convert.ToDecimal(txtrmpnumenvase.Text) + " where prov_clave = '" + txtprov_clave.Text + "' and rch_clave = '" + txtrch_clave.Text + "' and tbl_clave = '" + txttbl_clave.Text + "' and env_clave = '" + env_clave + "'";
                        reader1 = cmnd1.ExecuteReader();
                        reader1.Dispose();
                    }

                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "update tb_mstr_inv_envases set env_inv_cant = env_inv_cant - " + Convert.ToDecimal(txtrmpnumenvase.Text) + " where env_clave = '" + env_clave + "'";
                    reader1 = cmnd1.ExecuteReader();
                    reader1.Dispose();


                    if (Convert.ToDecimal(cls1) > 0 || Convert.ToDecimal(cls2) > 0)
                    {
                        if (ocg1 != "")
                        { 
                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "UPDATE tb_det_ordenescompra SET surtido_oc = surtido_oc - '" + cls1 + "' WHERE numero_oc = '" + ocg1 + "' AND prod_clave = '" + txtprod_clave.Text + "'";
                            cmnd1.ExecuteNonQuery();
                            cmnd1.Dispose();

                            //
                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "UPDATE tb_det_anticipada_mp SET hrp_estatus = 'C' WHERE hrp_recibo = '" + txtrecibo.Text + "' and numero_oc = '" + ocg1 + "'";
                            cmnd1.ExecuteNonQuery();
                            cmnd1.Dispose();
                        }
                        if (ocg2 != "")
                        {
                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "UPDATE tb_det_ordenescompra SET surtido_oc = surtido_oc - '" + cls2 + "' WHERE numero_oc = '" + ocg2 + "' AND prod_clave = '" + txtprod_clave.Text + "'";
                            cmnd1.ExecuteNonQuery();
                            cmnd1.Dispose();

                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "UPDATE tb_det_anticipada_mp SET hrp_estatus = 'C' WHERE hrp_recibo = '" + txtrecibo.Text + "' and numero_oc = '" + ocg2 + "'";
                            cmnd1.ExecuteNonQuery();
                            cmnd1.Dispose();
                        }
                    }
                    thisConnection.Close();
                }
                catch (SqlException ex)
                {
                    thisConnection.Close();
                    Utilerias.Class1.SendMail("sistemas@mrlucky.com.mx", "sistemas", "Sistem@s2026$", ex.ToString());
                    Utilerias.Class1.registro_errores(DateTime.Now, Utilerias.Class1.Usu_login, Environment.MachineName, "2.1", ex.ToString().Trim(), "MPSQL");
                    MessageBox.Show(ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                catch (Exception ex1)
                {
                    thisConnection.Close();
                    Utilerias.Class1.SendMail("sistemas@mrlucky.com.mx", "sistemas", "Sistem@s2026$", ex1.ToString());
                    MessageBox.Show(ex1.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }                 
                #endregion

                #region FOX
                /*
                try
                {                    
                    MyConnection.Open();
                    OleDbCommand dbCmdNull1 = MyConnection.CreateCommand();
                    dbCmdNull1.CommandText = "SET NULL OFF";
                    dbCmdNull1.ExecuteNonQuery();                    

                    if (txtrecibo.Text.Length < 6)
                        txtrecibo.Text = "0" + txtrecibo.Text;

                    //cambia el estatus a f en tb_mstr_recepcion_mp
                    cmd1 = MyConnection.CreateCommand();
                    cmd1.CommandText = "update tb_mstr_recepcion_mp set rmp_estatus = 'F' where rmp_recibo = '" + txtrecibo.Text + "'";
                    cmd1.Connection = MyConnection;
                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();

                    //cambia el estatus a C en tb_hist_recepcion
                    cmd1 = MyConnection.CreateCommand();
                    cmd1.CommandText = "update tb_hist_recepcion set hrp_estatus = 'C' where hrp_recibo = '" + txtrecibo.Text + "' and hrp_tipo_recepcion = 'MP'";
                    cmd1.Connection = MyConnection;
                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();

                    //afecta inventarios en la tb_mstr_inventario_mp
                    cmd1 = MyConnection.CreateCommand();
                    cmd1.CommandText = "select invmp_entradas_kg, invmp_entradas_un from tb_mstr_inventario_mp where invmp_fecha = ? and lin_clave = ? and prod_clave = ?";
                    cmd1.Parameters.Add("@Nombre1", OleDbType.Date).Value = System.DateTime.Now.ToShortDateString();
                    cmd1.Parameters.Add("@Nombre2", OleDbType.Char).Value = linea;
                    cmd1.Parameters.Add("@Nombre3", OleDbType.Char).Value = txtprod_clave.Text;
                    cmd1.Connection = MyConnection;
                    read1 = cmd1.ExecuteReader();
                    //cmd1.ExecuteNonQuery();
                    if (read1.HasRows)
                    {
                        while (read1.Read())
                        {
                            invmp_entradas_kg = Convert.ToDecimal(read1.GetDecimal(0).ToString());
                            invmp_entradas_un = Convert.ToDecimal(read1.GetDecimal(1).ToString());
                        }


                        invmp_salidas_kg = invmp_salidas_kg + Convert.ToDecimal(txttotalgrado1.Text);
                        invmp_salidas_un = invmp_salidas_un + Convert.ToDecimal(txtrmpnumenvase.Text);

                        cmd1.Dispose();
                        read1.Dispose();
                        dbCmdNull1.Dispose();

                        dbCmdNull1 = MyConnection.CreateCommand();
                        dbCmdNull1.CommandText = "SET NULL OFF";
                        dbCmdNull1.ExecuteNonQuery();
                        dbCmdNull1.Dispose();

                        dbCmdNull1 = MyConnection.CreateCommand();
                        dbCmdNull1.CommandText = "update tb_mstr_inventario_mp set invmp_salidas_kg = " + invmp_salidas_kg + ", invmp_entradas_un = " + invmp_salidas_un + " where lin_clave = '" + linea + "' and prod_clave = '" + txtprod_clave.Text + "'";
                        //dbCmdNull1.Parameters.Add("@Nombre1", OleDbType.Numeric).Value = invmp_entradas_kg;
                        //dbCmdNull1.Parameters.Add("@Nombre2", OleDbType.Numeric).Value = invmp_entradas_un;
                        dbCmdNull1.Connection = MyConnection;
                        read1 = dbCmdNull1.ExecuteReader();
                        cmd1.Dispose();
                        read1.Dispose();
                        dbCmdNull1.Dispose();
                    }
                    else
                    {
                        read1.Dispose();
                        cmd1.Dispose();
                        cmd1 = MyConnection.CreateCommand();
                        cmd1.CommandText = "select top 1 invmp_inicial_kg, invmp_inicial_un, invmp_entradas_kg, invmp_entradas_un, invmp_salidas_kg, invmp_salidas_un from tb_mstr_inventario_mp where lin_clave = ? and prod_clave = ? order BY invmp_fecha desc";
                        cmd1.Parameters.Add("@Nombre1", OleDbType.Char).Value = linea;
                        cmd1.Parameters.Add("@nombre2", OleDbType.Char).Value = txtprod_clave.Text;
                        cmd1.Connection = MyConnection;
                        read1 = cmd1.ExecuteReader();
                        if (read1.HasRows)
                        {
                            while (read1.Read())
                            {
                                //invmp_entradas_kg = Convert.ToDecimal(read1.GetDecimal(1).ToString());
                                //invmp_entradas_un = Convert.ToDecimal(read1.GetDecimal(2).ToString());
                                //invmp_entradas_kg = Convert.ToDecimal(read1.GetDecimal(3).ToString());
                                //invmp_entradas_un = Convert.ToDecimal(read1.GetDecimal(4).ToString());
                                //invmp_salidas_kg = Convert.ToDecimal(read1.GetDecimal(5).ToString());
                                //invmp_salidas_un = Convert.ToDecimal(read1.GetDecimal(5).ToString());

                                invmp_entradas_kg = Convert.ToDecimal(read1.GetDecimal(0).ToString());
                                invmp_entradas_un = Convert.ToDecimal(read1.GetDecimal(1).ToString());
                                invmp_entradas_kg = Convert.ToDecimal(read1.GetDecimal(2).ToString());
                                invmp_entradas_un = Convert.ToDecimal(read1.GetDecimal(3).ToString());
                                invmp_salidas_kg = Convert.ToDecimal(read1.GetDecimal(4).ToString());
                                invmp_salidas_un = Convert.ToDecimal(read1.GetDecimal(5).ToString());

                            }

                            var_dec_inv_inicial_kg = invmp_inicial_kg + invmp_entradas_kg - invmp_salidas_kg;
                            var_dec_inv_inicial_un = invmp_inicial_un + invmp_entradas_un - invmp_salidas_un;

                            read1.Dispose();
                            cmd1.Dispose();
                            cmd1 = MyConnection.CreateCommand();
                            cmd1.CommandText = "insert into tb_mstr_inventario_mp ([invmp_fecha], [lin_clave], [prod_clave], [invmp_inicial_un], [invmp_inicial_kg], [invmp_salidas_un], [invmp_salidas_kg]) values (?, ?, ?, ?, ?, ?, ?)";
                            cmd1.Parameters.Add("@Nombre1", OleDbType.Date).Value = System.DateTime.Now.ToShortDateString();
                            cmd1.Parameters.Add("@Nombre2", OleDbType.Char).Value = linea;
                            cmd1.Parameters.Add("@Nombre3", OleDbType.Char).Value = txtprod_clave.Text;
                            cmd1.Parameters.Add("@Nombre4", OleDbType.Numeric).Value = var_dec_inv_inicial_un;
                            cmd1.Parameters.Add("@Nombre5", OleDbType.Numeric).Value = var_dec_inv_inicial_kg;
                            cmd1.Parameters.Add("@Nombre6", OleDbType.Numeric).Value = float.Parse(txtrmpnumenvase.Text) + float.Parse(invmp_salidas_un.ToString());
                            cmd1.Parameters.Add("@Nombre7", OleDbType.Numeric).Value = float.Parse(txttotalgrado1.Text) + float.Parse(invmp_salidas_kg.ToString());
                            cmd1.Connection = MyConnection;
                            cmd1.ExecuteNonQuery();
                            cmd1.Dispose();
                            read1.Dispose();
                        }
                        else
                        {
                            cmd1.Dispose();
                            cmd1 = MyConnection.CreateCommand();
                            cmd1.CommandText = "insert into tb_mstr_inventario_mp ([invmp_fecha], [lin_clave], [prod_clave], [invmp_inicial_un], [invmp_inicial_kg], [invmp_salidas_un], [invmp_salidas_kg]) values (?, ?, ?, ?, ?, ?, ?)";
                            cmd1.Parameters.Add("@Nombre1", OleDbType.Date).Value = System.DateTime.Now.ToShortDateString();
                            cmd1.Parameters.Add("@Nombre2", OleDbType.Char).Value = linea;
                            cmd1.Parameters.Add("@Nombre3", OleDbType.Char).Value = txtprod_clave.Text;
                            cmd1.Parameters.Add("@Nombre4", OleDbType.Numeric).Value = 0;
                            cmd1.Parameters.Add("@Nombre5", OleDbType.Numeric).Value = 0;
                            cmd1.Parameters.Add("@Nombre6", OleDbType.Numeric).Value = float.Parse(txtrmpnumenvase.Text) + float.Parse(invmp_salidas_un.ToString());
                            cmd1.Parameters.Add("@Nombre7", OleDbType.Numeric).Value = float.Parse(txttotalgrado1.Text) + float.Parse(invmp_salidas_kg.ToString());
                            cmd1.Connection = MyConnection;
                            cmd1.ExecuteNonQuery();
                            cmd1.Dispose();
                        }
                    }
                    read1.Dispose();
                    cmd1.Dispose();
                    MyConnection.Close();
                }
                catch (SqlException ex)
                {
                    MyConnection.Close();
                    Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex.ToString());
                    Utilerias.Class1.registro_errores(DateTime.Now, Utilerias.Class1.Usu_login, Environment.MachineName, "2.1", ex.ToString().Trim(), "MPFOX");
                    MessageBox.Show(ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                catch (Exception ex1)
                {
                    MyConnection.Close();
                    Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex1.ToString());
                    MessageBox.Show(ex1.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                } */   
                #endregion
                
                Utilerias.Class1.registrar_movimiento(DateTime.Now, Environment.MachineName, Utilerias.Class1.Usu_login, "B", "2.1", txtrecibo.Text, "CANCELACION RECIBO DE MP " + txtrecibo.Text, "SIPGAB");                
                MessageBox.Show("el recibo " + txtrecibo.Text + " ha sido cancelado con éxito");
                limpiarTextBoxes(this);
            }//pregunta si desea cancelarlo
            else
                return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            limpiarTextBoxes(this);
            txtprod.SelectedIndex = -1;
            CBvariedad.SelectedIndex = -1;
            CBvariedad.Items.Clear();
            ticket.Items.Clear();
            cbticket.SelectedIndex = -1;
            cbticket.Items.Clear();
            CBvariedad.Enabled = false;
            CBcodigo.Enabled = false;
            txtprod.Enabled = false;
            cbticket.Enabled = false;
            btnAlta.Enabled = true;
            btnConsulta.Enabled = true;
            btncancelrecibo.Enabled = false;
            btnCancel.Enabled = false;
            btnGuardar.Enabled = false;
            btnimpre.Visible = false;
            btnemail.Visible = false;
            CBAjuste.Enabled = false;
            cbsobinsp.Checked = false;
            cbsobinsp.Enabled = false;
            btnAlta.Focus();
            CBMoneda.Enabled = false;
            CBMoneda.SelectedIndex = 0;
            cbevaluacion.SelectedIndex = 0;
            btneva.Enabled = false;
            btnaddfile.Enabled = false;
            btnpdf.Enabled = false;
            BtnGenPDF.Visible = false;
            cbevaluacion.Enabled = false;

            txtFechaRecoleccion.Text = "";
            txtFechaRecepcion.Text = "";
            lblOrdenG1.Text = "0";
            lblOrdenG2.Text = "0";
            lblEstado.Text = "0";

            lblCostoOCG1.Text = "0";
            lblCostoOCG2.Text = "0";
        }

        private void txtprod_clave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (consul != "S")
            {
                if (txtprod_clave.Text.Trim().Length > 0)
                {
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        try
                        {
                            foreach (DataRow row in productos.Select("prod_clave = '" + txtprod_clave.Text + "' and prod_tipo ='MP'"))
                            {
                                linea = Convert.ToString(row["lin_clave"].ToString().Trim());
                                txtprod.Text = Convert.ToString(row["prod_nombre"].ToString().Trim());
                            }
                            /*thisConnection.Open();
                            cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "select lin_clave, prod_nombre from tb_cat_producto where prod_clave = '" + txtprod_clave.Text + "' and prod_tipo ='MP'";
                            reader1 = cmnd1.ExecuteReader();
                            while (reader1.Read())
                            {
                                linea = reader1.GetValue(0).ToString().Trim();
                                txtprod.SelectedItem = reader1.GetValue(1).ToString().Trim();
                            }
                            reader1.Dispose();*/

                            //variedad
                            CBvariedad.Items.Clear();
                            foreach (DataRow row in variedades.Select("lin_clave = '" + linea + "'"))
                                CBvariedad.Items.Add(Convert.ToString(row["vari_nombre"].ToString().Trim()));

                            /*cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "SELECT * FROM tb_cat_variedad WHERE lin_clave = '" + linea.Trim() + "' order by vari_nombre";
                            reader1 = cmnd1.ExecuteReader();
                            while (reader1.Read())
                            {
                                CBvariedad.Items.Add(reader1.GetValue(2).ToString().Trim());
                            }
                            reader1.Dispose();*/

                            //trae el catalogo de daños de acuerdo a la linea 
                            DGV1.Rows.Clear();
                            DGV1.Update();
                            foreach(DataRow row in daños.Select("lin_clave = '"+linea+"' and dno_tipo = 'MP'"))
                                DGV1.Rows.Add(Convert.ToString(row["dno_nombre"].ToString().Trim()), "0.00", "0.00", Convert.ToString(row["dno_clave"].ToString().Trim()));
                            
                            /*cmnd1 = thisConnection.CreateCommand();
                            cmnd1.CommandText = "select dno_nombre, dno_clave from tb_cat_danos where dno_tipo = 'MP' and lin_clave = '" + linea + "' order by dno_clave";
                            reader1 = cmnd1.ExecuteReader();
                            while (reader1.Read())
                            {
                                DGV1.Rows.Add(reader1.GetValue(0).ToString().Trim(), "0.00", "0.00", reader1.GetValue(1).ToString().Trim());
                            }
                            reader1.Dispose();
                            thisConnection.Close();*/
                            LblApio.Visible = false;
                            CmbApio.Visible = false;
                            if (txtprod_clave.Text.Trim() == "09014") // APIO P/ENSALADAS
                            {
                                LblApio.Visible = true;
                                CmbApio.Visible = true;
                                CmbApio.SelectedIndex = -1;
                            }
                        }
                        catch (SqlException ex)
                        {
                            //thisConnection.Close();
                            Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex.ToString());                            
                            MessageBox.Show(ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        catch (Exception ex1)
                        {
                            //thisConnection.Close();
                            Utilerias.Class1.SendMail("jbravo@mrlucky.com.mx", "jbravo", "juanjose", ex1.ToString());
                            MessageBox.Show(ex1.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }    
                    }
                }
            }
        }

        private void txthoja_TextChanged(object sender, EventArgs e)
        {
            if (consul != "S")
            {
                if (txthoja.Text.Trim() != "")
                {
                    if (txthoja.Text != "0.00")
                    {                        
                        prod_muestra = 0;
                        foreach (DataRow row in productos.Select("prod_clave = '" + txtprod_clave.Text + "' and prod_tipo = 'MP'"))
                            prod_muestra = Convert.ToDecimal(row["prod_muestra"].ToString());

                        /*thisConnection.Open();
                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "select prod_muestra from tb_cat_producto where prod_tipo = 'MP' and prod_clave = '" + txtprod_clave.Text + "'";
                        reader1 = cmnd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            prod_muestra = reader1.GetSqlDecimal(0).Value;
                        }
                        reader1.Dispose();
                        thisConnection.Close();*/

                        if (prod_muestra > 0)
                        {
                            if (Convert.ToDecimal(txthoja.Text) == 0 && Convert.ToDecimal(txtpata.Text) == 0)
                                txtpesoutil.Text = (Convert.ToDecimal(txtpesoneto.Text) - (Convert.ToDecimal(txtcalhoja.Text) + Convert.ToDecimal(txtcalpata.Text))).ToString("###,###,###.##");
                            else
                            {
                                calhoja = Convert.ToDecimal(txtpesoneto.Text) * (Convert.ToDecimal(txthoja.Text) / prod_muestra);
                                calpata = Convert.ToDecimal(txtpesoneto.Text) * (Convert.ToDecimal(txtpata.Text) / prod_muestra);
                                txtpesoutil.Text = (Convert.ToDecimal(txtpesoneto.Text) - (calhoja + calpata)).ToString("###,###,###.##");
                                txtcalhoja.Text = calhoja.ToString("###,###,###.##");
                                txtcalpata.Text = calpata.ToString("###,###,###.##");
                            }
                        }
                        else
                            txtpesoutil.Text = (Convert.ToDecimal(txtpesoneto.Text) - (Convert.ToDecimal(txtcalhoja.Text) + Convert.ToDecimal(txtcalpata.Text))).ToString("###,###,###.##");
                    }
                }
                else
                    txthoja.Text = "0.00";
            }
        }

        private void txtpata_TextChanged(object sender, EventArgs e)
        {
            if (consul != "S")
            {
                if (txtpata.Text.Trim() != "")
                {
                    if (txtpata.Text != "0.00")
                    {
                        //thisConnection.Open();
                        prod_muestra = 0;
                        foreach (DataRow row in productos.Select("prod_clave = '" + txtprod_clave.Text + "' and prod_tipo = 'MP'"))
                            prod_muestra = Convert.ToDecimal(row["prod_muestra"].ToString());

                        if (prod_muestra == 0)
                        {
                            MessageBox.Show("El producto tiene una muestra de 0 en el catálogo de productos.\n\rFavor de modificarla para que se realice bien el calculo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //cmnd1 = thisConnection.CreateCommand();
                        //cmnd1.CommandText = "select prod_muestra from tb_cat_producto where prod_tipo = 'MP' and prod_clave = '" + txtprod_clave.Text + "'";
                        //reader1 = cmnd1.ExecuteReader();
                        //while (reader1.Read())
                        //{
                        //    prod_muestra = reader1.GetSqlDecimal(0).Value;
                        //}
                        //reader1.Dispose();
                        //thisConnection.Close();

                        if (prod_muestra > 0)
                        {
                            if (Convert.ToDecimal(txthoja.Text) == 0 && Convert.ToDecimal(txtpata.Text) == 0)
                                txtpesoutil.Text = (Convert.ToDecimal(txtpesoneto.Text) - (Convert.ToDecimal(txtcalhoja.Text) + Convert.ToDecimal(txtcalpata.Text))).ToString("###,###,###.##");
                            else
                            {
                                calhoja = Convert.ToDecimal(txtpesoneto.Text) * (Convert.ToDecimal(txthoja.Text) / prod_muestra);
                                calpata = Convert.ToDecimal(txtpesoneto.Text) * (Convert.ToDecimal(txtpata.Text) / prod_muestra);
                                txtpesoutil.Text = (Convert.ToDecimal(txtpesoneto.Text) - (calhoja + calpata)).ToString("###,###,###.##");
                                txtcalhoja.Text = calhoja.ToString("###,###,###.##");
                                txtcalpata.Text = calpata.ToString("###,###,###.##");
                            }
                        }
                        else
                            txtpesoutil.Text = (Convert.ToDecimal(txtpesoneto.Text) - (Convert.ToDecimal(txtcalhoja.Text) + Convert.ToDecimal(txtcalpata.Text))).ToString("###,###,###.##");
                    }
                }
                else
                    txtpata.Text = "0.00";
            }
        }

        private void txtprov_clave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtprov_clave.Text.Length > 0)
                {
                    foreach (DataRow row in proveedor.Select("prov_clave = '" + txtprov_clave.Text + "'"))
                        txtprov.Text = Convert.ToString(row["prov_nombre"].ToString().Trim());

                    if (txtprov.Text.Trim() == "")
                    {
                        MessageBox.Show("No existe ningún proveedor con esa clave, favor de intentar con otra clave", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }
                    /*thisConnection.Open();
                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "select prov_nombre from tb_cat_proveedor where prov_clave = '" + txtprov_clave.Text + "'";
                    reader1 = cmnd1.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            txtprov.Text = reader1.GetValue(0).ToString().Trim();
                        }
                        reader1.Dispose();
                        thisConnection.Close();
                    }
                    else
                    {
                        thisConnection.Close();
                        MessageBox.Show("No existe ningún proveedor con esa clave, favor de intentar con otra clave", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }*/
                }
            }
        }

        private void txtrch_clave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtrch_clave.Text.Length > 0)
                {
                    foreach (DataRow row in ranchos.Select("prov_clave = '" + txtprov_clave.Text + "' and rch_clave = '" + txtrch_clave.Text + "'"))
                        txtrancho.Text = Convert.ToString(row["rch_nombre"].ToString().Trim());

                    if (txtrancho.Text.Trim() == "")
                    {
                        MessageBox.Show("No existe ningún rancho con esa clave, favor de intentar con otra clave", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }
                    /*thisConnection.Open();
                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "select rch_nombre from tb_cat_ranchos where prov_clave = '" + txtprov_clave.Text + "' and rch_clave = '" + txtrch_clave.Text + "'";
                    reader1 = cmnd1.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            txtrancho.Text = reader1.GetValue(0).ToString().Trim();
                        }
                        reader1.Dispose();
                        thisConnection.Close();
                    }
                    else
                    {
                        thisConnection.Close();
                        MessageBox.Show("No existe ningún rancho con esa clave, favor de intentar con otra clave", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }*/
                }
            }
        }

        private void txttbl_clave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txttbl_clave.Text.Length > 0)
                {
                    foreach (DataRow row in tablas.Select("prov_clave = '" + txtprov_clave.Text + "' and rch_clave = '" + txtrch_clave.Text + "' and tbl_clave= '" + txttbl_clave.Text + "'"))
                        txttabla.Text = Convert.ToString(row["tbl_nombre"].ToString().Trim());

                    if (txttabla.Text.Trim() == "")
                    {
                        MessageBox.Show("No existe ninguna tabla con esa clave, favor de intentar con otra clave", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }
                    /*thisConnection.Open();
                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "select tbl_nombre from tb_cat_tablas where prov_clave = '" + txtprov_clave.Text + "' and rch_clave = '" + txtrch_clave.Text + "' and tbl_clave = '" + txttbl_clave.Text + "'";
                    reader1 = cmnd1.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            txttabla.Text = reader1.GetValue(0).ToString().Trim();
                        }
                        reader1.Dispose();

                        CBcodigo.Items.Clear();
                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "select tbl_codigo from tb_cat_subtablas where prov_clave ='" + txtprov_clave.Text + "' and rch_clave = '" + txtrch_clave.Text + "' and tbl_clave = '" + txttbl_clave.Text + "'";
                        reader1 = cmnd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            CBcodigo.Items.Add(reader1.GetValue(0).ToString());
                        }
                        reader1.Dispose();
                        thisConnection.Close();
                    }
                    else
                    {
                        thisConnection.Close();
                        MessageBox.Show("No existe ninguna tabla con esa clave, favor de intentar con otra clave", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }*/
                }
            }
        }

        private void txtflete_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtnumins_KeyPress(object sender, KeyPressEventArgs e)
        {
            //bool IsDec = false;
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            //else if (e.KeyChar == 46)
            //    e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;  
        }

        private void txtpzsmenor5_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool IsDec = false;
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;  
        }

        private void txtpzsmenor5_Click(object sender, EventArgs e)
        {
            txtpzsmenor5.SelectAll();
        }

        private void txtnumins_Click(object sender, EventArgs e)
        {
            txtnumins.SelectAll();
        }

        private void txtnumins_TextChanged(object sender, EventArgs e)
        {
            if (txtnumins.Text.Trim() == "")
                txtnumins.Text = "0";

            if (Convert.ToInt32(txtnumins.Text) > 0)
            {
                if (Convert.ToInt32(txtpzsxmuestra.Text) == 0)
                {
                    MessageBox.Show("Favor de capturar el número de piezas muestra", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtpzsxmuestra.Focus();
                    txtpzsxmuestra.SelectAll();                    
                    return;
                }
            }
        }

        private void txtpzsmenor5_TextChanged(object sender, EventArgs e)
        {
            if (txtpzsmenor5.Text.Trim() == "")
                txtpzsmenor5.Text = "0.00";
        }

        private void txtpzsxmuestra_TextChanged(object sender, EventArgs e)
        {
            if (txtpzsxmuestra.Text.Trim() == "")
                txtpzsxmuestra.Text = "0";
        }

        private void txtpzsxmuestra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;            
            else
                e.Handled = true;  
        }

        private void txtpzsxmuestra_Click(object sender, EventArgs e)
        {
            txtpzsxmuestra.SelectAll();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DGV2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DGV2.CurrentCell.ColumnIndex == 1)
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }

                bool IsDec = true;
                int nroDec = 0;

                for (int i = 0; i < txt1.Text.Length; i++)
                {
                    if (txt1.Text[i] == '.')
                        IsDec = true;

                    if (IsDec && nroDec++ >= 3)
                    {
                        e.Handled = true;
                        return;
                    }
                }

                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }
        }        
        private void DGV2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV2.CurrentCell.ColumnIndex == 1)
            {
                if (consulta != true)
                {
                    insectos = 0;
                    txtdescrip.Text = "";
                    string des = "";
                    for (int i = 0; i < DGV2.Rows.Count; i++)
                    {
                        insectos = insectos + Convert.ToInt32(DGV2.Rows[i].Cells[1].Value);
                        if (Convert.ToInt32(DGV2.Rows[i].Cells[1].Value) != 0)
                        {
                            //if (i == 0)
                            //    txtdescrip.Text = txtdescrip.Text + Convert.ToInt32(DGV2.Rows[i].Cells[1].Value) + " - " + Convert.ToString(DGV2.Rows[i].Cells[0].Value) + " ";
                            //else
                                //txtdescrip.Text = txtdescrip.Text + Convert.ToInt32(DGV2.Rows[i].Cells[1].Value) + " - " + Convert.ToString(DGV2.Rows[i].Cells[0].Value) + ", ";
                            des = des + Convert.ToInt32(DGV2.Rows[i].Cells[1].Value) + " - " + Convert.ToString(DGV2.Rows[i].Cells[0].Value) + ", ";
                        }
                    }

                    txtdescrip.Text = des.Substring(0, des.Length - 2);
                    txtnumins.Text = insectos.ToString("###,###,###");                    
                    DGV1.Update();
                }                
            }
        }

        private void DGV2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DGV2.CurrentCell.ColumnIndex == 1)
            {
                //if (DGV1.CurrentRow.Cells[1].Value.ToString().Length > 0)
                //{
                txt1 = e.Control as TextBox;
                if (txt1 != null)
                {
                    txt1.KeyPress -= new KeyPressEventHandler(DGV2_KeyPress);
                    txt1.KeyPress += new KeyPressEventHandler(DGV2_KeyPress);
                }
                //}
            }
        }

        private void lbfecha_ValueChanged(object sender, EventArgs e)
        {
            if (opcion == 1)
            {
                
                thisConnection.Open();
                cmnd1 = thisConnection.CreateCommand();
                cmnd1.CommandText = "select semana from tb_cat_semanas WHERE fecha1 <= '" + lbfecha.Text + "' AND fecha2 >= '" + lbfecha.Text + "'";
                reader1 = cmnd1.ExecuteReader();
                while (reader1.Read())
                {
                    DateTime dateValue = new DateTime(lbfecha.Value.Year, lbfecha.Value.Month, lbfecha.Value.Day);
                    lbcletiqueta.Text = reader1.GetValue(0).ToString() + "-" + dateValue.ToString("ddd").ToUpper();
                    cletiqueta = lbcletiqueta.Text.Substring(0, 5);
                    if (cletiqueta.Trim().Contains("Á"))
                        cletiqueta = cletiqueta.Replace('Á', 'A');

                    if (cletiqueta.Trim().Contains("É"))
                        cletiqueta = cletiqueta.Replace('É', 'E');
                    lbcletiqueta.Text = cletiqueta;
                }
                reader1.Dispose();
                thisConnection.Close();
                lbcletiqueta.Refresh();
                if (seconvirtio == 1)
                {
                    txtpreciogrado1.Text = Math.Round((Convert.ToDecimal(txtpreciogrado1.Text) / Convert.ToDecimal(TxtTipoCam.Text)), 2).ToString("##0.00");
                    txtpreciogrado2.Text = Math.Round((Convert.ToDecimal(txtpreciogrado2.Text) / Convert.ToDecimal(TxtTipoCam.Text)), 2).ToString("##0.00");
                    seconvirtio = 0;
                    CBMoneda.Text = tipomon;
                }
                TraeTipoCam();
            }
        }

        private void Genera_PDF_PrintPage(object sender, PrintPageEventArgs e)
        {
            SolidBrush color = new SolidBrush(Color.Black);
            Font fuente = new Font("Courier", 10);

            Image newImage = Image.FromFile(@"C:\SisGabWeb\MP.jpg");
            e.Graphics.DrawImage(newImage, 0, 0);

            //recibo
            Point recib = new Point(680, 120);
            e.Graphics.DrawString(txtrecibo.Text, fuente, color, recib);

            //lugar
            Point lug = new Point(680, 160);
            e.Graphics.DrawString("IRAPUATO GTO.", fuente, color, lug);

            //flete
            Point fle = new Point(715, 192);
            e.Graphics.DrawString(txtflete.Text, fuente, color, fle);

            //ticket
            Point tic = new Point(690, 220);
            e.Graphics.DrawString(ticket.SelectedItem.ToString().Trim(), fuente, color, tic);

            //proveedor            
            Point prov = new Point(17, 195);
            e.Graphics.DrawString(txtprov.Text, fuente, color, prov);

            //producto
            Point prod = new Point(330, 195);
            e.Graphics.DrawString(txtprod.Text, fuente, color, prod);

            //rancho
            Point rch = new Point(25, 270);
            e.Graphics.DrawString(txtrancho.Text, fuente, color, rch);

            //tabla
            Point tabl = new Point(330, 270);
            e.Graphics.DrawString(txttabla.Text, fuente, color, tabl);

            //subtabla o postura
            Point subtbl = new Point(330, 300);
            e.Graphics.DrawString(txtcodigo_clave.Text, fuente, color, subtbl);

            //fecha
            Point day = new Point(630, 275);
            e.Graphics.DrawString(lbfecha.Text, fuente, color, day);

            //peso bruto
            Point pb = new Point(650, 330);
            e.Graphics.DrawString(txtpesobruto.Text, fuente, color, pb);

            //tara 
            Point tc = new Point(650, 365);
            e.Graphics.DrawString(txttaracamion.Text, fuente, color, tc);

            //diferencia de peso bruto - tara
            Point dif = new Point(650, 395);
            e.Graphics.DrawString((Convert.ToDecimal(txtpesobruto.Text) - Convert.ToDecimal(txttaracamion.Text)).ToString(), fuente, color, dif);

            //peso envase con nombre y clave
            if (txtenv.Text.Length > 7)
                txtenv.Text.Substring(0, 7);

            Point pr = new Point(561, 420);
            e.Graphics.DrawString(txtenv.Text + "    " + txtrmpnumenvase.Text, fuente, color, pr);
            Point pr1 = new Point(650, 435);
            e.Graphics.DrawString(txtpesorecipiente.Text, fuente, color, pr1);

            //peso neto
            Point pn = new Point(650, 465);
            e.Graphics.DrawString(txtpesoneto.Text, fuente, color, pn);

            //hoja            
            if (Convert.ToDecimal(txthoja.Text) != 0)
            {
                if (prod_muestra > 0)
                {
                    decimal hoja = Convert.ToDecimal(txthoja.Text) / (prod_muestra / 100);
                    Point hoj = new Point(650, 495);
                    e.Graphics.DrawString(hoja.ToString("00.00"), fuente, color, hoj);
                }
                else
                {
                    Point hoj = new Point(650, 495);
                    e.Graphics.DrawString(txthoja.Text, fuente, color, hoj);
                }
            }
            else
            {
                Point hoj = new Point(650, 495);
                e.Graphics.DrawString(txthoja.Text, fuente, color, hoj);
            }

            //pata porcentaje
            if (Convert.ToDecimal(txtpata.Text) != 0)
            {
                if (prod_muestra > 0)
                {
                    decimal pata = Convert.ToDecimal(txtpata.Text) / (prod_muestra / 100);
                    Point pat = new Point(650, 535);
                    e.Graphics.DrawString(pata.ToString("00.00"), fuente, color, pat);
                }
                else
                {
                    Point pat = new Point(650, 535);
                    e.Graphics.DrawString(txtpata.Text, fuente, color, pat);
                }
            }
            else
            {
                Point pat = new Point(650, 535);
                e.Graphics.DrawString(txtpata.Text, fuente, color, pat);
            }

            //peso útil
            Point pu = new Point(650, 570);
            e.Graphics.DrawString(txtpesoutil.Text, fuente, color, pu);

            //muestra
            Point mue = new Point(115, 350);
            e.Graphics.DrawString(txtmuestrakg.Text, fuente, color, mue);


            if (DGV1.Rows.Count > 20)
                fuente = new Font("Courier", 9);

            //grid
            int con = 375;
            for (int i = 0; i < DGV1.Rows.Count; i++)
            {
                if (Convert.ToDecimal(DGV1.Rows[i].Cells[1].Value.ToString()) > 0)
                {
                    Point nom = new Point(25, con);
                    e.Graphics.DrawString(DGV1.Rows[i].Cells[0].Value.ToString(), fuente, color, nom);

                    Point kgs = new Point(250, con);
                    e.Graphics.DrawString(DGV1.Rows[i].Cells[1].Value.ToString(), fuente, color, kgs);

                    Point por = new Point(375, con);
                    e.Graphics.DrawString(Convert.ToDecimal(DGV1.Rows[i].Cells[2].Value).ToString("#0.00"), fuente, color, por);

                    con = con + 13;
                }
            }


            fuente = new Font("Courier", 9);

            //total kgs defectos
            Point defec = new Point(250, con + 26);
            e.Graphics.DrawString(txtdefectos.Text, fuente, color, defec);

            //total porcentaje defectos
            Point defecpor = new Point(375, con + 26);
            e.Graphics.DrawString(txtpordef.Text, fuente, color, defecpor);

            //grado1
            Point grad1 = new Point(540, 680);
            e.Graphics.DrawString(txtgrado1.Text, fuente, color, grad1);

            //porcentaje grado 1
            Point porgrad1 = new Point(640, 680);
            e.Graphics.DrawString(txtporgrado1.Text, fuente, color, porgrad1);

            //kg grado 1
            Point kggrad1 = new Point(740, 680);
            e.Graphics.DrawString(txttotalgrado1.Text, fuente, color, kggrad1);

            //grado2
            Point grad2 = new Point(540, 730);
            e.Graphics.DrawString(txtgrado2.Text, fuente, color, grad2);

            //porcentaje grado 1
            Point porgrad2 = new Point(640, 730);
            e.Graphics.DrawString(txtporgrado2.Text, fuente, color, porgrad2);

            //kg grado 1
            Point kggrad2 = new Point(740, 730);
            e.Graphics.DrawString(txttotalgrado2.Text, fuente, color, kggrad2);

            //defectos
            Point def = new Point(540, 820);
            e.Graphics.DrawString(txtdefectos.Text, fuente, color, def);

            //porcentaje defectos
            Point pordef = new Point(640, 820);
            e.Graphics.DrawString(txtpordef.Text, fuente, color, pordef);

            //kg defectos
            Point kgdef = new Point(740, 820);
            e.Graphics.DrawString(txttotaldef.Text, fuente, color, kgdef);

            //total grado1
            Point totgrad1 = new Point(540, 890);
            e.Graphics.DrawString(txttotal.Text, fuente, color, totgrad1);

            //total por
            Point totpor = new Point(640, 890);
            e.Graphics.DrawString(txttotalpor.Text, fuente, color, totpor);

            //total kg
            Point totkg = new Point(740, 890);
            e.Graphics.DrawString(txttotalkg.Text, fuente, color, totkg);

            //sobre inspeccion            
            //if (sobre_insp == "N")
            if (cbevaluacion.SelectedIndex == 0)
            {
                Point sob_insp_N = new Point(30, 810);
                e.Graphics.DrawString("X", fuente, color, sob_insp_N);
            }
            if (cbevaluacion.SelectedIndex == 1)
            //else
            {
                Point sob_insp_S = new Point(30, 820);
                e.Graphics.DrawString("X", fuente, color, sob_insp_S);
            }
            if (cbevaluacion.SelectedIndex == 3)
            {
                Point sob_insp_N = new Point(30, 830);
                e.Graphics.DrawString("X", fuente, color, sob_insp_N);
            }

            //pesador
            if (txtpesador.Text.Trim().Length > 7)
                txtpesador.Text = txtpesador.Text.Substring(0, 7);

            Point pesa = new Point(35, 875);
            e.Graphics.DrawString(txtpesador.Text, fuente, color, pesa);

            //evaluador
            if (txtevaluador.Text.Trim().Length > 8)
                txtevaluador.Text = txtevaluador.Text.Substring(0, 8);
            Point evalu = new Point(230, 875);
            e.Graphics.DrawString(txtevaluador.Text, fuente, color, evalu);

            //variedad
            if (CBvariedad.SelectedIndex != -1)
            {
                Point vari = new Point(25, 930);
                e.Graphics.DrawString(CBvariedad.SelectedItem.ToString(), fuente, color, vari);
            }

            //observaciones
            Point obs = new Point(25, 950);
            if (estatus.Trim() != "F")
                e.Graphics.DrawString(txtobs.Text, fuente, color, obs);
            else
                e.Graphics.DrawString(txtobs.Text + "\r\nEL RECIBO ESTÁ CANCELADO", fuente, color, obs);
        }

        private void btnemail_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("¿Desea enviar el recibo por correo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
                //if (email.Trim() == "")
                //{
                //    MessageBox.Show("El proveedor no tiene cuenta de correo registrada, favor de agregarla", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
            //if (txtprov.Text.Trim().Contains("AGUILARES"))
            //{
                SentToOutlook();
            //    return;
            //}
                label7.Text = "ENVIANDO CORREO . . .";
                label7.Visible = true;
                label7.Update();

                string body = string.Format("Hola Buen día" + "<br><br>" + "Envio información del detalle del recibo " + txtrecibo.Text + "<br><br>" +
                            "Del Día " + lbfecha.Text + "<br><br>" +
                            "Atentamente, " + "<br><br>" +
                            "Comercializadora GAB S.A. de C.V." + "<br>" +
                            "www.mrlucky.com.mx");

                PrintDocument printdocu = new PrintDocument();
                printdocu.PrintPage += new PrintPageEventHandler(this.Genera_PDF_PrintPage);
                printdocu.PrinterSettings.PrinterName = "Foxit Reader PDF Printer";
                printdocu.Print();
                var inv_pt1 = @"C:\\Reportes\document.pdf";
                if (Utilerias.Class1.ConnectionString.Contains("GABIRASQL"))
                {
                    var inv_pt2 = @"\\gabira1\Recibos_proveedores\MP_" + txtrecibo.Text + ".pdf";
                    //var inv_pt2 = @"\\gabira1\ConEmbNa\prueba.pdf";
                    if (!File.Exists(inv_pt1))
                    {
                        using (FileStream fs = File.Create(inv_pt1)) { }
                    }
                    if (File.Exists(inv_pt2))
                        File.Delete(inv_pt2);

                    File.Move(inv_pt1, inv_pt2);
                    if (email.Trim() != "")
                        SendMail(email, inv_pt2.ToString(), body, "Envio información del recibo " + txtrecibo.Text);
                }
                else
                {
                    var inv_pt3 = @"C:\\Reportes\MP_" + txtrecibo.Text + ".pdf";
                    if (File.Exists(inv_pt3))
                        File.Delete(inv_pt3);

                    File.Move(inv_pt1, inv_pt3);
                    if (email.Trim() != "")
                        SendMail(email, inv_pt3.ToString(), body, "Envio información del recibo " + txtrecibo.Text);
                }
                //MessageBox.Show("El archivo ha sido enviado al proveedor", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label7.Visible = false;
                //limpiarTextBoxes(this);
            //}
        }

        public void SendMail(string Dest, string Archivo, string mBody, string mAsunto)
        {
            MailMessage msg = new MailMessage();
            MailMessage email = new MailMessage();

            string[] destinatarios = Dest.Split(';');
            foreach (string destinos in destinatarios)
            {
                if (destinos.Trim().Length > 0)
                    email.To.Add(new MailAddress(destinos));
            }
            //email.To.Add(new MailAddress("gcamacho@mrlucky.com.mx"));
            //email.CC.Add(new MailAddress("gcamacho@mrlucky.com.mx")); 
            //email.CC.Add(new MailAddress("mprima@mrlucky.com.mx"));
            //email.CC.Add(new MailAddress("jimenezjosem@mrlucky.com.mx")); 
            //email.CC.Add(new MailAddress("aescamilla@mrlucky.com.mx")); 
            email.From = new MailAddress("mprima@mrlucky.com.mx"); //
            email.Subject = mAsunto; //"Mensaje de Prueba";
            email.Body = mBody;  //"Información de la factura";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            //string archivo = @"C:\Reportes\factura_informativa.txt";
            if (Archivo.Trim().Length > 0)
                if (File.Exists(Archivo))
                    email.Attachments.Add(new Attachment(Archivo));

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail1.mrlucky.com.mx";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("mprima", "F7udjVm1928M$123");

            try
            {
                smtp.Send(email);
                email.Dispose();
                //MessageBox.Show("correo enviado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("correo no enviado\r\n" + ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbevaluacion_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (cbevaluacion.SelectedIndex == 2 || cbevaluacion.SelectedIndex == 1)
            {
                No_conformidad.recibo = txtrecibo.Text;
                No_conformidad.nombre_proveedor = txtprov.Text + " - " + txttabla.Text;
                No_conformidad.evaluacion = cbevaluacion.SelectedItem.ToString().Trim();
                No_conformidad.fecha = lbfecha.Text;
                No_conformidad.danos = "";
                for (int i = 0; i < DGV1.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(DGV1.Rows[i].Cells[2].Value) > 0)
                        No_conformidad.danos = No_conformidad.danos + Convert.ToString(DGV1.Rows[i].Cells[0].Value).Trim() + " " + Convert.ToString(DGV1.Rows[i].Cells[2].Value).Trim() + "%, ";
                }
                if (No_conformidad.danos.Length != 0)
                    No_conformidad.danos = No_conformidad.danos.Substring(0, No_conformidad.danos.Length - 2);
                No_conformidad nocon = new No_conformidad();
                No_conformidad.productos.Rows.Clear();

                DataRow rw = No_conformidad.productos.NewRow();
                rw["producto"] = txtprod.Text;
                No_conformidad.productos.Rows.Add(rw);
                
                nocon.ShowDialog();
                btnCancel_Click(sender, e);
            }
        }

        private void btnaddfile_Click(object sender, EventArgs e)
        {
            var pdf_servidor = @"\\gabira1\No_conformidad\ " + txtfolnocon.Text + "MP.pdf";
            CargarPDF = new OpenFileDialog();
            CargarPDF.Filter = "Pdf Files|*.pdf";
            CargarPDF.InitialDirectory = "C:\\no_conformidad";
            if (CargarPDF.ShowDialog() == DialogResult.OK)
                ruta_pdf = CargarPDF.FileName;

            if (File.Exists(pdf_servidor))
            {
                if (MessageBox.Show("El archivo ya existe. ¿Desea reemplazarlo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Copy(ruta_pdf, pdf_servidor, true);
                }
            }
            else
            {
                if (File.Exists(ruta_pdf))
                    File.Move(ruta_pdf, pdf_servidor);
                else
                    MessageBox.Show("El archivo no existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void btnpdf_Click(object sender, EventArgs e)
        {
            string archivo = @"\\gabira1\No_conformidad\ " + txtfolnocon.Text + "MP.pdf";
            if (File.Exists(archivo))
            {
                ProcessStartInfo proces = new ProcessStartInfo(archivo);
                Process.Start(proces);
            }
            else
                MessageBox.Show("El archivo no existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btneva_Click(object sender, EventArgs e)
        {
            cbevaluacion.Enabled = true;
            btnpdf.Visible = true;
            btnaddfile.Visible = true;
        }

        private void txtnumped_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //if (txtnumped.Text.Trim().Length == 2)
            //{
            //    string pedimento = txtnumped.Text;
            //    txtnumped.Text = pedimento + " ";
            //    txtnumped.Select(3, 0);
            //}
            //if (txtnumped.Text.Trim().Length == 5)
            //{
            //    string pedimento = txtnumped.Text;
            //    txtnumped.Text = pedimento + " ";
            //    txtnumped.Select(6, 0);
            //}
            //if (txtnumped.Text.Trim().Length == 10)
            //{
            //    string pedimento = txtnumped.Text;
            //    txtnumped.Text = pedimento + " ";
            //    txtnumped.Select(11, 0);
            //}
        }

        private void BtnGenPDF_Click(object sender, EventArgs e)
        {
            PrintDocument printdocu = new PrintDocument();
            printdocu.PrintPage += new PrintPageEventHandler(this.Genera_PDF_PrintPage);
            printdocu.PrinterSettings.PrinterName = "Foxit Reader PDF Printer";
            printdocu.Print();
            var inv_pt1 = @"C:\\Reportes\document.pdf";
            if (Utilerias.Class1.ConnectionString.Contains("GABIRASQL"))
            {
                var inv_pt2 = @"\\gabira1\Recibos_proveedores\MP_" + txtrecibo.Text + ".pdf";
                //var inv_pt2 = @"\\gabira1\ConEmbNa\prueba.pdf";
                if (!File.Exists(inv_pt1))
                {
                    using (FileStream fs = File.Create(inv_pt1)) { }
                }
                if (File.Exists(inv_pt2))
                    File.Delete(inv_pt2);

                //MessageBox.Show("Archivo Creado!!!"); 
                File.Move(inv_pt1, inv_pt2);
                //if (email.Trim() != "")
                //    SendMail(email, inv_pt2.ToString(), body, "Envio información del recibo " + txtrecibo.Text);
            }
        }

        private string TraeUltPrecio(string mcve)
        {
            string mPre = "";
            string Cadena = "SELECT TOP 1 rmp_precio_grado1, rmp_precio_grado2 FROM tb_mstr_recepcion_mp WHERE prod_clave = '" + mcve + "'" +
                            " ORDER BY rmp_fecha DESC ";
            SqlCommand cmd = new SqlCommand(Cadena, thisConnection);
            reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {
                mPre = reader1["rmp_precio_grado1"].ToString() + "|" + reader1["rmp_precio_grado2"].ToString(); 
            }
            return mPre;
        }

        private void ChkImport_CheckedChanged(object sender, EventArgs e)
        {
            //CalculaPrecio();
        }

        private void TraeTipoCam()
        {
            // CARGO EL TIPO DE CAMBIO DEL DIA
            query = "SELECT TOP 1 * FROM tb_cat_tipocambio WHERE fecha <= '" + lbfecha.Value.ToShortDateString() + "' ORDER BY fecha DESC ";
            da = new SqlDataAdapter(query, thisConnection);
            da.Fill(ds, "TipoCam");
            TipoCam = ds.Tables["TipoCam"];
            foreach (DataRow row in TipoCam.Rows)
            {
                TxtTipoCam.Text = row["valor"].ToString();
                LblFecTC.Text = Convert.ToDateTime(row["fecha"]).ToShortDateString();
            }
            CalculaPrecio();
        }

        private void CalculaPrecio()
        {
            if (ChkImport.Checked)
            {
                txtpreciogrado1.Text = Math.Round((Convert.ToDecimal(txtpreciogrado1.Text) * Convert.ToDecimal(TxtTipoCam.Text)), 2).ToString();
                txtpreciogrado2.Text = Math.Round((Convert.ToDecimal(txtpreciogrado2.Text) * Convert.ToDecimal(TxtTipoCam.Text)), 2).ToString();
                if (Math.Round(Convert.ToDecimal(txtpreciogrado1.Text)) == 0 || Math.Round(Convert.ToDecimal(txtpreciogrado2.Text)) == 0)
                {
                    MessageBox.Show("Para Cambiarlo a Importacion primero hay que capturar el Precio de Grado 1 ó 2", "Aviso",MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ChkImport.Checked = false;
                    return;
                }
                seconvirtio = 1;
                tipomon = CBMoneda.Text;
                CBMoneda.Text = "PESOS";
                TxtPaisOrigen.Text = "";
                TxtPaisOrigen.ReadOnly = false ;
            }
            else
            {
                if (seconvirtio == 1)
                {
                    txtpreciogrado1.Text = Math.Round((Convert.ToDecimal(txtpreciogrado1.Text) / Convert.ToDecimal(TxtTipoCam.Text)), 2).ToString("##0.00");
                    txtpreciogrado2.Text = Math.Round((Convert.ToDecimal(txtpreciogrado2.Text) / Convert.ToDecimal(TxtTipoCam.Text)), 2).ToString("##0.00");
                    seconvirtio = 0;
                    CBMoneda.Text = tipomon;
                    TxtPaisOrigen.Text = "";
                    TxtPaisOrigen.ReadOnly = true;
                }
            }
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            //Verificar ordenes de compra anticipadas 24/05/2021
            string conteo = "";
            thisConnection.Open();
            cmnd1 = thisConnection.CreateCommand();
            cmnd1.CommandText = "SELECT count(A.numero_oc) AS cantidad FROM tb_mstr_ordencompra A JOIN tb_det_ordenescompra B ON A.numero_oc = B.numero_oc " +
                "WHERE A.cveprov_oc = '" + txtprov_clave.Text + "' AND B.prod_clave  = '" + txtprod_clave.Text + "' AND A.status_oc = 'A' AND A.factura_oc = 'MATERIAP' AND A.fecha_recepcion <= '" + DateTime.Now.ToShortDateString() + "' AND A.anticipada = '1' " +
                "AND B.surtido_oc <> B.cantidad_oc";
            reader1 = cmnd1.ExecuteReader();
            reader1.Read();
            conteo = reader1["cantidad"].ToString().Trim();
            reader1.Close();
            reader1.Dispose();
            cmnd1.Dispose();
            thisConnection.Close();

            Utilerias.Class1.registrar_movimiento(DateTime.Now, Environment.MachineName, Utilerias.Class1.Usu_login, "C", "", "", "Entra a Verificar Anticipadas " + Utilerias.Class1.Usu_login.ToString() + " " + Environment.MachineName.ToString() + " A.cveprov_oc = '" + txtprov_clave.Text + "' AND B.prod_clave  = '" + txtprod_clave.Text + "'", "SISEMP"); 

            if (Convert.ToInt32(conteo) > 0)
            {
                //Utilerias.Class1.SendMail("aescamilla@mrlucky.com.mx", "aescamilla", "atrejo", "Entra a Verificar Anticipadas " + Utilerias.Class1.Usu_login.ToString() + " " + Environment.MachineName.ToString() + " A.cveprov_oc = '" + txtprov_clave.Text + "' AND B.prod_clave  = '" + txtprod_clave.Text + "'");

                string cv = txtrecibo.Text;
                string pv = txtprov_clave.Text;
                string pd = txtprod_clave.Text;
                string g1 = txttotalgrado1.Text;
                string g2 = txttotalgrado2.Text;
                string npv = txtprov.Text;
                string npd = txtprod.Text;
                anticipadas dlg = new anticipadas(cv, pv, pd, g1, g2, npv, npd);
                dlg.ShowDialog();

                if (dlg.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    lblOrdenG1.Text = (anticipadas.SharedDatos.DatosCell.ocg1 == "-") ? "0" : anticipadas.SharedDatos.DatosCell.ocg1;
                    lblOrdenG2.Text = (anticipadas.SharedDatos.DatosCell.ocg2 == "-") ? "0" : anticipadas.SharedDatos.DatosCell.ocg2;
                    lblCostoOCG1.Text = (anticipadas.SharedDatos.DatosCell.costo1 == "-") ? "0" : anticipadas.SharedDatos.DatosCell.costo1;
                    lblCostoOCG2.Text = (anticipadas.SharedDatos.DatosCell.costo2 == "-") ? "0" : anticipadas.SharedDatos.DatosCell.costo2;
                    lblEstado.Text = anticipadas.SharedDatos.DatosCell.estado;
                }
            }
            //Verificar ordenes de compra anticipadas 24/05/2021
        }

        //private void dtpFechaRecoleccion_ValueChanged(object sender, EventArgs e)
        //{
        //    txtFechaRecoleccion.Text = Convert.ToDateTime(dtpFechaRecoleccion.Text).ToShortDateString();
        //}

        //private void dtpFechaRecepcion_ValueChanged(object sender, EventArgs e)
        //{
        //    txtFechaRecepcion.Text = Convert.ToDateTime(dtpFechaRecepcion.Text).ToShortDateString();
        //}

        private void btnGuardaOCA_Click(object sender, EventArgs e)
        {
            string queries = "";
            thisConnection.Open();
            int i = 0;
            try
            {
                if (lblOrdenG1.Text != "0")
                {
                    i++;
                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "UPDATE tb_hist_recepcion SET hrp_numoc = '" + lblOrdenG1.Text + "' WHERE hrp_recibo = '" + txtrecibo.Text + "' AND hrp_tipo_recepcion = 'MP' AND prod_clave = '" + txtprod_clave.Text + "'";
                    cmnd1.ExecuteNonQuery();
                    cmnd1.Dispose();

                    queries += "UPDATE tb_hist_recepcion SET hrp_numoc = '" + lblOrdenG1.Text + "' WHERE hrp_recibo = '" + txtrecibo.Text + "' AND hrp_tipo_recepcion = 'MP' AND prod_clave = '" + txtprod_clave.Text + "' - ";

                    i++;
                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "UPDATE tb_mstr_ordencompra SET fecha_recepcion = '" + Convert.ToDateTime(lbfecha.Text).ToShortDateString() + "' WHERE numero_oc = '" + lblOrdenG1.Text + "'";
                    cmnd1.ExecuteNonQuery();
                    cmnd1.Dispose();

                    query += "UPDATE tb_mstr_ordencompra SET fecha_recepcion = '" + Convert.ToDateTime(lbfecha.Text).ToShortDateString() + "' WHERE numero_oc = '" + lblOrdenG1.Text + "' - ";

                    i++;
                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "UPDATE tb_det_ordenescompra SET surtido_oc = surtido_oc + '" + Convert.ToDecimal(txttotalgrado1.Text).ToString() + "' WHERE numero_oc = '" + lblOrdenG1.Text + "' " +
                        "AND prod_clave = '" + txtprod_clave.Text + "'";
                    cmnd1.ExecuteNonQuery();
                    cmnd1.Dispose();

                    queries += "UPDATE tb_det_ordenescompra SET surtido_oc = surtido_oc + '" + Convert.ToDecimal(txttotalgrado1.Text).ToString() + "' WHERE numero_oc = '" + lblOrdenG1.Text + "' " +
                        "AND prod_clave = '" + txtprod_clave.Text + "' - ";

                    i++;
                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "INSERT INTO tb_det_anticipada_mp(hrp_recibo, numero_oc, hrp_cantidad, hrp_fecha, grado1) " +
                        "VALUES ('" + txtrecibo.Text + "','" + lblOrdenG1.Text + "','" + Convert.ToDecimal(txttotalgrado1.Text).ToString() + "','" + DateTime.Now.ToShortDateString() + "', '1')";
                    cmnd1.ExecuteNonQuery();
                    cmnd1.Dispose();

                    queries += "INSERT INTO tb_det_anticipada_mp(hrp_recibo, numero_oc, hrp_cantidad, hrp_fecha, grado1) " +
                        "VALUES ('" + txtrecibo.Text + "','" + lblOrdenG1.Text + "','" + Convert.ToDecimal(txttotalgrado1.Text).ToString() + "','" + DateTime.Now.ToShortDateString() + "', '1')";

                    queries = queries.Replace("'", " ");

                }
                if (lblOrdenG2.Text != "0")
                {
                    i++;
                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "UPDATE tb_hist_recepcion SET hrp_numoc_g2 = '" + lblOrdenG2.Text + "' WHERE hrp_recibo = '" + txtrecibo.Text + "' AND hrp_tipo_recepcion = 'MP' AND prod_clave = '" + txtprod_clave.Text + "'";
                    cmnd1.ExecuteNonQuery();
                    cmnd1.Dispose();

                    queries += "UPDATE tb_hist_recepcion SET hrp_numoc_g2 = '" + lblOrdenG2.Text + "' WHERE hrp_recibo = '" + txtrecibo.Text + "' AND hrp_tipo_recepcion = 'MP' AND prod_clave = '" + txtprod_clave.Text + "' - ";

                    i++;
                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "UPDATE tb_mstr_ordencompra SET fecha_recepcion = '" + Convert.ToDateTime(lbfecha.Text).ToShortDateString() + "' WHERE numero_oc = '" + lblOrdenG2.Text + "'";
                    cmnd1.ExecuteNonQuery();
                    cmnd1.Dispose();

                    query += "UPDATE tb_mstr_ordencompra SET fecha_recepcion = '" + Convert.ToDateTime(lbfecha.Text).ToShortDateString() + "' WHERE numero_oc = '" + lblOrdenG2.Text + "' - ";

                    i++;
                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "UPDATE tb_det_ordenescompra SET surtido_oc = surtido_oc + '" + Convert.ToDecimal(txttotalgrado2.Text).ToString() + "' WHERE numero_oc = '" + lblOrdenG2.Text + "' " +
                        "AND prod_clave = '" + txtprod_clave.Text + "'";
                    cmnd1.ExecuteNonQuery();
                    cmnd1.Dispose();

                    queries += "UPDATE tb_det_ordenescompra SET surtido_oc = surtido_oc + '" + Convert.ToDecimal(txttotalgrado2.Text).ToString() + "' WHERE numero_oc = '" + lblOrdenG2.Text + "' " +
                        "AND prod_clave = '" + txtprod_clave.Text + "' - ";

                    i++;
                    cmnd1 = thisConnection.CreateCommand();
                    cmnd1.CommandText = "INSERT INTO tb_det_anticipada_mp(hrp_recibo, numero_oc, hrp_cantidad, hrp_fecha, grado2) " +
                        "VALUES ('" + txtrecibo.Text + "','" + lblOrdenG2.Text + "','" + Convert.ToDecimal(txttotalgrado2.Text).ToString() + "','" + DateTime.Now.ToShortDateString() + "', '1')";
                    cmnd1.ExecuteNonQuery();
                    cmnd1.Dispose();

                    queries += "INSERT INTO tb_det_anticipada_mp(hrp_recibo, numero_oc, hrp_cantidad, hrp_fecha, grado2) " +
                        "VALUES ('" + txtrecibo.Text + "','" + lblOrdenG2.Text + "','" + Convert.ToDecimal(txttotalgrado2.Text).ToString() + "','" + DateTime.Now.ToShortDateString() + "', '1')";

                    queries = queries.Replace("'", " ");
                }
                thisConnection.Close();

                Utilerias.Class1.registrar_movimiento3(DateTime.Now, Environment.MachineName, Utilerias.Class1.Usu_login, "A", "2.1", txtrecibo.Text, "Orden Anticipada", "SIPGAB", "", " Queries: " + queries);

                //MessageBox.Show("Datos Guardados", "SIPGAB", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //this.Close();
            }
            catch (SqlException ex)
            {
                thisConnection.Close();
                if (i == 1)
                {
                    Utilerias.Class1.registrar_movimiento3(DateTime.Now, Environment.MachineName, Utilerias.Class1.Usu_login, "A", "2.1", txtrecibo.Text, "Error Orden Anticipada", "SIPGAB", "", " Queries: " + queries + " " + ex.ToString());
                }
                else if (i == 2)
                {
                    Utilerias.Class1.registrar_movimiento3(DateTime.Now, Environment.MachineName, Utilerias.Class1.Usu_login, "A", "2.1", txtrecibo.Text, "Error Orden Anticipada", "SIPGAB", "", " Queries: " + queries + " " + ex.ToString());
                    if (Convert.ToDecimal(txttotalgrado1.Text) > 0)
                    {
                        thisConnection.Open();
                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "UPDATE tb_hist_recepcion SET hrp_numoc = '' WHERE hrp_recibo = '" + txtrecibo.Text + "' AND hrp_tipo_recepcion = 'MP' AND prod_clave = '" + txtprod_clave.Text + "'";
                        cmnd1.ExecuteNonQuery();
                        cmnd1.Dispose();
                        thisConnection.Close();
                    }
                    if (Convert.ToDecimal(txttotalgrado2.Text) > 0)
                    {
                        thisConnection.Open();
                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "UPDATE tb_hist_recepcion SET hrp_numoc_g2 = '' WHERE hrp_recibo = '" + txtrecibo.Text + "' AND hrp_tipo_recepcion = 'MP' AND prod_clave = '" + txtprod_clave.Text + "'";
                        cmnd1.ExecuteNonQuery();
                        cmnd1.Dispose();
                        thisConnection.Close();
                    }
                }
                else if (i == 3)
                {
                    Utilerias.Class1.registrar_movimiento3(DateTime.Now, Environment.MachineName, Utilerias.Class1.Usu_login, "A", "2.1", txtrecibo.Text, "Error Orden Anticipada", "SIPGAB", "", " Queries: " + queries + " " + ex.ToString());
                    if (Convert.ToDecimal(txttotalgrado1.Text) > 0)
                    {
                        thisConnection.Open();
                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "UPDATE tb_hist_recepcion SET hrp_numoc = '' WHERE hrp_recibo = '" + txtrecibo.Text + "' AND hrp_tipo_recepcion = 'MP' AND prod_clave = '" + txtprod_clave.Text + "'";
                        cmnd1.ExecuteNonQuery();
                        cmnd1.Dispose();

                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "UPDATE tb_det_ordenescompra SET surtido_oc = surtido_oc - '" + Convert.ToDecimal(txttotalgrado1.Text).ToString() + "' WHERE numero_oc = '" + lblOrdenG1.Text + "' " +
                        "AND prod_clave = '" + txtprod_clave.Text + "'";
                        cmnd1.ExecuteNonQuery();
                        cmnd1.Dispose();
                        thisConnection.Close();
                    }
                    if (Convert.ToDecimal(txttotalgrado2.Text) > 0)
                    {
                        Utilerias.Class1.registrar_movimiento3(DateTime.Now, Environment.MachineName, Utilerias.Class1.Usu_login, "A", "2.1", txtrecibo.Text, "Error Orden Anticipada", "SIPGAB", "", " Queries: " + queries + " " + ex.ToString());
                        thisConnection.Open();
                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "UPDATE tb_hist_recepcion SET hrp_numoc_g2 = '' WHERE hrp_recibo = '" + txtrecibo.Text + "' AND hrp_tipo_recepcion = 'MP' AND prod_clave = '" + txtprod_clave.Text + "'";
                        cmnd1.ExecuteNonQuery();
                        cmnd1.Dispose();

                        cmnd1 = thisConnection.CreateCommand();
                        cmnd1.CommandText = "UPDATE tb_det_ordenescompra SET surtido_oc = surtido_oc - '" + Convert.ToDecimal(txttotalgrado2.Text).ToString() + "' WHERE numero_oc = '" + lblOrdenG2.Text + "' " +
                            "AND prod_clave = '" + txtprod_clave.Text + "'";
                        cmnd1.ExecuteNonQuery();
                        cmnd1.Dispose();
                        thisConnection.Close();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMail("aescamilla@mrlucky.com.mx", @"\\gabira1\Recibos_proveedores\MP_222970.pdf", "envio de correo de prueba", "Prueba envia correo");
        }

        private void txtobs_Enter(object sender, EventArgs e)
        {
            if (txtprod_clave.Text.Trim() == "09014") // APIO P/ENSALADAS
            {
                if (CmbApio.SelectedIndex < 0)
                {
                    MessageBox.Show("No se ha Seleccionado el Tipo de Apio, Seleccionelo Primero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbApio.Focus();
                    return;
                }
            }
        }

        private void CmbApio_Leave(object sender, EventArgs e)
        {
            if (CmbApio.SelectedIndex > -1)
            {
                if (txtobs.Text.Contains("ENTERO") || txtobs.Text.Contains("VARA"))
                {
                    txtobs.Text = txtobs.Text.Replace("ENTERO", "").Replace("VARA", "");
                    if (txtobs.Text.Trim().Length > 0)
                        txtobs.Text = CmbApio.Text + " " + txtobs.Text.Trim();
                    else
                        txtobs.Text = CmbApio.Text + " ";
                }
                else
                    txtobs.Text = CmbApio.Text + " " + txtobs.Text.Trim();
                txtobs.Focus();
            }
        }

        private void SentToOutlook()
        {
            string destinatarios = "mdelrio@mrlucky.com.mx;mrhernandez@mrlucky.com.mx;musabiaga@mrlucky.com.mx;msamano@mrlucky.com.mx;armandog@mrlucky.com.mx;arturonieto@grupou.mx;omaraleman@mrlucky.com.mx;ochavez@grupou.mx;cmoreno@mrlucky.com.mx;comprasmp@mrlucky.com.mx;jantonio@grupou.mx;estebanm@grupou.mx;mprima@mrlucky.com.mx;armandog@mrlucky.com.mx";
            string subject = txtprod.Text.Trim() + " Recibo: " +  txtrecibo.Text + " Del Día:  " + lbfecha.Value.ToShortDateString() ;
            string body = //"<H3><p style='color: blue'>Envio Información Del Flete de Personal " + FolioFle.ToString() + " </p></H3>" + 
                        "Hola Buen día" + "<br><br>" + "<H3><p style='color: blue'>Envío información de la EVALUACION del RECIBO " + txtrecibo.Text + "  Flete: "+ txtflete.Text.Trim() +"</p></H3><br><br>" + 
                        "<table border=\"1\"> " +
                       "<tr> <TH bgcolor='lightblue' COLSPAN=3>" + txtprod.Text.Trim() + " </TH></TR> " +
                       //"<tr> <TH COLSPAN=3>TABLA: " + txttabla.Text.Trim() + "           VARIEDAD:  " + CBvariedad.Text  +" </TH></TR> " +
                       "<tr> <td ALING=LEFT bgcolor='lightgreen'>TABLA: " + txttabla.Text.Trim() + "</td> " +
                            "<td ALING=LEFT>           </td> " +
                            "<td ALING=LEFT bgcolor='lightgreen'>VARIEDAD:  " + CBvariedad.Text + " </td></tr> " +
                       "<tr> <td ALING=LEFT bgcolor='lightgreen'>LLEGARON: " + txtrmpnumenvase.Text.ToString() + " " + txtenv.Text.Trim() + "</td> " +
                            "<td ALING=LEFT>          </td> " +
                            "<td ALING=LEFT bgcolor='lightgreen'>PESO DE " + (Convert.ToDecimal(txtpesoutil.Text) / Convert.ToDecimal(txtrmpnumenvase.Text)).ToString("#,###.00") + " KG" + " </td></TR> " +
                       " <tr>   " +
                       " <th scope=\"col\">DAÑOS</strong></th> " +
                       " <th scope=\"col\">PESO MUESTRA "+ txtmuestrakg.Text +" KG</strong></th> " +
                       " <th scope=\"col\">% DAÑO</strong></th> " +
                       " </tr>";

            //<tr><td>NOMBRE UNO</td>10<td></td>5.00 %<td></td></tr> ";
            string cap = "";
            for (int i = 0; i < DGV1.Rows.Count; i++)
            {
                if (Convert.ToDecimal(DGV1.Rows[i].Cells[1].Value.ToString()) > 0)
                {
                cap += "<tr>" +
                       "<td ALING=LEFT>" + DGV1.Rows[i].Cells[0].Value.ToString().Trim() + "</td>" +
                       "<td ALING=CENTER>" + Convert.ToDecimal(DGV1.Rows[i].Cells[1].Value).ToString("#,##0.00") + " Kg</td>" +
                       "<td ALING=CENTER>" + Convert.ToDecimal(DGV1.Rows[i].Cells[2].Value).ToString("#,##0.00") + " %</td>" +
                       "</tr>";
                }
            }
            string mgra = "";
            if (Convert.ToDecimal(txtporgrado1.Text) > 0)
               mgra = "GRADO 1: " + Convert.ToDecimal(txtporgrado1.Text).ToString("#,###.00");
            if (Convert.ToDecimal(txtporgrado2.Text) > 0)
                mgra = mgra + ((mgra.Trim().Length > 0) ? "    ": "") + "GRADO 2:" + Convert.ToDecimal(txtporgrado2.Text).ToString("#,###.00");
            cap += "<tr>" +
                "<TH bgcolor='yellow' COLSPAN=3>"+ mgra + " %</strong></td>" +
                   "</tr></table><br><br>";
            cap += "<table border=\"1\"> " +
                   "<tr> <TH COLSPAN=1> INSECTOS </TH></TR> " +
                   "<tr>" +
                   "<td ALING=CENTER>" + txtdescrip.Text.Trim() + "</td>" +
                   "</tr></table>";
            body = body + cap ;
            //276132
            // Inicializar la aplicación de Outlook
            Outlook.Application outlookApp = new Outlook.Application();

            // Crear un nuevo correo
            Outlook.MailItem mail = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            mail.Subject = subject;
            mail.To = destinatarios;
            mail.BCC = "ricardo.cortes@mrlucky.com.mx";
            mail.HTMLBody = body;

            // Mostrar el correo para que el usuario lo edite
            mail.Display(false);
        }

        private string ValidaActualizacion()
        {
            string Actu = "N";
            if (File.Exists(@"\\gabira1\sisgabweb\Valida.txt"))
            {
                DateTime FechaLocal = File.GetLastWriteTime(@"c:\sisgabweb\Recepcion_MP.exe");
                DateTime FechaServer = File.GetLastWriteTime(@"\\gabira1\sisgabweb\Recepcion_MP.exe");
                if (FechaServer > FechaLocal)
                {
                    MessageBox.Show("Hay una VERSION MAS Reciente se va a Cerrar el Sistema para que se Actualice, hay que volver abrir el programa!!", "Actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return Actu = "S";
                }
            }
            return Actu;
        }

        private void Recepcion_mp_FormClosed(object sender, FormClosedEventArgs e)
        {
            string ArchDescarga = @"c:\sisgabweb\DownFile.exe";
            if (Actualizar == "S" && File.Exists(ArchDescarga))
            {
                string ArchNuevo = @"\\gabira1\sisgabweb\Recepcion_MP.exe";
                if (File.Exists(ArchNuevo))
                    //File.Copy(ArchNuevo, ArchViejo, true);
                    System.Diagnostics.Process.Start(@"c:\sisgabweb\DownFile.exe", "Recepcion_MP.exe");
            }
        }
    }
}
