using System;
using System.Drawing;
using System.Windows.Forms;
using TecnoAventura2018.Properties;
using TecnoAventura2018.Screens.Levels.Level07_Desafio07;

namespace TecnoAventura2018.Screens.Levels.Level06_Desafio06
{
    public partial class Level06EcuacionScreen : LevelScreen
    {
        private Panel playButton;

        private String _videoStoppableUri = "ecuacion_video.mp4";

        public Level06EcuacionScreen(BoardScreen board) : base(board)
        {
            InitializeComponent();
        }

        private void Level06EcuacionScreen_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            // play video stoppable
            //board.GetForm().PlayVideoStoppable(_videoStoppableUri, true, false);

            ConfigAllTextBoxes();

            Panel validarButton = new Panel();
            validarButton.BackColor = Color.Transparent;
            validarButton.BackgroundImage = Resources.check_button;
            validarButton.BackgroundImageLayout = ImageLayout.Zoom;
            //validarButton.BorderStyle = BorderStyle.FixedSingle;
            validarButton.Width = (int)(Width * 0.21);
            validarButton.Height = (int)(validarButton.Width / 5.0962);
            validarButton.Left = Width / 2 - validarButton.Width / 2;
            validarButton.Top = (int)(Height * 0.73);
            validarButton.Click += (s, e) =>
            {
                ValidarEcuacion();
            };
            validarButton.MouseMove += MouseMoveEvent;
            Controls.Add(validarButton);

            // + Play button
            playButton = new Panel();
            playButton.Width = (int)(Width * 0.1);
            playButton.Height = playButton.Width;
            playButton.Left = (int)(Width * 0.802);
            playButton.Top = (int)(Height * 0.78);
            playButton.BackColor = Color.Transparent;
            //nextButton.BorderStyle = BorderStyle.FixedSingle;
            playButton.Click += PlayVideoStoppable;
            playButton.MouseMove += MouseMoveEvent;
            Controls.Add(playButton);

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
        }

        private void ConfigAllTextBoxes()
        {
            ConfigTextBox(textBox1, 0.146);
            ConfigTextBox(textBox2, 0.299);
            ConfigTextBox(textBox3, 0.452);
            ConfigTextBox(textBox4, 0.605);
            ConfigTextBox(textBox5, 0.758);
        }

        private void PlayVideoStoppable(object sender, EventArgs e)
        {
            // play video stoppable
            board.GetForm().PlayVideoStoppable(_videoStoppableUri, true, true);
        }

        private void ValidarEcuacion()
        {
            String elem1 = textBox1.Text.Trim().ToUpper();
            String elem2 = textBox2.Text.Trim().ToUpper();
            String elem3 = textBox3.Text.Trim().ToUpper();
            String elem4 = textBox4.Text.Trim().ToUpper();
            String elem5 = textBox5.Text.Trim().ToUpper();

            if (elem1.Equals("4")
                && elem2.Equals("5")
                && elem3.Equals("1")
                && elem4.Equals("5")
                && elem5.Equals("3"))
            {
                board.Success();
                board.SetLevelScreen(new Level07IntroScreen(board));
            }
            else
                board.Penalty();
        }

        private void ConfigTextBox(TextBox textBox, double left)
        {
            textBox.Multiline = true;
            textBox.TextAlign = HorizontalAlignment.Center;
            textBox.BorderStyle = BorderStyle.None;
            textBox.MaxLength = 1;
            textBox.Font = FontFamilyProvider.GetCustomFont(40);
            textBox.Width = (int)(Width * 0.095);
            textBox.Height = (int)(Height * 0.07);
            textBox.Left = (int)(Width * left);
            textBox.Top = (int)(Height * 0.41);
            textBox.Text = "X";
            Util.ScaleFont(textBox);
            textBox.Text = "";
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        
        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
