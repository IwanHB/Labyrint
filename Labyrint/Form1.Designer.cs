namespace Labyrint
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
            this.buttonLoadMaze = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.thepanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonLoadMaze
            // 
            this.buttonLoadMaze.Location = new System.Drawing.Point(45, 49);
            this.buttonLoadMaze.Name = "buttonLoadMaze";
            this.buttonLoadMaze.Size = new System.Drawing.Size(75, 45);
            this.buttonLoadMaze.TabIndex = 1;
            this.buttonLoadMaze.Text = "Load Maze";
            this.buttonLoadMaze.UseVisualStyleBackColor = true;
            this.buttonLoadMaze.Click += new System.EventHandler(this.buttonLoadMaze_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(45, 114);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonSolve
            // 
            this.buttonSolve.Location = new System.Drawing.Point(45, 169);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(75, 23);
            this.buttonSolve.TabIndex = 3;
            this.buttonSolve.Text = "Solve";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // thepanel
            // 
            this.thepanel.Location = new System.Drawing.Point(185, 49);
            this.thepanel.Name = "thepanel";
            this.thepanel.Size = new System.Drawing.Size(442, 401);
            this.thepanel.TabIndex = 4;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(659, 483);
            this.Controls.Add(this.thepanel);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonLoadMaze);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControl1 userControl11;
        private System.Windows.Forms.Button buttonLoadMaze;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.Panel thepanel;
    }
}

