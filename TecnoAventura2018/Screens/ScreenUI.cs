using System;
using System.Windows.Forms;

namespace TecnoAventura2018.Screens
{
    public partial class ScreenUI : UserControl
    {
        protected GameForm form;

        protected int screenMarginTop;
        protected int screenMarginLeft;
        protected int bgWidth;
        protected int bgHeight;

        public ScreenUI() { }

        public ScreenUI(GameForm form)
        {
            this.form = form;

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();
        }

        private void Screen_Load(object sender, EventArgs e)
        {
            SetBounds(0, 0, form.Width, form.Height);

            CalculateMargins();
        }

        private void CalculateMargins()
        {
            float screenRatio = (float)Width / Height;

            // if screen ratio is higher than width
            if (screenRatio <= Constants.BG_IMG_RATIO)
            {
                screenMarginTop = (int)Math.Round(Math.Abs(Height - (Width / Constants.BG_IMG_RATIO)) / 2);
                screenMarginLeft = 0;

                bgWidth = Width;
                bgHeight = (int)(Width / Constants.BG_IMG_RATIO);
            }
            // else screen ratio is wider than high
            else
            {
                screenMarginTop = 0;
                screenMarginLeft = (int)Math.Round(Math.Abs(Width - (Height * Constants.BG_IMG_RATIO)) / 2,0);

                bgWidth = (int)(Height * Constants.BG_IMG_RATIO);
                bgHeight = Height;
            }
        }

        public virtual void ExecutePostAudio() { }
    }
}
