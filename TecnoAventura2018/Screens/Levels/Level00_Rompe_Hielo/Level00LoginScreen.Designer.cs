namespace TecnoAventura2018.Screens.Levels.Level00_Rompe_Hielo
{
    partial class Level00LoginScreen
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
            this.UserText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UserText
            // 
            this.UserText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserText.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserText.Location = new System.Drawing.Point(58, 53);
            this.UserText.MaxLength = 20;
            this.UserText.Name = "UserText";
            this.UserText.Size = new System.Drawing.Size(550, 32);
            this.UserText.TabIndex = 1;
            this.UserText.Visible = false;
            this.UserText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // Level00LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TecnoAventura2018.Properties.Resources.level00_login_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.UserText);
            this.DoubleBuffered = true;
            this.Name = "Level00LoginScreen";
            this.Size = new System.Drawing.Size(652, 440);
            this.Load += new System.EventHandler(this.Level00LoginScreen_Load);
            this.Click += new System.EventHandler(this.Level00LoginScreen_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserText;
    }
}
