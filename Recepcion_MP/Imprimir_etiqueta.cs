using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;

namespace Recepcion_MP
{
    public partial class Imprimir_etiqueta : Form
    {
        public Imprimir_etiqueta()
        {
            InitializeComponent();
            string ruta = @"C:\SisGabWeb\fondo_formularios.jpg";
            this.BackgroundImage = System.Drawing.Bitmap.FromFile(ruta); 
        }

        private void imprimir_etiqueta_mp()
        {
            if (recibo.Length < 6)
                recibo = "0" + recibo;

            PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            //pd.DefaultPageSettings.PaperSize = new PaperSize("etiqueta", 400, 300);
            //pd.DefaultPageSettings.PaperSize = new PaperSize("etiqueta", 400, 200);
            pd.PrintPage += new PrintPageEventHandler(this.Etiqueta_PrintPage);
            PrintPreviewDialog VistaPrevia = new PrintPreviewDialog();            
            VistaPrevia.Document = Etiqueta;
            //VistaPrevia.ShowDialog();
            pd.Print();                            
        }

        public static string recibo = "", fecha = "", numenvase = "", producto = "", proveedor = "", rancho = "", tabla = "", evaluador = "", variedad = "", observa = "", num_viaje = "", num_tar = "";
        public static int i = 1;
        public static bool estado = false;
        Image imagen = null;

        private void Etiqueta_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            num_tar = num_tar.Replace(".00", " ");
            if (i <= Convert.ToInt32(num_tar))
            {
                SolidBrush color = new SolidBrush(Color.Black);
                Font fuente = new Font("Courier", 8);
                Font cod_bar = new Font("PF Barcode 39", 30);//código de barras
                //Font cod_bar = new Font("PF Barcode 128", 30);//código de barras
                Font fuente1 = new Font("Courier", 4);
                Font fuente2 = new Font("Courier", 10);

                //recibo
                Point recib = new Point(10, 35);
                e.Graphics.DrawString(recibo, fuente2, color, recib);

                //fecha
                Point day = new Point(80, 40);
                e.Graphics.DrawString(fecha, fuente, color, day);

                //cantidad
                Point canti = new Point(150, 40);
                e.Graphics.DrawString("Cantidad " + numenvase.Replace(".00",""), fuente, color, canti);

                //producto
                Point produc = new Point(10, 53);
                e.Graphics.DrawString("Producto\t" + producto, fuente, color, produc);

                //proveedor
                Point prove = new Point(10, 66);
                e.Graphics.DrawString("Proveedor\t" + proveedor, fuente, color, prove);

                //rancho
                Point rchtbl = new Point(10, 79);
                e.Graphics.DrawString("Rancho   \t" + rancho + " -> " + tabla, fuente, color, rchtbl);

                //evaluador
                Point eva = new Point(10, 92);
                e.Graphics.DrawString("Evaluador\t" + evaluador, fuente, color, eva);

                //variedad
                Point vari = new Point(10, 105);
                e.Graphics.DrawString(variedad, fuente, color, vari);


                //observaciones
                Point obs = new Point(10, 118);
                e.Graphics.DrawString(observa, fuente, color, obs);

                //Text1
                Point text1 = new Point(20, 131);
                e.Graphics.DrawString(txt1.Text, fuente, color, text1);

                //text2
                if (!ChkEti.Checked)
                {
                    Point text2 = new Point(200, 131);
                    e.Graphics.DrawString(txt2.Text, fuente, color, text2);
                }
                else
                {
                    Point text2 = new Point(200, 118);
                    e.Graphics.DrawString(txt2.Text, fuente, color, text2);
                }
                int pos1 = 20, pos2 = 200;
                if (ChkEti.Checked)
                {
                  pos1 = 5; pos2 = 150;
                }

                if (checkBox1.Checked == true)
                {
                    //tipo de corte
                    Point text3 = new Point(pos1, 144);
                    e.Graphics.DrawString(txt3.Text, fuente, color, text3);
                    Point text7 = new Point(pos2, 144);
                    e.Graphics.DrawString(txt7.Text, fuente, color, text7);

                    //diametro std fresco
                    Point text4 = new Point(pos1, 157);
                    e.Graphics.DrawString(txt4.Text, fuente, color, text4);
                    Point text8 = new Point(pos2, 157);
                    e.Graphics.DrawString(txt8.Text, fuente, color, text8);

                    //%G1 FRESCO
                    Point text5 = new Point(pos1, 170);
                    e.Graphics.DrawString(txt5.Text, fuente, color, text5);
                    Point text9 = new Point(pos2, 170);
                    e.Graphics.DrawString(txt9.Text, fuente, color, text9);

                    //%G1 ENSALADAS
                    Point text6 = new Point(pos1, 183);
                    e.Graphics.DrawString(txt6.Text, fuente, color, text6);
                    Point text10 = new Point(pos2, 183);
                    e.Graphics.DrawString(txt10.Text, fuente, color, text10);
                }

                // SE MODIFICO POR LA EMERGENCIA DE QUE NO HABIA ETIQUETA DE CARTON RCC 26 MAY 2022
                if (!ChkEti.Checked)
                {
                    #region SI LA ETIQUETA ES DE 100 X 75 CARTON
                    //numero de etiquetas
                    Point nu_eti = new Point(150, 200);
                    e.Graphics.DrawString((i).ToString() + " De " + numenvase.Replace(".00", ""), fuente, color, nu_eti);

                    //código de barras 
                    Point bar_code = new Point(70, 220);
                    //Point bar_code = new Point(70, 220);
                    e.Graphics.DrawImage(imagen, bar_code);
                    //e.Graphics.DrawString("*" + recibo + "*", cod_bar, color, bar_code);

                    //viaje
                    Point viaj = new Point(10, 220);
                    e.Graphics.DrawString("Viaje\r\n " + num_viaje, fuente, color, viaj);

                    //recibo bajo el código de barras
                    //Point rec = new Point(150, 256);
                    //e.Graphics.DrawString("*" + recibo + "*", fuente, color, rec);

                    //LETRAS CHIQUITAS
                    Point extra1 = new Point(300, 256);
                    e.Graphics.DrawString("F-200-15\r\nREV: 01", fuente1, color, extra1);
                    #endregion
                }
                else
                {
                    #region SI LA ETIQUETA ES DE 100 X 50 PAPEL 
                    //numero de etiquetas
                    Point nu_eti = new Point(270, 130);
                    e.Graphics.DrawString((i).ToString() + " De " + numenvase.Replace(".00", ""), fuente, color, nu_eti);

                    //código de barras 
                    Point bar_code = new Point(200, 150);
                    //Point bar_code = new Point(70, 220);
                    e.Graphics.DrawImage(imagen, bar_code);
                    //e.Graphics.DrawString("*" + recibo + "*", cod_bar, color, bar_code);

                    //viaje
                    Point viaj = new Point(180, 170);
                    e.Graphics.DrawString("Viaje\r\n " + num_viaje, fuente, color, viaj);

                    //recibo bajo el código de barras
                    //Point rec = new Point(150, 256);
                    //e.Graphics.DrawString("*" + recibo + "*", fuente, color, rec);

                    //LETRAS CHIQUITAS
                    Point extra1 = new Point(350, 15);
                    e.Graphics.DrawString("F-200-15\r\nREV: 01", fuente1, color, extra1);
                    #endregion
                }
            }
            if (i == Convert.ToInt32(num_tar))
            {
                e.HasMorePages = false;
                i = 1;
            }
            else
                e.HasMorePages = true;

