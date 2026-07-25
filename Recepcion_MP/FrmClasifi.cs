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
    public partial class FrmClasifi : Form
    {
        SqlConnection ThisConeccion = new SqlConnection(Utilerias.Class1.ConnectionString);
        public string Cve;
        public string Nombre;
        public string Folio;
        public string Linea;
        public DataTable Productos = new DataTable();
        public string Prove;
        decimal CjsRec = 0, KgsRec = 0;


        public FrmClasifi()
        {
            InitializeComponent();
        }

        private void PBbtnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmClasifi_Load(object sender, EventArgs e)
        {
            LblCveProd.Text = Cve;
            LblFolio.Text = Folio;
            LblProd.Text = Nombre;
            LblProv.Text = Prove;
            ThisConeccion.Open();
            string Cadena = "Select A.PROD_CLAVE, B.PROD_NOMBRE, A.RMP_UNIDADES,A.RMP_PESO, A.RMP_CJS_CLAS from TB_DET_RECEPCION_MP A, TB_CAT_PRODUCTO B where RMP_RECIBO = '" + Folio + "' and A.PROD_CLAVE = B.PROD_CLAVE";
            SqlDataAdapter da = new SqlDataAdapter(Cadena,ThisConeccion);
            DataSet ds = new DataSet();
            da.Fill(ds,"Info");
            DataTable Info = ds.Tables["Info"];

            if (Info.Rows.Count > 0)
            {
                decimal Cjs = 0, kg = 0;

                foreach (DataRow Row in Info.Rows)
                {
                    DGDatos.Rows.Add(Row["PROD_CLAVE"].ToString(), Row["PROD_NOMBRE"].ToString(), Row["RMP_UNIDADES"].ToString(), Row["RMP_PESO"].ToString());
                    Cjs += Convert.ToDecimal(Row["RMP_UNIDADES"]);
                    kg += Convert.ToDecimal(Row["RMP_PESO"]);
                    TxtUtil.Text = Row["RMP_CJS_CLAS"].ToString();
                }
                TxtTotCan.Text = Cjs.ToString("##,###.#");
                TxtTotKg.Text = kg.ToString("#,###,##0.00");
                DGDatos.ReadOnly = true;
                TxtUtil.Enabled = false;
                txtprod_clave.Enabled = false;
                txtprod.Enabled = false;
            }
            
            foreach (DataRow Row in Productos.Select("LIN_CLAVE = '" + Linea + "' AND PROD_TIPO = 'MP'"))
                   txtprod.Items.Add(Row["Prod_Nombre"].ToString());
            Cadena = "Select hrp_reman_kg, hrp_reman_unidades, hrp_num_unidades, hrp_peso_util  from tb_hist_recepcion where hrp_recibo = '" + Folio + "' and hrp_tipo_recepcion = 'MP'";
            da = new SqlDataAdapter(Cadena, ThisConeccion);
            ds = new DataSet();
            da.Fill(ds, "Tb_hist");
            foreach (DataRow Row in ds.Tables["tb_hist"].Rows)
            {
                TxtCan.Text = Row["hrp_reman_unidades"].ToString();
                TxtKg.Text = Row["hrp_reman_kg"].ToString();
                CjsRec = Convert.ToDecimal(Row["hrp_num_unidades"]);
                KgsRec = Convert.ToDecimal(Row["hrp_peso_util"]);
            }
            ThisConeccion.Close();
        }

        private void txtprod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (DataRow row in Productos.Select("prod_nombre = '" + txtprod.SelectedItem.ToString().Trim() + "'"))
            {
                //linea = Convert.ToString(row["lin_clave"].ToString().Trim());
                txtprod_clave.Text = Convert.ToString(row["prod_clave"].ToString().Trim());
                txtprod_clave.Focus();
            }
        }

        private void txtprod_clave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                foreach(DataGridViewRow  Row in DGDatos.Rows)
                    if (Row.Cells["CVEMP"].Value.ToString().Trim() == txtprod_clave.Text.Trim())
                    {
                        MessageBox.Show(txtprod.Text + " YA FUE AGREGADO!!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                DGDatos.Rows.Add(txtprod_clave.Text, txtprod.Text, 0, 0); 
            }
        }

        private void TxtUtil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (Convert.ToDecimal(TxtUtil.Text) > Convert.ToDecimal(TxtCan.Text))
                {
                    MessageBox.Show("Se Estan Tomando mas canastillas que las Disponible", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtUtil.Text = "";
                    BtnGraba.Visible = false;
                    return;
                }
                txtprod.Focus();
                BtnGraba.Visible = true;

            }
        }

        private void DGDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3) // captura de las canastillas
            {
                if (e.ColumnIndex == 2) // valido que no capture mas canastillas a las seleccionadas
                {
                    if (Convert.ToDecimal(DGDatos.CurrentRow.Cells["CANASTILLAS"].Value) > Convert.ToDecimal(TxtUtil.Text))
                    {
                        MessageBox.Show("Se Estan Tomando mas Canastillas que las Unidades a Clasificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        DGDatos.CurrentRow.Cells["CANASTILLAS"].Value = 0;
                        DGDatos.CurrentRow.Cells["KGs"].Value = 0;
                        BtnGraba.Visible = false;
                        return;
                    }
                }
                if (Convert.ToDecimal(DGDatos.CurrentRow.Cells["KGs"].Value) == 0)
                  DGDatos.CurrentRow.Cells["KGs"].Value = Math.Round((Convert.ToDecimal(TxtKg.Text) / Convert.ToDecimal(TxtCan.Text)) * Convert.ToDecimal(DGDatos.CurrentRow.Cells["CANASTILLAS"].Value),2); 
                suma();
            }
        }

        private void suma()
        {
            decimal Cjs = 0, kg = 0;
            foreach (DataGridViewRow Row in DGDatos.Rows)
            {
                Cjs += Convert.ToDecimal(Row.Cells["CANASTILLAS"].Value);
                kg += Convert.ToDecimal(Row.Cells["KGS"].Value);

            }
            TxtTotCan.Text = Cjs.ToString("##,###.#");
            TxtTotKg.Text = kg.ToString("#,###,##0.00");
            if (kg > Convert.ToDecimal(TxtKg.Text))
            {
                MessageBox.Show("ERROR: Se estan capturando mas Kilos que los disponible!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BtnGraba.Visible = false;
            }
            else
                BtnGraba.Visible = true;
        }

        private void BtnGraba_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(TxtUtil.Text) > 0 && Convert.ToDecimal(TxtKg.Text) >= Convert.ToDecimal(TxtTotKg.Text))
            {
                ThisConeccion.Open();
                string Cadena = "";
                SqlCommand cmd;
                int I = 0;
                string Cve = "", Cjs = "", Kg = "";
                foreach (DataGridViewRow Row in DGDatos.Rows)
                {
                    Cve = DGDatos.Rows[I].Cells["CVEMP"].Value.ToString();
                    Cjs = DGDatos.Rows[I].Cells["CANASTILLAS"].Value.ToString();
                    Kg = DGDatos.Rows[I].Cells["KGS"].Value.ToString();
                    Cadena = "INSERT INTO TB_DET_RECEPCION_MP(RMP_RECIBO,LIN_CLAVE,PROD_CLAVE,RMP_UNIDADES,RMP_PESO,RMP_EXIS_UNI,RMP_EXIS_PESO,RMP_CJS_CLAS) " +
                             "VALUES('" + Folio + "','" + Linea + "','" + Cve + "','" + Cjs + "','" + Kg + "','" + Cjs + "','" + Kg + "','" + TxtUtil.Text + "')";
                    cmd = new SqlCommand(Cadena, ThisConeccion);
                    cmd.ExecuteNonQuery();
                    I++;
                }
                Cadena = "UPDATE TB_HIST_RECEPCION SET HRP_REMAN_UNIDADES = HRP_REMAN_UNIDADES - '" + TxtUtil.Text + "'," +
                             " HRP_REMAN_KG = HRP_REMAN_KG - '" + ((KgsRec / CjsRec) * Convert.ToDecimal(TxtUtil.Text)).ToString() + "'" +
                             " WHERE HRP_RECIBO = '" + Folio + "' AND HRP_TIPO_RECEPCION = 'MP'";
                cmd = new SqlCommand(Cadena, ThisConeccion);
                cmd.ExecuteNonQuery();
                if (Convert.ToDecimal(TxtCan.Text) == Convert.ToDecimal(TxtUtil.Text))
                {
                    Cadena = "UPDATE TB_HIST_RECEPCION SET HRP_ESTATUS = 'F' WHERE HRP_RECIBO = '" + Folio + "' AND HRP_TIPO_RECEPCION = 'MP'";
                    cmd = new SqlCommand(Cadena, ThisConeccion);
                    cmd.ExecuteNonQuery();
                }
                ThisConeccion.Close();
            }
            else
            {
                MessageBox.Show("ERROR: FAVOR DE REVISAR LAS UNIDADES A UTILIZAR Y EL TOTAL DE KILOS CLASIFICADOS", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            MessageBox.Show("DATOS GRABADOS CON EXITO!!!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnGraba.Enabled = false;
        }
               
    }
}
