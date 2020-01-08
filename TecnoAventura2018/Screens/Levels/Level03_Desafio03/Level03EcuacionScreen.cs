using System;
using System.Drawing;
using System.Windows.Forms;
using TecnoAventura2018.Screens.Levels.Level04_Desafio04;

namespace TecnoAventura2018.Screens.Levels.Level03_Desafio03
{
    public partial class Level03EcuacionScreen : LevelScreen
    {
        public Level03EcuacionScreen(BoardScreen board) : base(board)
        {
            InitializeComponent();
        }

        private void Level03EcuacionScreen_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            ConfigAllTextBoxes();

            Panel validarButton = new Panel();
            validarButton.BackColor = Color.Transparent;
            //validarButton.BorderStyle = BorderStyle.FixedSingle;
            validarButton.Width = (int)(Width * 0.21);
            validarButton.Height = (int)(validarButton.Width / 5.0962);
            validarButton.Left = Width / 2 - validarButton.Width / 2;
            validarButton.Top = (int)(Height * 0.915);
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
            textBox6.Visible = true;
        }

        private void ConfigAllTextBoxes()
        {
            ConfigTextBox(textBox1, 0.06);
            ConfigTextBox(textBox2, 0.215);
            ConfigTextBox(textBox3, 0.375);
            ConfigTextBox(textBox4, 0.531);
            ConfigTextBox(textBox5, 0.686);
            ConfigTextBox(textBox6, 0.845);
        }

        private void ValidarEcuacion()
        {
            RecalcularResultado();

            String elem1 = textBox1.Text.Trim().ToUpper();
            String elem2 = textBox2.Text.Trim().ToUpper();
            String elem3 = textBox3.Text.Trim().ToUpper();
            String elem4 = textBox4.Text.Trim().ToUpper();
            String elem5 = textBox5.Text.Trim().ToUpper();
            String elem6 = textBox6.Text.Trim().ToUpper();

            if ((elem1.Equals("319994") || elem1.Equals("319.994") || elem1.Equals("319,994"))
                && elem2.Equals("200")
                && (elem3.Equals("21.5") || elem3.Equals("21,5"))
                && elem4.Equals("40")
                && elem5.Equals("13"))
            {
                board.Success();
                board.SetLevelScreen(new Level04IntroScreen(board));
            }
            else
                board.Penalty();
        }

        private void ConfigTextBox(TextBox textBox, double left)
        {
            textBox.Multiline = true;
            textBox.TextAlign = HorizontalAlignment.Center;
            textBox.BorderStyle = BorderStyle.None;
            textBox.MaxLength = 7;
            textBox.Font = FontFamilyProvider.GetCustomFont(40);
            textBox.Width = (int)(Width * 0.095);
            textBox.Height = (int)(Height * 0.07);
            textBox.Left = (int)(Width * left);
            textBox.Top = (int)(Height * 0.445);
            textBox.Text = "3000000";
            Util.ScaleFont(textBox);
            textBox.Text = "";
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter ||
                (e.KeyCode != Keys.D0
                && e.KeyCode != Keys.D1
                && e.KeyCode != Keys.D2
                && e.KeyCode != Keys.D3
                && e.KeyCode != Keys.D4
                && e.KeyCode != Keys.D5
                && e.KeyCode != Keys.D6
                && e.KeyCode != Keys.D7
                && e.KeyCode != Keys.D8
                && e.KeyCode != Keys.D9
                && e.KeyCode != Keys.NumPad0
                && e.KeyCode != Keys.NumPad1
                && e.KeyCode != Keys.NumPad2
                && e.KeyCode != Keys.NumPad3
                && e.KeyCode != Keys.NumPad4
                && e.KeyCode != Keys.NumPad5
                && e.KeyCode != Keys.NumPad6
                && e.KeyCode != Keys.NumPad7
                && e.KeyCode != Keys.NumPad8
                && e.KeyCode != Keys.NumPad9
                && e.KeyCode != Keys.Tab
                && e.KeyCode != Keys.Delete
                && e.KeyCode != Keys.Back
                && e.KeyCode != Keys.Oemcomma
                && e.KeyCode != Keys.OemPeriod
                && e.KeyCode != Keys.Left
                && e.KeyCode != Keys.Right))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void Level03EcuacionScreen_Click(object sender, EventArgs e)
        {
            //ConfigAllTextBoxes();
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            RecalcularResultado();
        }

        private void RecalcularResultado()
        {
            String result = String.Empty;

            string text1 = textBox1.Text.Trim();
            string text2 = textBox2.Text.Trim();
            string text3 = textBox3.Text.Trim();
            string text4 = textBox4.Text.Trim();
            string text5 = textBox5.Text.Trim();

            double result1, result2, result3, result4, result5;
            bool valid1, valid2, valid3, valid4, valid5;

            if (text1 != String.Empty && text2 != String.Empty &&
                text3 != String.Empty && text4 != String.Empty &&
                text5 != String.Empty)
            {
                text1 = ((text1 == "319.994" || text1 == "319,994") ? "319994" : text1.Replace(".", ""));
                text2 = text2.Replace(".", "");
                text3 = (text3 == "21.5" ? "21,5" : text3.Replace(".", ""));
                text4.Replace(".", "");
                text5.Replace(".", "");

                valid1 = Double.TryParse(text1, out result1);
                valid2 = Double.TryParse(text2, out result2);
                valid3 = Double.TryParse(text3, out result3);
                valid4 = Double.TryParse(text4, out result4);
                valid5 = Double.TryParse(text5, out result5);

                if (valid1 && valid2 && valid3 && valid4 && valid5)
                {
                    result = Math.Round((result1 / result2) - (result3 * result4) + result5, 2).ToString();
                }
            }

            textBox6.Text = result;
        }

        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
