using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TecnoAventura2018.Screens.Levels
{
    public partial class LevelScreen : UserControl
    {
        protected BoardScreen board;

        public LevelScreen() { }

        public LevelScreen(BoardScreen board)
        {
            this.board = board;

            InitializeComponent();
        }

        public virtual void ExecutePostAudio() { }
    }
}
