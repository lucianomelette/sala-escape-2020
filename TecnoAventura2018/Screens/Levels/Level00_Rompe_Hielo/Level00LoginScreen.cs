using System;
using System.Drawing;
using System.Windows.Forms;
using TecnoAventura2018.Properties;

namespace TecnoAventura2018.Screens.Levels.Level00_Rompe_Hielo
{
    public partial class Level00LoginScreen : ScreenUI
    {
        private Panel _loginButton;

        public Level00LoginScreen(GameForm form) : base(form)
        {
            InitializeComponent();
        }

        private void Level00LoginScreen_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            _loginButton = new Panel();
            _loginButton.BringToFront();
            _loginButton.Click += Login;
            _loginButton.MouseMove += MouseMoveEvent;
            Controls.Add(_loginButton);

            ConfigControls();       

            UserText.Visible = true;
        }

        private void Login(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(UserText.Text.Trim()))
            {
                UserText.Visible = false;
                BackgroundImage = Resources.level00_login_welcome_bg;

                form.GroupName = UserText.Text;

                Label groupName = new Label();
                groupName.Text = UserText.Text;
                groupName.Font = FontFamilyProvider.GetCustomFont(35);
                groupName.Width = Width;
                groupName.Left = 0;
                groupName.Height = (int)(Height * 0.35);
                groupName.Top = (int)(Height * 0.5);
                groupName.BackColor = Color.Transparent;
                groupName.TextAlign = ContentAlignment.MiddleCenter;
                Util.ScaleFont(groupName);
                Controls.Add(groupName);
                groupName.BringToFront();

                Timer t = new Timer();
                t.Interval = 2500;
                t.Tick += (s1, e1) =>
                {
                    t.Stop();
                    form.SetScreen(new BoardScreen(form));
                };
                t.Start();
            }
            else
            {
                form.Penalty();
            }
        }

        private void ConfigControls()
        {
            ConfigTextBox(UserText, (int)(0.488 * Height));

            _loginButton.Width = (int)(Width * 0.205);
            _loginButton.Height = (int)(Height * 0.07);
            _loginButton.Left = Width / 2 - _loginButton.Width / 2;
            _loginButton.Top = (int)(Height * 0.66);
            _loginButton.BackColor = Color.Transparent;
            //_loginButton.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ConfigTextBox(TextBox text, int top)
        {
            text.Width = (int)(0.375 * Width);
            text.Height = (int)(0.0540 * Height);
            //text.MaximumSize = new Size(text.Width, text.Height);
            text.MaximumSize = new Size(1000000, 1000000);
            text.Left = (Width / 2 - text.Width / 2) - (int)(Width * 0.0042);
            text.Top = top;

            // Font style
            text.Multiline = true;
            text.MaxLength = 19;
            text.Font = FontFamilyProvider.GetCustomFont(40);
            text.Text = "Ingrese el texto aquí";
            Util.ScaleFont(text);
            text.Text = "";
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void Level00LoginScreen_Click(object sender, EventArgs e)
        {
            //ConfigControls();
        }

        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
