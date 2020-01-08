using Simon2018.Audio;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TecnoAventura2018.Properties;
using TecnoAventura2018.Screens.Levels.Level01_Desafio01;
using TecnoAventura2018.Screens.Levels.Level04_Desafio04;
using TecnoAventura2018.Screens.Levels.Level05_Desafio05;
using TecnoAventura2018.Screens.Levels.Level06_Desafio06;
using TecnoAventura2018.Screens.Levels.Level07_Desafio07;

namespace TecnoAventura2018.Screens.Levels
{
    public partial class BoardScreen : ScreenUI
    {
        private LevelScreen _lastLevel;

        private int clockDiscounter;

        private CachedSound _errorSound = new CachedSound(new FileInfo("audios/incorrecto.wav").FullName);
        private CachedSound _correctSound = new CachedSound(new FileInfo("audios/correcto.wav").FullName);

        public BoardScreen(GameForm form) : base(form)
        {
            InitializeComponent();
        }

        private void LevelScreen_Load(object sender, System.EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            // level
            _lastLevel = null;

            // clock
            clockDiscounter = 60 * 45;
            UpdateClock();

            // timer
            timer1.Interval = 1000;
            timer1.Start();

            // + Clock text
            //clockLabel.ReadOnly = true;
            //clockLabel.Multiline = true;
            clockLabel.AutoSize = false;
            clockLabel.BackColor = Color.White;
            clockLabel.Width = (int)(bgWidth * 0.08);
            clockLabel.Height = (int)(bgHeight * 0.04);
            clockLabel.Top = (int)(bgHeight * 0.151) + screenMarginTop;
            clockLabel.Left = (int)(bgWidth - clockLabel.Width - bgWidth * 0.09) + screenMarginLeft;
            clockLabel.Font = FontFamilyProvider.GetCustomFont(35);
            clockLabel.TextAlign = ContentAlignment.MiddleCenter;
            clockLabel.Text = "00:00:00";
            //clockLabel.Visible = false;
            // scale font
            Util.ScaleFont(clockLabel);

            // + Group level
            GroupLabel.AutoSize = false;
            GroupLabel.BackColor = Color.White;
            GroupLabel.Width = (int)(bgWidth * 0.08);
            GroupLabel.Height = (int)(bgHeight * 0.04);
            GroupLabel.Top = (int)(bgHeight * 0.105) + screenMarginTop;
            GroupLabel.Left = (int)(bgWidth - GroupLabel.Width - bgWidth * 0.09) + screenMarginLeft;
            GroupLabel.Font = FontFamilyProvider.GetCustomFont(35);
            GroupLabel.TextAlign = ContentAlignment.MiddleCenter;
            GroupLabel.Text = form.GroupName;
            GroupLabel.Visible = true;
            // scale font
            Util.ScaleFont(GroupLabel);

            // + Picture title
            picTitle.Visible = false;
            picTitle.Width = (int)(bgWidth * 0.14);
            picTitle.Height = (int)(picTitle.Width / 0.63441);
            picTitle.Left = (int)(bgWidth - clockLabel.Width - bgWidth * 0.135) + screenMarginLeft;
            picTitle.Top = (int)(bgHeight * 0.42) + screenMarginTop;
            picTitle.Visible = true;

            SetLevelScreen(new Level01IntroScreen(this));
            //SetLevelScreen(new Level06EcuacionScreen(this));
        }

        public void SetGroupName(string groupName)
        {
            GroupLabel.Text = groupName;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (--clockDiscounter == 0)
                timer1.Stop();

            UpdateClock();
        }

        private void UpdateClock()
        {
            int mins = clockDiscounter / 60;
            int secs = clockDiscounter - mins * 60;

            clockLabel.Text = "00:" + (mins).ToString().PadLeft(2, '0') + 
                ":" + secs.ToString().PadLeft(2, '0');
        }

        internal void SetScreen(ScreenUI screen)
        {
            form.SetScreen(screen);
        }

        public void SetLevelScreen(LevelScreen level)
        {
            if (_lastLevel != null)
            {
                Controls.Remove(_lastLevel);
                _lastLevel.Controls.Clear();
                _lastLevel.Dispose();
                GC.SuppressFinalize(_lastLevel);
            }

            level.Width = (int)(bgWidth * 0.707);
            level.Height = (int)(bgHeight * 0.839);
            level.Top = (int)(bgHeight * 0.085) + screenMarginTop;
            level.Left = (int)(bgWidth * 0.069) + screenMarginLeft;

            Controls.Add(level);

            _lastLevel = level;
        }

