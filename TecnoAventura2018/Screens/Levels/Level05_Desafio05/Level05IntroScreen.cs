using System;
using System.Drawing;
using System.Windows.Forms;
using TecnoAventura2018.Properties;

namespace TecnoAventura2018.Screens.Levels.Level05_Desafio05
{
    public partial class Level05IntroScreen : LevelScreen
    {
        private String uriAudio = "level05_intro.mp3";
        private Bitmap levelTitle = Resources.level05_desafio;
        private Bitmap nextBackground = Resources.level05_intro_next_bg;

        private Panel playButton;
        private Panel nextButton;

        public Level05IntroScreen(BoardScreen board) : base(board)
        {
            InitializeComponent();
        }

        private void Level05IntroScreen_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            board.SetTitle(levelTitle);

            // + Play button
            playButton = new Panel();
            playButton.Width = (int)(Width * 0.1);
            playButton.Height = playButton.Width;
            playButton.Left = (int)(Width * 0.802);
            playButton.Top = (int)(Height * 0.78);
            playButton.BackColor = Color.Transparent;
            //nextButton.BorderStyle = BorderStyle.FixedSingle;
            playButton.Click += PlayAudio;
            playButton.MouseMove += MouseMoveEvent;
            Controls.Add(playButton);

            // + Next button
            nextButton = new Panel();
            nextButton.Width = (int)(Width * 0.25);
            nextButton.Height = (int)(Height * 0.1);
            nextButton.Left = Width / 2 - nextButton.Width / 2;
            nextButton.Top = (int)(Height * 0.84);
            nextButton.BackColor = Color.Transparent;
            //nextButton.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(nextButton);
        }

        private void PlayAudio(object sender, EventArgs e)
        {
            playButton.Click -= PlayAudio;
            nextButton.Click -= NextScreen;

            playButton.MouseMove -= MouseMoveEvent;
            nextButton.MouseMove -= MouseMoveEvent;

            board.PlayAudio(uriAudio);
        }

        public override void ExecutePostAudio()
        {
            base.ExecutePostAudio();

            BackgroundImage = nextBackground;

            playButton.Click += PlayAudio;
            nextButton.Click += NextScreen;

            playButton.MouseMove += MouseMoveEvent;
            nextButton.MouseMove += MouseMoveEvent;
        }

        private void NextScreen(object sender, EventArgs e)
        {
            board.SetLevelScreen(new Level05Question01Screen(board));
        }

        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
