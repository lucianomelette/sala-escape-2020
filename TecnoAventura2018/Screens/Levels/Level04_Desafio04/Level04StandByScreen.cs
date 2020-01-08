using System;
using System.Drawing;
using System.Windows.Forms;
using TecnoAventura2018.Properties;
using TecnoAventura2018.Screens.Levels.Level05_Desafio05;

namespace TecnoAventura2018.Screens.Levels.Level04_Desafio04
{
    public partial class Level04StandByScreen : LevelScreen
    {
        private Panel buttonA;
        private Panel buttonB;
        private Panel buttonC;

        public Level04StandByScreen(BoardScreen board) : base(board)
        {
            InitializeComponent();
        }

        private void Level04StandByScreen_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            buttonA = new Panel();
            buttonB = new Panel();
            buttonC = new Panel();

            ConfigAllButtons();

            buttonA.Click += AnswerSituation01;
            buttonB.Click += AnswerSituation01;
            buttonC.Click += AnswerSituation01;

            Controls.Add(buttonA);
            Controls.Add(buttonB);
            Controls.Add(buttonC);
        }

        private void ConfigAllButtons()
        {
            ConfigButton(buttonA, "buttonA", (int)(Height * 0.384));
            ConfigButton(buttonB, "buttonB", (int)(Height * 0.527));
            ConfigButton(buttonC, "buttonC", (int)(Height * 0.67));
        }

        private void ConfigButton(Panel button, String name, int top)
        {
            // + Next button
            //button = new Panel();
            button.Name = name;
            button.BackgroundImageLayout = ImageLayout.Zoom;
            button.Width = (int)(Width * 0.376);
            button.Height = (int)(Height * 0.098);
            button.Left = (int)(Width * 0.3);
            button.Top = top;
            button.BackColor = Color.Transparent;
            //button.BorderStyle = BorderStyle.FixedSingle;
            button.MouseMove += MouseMoveEvent;
        }

        private void Level04StandByScreen_Click(object sender, EventArgs e)
        {
            //ConfigAllButtons();
        }

        private void PaintButton(Panel btn)
        {
            if (btn.Name.Equals("buttonA"))
            {
                buttonA.BackgroundImage = Resources.level04_optionA;
            }
            else if (btn.Name.Equals("buttonB"))
            {
                buttonB.BackgroundImage = Resources.level04_optionB;
            }
            else if (btn.Name.Equals("buttonC"))
            {
                buttonC.BackgroundImage = Resources.level04_optionC;
            }
        }

        private void AnswerSituation01(object sender, EventArgs e)
        {
            buttonA.Click -= AnswerSituation01;
            buttonB.Click -= AnswerSituation01;
            buttonC.Click -= AnswerSituation01;

            buttonA.MouseMove -= MouseMoveEvent;
            buttonB.MouseMove -= MouseMoveEvent;
            buttonC.MouseMove -= MouseMoveEvent;

            Panel btn = (Panel)sender;
            PaintButton(btn);

            board.SuccessOtherOptions();

            BackgroundImage = Resources.level04_situation02;
            ResetButtons();
        }

        private void ResetButtons()
        {
            buttonA.BackgroundImage = null;
            buttonB.BackgroundImage = null;
            buttonC.BackgroundImage = null;

            buttonA.Click += AnswerSituation02;
            buttonB.Click += AnswerSituation02;
            buttonC.Click += AnswerSituation02;

            buttonA.MouseMove += MouseMoveEvent;
            buttonB.MouseMove += MouseMoveEvent;
            buttonC.MouseMove += MouseMoveEvent;
        }

        private void AnswerSituation02(object sender, EventArgs e)
        {
            buttonA.Click -= AnswerSituation02;
            buttonB.Click -= AnswerSituation02;
            buttonC.Click -= AnswerSituation02;

            buttonA.MouseMove -= MouseMoveEvent;
            buttonB.MouseMove -= MouseMoveEvent;
            buttonC.MouseMove -= MouseMoveEvent;

            Panel btn = (Panel)sender;
            PaintButton(btn);

            board.SuccessOtherOptions();
            board.SetLevelScreen(new Level05IntroScreen(board));
        }

        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
