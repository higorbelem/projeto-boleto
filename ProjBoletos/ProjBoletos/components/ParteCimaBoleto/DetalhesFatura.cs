using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjBoletos.utils;
using ProjBoletos.modelos;

namespace ProjBoletos.components.ParteCimaBoleto {
   public partial class DetalhesFatura : UserControl {

      Rectangle rect1, rect2, rect3, rect4, rect5;
      Rectangle rect1Padding, rect2Padding, rect3Padding, rect4Padding, rect5Padding;

      private string valor1 = "";
      private string valor2 = "";
      private string valor3 = "";
      private string valor4 = "";
      private string valor5 = "";

      private int paddingLeftRight = 8;
      private int paddingTopBottom = 2;

      private int radius;
      private float lineWidth;

      public DetalhesFatura(Rectangle rect, int radius, float lineWidth) {
         InitializeComponent();

         this.radius = radius;
         this.lineWidth = lineWidth;

         rect1 = new Rectangle(rect.X, rect.Y, rect.Width / 5, rect.Height);
         rect2 = new Rectangle(rect1.X + rect1.Width, rect.Y, rect.Width / 5, rect.Height);
         rect3 = new Rectangle(rect2.X + rect2.Width, rect.Y, rect.Width / 5, rect.Height);
         rect4 = new Rectangle(rect3.X + rect3.Width, rect.Y, rect.Width / 5, rect.Height);
         rect5 = new Rectangle(rect4.X + rect4.Width, rect.Y, rect.Width / 5, rect.Height);

         rect1Padding = new Rectangle(rect.X + paddingLeftRight, rect.Y + paddingTopBottom, (rect.Width / 5) - paddingLeftRight * 2, rect.Height - paddingTopBottom * 2);
         rect2Padding = new Rectangle(rect1.X + rect1.Width + paddingLeftRight, rect.Y + paddingTopBottom, (rect.Width / 5) - paddingLeftRight * 2, rect.Height - paddingTopBottom * 2);
         rect3Padding = new Rectangle(rect2.X + rect2.Width + paddingLeftRight, rect.Y + paddingTopBottom, (rect.Width / 5) - paddingLeftRight * 2, rect.Height - paddingTopBottom * 2);
         rect4Padding = new Rectangle(rect3.X + rect3.Width + paddingLeftRight, rect.Y + paddingTopBottom, (rect.Width / 5) - paddingLeftRight * 2, rect.Height - paddingTopBottom * 2);
         rect5Padding = new Rectangle(rect4.X + rect4.Width + paddingLeftRight, rect.Y + paddingTopBottom, (rect.Width / 5) - paddingLeftRight * 2, rect.Height - paddingTopBottom * 2);
      }

      public DetalhesFatura(int radius, float lineWidth, Cedente cedente, Medicao medicao) {
         InitializeComponent();

         this.radius = radius;
         this.lineWidth = lineWidth;

         valor1 = medicao.sacado.id;
         valor2 = medicao.id;
         valor3 = medicao.dataMedicao.ToString("MM/yyyy");

         int diaVencimento = Int32.Parse(medicao.casa.diaVencimento); 
         DateTime vencimento = medicao.dataMedicao;
         if (diaVencimento < medicao.dataMedicao.Day) {
            vencimento = new DateTime(vencimento.Year, vencimento.AddMonths(1).Month, diaVencimento, vencimento.Hour, vencimento.Minute, vencimento.Second);
         } else {
            vencimento = new DateTime(vencimento.Year, vencimento.Month, diaVencimento, vencimento.Hour, vencimento.Minute, vencimento.Second);
         }
         valor4 = vencimento.ToString("dd/MM/yyyy");

         //Console.WriteLine(cedente.getValor(FaturaUtils.calculaValorMedicao(medicao)));

         valor5 = "R$ " + cedente.getValor(FaturaUtils.calculaValorMedicao(medicao));
      }

