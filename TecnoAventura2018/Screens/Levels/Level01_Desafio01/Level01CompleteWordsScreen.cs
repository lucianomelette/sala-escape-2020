using System;
using System.Drawing;
using System.Windows.Forms;
using TecnoAventura2018.Properties;
using TecnoAventura2018.Screens.Levels.Level02_Desafio02;

namespace TecnoAventura2018.Screens.Levels.Level01_Desafio01
{
    public partial class Level01CompleteWordsScreen : LevelScreen
    {
        public Level01CompleteWordsScreen(BoardScreen board) : base(board)
        {
            InitializeComponent();
        }

        private void Level01CompleteWordsScreen_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            ConfigAllTextBoxes();

            Panel validarButton = new Panel();
            validarButton.BackColor = Color.Transparent;
            //validarButton.BorderStyle = BorderStyle.FixedSingle;
            validarButton.BackgroundImage = Resources.check_button;
            validarButton.BackgroundImageLayout = ImageLayout.Zoom;
            validarButton.Width = (int)(Width * 0.21);
            validarButton.Height = (int)(validarButton.Width / 5.0962);
            validarButton.Left = Width / 2 - validarButton.Width / 2 + Width / 4;
            validarButton.Top = (int)(Height * 0.835);
            validarButton.Click += (s, e) =>
            {
                ValidarEcuacion();
            };
            validarButton.MouseMove += MouseMoveEvent;
            Controls.Add(validarButton);

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
        }

        private void ValidarEcuacion()
        {
            String elem1 = textBox1.Text.Trim().ToUpper();
            String elem2 = textBox2.Text.Trim().ToUpper();
            String elem3 = textBox3.Text.Trim().ToUpper();
            String elem4 = textBox4.Text.Trim().ToUpper();
            String elem5 = textBox5.Text.Trim().ToUpper();

            if (elem1.Equals("OCASIONAL") 
                && elem2.Equals("SALUD") 
                && elem3.Equals("LEY") 
                && elem4.Equals("ABUSOS") 
                && elem5.Equals("ADICCIONES"))
            {
                board.Success();
                board.SetLevelScreen(new Level02IntroScreen(board));
            }
            else
                board.Penalty();
        }

        private void ConfigTextBox(TextBox textBox, double top, double left, double width = 0)
        {
            textBox.Multiline = true;
            textBox.TextAlign = HorizontalAlignment.Center;
            textBox.BorderStyle = BorderStyle.None;
            textBox.BackColor = Color.FromArgb(179, 158, 139);
            textBox.MaxLength = 10;
            textBox.Font = FontFamilyProvider.GetCustomFont(18);
            textBox.ForeColor = Color.Black;
            textBox.CharacterCasing = CharacterCasing.Upper;

            if (width == 0)
                textBox.Width = (int)(Width * 0.13);
            else
                textBox.Width = (int)(Width * width);

            textBox.Height = (int)(Height * 0.035);
            textBox.Left = (int)(Width * left);
            textBox.Top = (int)(Height * top);
            textBox.Text = "ocasional";
            //Util.ScaleFont(textBox);
            textBox.Text = "";
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void ConfigAllTextBoxes()
        {
            ConfigTextBox(textBox1, 0.353, 0.222);
            ConfigTextBox(textBox2, 0.457, 0.306);
            ConfigTextBox(textBox3, 0.762, 0.145, 0.09);
            ConfigTextBox(textBox4, 0.303, 0.55);
            ConfigTextBox(textBox5, 0.303, 0.72);
        }

        private void Level01CompleteWordsScreen_Click(object sender, EventArgs e)
        {
            //ConfigAllTextBoxes();
        }

        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
