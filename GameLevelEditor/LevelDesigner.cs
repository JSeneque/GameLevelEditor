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

        // stores the tiles drawn on the map
        // private TileInfo tiles[180] = new TileInfo[180];

        // has the information for the selected tile
        TileInfo selectedTile;

        // stores the map of the level draw
        TileInfo[] map;


        int gridWidth = 16;
        int gridHeight = 16;
        int spacing = 0;


        public Point SelectedCanvasTile { get; private set; } = new Point();
        public Point SelectedSpritesheetTile { get; private set; } = new Point();

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
            //spritesheetArea = new Bitmap (spritesheetPBox.Width, spritesheetPBox.Height); // fix these later
            clearCanvas();
            //clearSS();

            // we can ask the user to define the size of the map at the start
            map = new TileInfo[180];

            // allow dragging an image to the spritesheet picture box
            spritesheetPBox.AllowDrop = true;
        }

        private void CanvasPBox_Click(object sender, EventArgs e)
        {
            if (Spritesheet == null)
                return;

            // get tile coordinate of click 
            if (e.GetType() == typeof(MouseEventArgs))
            {
                MouseEventArgs mouse = e as MouseEventArgs;

                // draw the current tile there
                SelectedCanvasTile = new Point(
                    mouse.X / (gridWidth + spacing)
                    , mouse.Y / (gridHeight + spacing));

                // add the selected tiles to the map list
                map[SelectedCanvasTile.X + (SelectedCanvasTile.Y)*15] =  selectedTile;

                DrawTiles();
                //drawGridOnCanvas();
                
            }
        }

        private void spritesheetPBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void spritesheetPBox_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string pic in ((string[])e.Data.GetData(DataFormats.FileDrop)))
            {
                Image img = Image.FromFile(pic);
                spritesheetPBox.Image = img;
                Spritesheet = new Spritesheet(pic);
            }
            
            spritesheetArea = new Bitmap(Spritesheet.Width, Spritesheet.Height);
            drawGrid();
        }


        private void DrawTile()
        {
            // assign the drawing canvas
            Graphics g = Graphics.FromImage(canvasArea);

            // define the size of the tile
            // understand what << 2 means exactly
            Rectangle dest = new Rectangle(0, 0, gridWidth << 2, gridHeight << 2);
        }

        private void spritesheetPBox_Click(object sender, EventArgs e)
        {

        }

        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxWidth.Text, out gridWidth) == true)
            {
                drawGrid();
            }

            textBoxWidth.Text = gridWidth.ToString();
            Spritesheet.GridWidth = gridWidth;
        }

        private void textBoxHeight_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxHeight.Text, out gridHeight) == true)
            {
                drawGrid();
            }

            textBoxHeight.Text = gridHeight.ToString();
            Spritesheet.GridHeight = gridHeight;
        }

        private void textBoxSpacing_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxSpacing.Text, out spacing) == true)
            {
                drawGrid();
            }

            textBoxSpacing.Text = spacing.ToString();
            Spritesheet.GridSpacing = spacing;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.CheckFileExists == true)
                {
                    Spritesheet = new Spritesheet(dlg.FileName);
                    spritesheetArea = new Bitmap(Spritesheet.Width, Spritesheet.Height);
                    drawGrid();
                }
            }
        }

        private void drawGrid()
        {
            //drawGridOnCanvas();
            drawGridOnSpritesheet();
        }

        private void drawGridOnCanvas()
        {
            CanvasPBox.DrawToBitmap(canvasArea, CanvasPBox.Bounds);

            Graphics g;
            g = Graphics.FromImage(canvasArea);

            //g.Clear(Color.White);

            if (Spritesheet == null)
                return;

            Pen pen = new Pen(Brushes.LightGray);

            int height = CanvasPBox.Height;
            int width = CanvasPBox.Width;
            for (int y = 0; y < height; y += gridHeight + spacing)
            {
                g.DrawLine(pen, 0, y, width, y);
            }

            for (int x = 0; x < width; x += gridWidth + spacing)
            {
                g.DrawLine(pen, x, 0, x, height);
            }

            Pen highlight = new Pen(Brushes.Red);
            g.DrawRectangle(highlight,
                SelectedCanvasTile.X * (gridWidth + spacing),
                SelectedCanvasTile.Y * (gridHeight + spacing),
                gridWidth + spacing,
                gridHeight + spacing);


            g.Dispose();

            CanvasPBox.Image = canvasArea;
        }

        private void drawGridOnSpritesheet()
        {
            spritesheetPBox.DrawToBitmap(spritesheetArea, spritesheetPBox.Bounds);

            Graphics g;
            g = Graphics.FromImage(spritesheetArea);

            g.Clear(Color.White);

            if (Spritesheet == null)
                return;

            // draw the spritesheet (regardless of size mine you) to the
            g.DrawImage(Spritesheet.Image, 0, 0);
            //g.DrawImageU

            Pen pen = new Pen(Brushes.LightGray);

            int height = spritesheetPBox.Height;
            int width = spritesheetPBox.Width;
            for (int y = 0; y < height; y += gridHeight + spacing)
            {
                g.DrawLine(pen, 0, y, width, y);
            }

            for (int x = 0; x < width; x += gridWidth + spacing)
            {
                g.DrawLine(pen, x, 0, x, height);
            }

            Pen highlight = new Pen(Brushes.Red);
            g.DrawRectangle(highlight,
                SelectedSpritesheetTile.X * (gridWidth + spacing),
                SelectedSpritesheetTile.Y * (gridHeight + spacing),
                gridWidth + spacing,
                gridHeight + spacing);


            g.Dispose();

            spritesheetPBox.Image = spritesheetArea;
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

        private void spritesheetPBox_Click_1(object sender, EventArgs e)
        {
            if (Spritesheet == null)
                return;
            
            // get tile coordinate of click 
            if (e.GetType() == typeof(MouseEventArgs))
            {
                MouseEventArgs mouse = e as MouseEventArgs;
                SelectedSpritesheetTile = new Point( 
                    mouse.X / (gridWidth + spacing)
                    , mouse.Y / (gridHeight + spacing));

                selectedTile = new TileInfo(SelectedSpritesheetTile, Spritesheet);

                drawGridOnSpritesheet();
            }
        }

        private void LevelDesigner_Shown(object sender, EventArgs e)
        {
            //drawGrid();
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

        private void DrawTiles()
        {
            Graphics g = Graphics.FromImage(canvasArea);
            g.FillRectangle(Brushes.White, 0, 0, canvasArea.Width, canvasArea.Height);

            

            // paint the tiles to the picturebox
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] != null)
                {
                    // get the tile at that map location
                    TileInfo tile = map[i];
                    int row, col;

                    // determine the grid position based
                    // hardcoded 15 columns
                    row = i / 15;
                    col = i % 15;

                    // set the destination rect
                    Rectangle dest = new Rectangle((Spritesheet.GridWidth + Spritesheet.GridSpacing) * col
                        , (Spritesheet.GridHeight + Spritesheet.GridSpacing) * row
                        , Spritesheet.GridWidth, Spritesheet.GridHeight);

                    Rectangle source = new Rectangle(
                      tile.Index.X * (Spritesheet.GridWidth +
                           Spritesheet.GridSpacing),
                       tile.Index.Y * (Spritesheet.GridHeight +
                           Spritesheet.GridSpacing),
                       Spritesheet.GridWidth,
                       Spritesheet.GridHeight);

                    g.DrawImage(Spritesheet.Image, dest, source, GraphicsUnit.Pixel);
                }
                
            }
            //g.DrawImage(Spritesheet.Image, 0, 0);
            g.Dispose();

            CanvasPBox.Image = canvasArea;
        }


    }

    
}
