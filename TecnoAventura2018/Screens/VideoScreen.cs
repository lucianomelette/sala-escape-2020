using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using TecnoAventura2018.Properties;
using Vlc.DotNet.Core;
using TecnoAventura2018.Screens.Levels;
using System.Threading;

namespace TecnoAventura2018.Screens
{
    public partial class VideoScreen : ScreenUI
    {
        private int _distroyCounter = 0;

        private bool _isAudio = false;

        private ScreenUI _nextScreen = null;

        public VideoScreen(GameForm form) : base(form)
        {
            InitializeComponent();
        }

        private void VideoScreen_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            vlcControl1.SetBounds(0, 0, Width, Height);

            RegisterHandlers();
        }

        public void Play(String filename, ScreenUI nextScreen)
        {
            _isAudio = false;

            _nextScreen = nextScreen;

            // Play video
            vlcControl1.Play(new System.IO.FileInfo("videos/" + filename.Trim()));
        }

        public void PlayAudio(String filename)
        {
            _isAudio = true;

            // Play audio
            vlcControl1.Play(new System.IO.FileInfo("audios/" + filename.Trim()));
        }

        private void RegisterHandlers()
        {
            // change screen when video is finished
            vlcControl1.EndReached += (s1, e1) => {
                if (form.InvokeRequired)
                {
                    form.Invoke(new MethodInvoker(delegate
                    {
                        if (_isAudio)
                            form.ExecutePostAudio();
                        else
                            form.SetScreenAfterVideo(_nextScreen);
                    }));
                }
            };

            // destroy vlc control
            vlcControl1.HandleDestroyed += (s1, e1) =>
            {
                _distroyCounter++;
                Console.WriteLine("VLC control distroyed #" + _distroyCounter);
                vlcControl1.Dispose();
            };
        }

        /// <summary>
        /// When the Vlc control needs to find the location of the libvlc.dll.
        /// You could have set the VlcLibDirectory in the designer, but for this sample, we are in AnyCPU mode, and we don't know the process bitness.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vlcControl1_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;

            // Default installation path of VideoLAN.LibVLC.Windows
            e.VlcLibDirectory = new DirectoryInfo(
                Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }
    }
}
