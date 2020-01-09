using System;
using System.Drawing;
using System.Windows.Forms;
using TecnoAventura2018.Properties;
using TecnoAventura2018.Screens.Levels.Level07_Desafio07;

namespace TecnoAventura2018.Screens.Levels.Level05_Desafio05
{
    public partial class Level05Question04Screen : LevelScreen
    {
        private Panel _okPanel;
        private Panel _errorPanel;
        private Panel _closeButton;

        public Level05Question04Screen(BoardScreen board) : base(board)
        {
            InitializeComponent();
        }

        private void Level05Question04Screen_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            _okPanel = new Panel();
            _okPanel.BackColor = Color.Transparent;
            //_okPanel.BorderStyle = BorderStyle.FixedSingle;
            _okPanel.Width = (int)(Width * 0.84);
            _okPanel.Height = (int)(Height * 0.07);
            _okPanel.Top = (int)(Height * 0.81);
            _okPanel.Left = (int)(Width * 0.077);
            _okPanel.Click += CorrectAnswer;
            _okPanel.MouseMove += MouseMoveEvent;
            Controls.Add(_okPanel);

            _errorPanel = new Panel();
            _errorPanel.BackColor = Color.Transparent;
            //_errorPanel.BorderStyle = BorderStyle.FixedSingle;
            _errorPanel.Width = (int)(Width * 0.84);
            _errorPanel.Height = (int)(Height * 0.43);
            _errorPanel.Top = (int)(Height * 0.45);
            _errorPanel.Left = (int)(Width * 0.077);
            _errorPanel.Click += IncorrectAnswer;
            _errorPanel.MouseMove += MouseMoveEvent;
            Controls.Add(_errorPanel);
        }

        private void CorrectAnswer(object sender, EventArgs e)
        {
            _okPanel.Click -= CorrectAnswer;
            _okPanel.MouseMove -= MouseMoveEvent;
            _okPanel.Dispose();

            _errorPanel.Click -= IncorrectAnswer;
            _errorPanel.MouseMove -= MouseMoveEvent;
            _errorPanel.Dispose();

            board.Success();

            BackgroundImage = Resources.level05_popup04;

            _closeButton = new Panel();
            _closeButton.Click += (s1, e1) =>
            {
                board.SetLevelScreen(new Level07IntroScreen(board));
            };
            _closeButton.MouseMove += MouseMoveEvent;
            setupCloseButton();
            Controls.Add(_closeButton);
        }

        private void IncorrectAnswer(object sender, EventArgs e)
        {
            board.Penalty();
        }

        private void setupCloseButton()
        {
            _closeButton.Width = (int)(Width * 0.045);
            _closeButton.Height = (int)(Height * 0.043);
            _closeButton.Left = (int)(Width * 0.822);
            _closeButton.Top = (int)(Height * 0.285);
            //_closeButton.BorderStyle = BorderStyle.FixedSingle;
            _closeButton.BackColor = Color.Transparent;
            _closeButton.BringToFront();
        }

        private void Level05Question04Screen_Click(object sender, EventArgs e)
        {
            //setupCloseButton();
        }

        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
