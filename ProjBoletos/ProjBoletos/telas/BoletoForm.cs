using Newtonsoft.Json;
using ProjBoletos.modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.telas
{
    public partial class BoletoForm : Form
    {

        private Medicao medicao;
        private Cedente cedente;

        public BoletoForm(Medicao medicao)
        {
            InitializeComponent();

            this.medicao = medicao;

            var cedenteJson = Properties.Settings.Default["cedenteAtual"].ToString();
            cedente = JsonConvert.DeserializeObject<Cedente>(cedenteJson);
            if (cedente == null)
            {
                Application.Exit();
            }
            //Console.WriteLine(medicao.contaSelecionadaIndex + " " + medicao.carteiraSelecionada);
            fullBoletoLayout1.MakeBoleto(cedente,medicao);
        }

        private void BoletoForm_Load(object sender, EventArgs e)
        {
            BoletoForm_Resize(sender, e);
        }

        private void fullBoletoLayout1_Load(object sender, EventArgs e)
        {

        }

        private void BoletoForm_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(1,1);
            panel1.Size = new Size(ClientRectangle.Width + SystemInformation.VerticalScrollBarWidth - 2,ClientRectangle.Height-2);

            fullBoletoLayout1.Location = new Point(0,0);
            fullBoletoLayout1.Size = new Size(panel1.Width - SystemInformation.VerticalScrollBarWidth, panel1.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument pDoc = new PrintDocument();
            pDoc.DefaultPageSettings.PaperSize = new PaperSize("A4",1000, (int)(1000 * Math.Sqrt(2)));
            pDoc.PrintPage += new PrintPageEventHandler(pDoc_PrintPageUnico);

            //pDoc.DefaultPageSettings.Landscape = true;

            PrintDialog dlgPrinter = new PrintDialog();
            PrintPreviewDialog ppw = new PrintPreviewDialog();
            ppw.Document = pDoc;
            ppw.MdiParent = this.MdiParent;
            ppw.WindowState = FormWindowState.Maximized;

            ToolStripButton b = new ToolStripButton();
            //b.Image = Properties.Resources.PrintIcon;
            b.DisplayStyle = ToolStripItemDisplayStyle.Image;
            b.Click += (object sender1 , EventArgs e1) => {
                if (dlgPrinter.ShowDialog() == DialogResult.OK)
                {
                    pDoc.Print();
                }
            };
            ((ToolStrip)(ppw.Controls[1])).Items.RemoveAt(0);
            ((ToolStrip)(ppw.Controls[1])).Items.Insert(0, b);

            ppw.ShowDialog();

            /*if (dlgPrinter.ShowDialog() == DialogResult.OK)
            {
                pDoc.Print();
            }*/
        }

        void pDoc_PrintPageUnico(object sender, PrintPageEventArgs e)
        {
            try
            {
                fullBoletoLayout1.MakeBoleto(cedente, medicao);
                fullBoletoLayout1.print(e.Graphics, e.PageBounds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
