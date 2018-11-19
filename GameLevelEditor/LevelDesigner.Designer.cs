namespace GameLevelEditor
{
    partial class LevelDesigner
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
            this.CanvasPBox = new System.Windows.Forms.PictureBox();
            this.spritesheetPBox = new System.Windows.Forms.PictureBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSpacing = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CanvasPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spritesheetPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CanvasPBox
            // 
            this.CanvasPBox.Location = new System.Drawing.Point(13, 29);
            this.CanvasPBox.Name = "CanvasPBox";
            this.CanvasPBox.Size = new System.Drawing.Size(808, 409);
            this.CanvasPBox.TabIndex = 0;
            this.CanvasPBox.TabStop = false;
            this.CanvasPBox.Click += new System.EventHandler(this.CanvasPBox_Click);
            // 
            // spritesheetPBox
            // 
            this.spritesheetPBox.Location = new System.Drawing.Point(828, 29);
            this.spritesheetPBox.Name = "spritesheetPBox";
            this.spritesheetPBox.Size = new System.Drawing.Size(360, 380);
            this.spritesheetPBox.TabIndex = 1;
            this.spritesheetPBox.TabStop = false;
            this.spritesheetPBox.Click += new System.EventHandler(this.spritesheetPBox_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(1113, 415);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Game Level Canvas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(828, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Spritesheet";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(829, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Width:";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(873, 415);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(33, 20);
            this.textBoxWidth.TabIndex = 6;
            this.textBoxWidth.TextChanged += new System.EventHandler(this.textBoxWidth_TextChanged);
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(973, 415);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(33, 20);
            this.textBoxHeight.TabIndex = 8;
            this.textBoxHeight.TextChanged += new System.EventHandler(this.textBoxHeight_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(927, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Height:";
            // 
            // textBoxSpacing
            // 
            this.textBoxSpacing.Location = new System.Drawing.Point(1074, 415);
            this.textBoxSpacing.Name = "textBoxSpacing";
            this.textBoxSpacing.Size = new System.Drawing.Size(33, 20);
            this.textBoxSpacing.TabIndex = 10;
            this.textBoxSpacing.TextChanged += new System.EventHandler(this.textBoxSpacing_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1023, 418);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Spacing:";
            // 
            // LevelDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 450);
            this.Controls.Add(this.textBoxSpacing);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.spritesheetPBox);
            this.Controls.Add(this.CanvasPBox);
            this.Name = "LevelDesigner";
            this.Text = "Level Designer";
            ((System.ComponentModel.ISupportInitialize)(this.CanvasPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spritesheetPBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CanvasPBox;
        private System.Windows.Forms.PictureBox spritesheetPBox;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSpacing;
        private System.Windows.Forms.Label label5;
    }
}

