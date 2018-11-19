using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameLevelEditor
{
    public partial class LevelDesigner : Form
    {
        public Spritesheet Spritesheet { get; private set; }
        Bitmap canvasArea, spritesheetArea;

        public Point CurrentTile { get; private set; } = new Point();

        public string Filename
        {
            get
            {
                return (Spritesheet != null) ?
                 Spritesheet.Filename : string.Empty;
            }
        }

        public LevelDesigner()
        {
            InitializeComponent();

            // get the dimensions of the canvas area
            canvasArea = new Bitmap(CanvasPBox.Width, CanvasPBox.Height);
            spritesheetArea = new Bitmap(360, 380); // fix these later
            clearCanvas();
            clearSS();
        }

        private void CanvasPBox_Click(object sender, EventArgs e)
        {

        }

        private void spritesheetPBox_Click(object sender, EventArgs e)
        {

        }

        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxHeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSpacing_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.CheckFileExists == true)
                {
                    Spritesheet = new Spritesheet(dlg.FileName);
                    drawGrid();
                }
            }
        }

        private void drawGrid()
        {
            CanvasPBox.DrawToBitmap(canvasArea, CanvasPBox.Bounds);

            Graphics g;
            g = Graphics.FromImage(canvasArea);

            g.Clear(Color.White);

            if (Spritesheet == null)
                return;

            // draw the spritesheet (regardless of size mine you) to the
            g.DrawImage(Spritesheet.Image, 0, 0);

            Pen pen = new Pen(Brushes.Black);

            int height = CanvasPBox.Height;
            int width = CanvasPBox.Width;
            for (int y = 0; y < height; y += Spritesheet.GridHeight + Spritesheet.Spacing)
            {
                g.DrawLine(pen, 0, y, width, y);
            }

            for (int x = 0; x < width; x += Spritesheet.GridWidth + Spritesheet.Spacing)
            {
                g.DrawLine(pen, x, 0, x, height);
            }

            Pen highlight = new Pen(Brushes.Red);
            g.DrawRectangle(highlight,
                CurrentTile.X * (Spritesheet.GridWidth + Spritesheet.Spacing),
                CurrentTile.Y * (Spritesheet.GridHeight + Spritesheet.Spacing),
                Spritesheet.GridWidth + Spritesheet.Spacing,
                Spritesheet.GridHeight + Spritesheet.Spacing);


            g.Dispose();

            CanvasPBox.Image = canvasArea;
        }

        // clear canvas 
        // (we can combine these to to one by passing bitmap)
        private void clearCanvas()
        {
            Graphics g;
            g = Graphics.FromImage(canvasArea);

            g.Clear(Color.White);

            g.Dispose();

            CanvasPBox.Image = canvasArea;
        }

        // clear spritesheet area
        // (we can combine these to to one by passing bitmap)
        private void clearSS()
        {
            Graphics g;
            g = Graphics.FromImage(spritesheetArea);

            g.Clear(Color.White);

            g.Dispose();

            spritesheetPBox.Image = spritesheetArea;
        }


    }

    
}