            i++;
        }

        private void btnimp_Click(object sender, EventArgs e)
        {
            if (Cbimp.SelectedIndex != -1)
            {
                //nivel detalle imprime todas las etiquetas
                if (Cbimp.SelectedIndex == 0)
                {
                    num_tar = numenvase;
                    imprimir_etiqueta_mp();
                }
                //nivel tarima, imprime etiquetas por tarima
                if (Cbimp.SelectedIndex == 1)
                {
                    //numenvase = num_tar;
                    if (LblTar.Text == "0")
                    {
                        MessageBox.Show("No se Puede Imprimir por Tarima ya que la Cantidad es 0, revise la informacion de Bascula que coincida el producto", "Etiquetas X Tarima", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    imprimir_etiqueta_mp();                    
                }
                i = 1;
            }
            else
            {
                MessageBox.Show("Favor de seleccionar impresión de etiquetas", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cbimp.Focus();
                return;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txt3.Visible = true;
                txt4.Visible = true;
                txt5.Visible = true;
                txt6.Visible = true;
                txt7.Visible = true;
                txt8.Visible = true;
                txt9.Visible = true;
                txt10.Visible = true;
            }
            else
            {
                txt3.Visible = false;
                txt4.Visible = false;
                txt5.Visible = false;
                txt6.Visible = false;
                txt7.Visible = false;
                txt8.Visible = false;
                txt9.Visible = false;
                txt10.Visible = false;
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Imprimir_etiqueta_Load(object sender, EventArgs e)
        {
            BarcodeLib.Barcode.Linear code39 = new BarcodeLib.Barcode.Linear();
            code39.Type = BarcodeLib.Barcode.BarcodeType.CODE128;
            code39.Data = recibo;
            code39.AddCheckSum = true;
            code39.UOM = BarcodeLib.Barcode.UnitOfMeasure.PIXEL;
            code39.BarHeight = 50;
            code39.BarWidth = 2;
            byte[] code93 = code39.drawBarcodeAsBytes();
            MemoryStream ms = new MemoryStream(code93);
            imagen = Image.FromStream(ms);
        }

        private void Cbimp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //LblTar.Visible = false;
            //if (Cbimp.Text == "Tarima")
            //{
            //    LblTar.Visible = true;
            //    LblTar.Text = (num_tar.Trim() == "") ? "0" : num_tar;
            //}
        }

        private void Cbimp_TextChanged(object sender, EventArgs e)
        {
            LblTar.Visible = false;
            if (Cbimp.Text == "Tarima")
            {
                LblTar.Visible = true;
                LblTar.Text = (num_tar.Trim() == "") ? "0" : num_tar;
            }
        }
    }
}
