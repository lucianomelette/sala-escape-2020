namespace TecnoAventura2018.Screens.Levels.Level04_Desafio04
{
    partial class Level04StandByScreen
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
            // Level04StandByScreen
            // 
            this.BackgroundImage = global::TecnoAventura2018.Properties.Resources.level04_situation01;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DoubleBuffered = true;
            this.Name = "Level04StandByScreen";
            this.Size = new System.Drawing.Size(531, 354);
            this.Load += new System.EventHandler(this.Level04StandByScreen_Load);
            this.Click += new System.EventHandler(this.Level04StandByScreen_Click);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
