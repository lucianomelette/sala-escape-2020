using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnoAventura2018.Properties;
using TecnoAventura2018.Screens;
using TecnoAventura2018.Screens.Intro;
using TecnoAventura2018.Screens.Levels;
using TecnoAventura2018.Screens.Levels.Level00_Rompe_Hielo;

namespace TecnoAventura2018
{
    public partial class GameForm : Form
    {
        private ScreenUI _lastScreen = null;
        private VideoScreen _videoScreen = null;
        private VideoStoppableScreen _videoStoppableScreen = null;

        private Timer _videoDelayTimer = new Timer();
        private Timer _videoStoppableDelayTimer = new Timer();

        public String GroupName { get; set; }

        public GameForm()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();

            SetFullscreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            // Video delay timer
            _videoDelayTimer.Interval = 1000;
            _videoDelayTimer.Tick += (s, e) =>
            {
                SetVideoVisible(true);
                _videoDelayTimer.Stop();
            };

            // Video Stoppable delay timer
            _videoStoppableDelayTimer.Interval = 1000;
            _videoStoppableDelayTimer.Tick += (s, e) =>
            {
                SetVideoStoppableVisible(true);
                _videoStoppableDelayTimer.Stop();
            };

            SetVideoScreen();

            SetVideoStoppableScreen();

            SetScreen(new IntroScreen(this));
            //SetScreen(new BoardScreen(this));
        }

        private void SetFullscreen()
        {
            //this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        public void SetScreen(ScreenUI screen)
        {
            if (_lastScreen != null)
            {
                Controls.Remove(_lastScreen);
                _lastScreen.Dispose();
            }

            Controls.Add(screen);

            _lastScreen = screen;
        }

        public void ExecutePostAudio()
        {
            _lastScreen.ExecutePostAudio();
        }

        public void SetScreenAfterVideo(ScreenUI nextScreen)
        {
            SetVideoVisible(false);

            if (nextScreen != null)
                SetScreen(nextScreen);
        }

        // Video Stoppable NEW
        public void SetScreenAfterVideoStoppable()
        {
            SetVideoStoppableVisible(false);

            //if (nextScreen != null)
                //SetScreen(nextScreen);
        }

        private void SetVideoScreen()
        {
            _videoScreen = new VideoScreen(this);
            Controls.Add(_videoScreen);
            _videoScreen.Visible = false;
        }

        // Video Stoppable NEW
        private void SetVideoStoppableScreen()
        {
            _videoStoppableScreen = new VideoStoppableScreen(this);
            Controls.Add(_videoStoppableScreen);
            _videoStoppableScreen.Visible = false;
        }

        public void PlayVideo(String filename, ScreenUI nextScreen, bool delay)
        {
            if (_videoScreen != null)
            {
                if (delay)
                {
                    _videoScreen.Play(filename, nextScreen);
                    _videoDelayTimer.Start();
                }
                else
                {
                    SetVideoVisible(true);
                    _videoScreen.Play(filename, nextScreen);
                }
            }
            else
            {
                throw new Exception();
            }
        }

        // Video Stoppable NEW
        public void PlayVideoStoppable(String filename, bool delay, bool stoppable)
        {
            if (_videoStoppableScreen != null)
            {
                if (delay)
                {
                    _videoStoppableScreen.Play(filename, stoppable);
                    _videoStoppableDelayTimer.Start();
                }
                else
                {
                    SetVideoStoppableVisible(true);
                    _videoStoppableScreen.Play(filename, stoppable);
                }
            }
            else
            {
                throw new Exception();
            }
        }

        public void PlayAudio(String filename)
        {
            if (_videoScreen != null)
            {
                _videoScreen.PlayAudio(filename);
            }
        }

        private void SetVideoVisible(bool visible)
        {
            _videoScreen.Visible = visible;
            if (visible)
                _videoScreen.BringToFront();
            else
                _videoScreen.SendToBack();
        }

        private void SetVideoStoppableVisible(bool visible)
        {
            _videoStoppableScreen.Visible = visible;
            if (visible)
                _videoStoppableScreen.BringToFront();
            else
                _videoStoppableScreen.SendToBack();
        }

        public void Penalty()
        {
            int penaltyDiscounter = 10;

            Form f = new Form();
            f.FormBorderStyle = FormBorderStyle.None;
            f.StartPosition = FormStartPosition.Manual;
            f.BackColor = Color.FromArgb(255, 12, 110, 183);
            f.BackgroundImage = Resources.board_penalty_bg;
            f.BackgroundImageLayout = ImageLayout.Stretch;
            f.Width = Width;
            f.Height = (int)(Width / 5.067164);
            f.Top = Height / 2 - f.Height / 2;
            f.Left = 0;
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
            Success(Resources.board_success_next_bg);
        }

        public void Success()
        {
            Success(Resources.board_success_bg);
        }

        private void Success(Bitmap img)
        {
            int successDiscounter = 3;

            Form f = new Form();
            f.FormBorderStyle = FormBorderStyle.None;
            f.StartPosition = FormStartPosition.Manual;
            f.BackColor = Color.FromArgb(255, 12, 110, 183);
            f.BackgroundImage = img;
            f.BackgroundImageLayout = ImageLayout.Stretch;
            f.Width = Width;
            f.Height = (int)(Width / 5.067164);
            f.Top = Height / 2 - f.Height / 2;
            f.Left = 0;
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
    }
}
