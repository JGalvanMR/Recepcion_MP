using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Recepcion_MP
{
    public partial class anticipadas : Form
    {
        SqlConnection thisConnection = new SqlConnection(Utilerias.Class1.ConnectionString);
        SqlCommand cmnd1;
        SqlDataReader reader1;
        SqlDataAdapter adapter1;
        DataSet ds = new DataSet();

        string clav = "";
        string prov = "";
        string prod = "";
        string gra1 = "";
        string gra2 = "";
        string nprov = "";
        string nprod = "";
        string pgdo1 = "";
        string pgdo2 = "";

        public anticipadas(string cv, string pv, string pd, string g1, string g2, string npv, string npd)
        {
            InitializeComponent();

            string ruta = @"C:\SisGabWeb\fondo_formularios.jpg";
            this.BackgroundImage = System.Drawing.Bitmap.FromFile(ruta);

            clav = cv;
            prov = pv;
            prod = pd;
            gra1 = g1;
            gra2 = g2;
            nprov = npv;
            nprod = npd;


            lblRecibo.Text = clav;
            txtGrado1.Text = g1;
            txtGrado2.Text = g2;
            lblCveProv.Text = prov;
            lblCveProd.Text = prod;
            lblProveedor.Text = nprov;
            lblProducto.Text = nprod;

            //adapter1 = new SqlDataAdapter(
            //    "select A.numero_oc, A.fecha_recepcion, B.cantidad_oc, B.surtido_oc FROM tb_mstr_ordencompra A join tb_det_ordenescompra B on A.numero_oc = B.numero_oc where A.anticipada = '1' " +
            //    "and A.status_oc = 'A' AND A.factura_oc = 'MATERIAP' AND B.surtido_oc < B.cantidad_oc and A.cveprov_oc = '" + prov + "' and A.cveprod_oc = '" + prod + "' AND a.liquidacion = 'GRADO1' " +
            //    "AND LEN(B.prod_clave) > 4  AND A.fecha_recepcion <= '" + DateTime.Now.ToShortDateString() + "' order by A.fecha_recepcion ASC",
            //    thisConnection
            //    );
            adapter1 = new SqlDataAdapter("select A.numero_oc, A.fecha_recepcion, B.cantidad_oc, B.precio_oc,/*B.surtido_oc,*/ " +
                "(select ISNULL(sum(hrp_clase1), 0) from tb_hist_recepcion C " +
                "where C.hrp_numoc = A.numero_oc AND hrp_estatus <> 'C' AND C.prod_clave = B.prod_clave AND C.hrp_tipo_recepcion <> 'C') AS surtido_oc " +
                "FROM tb_mstr_ordencompra A " + 
                "join tb_det_ordenescompra B on A.numero_oc = B.numero_oc " + 
                "where A.anticipada = '1' " +
                "and A.status_oc = 'A' AND A.factura_oc = 'MATERIAP' AND (select ISNULL(sum(hrp_clase1), 0) from tb_hist_recepcion C " +
                "where C.hrp_numoc = A.numero_oc AND hrp_estatus <> 'C' AND C.prod_clave = B.prod_clave AND C.hrp_tipo_recepcion <> 'C') < B.cantidad_oc " +
                "and A.cveprov_oc = '" + prov + "' and B.prod_clave = '" + prod + "' AND a.liquidacion = 'GRADO1' " + //A.cveprod_oc
                "AND LEN(B.prod_clave) > 4  AND A.fecha_recepcion <= '" + DateTime.Now.ToShortDateString() + "' " +
                "order by A.fecha_recepcion ASC",
                thisConnection);
            adapter1.SelectCommand.CommandTimeout = 0;
            adapter1.Fill(ds, "ordenesg1");

            //adapter1 = new SqlDataAdapter(
            //    "select A.numero_oc, A.fecha_recepcion, B.cantidad_oc, B.surtido_oc FROM tb_mstr_ordencompra A join tb_det_ordenescompra B on A.numero_oc = B.numero_oc where A.anticipada = '1' " +
            //    "and A.status_oc = 'A' AND A.factura_oc = 'MATERIAP' AND B.surtido_oc < B.cantidad_oc and A.cveprov_oc = '" + prov + "' and A.cveprod_oc = '" + prod + "' AND a.liquidacion = 'GRADO2' " +
            //    "AND LEN(B.prod_clave) > 4 AND A.fecha_recepcion <= '" + DateTime.Now.ToShortDateString() + "' order by A.fecha_recepcion ASC",
            //    thisConnection
            //    );
            adapter1 = new SqlDataAdapter("select A.numero_oc, A.fecha_recepcion, B.cantidad_oc, B.precio_oc, /*B.surtido_oc,*/ " +
                "(select ISNULL(sum(hrp_clase2), 0) from tb_hist_recepcion C " +
                "where C.hrp_numoc_g2 = A.numero_oc AND hrp_estatus <> 'C' AND C.prod_clave = B.prod_clave AND C.hrp_tipo_recepcion <> 'C') AS surtido_oc " +
                "FROM tb_mstr_ordencompra A " +
                "join tb_det_ordenescompra B on A.numero_oc = B.numero_oc " +
                "where A.anticipada = '1' " +
                "and A.status_oc = 'A' AND A.factura_oc = 'MATERIAP' AND (select ISNULL(sum(hrp_clase2), 0) from tb_hist_recepcion C " +
                "where C.hrp_numoc_g2 = A.numero_oc AND hrp_estatus <> 'C' AND C.prod_clave = B.prod_clave AND C.hrp_tipo_recepcion <> 'C') < B.cantidad_oc " +
                "and A.cveprov_oc = '" + prov + "' and B.prod_clave = '" + prod + "' AND a.liquidacion = 'GRADO2' " + //A.cveprod_oc
                "AND LEN(B.prod_clave) > 4  AND A.fecha_recepcion <= '" + DateTime.Now.ToShortDateString() + "' " +
                "order by A.fecha_recepcion ASC",
                thisConnection);
            adapter1.SelectCommand.CommandTimeout = 0;
            adapter1.Fill(ds, "ordenesg2");

            foreach (DataRow rw in ds.Tables["ordenesg1"].Rows)
            {
                dtgGrado1.Rows.Add(rw["numero_oc"].ToString().Trim(), Convert.ToDateTime(rw["fecha_recepcion"].ToString().Trim()).ToShortDateString(), Convert.ToDecimal(rw["cantidad_oc"].ToString().Trim()).ToString("###,##0.00"),
                    Convert.ToDecimal(rw["surtido_oc"].ToString().Trim()).ToString("###,##0.00"), Convert.ToDecimal(rw["precio_oc"].ToString().Trim()).ToString("###,##0.00"));
            }

            foreach (DataRow rw in ds.Tables["ordenesg2"].Rows)
            {
                dtgGrado2.Rows.Add(rw["numero_oc"].ToString().Trim(), Convert.ToDateTime(rw["fecha_recepcion"].ToString().Trim()).ToShortDateString(), Convert.ToDecimal(rw["cantidad_oc"].ToString().Trim()).ToString("###,##0.00"),
                    Convert.ToDecimal(rw["surtido_oc"].ToString().Trim()).ToString("###,##0.00"), Convert.ToDecimal(rw["precio_oc"].ToString().Trim()).ToString("###,##0.00"));
            }

        }

        private void dtgGrado1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblOrdenCompra.Text = dtgGrado1.CurrentRow.Cells[0].Value.ToString();
            lblFecha.Text = dtgGrado1.CurrentRow.Cells[1].Value.ToString();
            lblCantidad.Text = dtgGrado1.CurrentRow.Cells[2].Value.ToString();
            lblSurtido.Text = dtgGrado1.CurrentRow.Cells[3].Value.ToString();
            lblCosto.Text = dtgGrado1.CurrentRow.Cells[4].Value.ToString();
        }

        private void dtgGrado2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblOrdenCompra2.Text = dtgGrado2.CurrentRow.Cells[0].Value.ToString();
            lblFecha2.Text = dtgGrado2.CurrentRow.Cells[1].Value.ToString();
            lblCantidad2.Text = dtgGrado2.CurrentRow.Cells[2].Value.ToString();
            lblSurtido2.Text = dtgGrado2.CurrentRow.Cells[3].Value.ToString();
            lblCosto2.Text = dtgGrado2.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ////if (Convert.ToDecimal(txtGrado1.Text) > 0)
            ////{
            ////    if (lblOrdenCompra.Text == "-")
            ////    {
            ////        MessageBox.Show("Debe seleccionar la orden de compra anticipada (GRADO 1)", "SIPGAB", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////        return;
            ////    }
            ////}
            ////if (Convert.ToDecimal(txtGrado2.Text) > 0)
            ////{
            ////    if (lblOrdenCompra2.Text == "-")
            ////    {
            ////        MessageBox.Show("Debe seleccionar la orden de compra anticipada (GRADO 2)", "SIPGAB", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////        return;
            ////    }
            ////}

            
            //comentado 27/12/2022
            //if (dtgGrado1.Rows.Count > 0)
            //{
            //    if (lblOrdenCompra.Text == "-")
            //    {
            //        MessageBox.Show("Debe seleccionar la orden de compra anticipada (GRADO 1)", "SIPGAB", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //}
            //if (dtgGrado2.Rows.Count > 0)
            //{
            //    if (lblOrdenCompra2.Text == "-")
            //    {
            //        MessageBox.Show("Debe seleccionar la orden de compra anticipada (GRADO 2)", "SIPGAB", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //}

            if (Convert.ToDecimal(txtGrado1.Text) > 0)
            {
                if (lblOrdenCompra.Text == "-")
                {
                    MessageBox.Show("Debe seleccionar la orden de compra anticipada (GRADO 1)", "SIPGAB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (Convert.ToDecimal(txtGrado2.Text) > 0)
            {
                if (lblOrdenCompra.Text == "-")
                {
                    MessageBox.Show("Debe seleccionar la orden de compra anticipada (GRADO 2)", "SIPGAB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            datos val = new datos();
            //if (lblCantidad.Text != "-")
            //{
                val.ocg1 = lblOrdenCompra.Text;
            //}
            //if (lblCantidad2.Text != "-")
            //{
                val.ocg2 = lblOrdenCompra2.Text;
            //}
                val.estado = "1";
                val.costo1 = lblCosto.Text;
                val.costo2 = lblCosto2.Text;
            SharedDatos.DatosCell = val;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

            
        }

        public class datos
        {
            private String _ocg1;
            public String ocg1
            {
                get { return _ocg1; }
                set { _ocg1 = value; }
            }

            private String _ocg2;
            public String ocg2
            {
                get { return _ocg2; }
                set { _ocg2 = value; }
            }

            private String _estado;
            public String estado
            {
                get { return _estado; }
                set { _estado = value; }
            }

            private String _costo1;
            public String costo1
            {
                get { return _costo1; }
                set { _costo1 = value; }
            }

            private String _costo2;
            public String costo2
            {
                get { return _costo2; }
                set { _costo2 = value; }
            }
        }

        public class SharedDatos
        {
            public static datos DatosCell;
        }

        private void anticipadas_Load(object sender, EventArgs e)
        {

        }
    }
}
