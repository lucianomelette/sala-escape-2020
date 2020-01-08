using System;
using System.Drawing;
using System.Windows.Forms;
using TecnoAventura2018.Screens.Levels;
using TecnoAventura2018.Screens.Levels.Level00_Rompe_Hielo;

namespace TecnoAventura2018.Screens.Intro
{
    public partial class IntroScreen : ScreenUI
    {
        Panel _playButton;

        public IntroScreen(GameForm form) : base(form)
        {
            InitializeComponent();
        }

        private void IntroScreen_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            // + Play button
            _playButton = new Panel();
            _playButton.Width = (int)(Width * 0.2);
            _playButton.Height = (int)(Height * 0.1);
            _playButton.Left = (Width / 2 - _playButton.Width / 2);
            _playButton.Top = (int)(Height * 0.72);
            _playButton.Click += playButton_Click;
            _playButton.BackColor = Color.Transparent;
            //playButton.BorderStyle = BorderStyle.FixedSingle;

            _playButton.MouseMove += MouseMoveEvent;

            Controls.Add(_playButton);
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            PlayVideo();
        }

        private void PlayVideo()
        {
            Cursor.Current = Cursors.WaitCursor;
            form.PlayVideo("intro_video.mp4", new Level00LoginScreen(form), false);
            //form.SetScreen(new BoardScreen(form));
        }

        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
