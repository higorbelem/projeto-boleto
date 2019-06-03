using Newtonsoft.Json;
using ProjBoletos.components.ParteCimaBoleto;
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

        private FullBoletoLayout fullBoletoLayout;

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
            //fullBoletoLayout1.MakeBoleto(cedente,medicao);

            fullBoletoLayout = new FullBoletoLayout(cedente, medicao);

            fullBoletoLayout.AutoSize = true;
            fullBoletoLayout.BackColor = System.Drawing.SystemColors.Control;
            fullBoletoLayout.Location = new System.Drawing.Point(0, 0);
            fullBoletoLayout.Margin = new System.Windows.Forms.Padding(0);
            fullBoletoLayout.Name = "fullBoletoLayout1";
            fullBoletoLayout.Size = new System.Drawing.Size(292, 412);
            fullBoletoLayout.TabIndex = 0;
            fullBoletoLayout.Load += new System.EventHandler(this.fullBoletoLayout1_Load);

            panel1.Controls.Add(fullBoletoLayout);

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

            fullBoletoLayout.Location = new Point(0,0);
            fullBoletoLayout.Size = new Size(panel1.Width - SystemInformation.VerticalScrollBarWidth, panel1.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument pDoc = new PrintDocument();
            //pDoc.DefaultPageSettings.PaperSize = new PaperSize("A4",850, (int)(850 * Math.Sqrt(2)));
            pDoc.PrintPage += new PrintPageEventHandler(pDoc_PrintPageUnico);

            IEnumerable<PaperSize> paperSizes = pDoc.PrinterSettings.PaperSizes.Cast<PaperSize>();
            PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A4); // setting paper size to A4 size
            pDoc.DefaultPageSettings.PaperSize = sizeA4;
            pDoc.OriginAtMargins = false; //true = soft margins, false = hard margins

            //pDoc.DefaultPageSettings.Landscape = true;

            PrintDialog dlgPrinter = new PrintDialog();
            dlgPrinter.AllowSomePages = true;
            dlgPrinter.Document = pDoc;
            dlgPrinter.AllowPrintToFile = true;

            PrintPreviewDialog ppw = new PrintPreviewDialog();
            ppw.Document = pDoc;
            ppw.MdiParent = this.MdiParent;
            ppw.WindowState = FormWindowState.Maximized;

            ToolStripButton b = new ToolStripButton();
            //b.Image = Properties.Resources.PrintIcon;
            //b.DisplayStyle = ToolStripItemDisplayStyle.Image;
            b.Click += (object sender1 , EventArgs e1) => {
                if (dlgPrinter.ShowDialog() == DialogResult.OK)
                {
                    pDoc.Print();
                }
            };
            ((ToolStrip)(ppw.Controls[1])).Items.RemoveAt(0);
            ((ToolStrip)(ppw.Controls[1])).Items.Insert(0, b);

            ppw.ShowDialog();
            
            fullBoletoLayout.setSizes();

            /*if (dlgPrinter.ShowDialog() == DialogResult.OK)
            {
                pDoc.Print();
            }*/
        }

        void pDoc_PrintPageUnico(object sender, PrintPageEventArgs e)
        {
            try
            {
                //fullBoletoLayout.MakeBoleto(cedente, medicao);
                //fullBoletoLayout1.print(e.Graphics, new Rectangle((int)e.PageSettings.PrintableArea.X, (int)e.PageSettings.PrintableArea.Y, (int)e.PageSettings.PrintableArea.Width, (int)e.PageSettings.PrintableArea.Height));
                fullBoletoLayout.print(e.Graphics, e.PageBounds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
