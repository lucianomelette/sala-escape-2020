namespace TecnoAventura2018.Screens.Levels.Level06_Desafio06
{ 
    partial class Level06IntroScreen
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
            this.SuspendLayout();
            // 
            // Level06IntroScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TecnoAventura2018.Properties.Resources.level06_intro_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DoubleBuffered = true;
            this.Name = "Level06IntroScreen";
            this.Size = new System.Drawing.Size(655, 433);
            this.Load += new System.EventHandler(this.Level06IntroScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
