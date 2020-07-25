namespace ProyectoFinal
{
    partial class F_Principal
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Principal));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.C_Modo = new System.Windows.Forms.ComboBox();
            this.B_COMENZAR = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Nombre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // C_Modo
            // 
            this.C_Modo.FormattingEnabled = true;
            this.C_Modo.Items.AddRange(new object[] {
            resources.GetString("C_Modo.Items"),
            resources.GetString("C_Modo.Items1"),
            resources.GetString("C_Modo.Items2")});
            resources.ApplyResources(this.C_Modo, "C_Modo");
            this.C_Modo.Name = "C_Modo";
            this.C_Modo.UseWaitCursor = true;
            // 
            // B_COMENZAR
            // 
            this.B_COMENZAR.BackColor = System.Drawing.Color.Transparent;
            this.B_COMENZAR.FlatAppearance.BorderSize = 0;
            this.B_COMENZAR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.B_COMENZAR, "B_COMENZAR");
            this.B_COMENZAR.Image = global::ProyectoFinal.Properties.Resources.botonPlayfinal4;
            this.B_COMENZAR.Name = "B_COMENZAR";
            this.B_COMENZAR.UseVisualStyleBackColor = false;
            this.B_COMENZAR.Click += new System.EventHandler(this.B_COMENZAR_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // TB_Nombre
            // 
            resources.ApplyResources(this.TB_Nombre, "TB_Nombre");
            this.TB_Nombre.Name = "TB_Nombre";
            // 
            // F_Principal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.BackgroundImage = global::ProyectoFinal.Properties.Resources.fondojuego1;
            this.Controls.Add(this.TB_Nombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.B_COMENZAR);
            this.Controls.Add(this.C_Modo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "F_Principal";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_Principal_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox C_Modo;
        private System.Windows.Forms.Button B_COMENZAR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Nombre;
    }
}

