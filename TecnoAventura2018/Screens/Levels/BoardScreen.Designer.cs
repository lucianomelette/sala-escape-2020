namespace TecnoAventura2018.Screens.Levels
{
    partial class BoardScreen
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.clockLabel = new System.Windows.Forms.Label();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.GroupLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // clockLabel
            // 
            this.clockLabel.AutoSize = true;
            this.clockLabel.Location = new System.Drawing.Point(482, 23);
            this.clockLabel.Name = "clockLabel";
            this.clockLabel.Size = new System.Drawing.Size(49, 13);
            this.clockLabel.TabIndex = 1;
            this.clockLabel.Text = "00:00:00";
            // 
            // picTitle
            // 
            this.picTitle.BackColor = System.Drawing.Color.Transparent;
            this.picTitle.BackgroundImage = global::TecnoAventura2018.Properties.Resources.level01_desafio;
            this.picTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picTitle.Location = new System.Drawing.Point(580, 229);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(100, 150);
            this.picTitle.TabIndex = 2;
            this.picTitle.TabStop = false;
            // 
            // GroupLabel
            // 
            this.GroupLabel.AutoSize = true;
            this.GroupLabel.Location = new System.Drawing.Point(372, 13);
            this.GroupLabel.Name = "GroupLabel";
            this.GroupLabel.Size = new System.Drawing.Size(36, 13);
            this.GroupLabel.TabIndex = 3;
            this.GroupLabel.Text = "Grupo";
            // 
            // BoardScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TecnoAventura2018.Properties.Resources.board_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.GroupLabel);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.clockLabel);
            this.Name = "BoardScreen";
            this.Size = new System.Drawing.Size(738, 497);
            this.Load += new System.EventHandler(this.LevelScreen_Load);
            this.Click += new System.EventHandler(this.BoardScreen_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label clockLabel;
        private System.Windows.Forms.PictureBox picTitle;
        private System.Windows.Forms.Label GroupLabel;
    }
}
