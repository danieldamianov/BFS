namespace PathFinding
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
            this.labyrinthPanel = new System.Windows.Forms.Panel();
            this.Label = new System.Windows.Forms.Label();
            this.FindPathButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labyrinthPanel
            // 
            this.labyrinthPanel.AutoSize = true;
            this.labyrinthPanel.Location = new System.Drawing.Point(12, 103);
            this.labyrinthPanel.Name = "labyrinthPanel";
            this.labyrinthPanel.Size = new System.Drawing.Size(1200, 600);
            this.labyrinthPanel.TabIndex = 0;
            this.labyrinthPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.labyrinthPanel_Paint);
            // 
            // Label
            // 
            this.Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label.Location = new System.Drawing.Point(12, 9);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(1156, 73);
            this.Label.TabIndex = 1;
            this.Label.Text = "label1";
            this.Label.Click += new System.EventHandler(this.Label_Click);
            // 
            // FindPathButton
            // 
            this.FindPathButton.Location = new System.Drawing.Point(874, 19);
            this.FindPathButton.Name = "FindPathButton";
            this.FindPathButton.Size = new System.Drawing.Size(233, 33);
            this.FindPathButton.TabIndex = 2;
            this.FindPathButton.Text = "Find Path";
            this.FindPathButton.UseVisualStyleBackColor = true;
            this.FindPathButton.Visible = false;
            this.FindPathButton.Click += new System.EventHandler(this.FindPathButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1370, 826);
            this.Controls.Add(this.FindPathButton);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.labyrinthPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel labyrinthPanel;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Button FindPathButton;
    }
}