        public void SetTitle(Bitmap title)
        {
            picTitle.BackgroundImage = title;
        }

        public void Penalty()
        {
            PlayErrorSound();

            int penaltyDiscounter = 10;

            Form f = new Form();
            f.FormBorderStyle = FormBorderStyle.None;
            f.StartPosition = FormStartPosition.Manual;
            f.BackColor = Color.FromArgb(255, 12, 110, 183);
            f.BackgroundImage = Resources.board_penalty_bg;
            f.BackgroundImageLayout = ImageLayout.Stretch;
            f.Width = _lastLevel.Width;
            f.Height = (int)(_lastLevel.Width / 5.067164);
            f.Top = _lastLevel.Height / 2 - f.Height / 2 + _lastLevel.Top;
            f.Left = _lastLevel.Left;
            f.Load += (s, e) =>
            {
                Label counter = new Label();
                counter.BackColor = Color.Transparent;
                counter.ForeColor = Color.White;
                counter.TextAlign = ContentAlignment.MiddleCenter;
                counter.Text = "10 segundos";
                counter.AutoSize = true;
                counter.MinimumSize = new Size(f.Width, 0);
                counter.Font = FontFamilyProvider.GetCustomFont(30);
                counter.Height = (int)(f.Height * 0.2);
                counter.Left = f.Width / 2 - counter.Width / 2;
                counter.Top = f.Height / 2 - counter.Height / 2 + (int)(f.Height * 0.2);
                Util.ScaleFont(counter);
                f.Controls.Add(counter);

                Timer timer = new Timer();
                timer.Interval = 1000;
                timer.Start();
                timer.Tick += (s1, e1) =>
                {
                    if (--penaltyDiscounter == -1)
                    {
                        timer.Stop();
                        f.Close();
                        f.Dispose();
                    }

                    counter.Left = f.Width / 2 - counter.Width / 2;
                    counter.Text = penaltyDiscounter + (penaltyDiscounter == 1 ? " segundo" : " segundos");
                };
            };
           
            f.ShowDialog();
        }

        public void SuccessNext()
        {
            PlayCorrectSound();
            ShowDialog(Resources.board_success_next_bg);
        }

        public void SuccessOtherOptions()
        {
            PlayCorrectSound();
            ShowDialog(Resources.board_success_other_bg);
        }

        public void Success()
        {
            PlayCorrectSound();
            ShowDialog(Resources.board_success_bg);
        }

        public void ShowDialog(Bitmap img, int discounter = 3)
        {
            int successDiscounter = discounter;

            Form f = new Form();
            f.FormBorderStyle = FormBorderStyle.None;
            f.StartPosition = FormStartPosition.Manual;
            f.BackColor = Color.FromArgb(255, 12, 110, 183);
            f.TransparencyKey = Color.FromArgb(255, 12, 110, 183);
            f.BackgroundImage = img;
            f.BackgroundImageLayout = ImageLayout.Stretch;
            f.Width = _lastLevel.Width;
            f.Height = (int)(_lastLevel.Width / 5.067164);
            f.Top = _lastLevel.Height / 2 - f.Height / 2 + _lastLevel.Top;
            f.Left = _lastLevel.Left;
            f.Load += (s, e) =>
            {
                Timer timer = new Timer();
                timer.Interval = 1000;
                timer.Start();
                timer.Tick += (s1, e1) =>
                {
                    if (--successDiscounter == -1)
                    {
                        timer.Stop();
                        f.Close();
                        f.Dispose();
                    }
                };
            };

            f.ShowDialog();
        }

        public void PlayAudio(String filename)
        {
            form.PlayAudio(filename);
        }

        public override void ExecutePostAudio()
        {
            base.ExecutePostAudio();

            _lastLevel.ExecutePostAudio();
        }

        public GameForm GetForm()
        {
            return form;
        }

        private void BoardScreen_Click(object sender, EventArgs e)
        {
        }

        public void PlaySound(CachedSound cs)
        {
            AudioPlaybackEngine.Instance.PlaySound(cs);
        }

        public void PlayErrorSound()
        {
            PlaySound(_errorSound);
        }

        public void PlayCorrectSound()
        {
            PlaySound(_correctSound);
        }
    }
}
 