using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GinasticaLaboral
{



    public partial class MainForm : Form
    {

        /*
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
         * */



        public MainForm()
        {
            InitializeComponent();

            /*
            this.defaultNotifyIcon.Tag = 0;
            this.defaultNotifyIcon.BalloonTipShown += defaultNotifyIcon_BalloonTipShown;
            this.defaultNotifyIcon.BalloonTipClosed += defaultNotifyIcon_BalloonTipClosed;
            this.defaultNotifyIcon.BalloonTipClicked += defaultNotifyIcon_BalloonTipClicked;
             * */

            this.defaultNotifyIcon.MouseUp += defaultNotifyIcon_MouseUp;
            this.defaultNotifyIcon.DoubleClick += defaultNotifyIcon_DoubleClick;

            this.Size = new Size(540, 100);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            int padding = 0;
            int left = Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width - padding;
            int top = Screen.PrimaryScreen.WorkingArea.Height - this.Size.Height - padding;
            this.Location = new Point(left, top);
            this.TopMost = true;


            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;

            this.exibicaoAutomaticaToolStripMenuItem.Checked = this.ObterExibicaoAutomaticaRegistro();


        }

        void defaultNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.iniciarSlides();
        }

        void defaultNotifyIcon_MouseUp(object sender, MouseEventArgs e)
        {
            /*
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MessageBox.Show("Abre tela de ajuda");
            }
             * */
        }


        private RegistryKey ObterChaveRegistro()
        {
            using (RegistryKey rk = Registry.CurrentUser)
            {
                using (var softwareKey = rk.CreateSubKey("Software"))
                {
                    /*
                    using (var trtesKey = softwareKey.CreateSubKey("TRT-ES"))
                    {
                        var key = trtesKey.CreateSubKey("GinasticaLaboral");
                        return key;
                    }
                     * */
                    var key = softwareKey.CreateSubKey("GinasticaLaboral");
                    return key;
                }
            }
        }

        private void DefinirExibicaoAutomaticaRegistro(bool valor)
        {
            using (var key = this.ObterChaveRegistro())
            {
                key.SetValue("ExibicaoAutomatica", valor);
                this.exibicaoAutomaticaToolStripMenuItem.Checked = valor;
            }

        }

        private bool ObterExibicaoAutomaticaRegistro()
        {

            using (var key = this.ObterChaveRegistro())
            {
                var obj = key.GetValue("ExibicaoAutomatica");
                if (obj != null)
                {
                    bool ea = true;
                    if (bool.TryParse(obj.ToString(), out ea))
                    {
                        return ea;
                    }
                }
            }

            return true;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.HideForm();
            //this.TopMost = true;
            defaultTimer.Interval = 1000;
            defaultTimer.Enabled = true;
        }

        //private void HideForm()
        //{
        //    BeginInvoke(new MethodInvoker(delegate
        //    {
        //        Hide();
        //    }));
        //}

        private void defaultTimer_Tick(object sender, EventArgs e)
        {
            if (this.PodeExibir())
            {
                if (this.Visible)
                {
                    this.ExibirAlerta();
                }
            }
            GC.Collect();
        }

        private bool PodeExibir()
        {
            var agora = DateTime.Now;

            var podeExibir = false;
            foreach (string horario in Properties.Settings.Default.Horarios)
            {
                TimeSpan ts;
                if (TimeSpan.TryParse(horario, out ts)) {
                    podeExibir = podeExibir || (agora.Hour == ts.Hours && agora.Minute == ts.Minutes);
                }
            }

            return this.exibicaoAutomaticaToolStripMenuItem.Checked && podeExibir;
        }


        /*
        void defaultNotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            this.ExibirAlerta();
        }

        void defaultNotifyIcon_BalloonTipClosed(object sender, EventArgs e)
        {
            this.defaultNotifyIcon.Tag = 0;
        }

        void defaultNotifyIcon_BalloonTipShown(object sender, EventArgs e)
        {
            this.defaultNotifyIcon.Tag = 1;
        }
         * */

        private void ExibirAlerta()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }


        private void exibirAgoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.ExibirAlerta();
            this.iniciarSlides();
        }

        private void iniciarSlides()
        {
            this.Hide();
            using (var form = new SlideForm())
            {
                form.ShowDialog();
            }
            this.MinimizeToTray();
        }

        private void exibicaoAutomaticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var exibirAutomaticamente = !exibicaoAutomaticaToolStripMenuItem.Checked;
            this.exibicaoAutomaticaToolStripMenuItem.Checked = exibirAutomaticamente;
            this.DefinirExibicaoAutomaticaRegistro(exibirAutomaticamente);
            if (exibirAutomaticamente)
            {
                MessageBox.Show("A campanha será exibida automaticamente em horários específicos.");
            }
            else
            {
                MessageBox.Show("A campanha não será mais exibida automaticamente.");
            }
        }



        private void MinimizeToTray()
        {
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            /*
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
             * */
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.MinimizeToTray();
        }



        private void iniciarPictureBox_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new SlideForm())
            {
                form.ShowDialog();
            }
            this.MinimizeToTray();
        }


        private void agoraNaoPictureBox_Click(object sender, EventArgs e)
        {
            this.MinimizeToTray();
        }

        private void naoExibirCampanhaLinkLabel_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Esta campanha não será mais exibida. Tem certeza que deseja desativá-la? OBS: Você poderá ativá-la novamente através do ícone da Ginástica Laboral.", "Ginástica Laboral", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                this.MinimizeToTray();
                this.defaultNotifyIcon.BalloonTipTitle = "Ginástica Laboral";
                this.defaultNotifyIcon.BalloonTipText = "Você poderá reativar a campanha clicando com o botão direito no ícone abaixo.";
                this.defaultNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                this.defaultNotifyIcon.ShowBalloonTip(10000);
                this.DefinirExibicaoAutomaticaRegistro(false);
            }
        }

    }
}
