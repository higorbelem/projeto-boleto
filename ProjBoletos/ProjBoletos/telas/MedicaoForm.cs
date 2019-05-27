using ProjBoletos.modelos;
using ProjBoletos.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.telas
{
    public partial class MedicaoForm : Form
    {

        Padding padding = new Padding(70, 10, 70, 40);

        Medicao medicao;

        public MedicaoForm(Medicao medicao)
        {
            InitializeComponent();

            this.medicao = medicao;

            BackColor = Colors.bg;

            panelMaster.MouseWheel += new MouseEventHandler(this.MedicaoForm_MouseWheel);
        }

        private void MedicaoForm_Load(object sender, EventArgs e)
        {
            boxMedicao.shadowSize = 5;
            boxMedicao.radius = 20;
            boxCasa.shadowSize = 5;
            boxCasa.radius = 20;
            boxCliente.shadowSize = 5;
            boxCliente.radius = 20;
            boxMedidor.shadowSize = 5;
            boxMedidor.radius = 20;

            MedicaoForm_Resize(sender, e);
        }

        private void MedicaoForm_Resize(object sender, EventArgs e)
        {
            panelMaster.BackColor = Colors.bg;
            panelMaster.Location = new Point(0, 0);
            panelMaster.Size = new Size(ClientRectangle.Width + SystemInformation.VerticalScrollBarWidth, ClientRectangle.Height);

            panelMasterInterno.BackColor = Colors.bg;
            panelMasterInterno.Location = new Point(0, 0);
            panelMasterInterno.MaximumSize = new Size(ClientRectangle.Width, 0);

            Rectangle newSize = new Rectangle(padding.Left, padding.Top, ClientRectangle.Width - padding.Left - padding.Right, ClientRectangle.Height - padding.Top - padding.Bottom);

            labelTitulo.Location = new Point(100,newSize.Y + 20);
            labelTitulo.BackColor = Colors.bg;
            labelTitulo.ForeColor = Colors.headerText;

            setupMedicao(new Rectangle(newSize.X, labelTitulo.Location.Y + labelTitulo.Height + 10, newSize.Width, newSize.Height));
            setupCasa(new Rectangle(newSize.X,boxMedicao.Location.Y + boxMedicao.Height + 10, newSize.Width, newSize.Height));
            setupCliente(new Rectangle(newSize.X, boxCasa.Location.Y + boxCasa.Height + 10, newSize.Width, newSize.Height));
            setupMedidor(new Rectangle(newSize.X, boxCliente.Location.Y + boxCliente.Height + 10, newSize.Width, newSize.Height));

            customScrollbar1.backgroundColor = Color.White;
            customScrollbar1.color = Colors.accent1;
            customScrollbar1.btnsColor = Colors.accent1Secondary;
            customScrollbar1.Size = new Size(10, panelMaster.Height);
            customScrollbar1.Location = new Point(ClientRectangle.Width - 10, panelMasterInterno.Location.Y);
            customScrollbar1.Minimum = 0;
            customScrollbar1.Maximum = panelMasterInterno.Height;
            customScrollbar1.LargeChange = customScrollbar1.Maximum / customScrollbar1.Height + panelMaster.Height;
            customScrollbar1.SmallChange = 15;
            customScrollbar1.Value = Math.Abs(panelMaster.AutoScrollPosition.Y);
        }

        private void setupMedidor(Rectangle newSize)
        {
            FlowLayoutPanel flowMedidior = new FlowLayoutPanel();

            boxMedidor.color = Color.White;
            boxMedidor.Location = new Point(newSize.X, newSize.Y);
            boxMedidor.Size = new Size(newSize.Width, 0);

            flowMedidior.AutoSize = true;
            flowMedidior.FlowDirection = FlowDirection.TopDown;
            flowMedidior.BackColor = Color.White;
            flowMedidior.Location = new Point(50, 50);
            flowMedidior.Size = new Size(boxMedidor.Width - 100, 0);
            flowMedidior.Controls.Add(new Label()
            {
                Text = "MEDIDOR",
                Size = new Size(flowMedidior.Width, 30),
                Font = Fonts.mainBold12,
                ForeColor = Colors.secondaryHeaderText
            });
            flowMedidior.Controls.Add(new Label()
            {
                Text = "NOME: " + medicao.medidor.nome + "      DOCUMENTO: " + medicao.medidor.cpf,
                Size = new Size(flowMedidior.Width, 30),
                Font = Fonts.mainBold10,
                ForeColor = Colors.primaryText
            });
            boxMedidor.Controls.Add(flowMedidior);

            boxMedidor.MinimumSize = new Size(0, flowMedidior.Height + 100);
        }

        private void setupCliente(Rectangle newSize)
        {
            FlowLayoutPanel flowCliente = new FlowLayoutPanel();

            boxCliente.color = Color.White;
            boxCliente.Location = new Point(newSize.X, newSize.Y);
            boxCliente.Size = new Size(newSize.Width, 0);

            flowCliente.AutoSize = true;
            flowCliente.FlowDirection = FlowDirection.TopDown;
            flowCliente.BackColor = Color.White;
            flowCliente.Location = new Point(50, 50);
            flowCliente.Size = new Size(boxCliente.Width - 100, 0);
            flowCliente.Controls.Add(new Label()
            {
                Text = "CLIENTE",
                Size = new Size(flowCliente.Width, 30),
                Font = Fonts.mainBold12,
                ForeColor = Colors.secondaryHeaderText
            });
            flowCliente.Controls.Add(new Label()
            {
                Text = "NOME: " + medicao.sacado.nome + "      DOCUMENTO: " + medicao.sacado.documento,
                Size = new Size(flowCliente.Width, 30),
                Font = Fonts.mainBold10,
                ForeColor = Colors.primaryText
            });
            flowCliente.Controls.Add(new Label()
            {
                Text = "EMAIL: " + medicao.sacado.email,
                Size = new Size(flowCliente.Width, 30),
                Font = Fonts.mainBold10,
                ForeColor = Colors.primaryText
            });
            boxCliente.Controls.Add(flowCliente);

            boxCliente.MinimumSize = new Size(0, flowCliente.Height + 100);
        }

        private void setupCasa(Rectangle newSize)
        {
            FlowLayoutPanel flowCasa = new FlowLayoutPanel();

            boxCasa.color = Color.White;
            boxCasa.Location = new Point(newSize.X, newSize.Y);
            boxCasa.Size = new Size(newSize.Width, 0);

            flowCasa.AutoSize = true;
            flowCasa.FlowDirection = FlowDirection.TopDown;
            flowCasa.BackColor = Color.White;
            flowCasa.Location = new Point(50, 50);
            flowCasa.Size = new Size(boxCasa.Width - 100, 0);
            flowCasa.Controls.Add(new Label()
            {
                Text = "CASA",
                Size = new Size(flowCasa.Width, 30),
                Font = Fonts.mainBold12,
                ForeColor = Colors.secondaryHeaderText
            });
            flowCasa.Controls.Add(new Label()
            {
                Text = "ENDEREÇO: " + medicao.casa.rua + ", " + medicao.casa.numero + "      BAIRRO: " + medicao.casa.bairro + "      CIDADE: " + medicao.casa.cidade,
                Size = new Size(flowCasa.Width, 30),
                Font = Fonts.mainBold10,
                ForeColor = Colors.primaryText
            });
            flowCasa.Controls.Add(new Label()
            {
                Text = "UF: " + medicao.casa.uf + "      CEP: " + medicao.casa.cep,
                Size = new Size(flowCasa.Width, 30),
                Font = Fonts.mainBold10,
                ForeColor = Colors.primaryText
            });
            flowCasa.Controls.Add(new Label()
            {
                Text = "NÚMERO DO HIDRÔMETRO: " + medicao.casa.numHidrometro,
                Size = new Size(flowCasa.Width, 30),
                Font = Fonts.mainBold10,
                ForeColor = Colors.primaryText
            });
            flowCasa.Controls.Add(new Label()
            {
                Text = "DIA DO VENCIMENTO: " + medicao.casa.diaVencimento,
                Size = new Size(flowCasa.Width, 30),
                Font = Fonts.mainBold10,
                ForeColor = Colors.primaryText
            });
            boxCasa.Controls.Add(flowCasa);

            boxCasa.MinimumSize = new Size(0, flowCasa.Height + 100);
        }

        private void setupMedicao(Rectangle newSize)
        {
            FlowLayoutPanel flowMedicao = new FlowLayoutPanel();

            boxMedicao.color = Color.White;
            boxMedicao.Location = new Point(newSize.X, newSize.Y);
            boxMedicao.Size = new Size(newSize.Width, 0);

            flowMedicao.AutoSize = true;
            flowMedicao.FlowDirection = FlowDirection.TopDown;
            flowMedicao.BackColor = Color.White;
            flowMedicao.Location = new Point(50, 50);
            flowMedicao.Size = new Size(boxMedicao.Width - 100, 0);
            flowMedicao.Controls.Add(new Label()
            {
                Text = "MEDIÇÃO",
                Size = new Size(flowMedicao.Width, 30),
                Font = Fonts.mainBold12,
                ForeColor = Colors.secondaryHeaderText
            });
            flowMedicao.Controls.Add(new Label()
            {
                Text = "DATA: " + medicao.dataMedicao.ToString() + "      VALOR: " + medicao.medicao + " m³",
                Size = new Size(flowMedicao.Width, 30),
                Font = Fonts.mainBold10,
                ForeColor = Colors.primaryText
            });
            boxMedicao.Controls.Add(flowMedicao);

            boxMedicao.MinimumSize = new Size(0, flowMedicao.Height + 100);
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void customScrollbar1_Scroll(object sender, EventArgs e)
        {
            panelMaster.AutoScrollPosition = new Point(0, customScrollbar1.Value);
            customScrollbar1.Invalidate();
            Application.DoEvents();
        }

        private void MedicaoForm_MouseWheel(object sender, MouseEventArgs e)
        {
            Console.WriteLine("asdasdas");
            customScrollbar1.Value = panelMaster.VerticalScroll.Value;
            customScrollbar1.Invalidate();
            Application.DoEvents();
        }
    }
}