      public void setRect(Rectangle rect) {
         rect1 = new Rectangle(rect.X, rect.Y, rect.Width / 5, rect.Height);
         rect2 = new Rectangle(rect1.X + rect1.Width, rect.Y, rect.Width / 5, rect.Height);
         rect3 = new Rectangle(rect2.X + rect2.Width, rect.Y, rect.Width / 5, rect.Height);
         rect4 = new Rectangle(rect3.X + rect3.Width, rect.Y, rect.Width / 5, rect.Height);
         rect5 = new Rectangle(rect4.X + rect4.Width, rect.Y, rect.Width / 5, rect.Height);

         rect1Padding = new Rectangle(rect.X + paddingLeftRight, rect.Y + paddingTopBottom, (rect.Width / 5) - paddingLeftRight * 2, rect.Height - paddingTopBottom * 2);
         rect2Padding = new Rectangle(rect1.X + rect1.Width + paddingLeftRight, rect.Y + paddingTopBottom, (rect.Width / 5) - paddingLeftRight * 2, rect.Height - paddingTopBottom * 2);
         rect3Padding = new Rectangle(rect2.X + rect2.Width + paddingLeftRight, rect.Y + paddingTopBottom, (rect.Width / 5) - paddingLeftRight * 2, rect.Height - paddingTopBottom * 2);
         rect4Padding = new Rectangle(rect3.X + rect3.Width + paddingLeftRight, rect.Y + paddingTopBottom, (rect.Width / 5) - paddingLeftRight * 2, rect.Height - paddingTopBottom * 2);
         rect5Padding = new Rectangle(rect4.X + rect4.Width + paddingLeftRight, rect.Y + paddingTopBottom, (rect.Width / 5) - paddingLeftRight * 2, rect.Height - paddingTopBottom * 2);
      }

      public void render(Graphics g) {
         StringFormat format = new StringFormat();
         format.LineAlignment = StringAlignment.Near;
         format.Alignment = StringAlignment.Near;

         StringFormat formatValor = new StringFormat();
         formatValor.LineAlignment = StringAlignment.Far;
         formatValor.Alignment = StringAlignment.Center;

         System.Drawing.Drawing2D.GraphicsPath path = RoundedRectangles.Create(rect1, radius, true, false, true, false);
         g.DrawPath(new Pen(Colors.boletoLines, lineWidth), path);
         g.DrawString("Inscrição", Fonts.main7, new SolidBrush(Colors.boletoLines), rect1Padding, format);
         g.DrawString(valor1, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect1Padding, formatValor);

         g.DrawRectangle(new Pen(Colors.boletoLines, lineWidth), rect2);
         g.DrawString("N°. Fatura", Fonts.main7, new SolidBrush(Colors.boletoLines), rect2Padding, format);
         g.DrawString(valor2, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect2Padding, formatValor);

         g.DrawRectangle(new Pen(Colors.boletoLines, lineWidth), rect3);
         g.DrawString("Mês Referencia", Fonts.main7, new SolidBrush(Colors.boletoLines), rect3Padding, format);
         g.DrawString(valor3, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect3Padding, formatValor);

         g.FillRectangle(new SolidBrush(Colors.bg3), rect4);
         g.DrawRectangle(new Pen(Colors.boletoLines, lineWidth), rect4);
         g.DrawString("Vencimento", Fonts.main7, new SolidBrush(Colors.boletoLines), rect4Padding, format);
         g.DrawString(valor4, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect4Padding, formatValor);

         path = RoundedRectangles.Create(rect5, radius, false, true, false, true);
         g.FillPath(new SolidBrush(Colors.bg3), path);
         g.DrawPath(new Pen(Colors.boletoLines, lineWidth), path);
         g.DrawString("Total da Conta", Fonts.main7, new SolidBrush(Colors.boletoLines), rect5Padding, format);
         g.DrawString(valor5, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect5Padding, formatValor);
      }

      private void DetalhesFatura_Load(object sender, EventArgs e) {

      }
   }
}
