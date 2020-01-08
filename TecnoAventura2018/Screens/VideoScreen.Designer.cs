namespace TecnoAventura2018.Screens
{
    partial class VideoScreen
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // vlcControl1
            // 
            this.vlcControl1.BackColor = System.Drawing.Color.Black;
            this.vlcControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcControl1.Location = new System.Drawing.Point(0, 0);
            this.vlcControl1.Name = "vlcControl1";
            this.vlcControl1.Size = new System.Drawing.Size(610, 399);
            this.vlcControl1.Spu = -1;
            this.vlcControl1.TabIndex = 0;
            this.vlcControl1.Text = "vlcControl1";
            this.vlcControl1.VlcLibDirectory = null;
            this.vlcControl1.VlcMediaplayerOptions = null;
            this.vlcControl1.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);
            // 
            // VideoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vlcControl1);
            this.Name = "VideoScreen";
            this.Size = new System.Drawing.Size(610, 399);
            this.Load += new System.EventHandler(this.VideoScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Vlc.DotNet.Forms.VlcControl vlcControl1;
    }
}
