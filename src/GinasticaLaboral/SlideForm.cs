using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;
using System.IO;

namespace GinasticaLaboral
{
    class SlideForm : Form
    {

        protected static string basePath = AssemblyDirectory;
        protected bool imagensCarregadas = false;
        protected int slideIndex = -1;
        //protected Image inicioImage = null;
        //protected Image fimImage = null;
        protected Image closeImage = null;
        protected Image closeImageHover = null;
        protected IEnumerable<Image> slides = null;
        protected PictureBox closeButton = new PictureBox();

        public SlideForm()
            : base()
        {

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MinimizeBox = false;
            this.TopMost = true;
            this.KeyUp += form_KeyUp;
            this.Click += form_Click;


            if (this.carregarImagens())
            {

                //this.BackgroundImage = inicioImage;
                this.BackgroundImage = this.slides.First();
                this.BackgroundImageLayout = ImageLayout.Zoom;

                this.configurarBotaoFechar();

                // Tooltip
                System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();
                tooltip.SetToolTip(closeButton, "Fechar esta janela");
            }
            else
            {
                Label mensagem = new Label();
                mensagem.ForeColor = Color.White;
                mensagem.AutoSize = true;
                mensagem.Font = new Font("Arial", (float)14);
                mensagem.Text = "Não foi possível carregar arquivo(s) de imagem. Pressione [ESC] para sair.";
                this.Controls.Add(mensagem);
            }
        }



        void form_Click(object sender, EventArgs e)
        {
            if (this.imagensCarregadas)
            {
                this.proximoSlide();
            }
        }

        private bool carregarImagens()
        {
            try
            {
                string imagesPath = string.Format(@"{0}\images", basePath);
                this.closeImage = Image.FromFile(string.Format(@"{0}\close.png", imagesPath));
                this.closeImageHover = Image.FromFile(string.Format(@"{0}\close-hover.png", imagesPath));

                string slidesPath = string.Format(@"{0}\slides", basePath);
                //this.inicioImage = Image.FromFile(string.Format(@"{0}\inicio.jpg", slidesPath));
                //this.fimImage = Image.FromFile(string.Format(@"{0}\inicio.jpg", slidesPath));
                this.slides = System.IO.Directory.GetFiles(slidesPath, "slide.*.jpg", System.IO.SearchOption.TopDirectoryOnly).OrderBy(file => file).Select(file => Image.FromFile(file));
                //this.inicioImage = slides.First();
                this.imagensCarregadas = true;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private void configurarBotaoFechar()
        {
            int padding = 25;
            int topSpacing = 0;
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            int imageWidth = this.slides.First().Width;
            int imageHeight = this.slides.First().Height;

            double proporcaoLargura = (double)screenWidth / imageWidth;
            double proporcaoAltura = (double)screenHeight / imageHeight;

            closeButton.BackgroundImage = closeImage;
            closeButton.BackgroundImageLayout = ImageLayout.Zoom;
            closeButton.Width = (int)(closeImage.Width * proporcaoLargura);
            closeButton.Height = (int)(closeImage.Height * proporcaoAltura);

            int paddingRightProporcional = (int)(padding * proporcaoLargura);
            int paddingTopProporcional = (int)(padding * proporcaoAltura);

            double imageSizeRatio = (double)imageWidth / imageHeight;
            int newImageWidth = screenWidth;
            int newImageHeight = (int)((double)newImageWidth / imageSizeRatio);
            topSpacing = (int)((screenHeight - newImageHeight) / 2);

            if (screenWidth < screenHeight)
            {
                // Valor arbitrário para ajuste (verificar)
                paddingTopProporcional = -5;
            }

            closeButton.Left = Screen.PrimaryScreen.Bounds.Width - closeButton.Width - paddingRightProporcional;
            closeButton.Top = (int)(paddingTopProporcional + topSpacing);
            closeButton.BackColor = Color.Transparent;

            closeButton.Cursor = Cursors.Hand;
            closeButton.MouseEnter += closeButton_MouseEnter;
            closeButton.MouseLeave += closeButton_MouseLeave;
            closeButton.Click += closeButton_Click;

            this.Controls.Add(closeButton);
        }


        void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void closeButton_MouseLeave(object sender, EventArgs e)
        {
            this.closeButton.BackgroundImage = closeImage;
        }

        void closeButton_MouseEnter(object sender, EventArgs e)
        {
            this.closeButton.BackgroundImage = closeImageHover;
        }

        void form_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.pressionouTeclaParaFechar(e))
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                this.Close();
            }
            else
            {
                if (this.imagensCarregadas)
                {
                    if (this.pressionouTeclaParaAvancar(e))
                    {
                        this.proximoSlide();
                    }
                    else if (this.pressionouTeclaParaRecuar(e))
                    {
                        this.slideAnterior();
                    }
                }
            }
        }

        private bool pressionouTeclaParaFechar(KeyEventArgs e)
        {
            return e.KeyCode == Keys.Escape;
        }

        private bool podeRecuarSlide()
        {
            return this.slideIndex > 0;
        }

        private bool podeAvancarSlide()
        {
            return this.slideIndex < this.slides.Count() - 1;
        }

        private bool pressionouTeclaParaRecuar(KeyEventArgs e)
        {
            return e.KeyCode == Keys.Left;
        }

        private bool pressionouTeclaParaAvancar(KeyEventArgs e)
        {
            return (e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Space);
        }

        private void proximoSlide()
        {
            if (this.podeAvancarSlide())
            {
                this.slideIndex++;
                this.atualizarSlide();
            }
        }

        private void slideAnterior()
        {
            if (this.podeRecuarSlide())
            {
                this.slideIndex--;
                this.atualizarSlide();
            }
        }

        private void atualizarSlide()
        {
            this.BackgroundImage = this.slides.Skip(this.slideIndex).Take(1).Single();
        }

        private static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

    }
}
