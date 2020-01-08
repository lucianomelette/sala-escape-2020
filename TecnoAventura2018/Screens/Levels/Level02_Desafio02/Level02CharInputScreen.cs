using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TecnoAventura2018.Properties;
using TecnoAventura2018.Screens.Levels.Level03_Desafio03;

namespace TecnoAventura2018.Screens.Levels.Level02_Desafio02
{
    public partial class Level02CharInputScreen : LevelScreen
    {
        private int counter;

        private enum LEVEL_STATUS
        {
            SEARCHING_CHARS = 0,
            SELECTING_ITEMS = 1,
        };

        private LEVEL_STATUS levelStatus;

        private IList<PictureBox> selectedPictures;

        public Level02CharInputScreen(BoardScreen board) : base(board)
        {
            InitializeComponent();
        }

        private void Level02CharInputScreen_Load(object sender, EventArgs e)
        {
            Init();

            //TestingSelection();
        }

        private void Init()
        {
            counter = 0;

            levelStatus = LEVEL_STATUS.SEARCHING_CHARS;

            selectedPictures = new List<PictureBox>();

            // + Validator panel
            validatorPanel.Width = Width;
            validatorPanel.Height = (int)(Width / 16.54878);
            validatorPanel.Top = Height - validatorPanel.Height;
            validatorPanel.Left = 0;

            // + Char text validator
            inputValidatorText.Multiline = true;
            inputValidatorText.MaxLength = 1;
            inputValidatorText.Width = (int)(Width * 0.1);
            inputValidatorText.Height = (int)(Height * 0.058);
            inputValidatorText.Left = (int)(Width * 0.685);
            inputValidatorText.Top = (int)(Height * 0.925);
            inputValidatorText.Font = FontFamilyProvider.GetCustomFont(40);
            inputValidatorText.Text = "W";
            Util.ScaleFont(inputValidatorText);
            inputValidatorText.Text = "";
            inputValidatorText.BackColor = Color.FromArgb(139, 196, 63);

            // Validate button
            Panel validateButton = new Panel();
            validateButton.BackColor = Color.Transparent;
            //validateButton.BorderStyle = BorderStyle.FixedSingle;
            validateButton.Width = (int)(Width * 0.2);
            validateButton.Height = (int)(Height * 0.058);
            validateButton.Left = (int)(Width * 0.79);
            validateButton.Top = (int)(Height * 0.015);
            validateButton.Click += validateButton_Click;
            validateButton.MouseMove += MouseMoveEvent;
            validatorPanel.Controls.Add(validateButton);

            // + Pictures
            foreach (Control c in Controls)
            {
                if (c.GetType().Equals(typeof(PictureBox)))
                {
                    c.Width = (int)(Width * 0.168);
                    c.Height = (int)(Height * 0.253);
                    c.Click += (s, e) =>
                    {
                        if (levelStatus == LEVEL_STATUS.SELECTING_ITEMS)
                        {
                            if (selectedPictures.Count() < 5 && !selectedPictures.Contains(c))
                            {
                                string num = c.Name.Substring(10).PadLeft(2, '0');
                                c.BackgroundImage =
                                    (Image)Resources.ResourceManager.GetObject("level02_pic" + num + "_sel");

                                selectedPictures.Add((PictureBox)c);
                            }
                        }
                    };
                    c.MouseMove += MouseMoveEvent;

                    // Top
                    if (new[] { "pictureBox1", "pictureBox2", "pictureBox3", "pictureBox4", "pictureBox5" }.Contains(c.Name))
                    {
                        c.Top = (int)(Height * 0.048);
                    }
                    else if (new[] { "pictureBox6", "pictureBox7", "pictureBox8", "pictureBox9", "pictureBox10" }.Contains(c.Name))
                    {
                        c.Top = (int)(Height * 0.328);
                    }
                    else if (new[] { "pictureBox11", "pictureBox12", "pictureBox13", "pictureBox14", "pictureBox15" }.Contains(c.Name))
                    {
                        c.Top = (int)(Height * 0.608);
                    }

                    // Left
                    if (new[] { "pictureBox1", "pictureBox6", "pictureBox11" }.Contains(c.Name))
                    {
                        c.Left = (int)(Width * 0.045);
                    }
                    else if (new[] { "pictureBox2", "pictureBox7", "pictureBox12" }.Contains(c.Name))
                    {
                        c.Left = (int)(Width * 0.23);
                    }
                    else if (new[] { "pictureBox3", "pictureBox8", "pictureBox13" }.Contains(c.Name))
                    {
                        c.Left = (int)(Width * 0.415);
                    }
                    else if (new[] { "pictureBox4", "pictureBox9", "pictureBox14" }.Contains(c.Name))
                    {
                        c.Left = (int)(Width * 0.6);
                    }
                    else if (new[] { "pictureBox5", "pictureBox10", "pictureBox15" }.Contains(c.Name))
                    {
                        c.Left = (int)(Width * 0.785);
                    }
                }
            }

            // + Background image
            BackgroundImage = Resources.level02_items_list;
        }

