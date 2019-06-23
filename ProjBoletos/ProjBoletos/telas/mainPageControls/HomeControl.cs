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

namespace ProjBoletos.telas.mainPageControls {
   public partial class HomeControl : UserControl {

      public HomeControl() {
         InitializeComponent();
         //Console.WriteLine("constr: " + Width);
      }

      private void HomeControl_Load(object sender, EventArgs e) {
         //Console.WriteLine("onload: " + Width);
         //int cardWidth = (this.Width / quantCards) - (spaceBetweenCards / 2);
         tabMedicoesWindow.updateCustomViewList();
         bringClickedTab("medicoes");

         tabMenu.BackColor = Colors.bg3;

         tabMedicoes.normalColor = ColorTranslator.FromHtml("#e6e6e6");
         tabMedicoes.onEnterColor = ColorTranslator.FromHtml("#d9d9d9");
         tabMedicoes.onClickColor = ColorTranslator.FromHtml("#cccccc");
         tabMedicoes.title = "Medições";

         tabBoletos.normalColor = ColorTranslator.FromHtml("#e6e6e6");
         tabBoletos.onEnterColor = ColorTranslator.FromHtml("#d9d9d9");
         tabBoletos.onClickColor = ColorTranslator.FromHtml("#cccccc");
         tabBoletos.title = "Boletos";

         tabRemessas.normalColor = ColorTranslator.FromHtml("#e6e6e6");
         tabRemessas.onEnterColor = ColorTranslator.FromHtml("#d9d9d9");
         tabRemessas.onClickColor = ColorTranslator.FromHtml("#cccccc");
         tabRemessas.title = "Remessas";

      }

      private void HomeControl_Resize(object sender, EventArgs e) {

         tabMenu.Location = new Point(0, 0);
         tabMenu.Size = new Size(ClientRectangle.Width, 60);

         tabMedicoes.Size = new Size(150, tabMenu.Height);
         tabMedicoes.Margin = new Padding(20, 0, 0, 0);

         tabBoletos.Size = new Size(150, tabMenu.Height);
         //tabBoletos.Margin = new Padding(20, 0, 0, 0);
         
         tabRemessas.Size = new Size(150, tabMenu.Height);

         tabMedicoesWindow.Location = new Point(0, tabMenu.Height);
         tabMedicoesWindow.Size = new Size(ClientRectangle.Width + SystemInformation.VerticalScrollBarWidth, ClientRectangle.Height - tabMenu.Height);

         medicoesCustomScrollbar.backgroundColor = Color.White;
         medicoesCustomScrollbar.color = ColorTranslator.FromHtml("#3289d8");
         medicoesCustomScrollbar.btnsColor = ColorTranslator.FromHtml("#2575c1");
         medicoesCustomScrollbar.Size = new Size(10, tabMedicoesWindow.Height);
         medicoesCustomScrollbar.Location = new Point(Width - 10, tabMedicoesWindow.Location.Y);
         medicoesCustomScrollbar.Minimum = 0;
         medicoesCustomScrollbar.Maximum = tabMedicoesWindow.panel.Size.Height;
         medicoesCustomScrollbar.LargeChange = medicoesCustomScrollbar.Maximum / medicoesCustomScrollbar.Height + tabMedicoesWindow.Height;
         medicoesCustomScrollbar.SmallChange = 15;
         medicoesCustomScrollbar.Value = Math.Abs(tabMedicoesWindow.AutoScrollPosition.Y);

         tabBoletosWindow.Location = new Point(0, tabMenu.Height);
         tabBoletosWindow.Size = new Size(ClientRectangle.Width + SystemInformation.VerticalScrollBarWidth, ClientRectangle.Height - tabMenu.Height);

         boletosCustomScrollbar.backgroundColor = Color.White;
         boletosCustomScrollbar.color = ColorTranslator.FromHtml("#3289d8");
         boletosCustomScrollbar.btnsColor = ColorTranslator.FromHtml("#2575c1");
         boletosCustomScrollbar.Size = new Size(10, tabBoletosWindow.Height);
         boletosCustomScrollbar.Location = new Point(Width - 10, tabBoletosWindow.Location.Y);
         boletosCustomScrollbar.Minimum = 0;
         boletosCustomScrollbar.Maximum = tabBoletosWindow.panel.Size.Height;
         boletosCustomScrollbar.LargeChange = boletosCustomScrollbar.Maximum / boletosCustomScrollbar.Height + tabBoletosWindow.Height;
         boletosCustomScrollbar.SmallChange = 15;
         boletosCustomScrollbar.Value = Math.Abs(tabBoletosWindow.AutoScrollPosition.Y);

         tabRemessasWindow.Location = new Point(0, tabMenu.Height);
         tabRemessasWindow.Size = new Size(ClientRectangle.Width + SystemInformation.VerticalScrollBarWidth, ClientRectangle.Height - tabMenu.Height);

         remessasCustomScrollbar.backgroundColor = Color.White;
         remessasCustomScrollbar.color = ColorTranslator.FromHtml("#3289d8");
         remessasCustomScrollbar.btnsColor = ColorTranslator.FromHtml("#2575c1");
         remessasCustomScrollbar.Size = new Size(10, tabRemessasWindow.Height);
         remessasCustomScrollbar.Location = new Point(Width - 10, tabRemessasWindow.Location.Y);
         remessasCustomScrollbar.Minimum = 0;
         remessasCustomScrollbar.Maximum = tabRemessasWindow.panel.Size.Height;
         remessasCustomScrollbar.LargeChange = remessasCustomScrollbar.Maximum / remessasCustomScrollbar.Height + tabRemessasWindow.Height;
         remessasCustomScrollbar.SmallChange = 15;
         remessasCustomScrollbar.Value = Math.Abs(tabRemessasWindow.AutoScrollPosition.Y);
      }

