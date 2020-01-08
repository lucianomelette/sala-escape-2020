using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TecnoAventura2018.Properties;

namespace TecnoAventura2018.Screens.Levels.Level07_Desafio07
{
    public partial class Level07IntroScreen : LevelScreen
    {
        private String uriAudio = "level07_intro.mp3";
        private Bitmap levelTitle = Resources.level07_desafio;
        private Bitmap nextBackground = Resources.level07_intro_next_bg;

        private Panel playButton;
        private Panel nextButton;

        private Panel validarButton;

        public Level07IntroScreen(BoardScreen board) : base(board)
        {
            InitializeComponent();
        }

        private void Level07IntroScreen_Load(object sender, EventArgs e)
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

        private IList<Bitmap> _textScreens = new List<Bitmap>();
        private IList<String> _groupTexts = new List<String>();

        private void NextScreen(object sender, EventArgs e)
        {
            playButton.Click -= PlayAudio;
            nextButton.Click -= NextScreen;

            playButton.MouseMove -= MouseMoveEvent;
            nextButton.MouseMove -= MouseMoveEvent;

            playButton.Dispose();
            nextButton.Dispose();

            ConfigScreenControl();
            NextTextScreen();
        }

        private void ConfigScreenControl()
        {
            _textScreens.Add(Resources.level07_texto_01_bg);
            _textScreens.Add(Resources.level07_texto_02_bg);
            _textScreens.Add(Resources.level07_texto_03_bg);
            _textScreens.Add(Resources.level07_texto_04_bg);
            _textScreens.Add(Resources.level07_texto_05_bg);

            // + Text
            textBox1.Multiline = true;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.MaxLength = 100;
            textBox1.Font = FontFamilyProvider.GetCustomFont(20);
            textBox1.Width = (int)(Width * 0.54);
            textBox1.Height = (int)(Height * 0.44);
            textBox1.Left = (int)(Width * 0.23);
            textBox1.Top = (int)(Height * 0.31);

            // + Validar button
            validarButton = new Panel();
            validarButton.BackColor = Color.Transparent;
            //validarButton.BorderStyle = BorderStyle.FixedSingle;
            validarButton.Width = (int)(Width * 0.21);
            validarButton.Height = (int)(validarButton.Width / 5.0962);
            validarButton.Left = Width / 2 - validarButton.Width / 2;
            validarButton.Top = (int)(Height * 0.848);
            validarButton.Click += ValidarTexto;
            validarButton.MouseMove += MouseMoveEvent;
            Controls.Add(validarButton);

            textBox1.Visible = true;
        }

        private void ValidarTexto(object sender, EventArgs e)
        {
            String text = textBox1.Text.Trim();

            if (!text.Equals(String.Empty))
            {
                _groupTexts.Add(text);

                NextTextScreen();
            }
        }

        private void NextTextScreen()
        {
            if (_textScreens.Count == 0)
            {
                //board.SetScreen(new Level07AplausosScreen(board.GetForm()));

                AllTextsScreen();
            }
            else
            {
                textBox1.Text = String.Empty;

                BackgroundImage = _textScreens[0];

                _textScreens.RemoveAt(0);
            }
        }

        private Label label1 = new Label();
        private Label label2 = new Label();
        private Label label3 = new Label();
        private Label label4 = new Label();
        private Label label5 = new Label();

        Panel endButton;
        Panel showVideoButton;

        private void AllTextsScreen()
        {
            textBox1.Text = String.Empty;
            textBox1.Dispose();
            Controls.Remove(textBox1);

            validarButton.Click -= ValidarTexto;
            validarButton.MouseMove -= MouseMoveEvent;
            validarButton.Dispose();

            BackgroundImage = Resources.level07_texto_all_bg;

            ConfigTextLabels();

            // + End button
            endButton = new Panel();
            endButton.BackColor = Color.Transparent;
            //validarButton.BorderStyle = BorderStyle.FixedSingle;
            endButton.Width = (int)(Width * 0.33);
            endButton.Height = (int)(validarButton.Width / 5.0962);
            endButton.Left = Width / 2 - validarButton.Width / 2 - (int)(Width * 0.05); ;
            endButton.Top = (int)(Height * 0.91);
            endButton.Click += EndGame;
            endButton.MouseMove += MouseMoveEvent;

            Controls.Add(endButton);

            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
        }

        private void ConfigTextLabels()
        {
            ConfigTextLabel(label1, (int)(Width * 0.14), (int)(Height * 0.27), _groupTexts[0]);
            ConfigTextLabel(label2, (int)(Width * 0.29), (int)(Height * 0.40), _groupTexts[1]);
            ConfigTextLabel(label3, (int)(Width * 0.10), (int)(Height * 0.53), _groupTexts[2]);
            ConfigTextLabel(label4, (int)(Width * 0.36), (int)(Height * 0.65), _groupTexts[3]);
            ConfigTextLabel(label5, (int)(Width * 0.22), (int)(Height * 0.78), _groupTexts[4]);
        }

        private void ConfigTextLabel(Label label, int left, int top, String text)
        {
            label.BackColor = Color.Transparent;
            label.Text = text;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BorderStyle = BorderStyle.None;
            label.Font = FontFamilyProvider.GetCustomFont(20);
            label.Width = (int)(Width * 0.555);
            label.Height = (int)(Height * 0.095);
            label.Left = left;
            Util.ScaleFont(label);
            label.Top = top;
        }

        private void EndGame(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            Controls.Remove(label1);
            Controls.Remove(label2);
            Controls.Remove(label3);
            Controls.Remove(label4);
            Controls.Remove(label5);

            endButton.Click -= EndGame;
            endButton.MouseMove -= MouseMoveEvent;

            BackgroundImage = Resources.level07_end_bg;

            // + End button
            showVideoButton = new Panel();
            showVideoButton.BackColor = Color.Transparent;
            //showVideoButton.BorderStyle = BorderStyle.FixedSingle;
            showVideoButton.Width = (int)(Width * 0.33);
            showVideoButton.Height = (int)(validarButton.Width / 5.0962);
            showVideoButton.Left = Width / 2 - validarButton.Width / 2 - (int)(Width * 0.05); ;
            showVideoButton.Top = (int)(Height * 0.78);
            showVideoButton.Click += ShowVideo;
            showVideoButton.MouseMove += MouseMoveEvent;

            Controls.Add(showVideoButton);

            showVideoButton.BringToFront();
        }

        private void ShowVideo(object sender, EventArgs e)
        {
            board.GetForm().PlayVideo("final_video.mp4", new Level07AplausosScreen(board.GetForm()), false);
        }

        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
