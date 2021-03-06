﻿namespace GameLevelEditor
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
            this.buttonLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSpacing = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.spritesheetPBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CanvasPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spritesheetPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CanvasPBox
            // 
            this.CanvasPBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CanvasPBox.Location = new System.Drawing.Point(12, 26);
            this.CanvasPBox.Name = "CanvasPBox";
            this.CanvasPBox.Size = new System.Drawing.Size(811, 638);
            this.CanvasPBox.TabIndex = 0;
            this.CanvasPBox.TabStop = false;
            this.CanvasPBox.Click += new System.EventHandler(this.CanvasPBox_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(1114, 644);
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
            this.label1.Location = new System.Drawing.Point(9, 10);
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
            this.label3.Location = new System.Drawing.Point(830, 647);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Width:";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(874, 644);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(33, 20);
            this.textBoxWidth.TabIndex = 6;
            this.textBoxWidth.TextChanged += new System.EventHandler(this.textBoxWidth_TextChanged);
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(974, 644);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(33, 20);
            this.textBoxHeight.TabIndex = 8;
            this.textBoxHeight.TextChanged += new System.EventHandler(this.textBoxHeight_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(928, 647);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Height:";
            // 
            // textBoxSpacing
            // 
            this.textBoxSpacing.Location = new System.Drawing.Point(1075, 644);
            this.textBoxSpacing.Name = "textBoxSpacing";
            this.textBoxSpacing.Size = new System.Drawing.Size(33, 20);
            this.textBoxSpacing.TabIndex = 10;
            this.textBoxSpacing.TextChanged += new System.EventHandler(this.textBoxSpacing_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1024, 647);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Spacing:";
            // 
            // spritesheetPBox
            // 
            this.spritesheetPBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spritesheetPBox.Location = new System.Drawing.Point(833, 26);
            this.spritesheetPBox.Name = "spritesheetPBox";
            this.spritesheetPBox.Size = new System.Drawing.Size(389, 584);
            this.spritesheetPBox.TabIndex = 2;
            this.spritesheetPBox.TabStop = false;
            this.spritesheetPBox.Click += new System.EventHandler(this.spritesheetPBox_Click_1);
            this.spritesheetPBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.spritesheetPBox_DragDrop);
            this.spritesheetPBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.spritesheetPBox_DragEnter);
            // 
            // LevelDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 679);
            this.Controls.Add(this.spritesheetPBox);
            this.Controls.Add(this.textBoxSpacing);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.CanvasPBox);
            this.Name = "LevelDesigner";
            this.Text = "Level Designer";
            this.Shown += new System.EventHandler(this.LevelDesigner_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.CanvasPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spritesheetPBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CanvasPBox;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSpacing;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox spritesheetPBox;
    }
}

