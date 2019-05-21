using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace ProjBoletos.telas {
    public partial class MainPage : Form {

        System.Timers.Timer timer;

        bool animationToOpen = true;

        public MainPage() {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e) {
            bringClickedControl("home");

            btnConfig.icon.Click += new EventHandler(btnConfig_click);
            btnHome.icon.Click += new EventHandler(btnHome_click);
            accountButton.icon.Click += new EventHandler(accountButton_click);
            accountButton.dropIcon.Click += new EventHandler(accountButton_click);

            sideBarFlowPanel.BackColor = ColorTranslator.FromHtml("#434549");

            topBarFlowLayout.BackColor = ColorTranslator.FromHtml("#383a3d");

            accountButton.icon.Image = new Bitmap(Properties.Resources.icon_person1);
            accountButton.dropIcon.Image = new Bitmap(Properties.Resources.icon_drop_arrow);
            accountButton.title = "Nome";

            btnHome.icon.Image = new Bitmap(Properties.Resources.icon_person1);
            btnHome.title = "HOME";
            

            btnConfig.icon.Image = new Bitmap(Properties.Resources.icon_person1);
            btnConfig.title = "CONFIGURAÇÕES";
            
            dropMenu.Visible = false;
            
            dropMenuButtonSair.marginLeftIcon = 0;
            dropMenuButtonSair.distIconString = 0;
            dropMenuButtonSair.title = "SAIR";

            timer = new System.Timers.Timer(8); //~60 FPS
            timer.AutoReset = true;
            timer.SynchronizingObject = this;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        private void Main_Resize(object sender, EventArgs e) {
            sideBarFlowPanel.Location = new Point(0, 0);
            sideBarFlowPanel.Size = new Size(200, ClientRectangle.Height);
            
            topBarFlowLayout.Location = new Point(sideBarFlowPanel.Width, 0);
            topBarFlowLayout.Size = new Size(ClientRectangle.Width - sideBarFlowPanel.Width, 35);
            
            accountButton.Height = topBarFlowLayout.Height;

            homeControl.Location = new Point(sideBarFlowPanel.Width, topBarFlowLayout.Height);
            homeControl.Size = new Size(ClientRectangle.Width - sideBarFlowPanel.Width, ClientRectangle.Height - topBarFlowLayout.Height);
            configControl.Location = new Point(sideBarFlowPanel.Width, topBarFlowLayout.Height);
            configControl.Size = new Size(Width - sideBarFlowPanel.Width, ClientRectangle.Height - topBarFlowLayout.Height);

            btnHome.Width = sideBarFlowPanel.Width;

            separator1.Size = new Size(sideBarFlowPanel.Width, 30);

            logoImage.Size = new Size(sideBarFlowPanel.Width, sideBarFlowPanel.Width);

            btnConfig.Width = sideBarFlowPanel.Width;

            dropMenu.Size = new Size(177, 0);
            dropMenu.Location = new Point(ClientRectangle.Width - dropMenu.Width, topBarFlowLayout.Height);

            dropMenuButtonSair.Location = new Point(0, 0);
            dropMenuButtonSair.Size = new Size(dropMenu.Width, 50);
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e) {
            if (animationToOpen) {
                animationOpen();
            } else {
                animationClose();
            }
        }

        private void animationOpen() {
            dropMenu.Visible = true;
            if (dropMenu.Height < dropMenuButtonSair.Height) {
                dropMenu.Height += 10; //Increment
                                      //Application.DoEvents();
            } else {
                timer.Stop(); //Disable
                animationToOpen = false;
            }
        }

        private void animationClose() {
            if (dropMenu.Height > 0) {
                dropMenu.Height -= 10; //Increment
                                      //Application.DoEvents();
            } else {
                timer.Stop(); //Disable
                animationToOpen = true;
                dropMenu.Visible = true;
            }
        }

        public void accountButton_click(object sender, EventArgs e) {
            timer.Start();
        }

        public void dropMenuButtonSair_click(object sender, EventArgs e) {
            //Console.WriteLine("asdasdasd");
            Properties.Settings.Default["cedenteAtual"] = "";
            Properties.Settings.Default["logado"] = false;
            Properties.Settings.Default.Save();

            this.Hide();
            Login login = new Login();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        public void btnHome_click(object sender, EventArgs e) {
            bringClickedControl("home");
        }

        public void btnConfig_click(object sender, EventArgs e) {
            bringClickedControl("config");
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void bringClickedControl(string control) {
            if (control.Equals("home")) {
                homeControl.Visible = true;
                configControl.Visible = false;
                btnHome.selected = true;
            } else {
                btnHome.selected = false;
            }

            if (control.Equals("config")) {
                homeControl.Visible = false;
                configControl.Visible = true;
                btnConfig.selected = true;
            } else {
                btnConfig.selected = false;
            }

            btnHome.Invalidate();
            btnConfig.Invalidate();
        }

        private void topBarFlowLayout_Paint(object sender, PaintEventArgs e) {

        }

        private void dropMenuButtonSair_Load(object sender, EventArgs e) {

        }
    }
}
