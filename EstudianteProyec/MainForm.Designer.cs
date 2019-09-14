namespace EstudianteProyec
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.registroToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cosultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroEstudianteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroInscripcionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroToolStripMenuItem1,
            this.cosultasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1066, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // registroToolStripMenuItem1
            // 
            this.registroToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroEstudianteToolStripMenuItem,
            this.registroInscripcionToolStripMenuItem});
            this.registroToolStripMenuItem1.Name = "registroToolStripMenuItem1";
            this.registroToolStripMenuItem1.Size = new System.Drawing.Size(93, 29);
            this.registroToolStripMenuItem1.Text = "Registro";
            this.registroToolStripMenuItem1.Click += new System.EventHandler(this.RegistroToolStripMenuItem1_Click);
            // 
            // cosultasToolStripMenuItem
            // 
            this.cosultasToolStripMenuItem.Name = "cosultasToolStripMenuItem";
            this.cosultasToolStripMenuItem.Size = new System.Drawing.Size(95, 29);
            this.cosultasToolStripMenuItem.Text = "Cosultas";
            this.cosultasToolStripMenuItem.Click += new System.EventHandler(this.CosultasToolStripMenuItem_Click);
            // 
            // registroToolStripMenuItem
            // 
            this.registroToolStripMenuItem.Name = "registroToolStripMenuItem";
            this.registroToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.registroToolStripMenuItem.Text = "Registro";
            this.registroToolStripMenuItem.Click += new System.EventHandler(this.RegistroToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(97, 29);
            this.consultasToolStripMenuItem.Text = "Consulta";
            // 
            // registroEstudianteToolStripMenuItem
            // 
            this.registroEstudianteToolStripMenuItem.Name = "registroEstudianteToolStripMenuItem";
            this.registroEstudianteToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.registroEstudianteToolStripMenuItem.Text = "Registro Estudiante";
            this.registroEstudianteToolStripMenuItem.Click += new System.EventHandler(this.RegistroEstudianteToolStripMenuItem_Click);
            // 
            // registroInscripcionToolStripMenuItem
            // 
            this.registroInscripcionToolStripMenuItem.Name = "registroInscripcionToolStripMenuItem";
            this.registroInscripcionToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.registroInscripcionToolStripMenuItem.Text = "Registro Inscripcion";
            this.registroInscripcionToolStripMenuItem.Click += new System.EventHandler(this.RegistroInscripcionToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 589);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem registroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cosultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroEstudianteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroInscripcionToolStripMenuItem;
    }
}

