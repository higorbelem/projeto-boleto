using ProjBoletos.components;
using ProjBoletos.modelos;
using ProjBoletos.testes;
using ProjBoletos.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.telas.dialogs {
   public partial class GerarRemessaDialog : Form {

      private List<Remessa> remessas;
      private Form parentForm;

      public GerarRemessaDialog(List<Remessa> remessas, Form parentForm) {
         InitializeComponent();

         this.remessas = remessas;
         this.parentForm = parentForm;
      }

      private void GerarRemessaDialog_Load(object sender, EventArgs e) {
         BackColor = Colors.bg3;

         btnGerarTodos.BackColor = Colors.bg3;
         btnGerarTodos.title = "GERAR TODAS";
         btnGerarTodos.cornerRadius = 20;
         btnGerarTodos.Location = new Point((ClientRectangle.Width/2)-(btnGerarTodos.Width/2),10);

         flowLayoutPanel1.BackColor = Colors.bg3;
         flowLayoutPanel1.Location = new Point(ClientRectangle.X, btnGerarTodos.Location.Y + btnGerarTodos.Height + 10);
         flowLayoutPanel1.Size = new Size(ClientRectangle.Width + SystemInformation.VerticalScrollBarWidth, ClientRectangle.Height - flowLayoutPanel1.Location.Y - 20);

         int indexI = 0;
         foreach (Remessa remessa in remessas) {
            FlowLayoutPanel flow = new FlowLayoutPanel() {
               BackColor = Colors.bg2,
               Size = new Size(flowLayoutPanel1.Width - SystemInformation.VerticalScrollBarWidth, 0),
               MinimumSize = new Size(flowLayoutPanel1.Width - SystemInformation.VerticalScrollBarWidth, 0),
               MaximumSize = new Size(flowLayoutPanel1.Width - SystemInformation.VerticalScrollBarWidth, 0),
               AutoSize = true,
               Margin = new Padding(0,5,0,5)
            };

            Label labelRemessa = new Label() {
               Size = new Size(flow.Width, 30),
               Text = "Remessa " + (indexI + 1),
               ForeColor = Colors.primaryText,
               Font = Fonts.mainBold14,
               TextAlign = ContentAlignment.MiddleCenter,
               Margin = new Padding(0)
            };

            FlowLayoutPanel flowContaCarteiraLabel = new FlowLayoutPanel() {
               Size = new Size(flow.Width, 0),
               MinimumSize = new Size(flow.Width, 0),
               MaximumSize = new Size(flow.Width, 0),
               AutoSize = true,
               FlowDirection = FlowDirection.LeftToRight,
               Margin = new Padding(0)
            };
            flowContaCarteiraLabel.Controls.Add(new Label() {
               Size = new Size(flowContaCarteiraLabel.Width / 2 - 10, 30),
               Text = "Conta: " + remessa.conta,
               ForeColor = Colors.primaryText,
               Font = Fonts.main12,
               TextAlign = ContentAlignment.MiddleCenter,
               Margin = new Padding(0)
            });
            flowContaCarteiraLabel.Controls.Add(new Label() {
               Size = new Size(flowContaCarteiraLabel.Width / 2 - 10, 30),
               Text = "Carteira: " + remessa.carteira,
               ForeColor = Colors.primaryText,
               Font = Fonts.main12,
               TextAlign = ContentAlignment.MiddleCenter,
               Margin = new Padding(0)
            });
            
            flow.Controls.Add(labelRemessa);
            flow.Controls.Add(flowContaCarteiraLabel);
            flow.Controls.Add(new Separator() {
               Size = new Size(flow.Width - 30, 10),
               Margin = new Padding(15, 0, 15, 0)
            });

            int indexJ = 0;
            foreach (Medicao  medicao in remessa.medicoes) {
               Panel panel = new Panel() {
                  BackColor = Colors.bg2,
                  Size = new Size(flow.Width - 30, 70),
                  Margin = new Padding(15,5,15,5)
               };

               Panel panelDetalhesMedicao = new Panel() {
                  Location = new Point(panel.Location.X,panel.Location.Y),
                  Size = new Size((int)(panel.Width * 0.8),panel.Height),
               };
               panelDetalhesMedicao.Controls.Add(new Label() {
                  Location = new Point(panelDetalhesMedicao.Location.X, panelDetalhesMedicao.Location.Y),
                  Size = new Size(flowContaCarteiraLabel.Width, panelDetalhesMedicao.Height / 2),
                  Text = medicao.sacado.nome,
                  ForeColor = Colors.primaryText,
                  Font = Fonts.mainBold10,
                  TextAlign = ContentAlignment.BottomLeft,
                  Margin = new Padding(0)
               });
               panelDetalhesMedicao.Controls.Add(new Label() {
                  Location = new Point(panelDetalhesMedicao.Location.X, panelDetalhesMedicao.Location.Y + panelDetalhesMedicao.Height / 2),
                  Size = new Size(flowContaCarteiraLabel.Width, panelDetalhesMedicao.Height / 2),
                  Text = medicao.casa.rua + ", " + medicao.casa.numero,
                  ForeColor = Colors.primaryText,
                  Font = Fonts.mainBold10,
                  TextAlign = ContentAlignment.TopLeft,
                  Margin = new Padding(0)
               });

               MeuButton btnVer = new MeuButton() {
                  title = "VER",
                  Size = new Size((int)(panel.Width * 0.2), panel.Height/2),
                  Location = new Point(panelDetalhesMedicao.Location.X + panelDetalhesMedicao.Width, panel.Location.Y + (panel.Height/2) - (panel.Height/4))
               };
               btnVer.Click += new EventHandler((object s1, EventArgs e1) => {
                  BoletoForm boletoForm = new BoletoForm(medicao);
                  boletoForm.ShowDialog();
               });

               panel.Controls.Add(panelDetalhesMedicao);
               panel.Controls.Add(btnVer);

               flow.Controls.Add(panel);
               flow.Controls.Add(new Separator() {
                  Size = new Size(flow.Width - 30, 10),
                  Margin = new Padding(15, 0, 15, 0)
               });
               indexJ++;
            }

            MeuButton btnGerarRemessa = new MeuButton() {
               title = "GERAR REMESSA",
               cornerRadius = 20,
               Size = new Size(flow.Width - 140, 40),
               Margin = new Padding(70,0,70,15)
            };
            btnGerarRemessa.Click += new EventHandler((object s1, EventArgs e1) => {
               //asdadadadadadada
            });

            flow.Controls.Add(btnGerarRemessa);

            flowLayoutPanel1.Controls.Add(flow);
            indexI++;
         }
      }

      protected override void OnPaintBackground(PaintEventArgs e) {
         e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

         GraphicsPath path = RoundedRectangles.Create(new Rectangle(1, 1, ClientRectangle.Width - 2, ClientRectangle.Height - 2), 5, true, true, true, true);

         e.Graphics.FillPath(new SolidBrush(Colors.bg3), path);
      }

      private void btnGerarTodos_Click(object sender, EventArgs e) {
         //asdadadadadadada
      }

      protected override CreateParams CreateParams {
         get {
            const int CS_DROPSHADOW = 0x20000;
            CreateParams cp = base.CreateParams;
            cp.ClassStyle |= CS_DROPSHADOW;
            return cp;
         }
      }

      protected override void WndProc(ref Message m) {
         const UInt32 WM_NCACTIVATE = 0x0086;

         if (m.Msg == WM_NCACTIVATE && m.WParam.ToInt32() == 0) {
            //Application.OpenForms[parentForm.Name].Focus();
            //Console.WriteLine(parentForm.Name);

            this.Close();
            this.DialogResult = DialogResult.Cancel;
            //parentForm.Show();
            
            //ParentForm
         } else {
            base.WndProc(ref m);
         }
      }
   }
}