        private void ResetSelection()
        {
            board.Penalty();

            foreach(PictureBox p in selectedPictures)
            {
                string num = p.Name.Substring(10).PadLeft(2, '0');
                p.BackgroundImage =
                    (Image)Resources.ResourceManager.GetObject("level02_pic" + num);
            }
            selectedPictures.Clear();
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            ValidarCaracter();
        }

        private void ValidarCaracter()
        {
            if (!String.IsNullOrEmpty(inputValidatorText.Text.Trim()))
            {
                switch (inputValidatorText.Text.Trim().ToUpper()[0])
                {
                    case 'O': ValidatePictureVisible(pictureBox1); break;
                    case 'F': ValidatePictureVisible(pictureBox2); break;
                    case '1': ValidatePictureVisible(pictureBox3); break;
                    case '4': ValidatePictureVisible(pictureBox4); break;
                    case 'Y': ValidatePictureVisible(pictureBox5); break;
                    case 'A': ValidatePictureVisible(pictureBox6); break;
                    case 'L': ValidatePictureVisible(pictureBox7); break;
                    case 'Q': ValidatePictureVisible(pictureBox8); break;
                    case 'T': ValidatePictureVisible(pictureBox9); break;
                    case '9': ValidatePictureVisible(pictureBox10); break;
                    case 'X': ValidatePictureVisible(pictureBox11); break;
                    case '2': ValidatePictureVisible(pictureBox12); break;
                    case '7': ValidatePictureVisible(pictureBox13); break;
                    case 'B': ValidatePictureVisible(pictureBox14); break;
                    case '5': ValidatePictureVisible(pictureBox15); break;
                    default: board.Penalty(); break;
                }
            }
            else
            {
                board.Penalty();
            }

            inputValidatorText.Text = "";

            if (counter == 15)
            {
                // Habilitar en la versión final
                ChangeToSelectionMode();

                //board.SuccessNext();
                //board.SetLevelScreen(new Level03IntroScreen(board));
            }
        }

        private void ChangeToSelectionMode()
        {
            levelStatus = LEVEL_STATUS.SELECTING_ITEMS;
            counter = 0;

            // Remove validator panel
            Controls.Remove(validatorPanel);
            Controls.Remove(inputValidatorText);

            Panel validateSelButton = new Panel();
            //validateSelButton.BorderStyle = BorderStyle.FixedSingle;
            validateSelButton.BackColor = Color.Transparent;
            validateSelButton.Width = (int)(Width * 0.2);
            validateSelButton.Height = (int)(Height * 0.058);
            validateSelButton.Top = (int)(Height * 0.92);
            validateSelButton.Left = Width / 2 - validateSelButton.Width / 2;
            validateSelButton.Click += (s, e) =>
            {
                ValidateSelection();
            };
            validateSelButton.MouseMove += MouseMoveEvent;
            Controls.Add(validateSelButton);
        }

        private void ValidateSelection()
        {
            bool ok = (selectedPictures.Count() == 5);

            if (ok)
            {
                board.SuccessOtherOptions();
                board.SetLevelScreen(new Level03IntroScreen(board));
            }
            else
                ResetSelection();
        }

        private void ValidatePictureVisible(PictureBox picture)
        {
            if (picture.Visible != true)
            {
                picture.Visible = true;
                counter++;
            }
            else
                board.Penalty();
        }

        private void TestingSelection()
        {
            ValidatePictureVisible(pictureBox1);
            ValidatePictureVisible(pictureBox2);
            ValidatePictureVisible(pictureBox3);
            ValidatePictureVisible(pictureBox4);
            ValidatePictureVisible(pictureBox5);
            ValidatePictureVisible(pictureBox6);
            ValidatePictureVisible(pictureBox7);
            ValidatePictureVisible(pictureBox8);
            ValidatePictureVisible(pictureBox9);
            ValidatePictureVisible(pictureBox10);
            ValidatePictureVisible(pictureBox11);
            ValidatePictureVisible(pictureBox12);
            ValidatePictureVisible(pictureBox13);
            ValidatePictureVisible(pictureBox14);
            ValidatePictureVisible(pictureBox15);

            ChangeToSelectionMode();
        }

        private void inputValidatorText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ValidarCaracter();
            }
        }

        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