      protected override void OnPaint(PaintEventArgs e) {
         base.OnPaint(e);

         //e.Graphics.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0,0,Width,Height));
         //e.Graphics.FillRectangle(new SolidBrush(Color.Red),newSize);
      }

      private void bringClickedTab(string control) {
         if (control.Equals("medicoes")) {
            tabMedicoesWindow.Visible = true;
            medicoesCustomScrollbar.Visible = true;
            tabBoletosWindow.Visible = false;
            boletosCustomScrollbar.Visible = false;
            tabRemessasWindow.Visible = false;
            remessasCustomScrollbar.Visible = false;
            tabMedicoes.selected = true;
         } else {
            tabMedicoes.selected = false;
         }

         if (control.Equals("boletos")) {
            tabMedicoesWindow.Visible = false;
            medicoesCustomScrollbar.Visible = false;
            tabBoletosWindow.Visible = true;
            boletosCustomScrollbar.Visible = true;
            tabRemessasWindow.Visible = false;
            remessasCustomScrollbar.Visible = false;
            tabBoletos.selected = true;
         } else {
            tabBoletos.selected = false;
         }

         if (control.Equals("remessas")) {
            tabMedicoesWindow.Visible = false;
            medicoesCustomScrollbar.Visible = false;
            tabBoletosWindow.Visible = false;
            boletosCustomScrollbar.Visible = false;
            tabRemessasWindow.Visible = true;
            remessasCustomScrollbar.Visible = true;
            tabRemessas.selected = true;
         } else {
            tabRemessas.selected = false;
         }

         tabMedicoes.Invalidate();
         tabBoletos.Invalidate();
         tabRemessas.Invalidate();
      }

      private void tabMedicoes_Click(object sender, EventArgs e) {
         tabMedicoesWindow.updateCustomViewList();
         bringClickedTab("medicoes");
      }

      private void tabBoletos_Click(object sender, EventArgs e) {
         tabBoletosWindow.updateCustomViewList();
         bringClickedTab("boletos");
      }

      private void tabRemessas_Click(object sender, EventArgs e) {
         tabRemessasWindow.updatePage();
         bringClickedTab("remessas");
      }

      private void tabBoletos_Load(object sender, EventArgs e) {

      }

      private void medicoesCustomScrollbar_Scroll(object sender, EventArgs e) {
         tabMedicoesWindow.AutoScrollPosition = new Point(0, medicoesCustomScrollbar.Value);
         medicoesCustomScrollbar.Invalidate();
         Application.DoEvents();
      }

      private void remessasCustomScrollbar_Scroll(object sender, EventArgs e) {
         tabRemessasWindow.AutoScrollPosition = new Point(0, remessasCustomScrollbar.Value);
         remessasCustomScrollbar.Invalidate();
         Application.DoEvents();
      }

      private void tabMedicoesWindow_Scroll(object sender, ScrollEventArgs e) {

      }

      private void tabMedicoesWindow_MouseWheel(object sender, MouseEventArgs e) {
         medicoesCustomScrollbar.Value = tabMedicoesWindow.VerticalScroll.Value;
         medicoesCustomScrollbar.Invalidate();
         Application.DoEvents();
      }

      private void tabRemessasWindow_MouseWheel(object sender, MouseEventArgs e) {
         remessasCustomScrollbar.Value = tabRemessasWindow.VerticalScroll.Value;
         remessasCustomScrollbar.Invalidate();
         Application.DoEvents();
      }

      private void tabBoletosWindow_MouseWheel(object sender, MouseEventArgs e) {
         boletosCustomScrollbar.Value = tabBoletosWindow.VerticalScroll.Value;
         boletosCustomScrollbar.Invalidate();
         Application.DoEvents();
      }

      private void boletosCustomScrollbar_Scroll(object sender, EventArgs e) {
         tabBoletosWindow.AutoScrollPosition = new Point(0, boletosCustomScrollbar.Value);
         boletosCustomScrollbar.Invalidate();
         Application.DoEvents();
      }
   }
}
