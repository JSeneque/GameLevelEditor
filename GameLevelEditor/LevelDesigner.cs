﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;



namespace GameLevelEditor
{
    public partial class LevelDesigner : Form
    {
        public Spritesheet Spritesheet { get; private set; }
        Bitmap canvasArea, spritesheetArea;

        // has the information for the selected tile
        TileInfo selectedTile;


        // stores the level information
        Level level;


        int gridWidth = 64;
        int gridHeight = 64;
        int spacing = 1;

        // next version allow the user to specific the size of the level
        int levelRows = 15;
        int levelColumns = 12;


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
            clearCanvas();

            level = new Level();

            // later we will allow the user to choose the size of the level
            level.SetMapSize(levelColumns, levelRows);

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

                if (mouse.Button == MouseButtons.Left)
                {

                    // draw the current tile there
                    SelectedCanvasTile = new Point(
                    mouse.X / (gridWidth + spacing)
                    , mouse.Y / (gridHeight + spacing));

                    // add the selected tiles to the map list
                    level.SetTileAt(SelectedCanvasTile.X + (SelectedCanvasTile.Y) * levelRows, selectedTile);

                    DrawTiles();
                }
                else if (mouse.Button == MouseButtons.Right)
                {
                    // draw the current tile there
                    SelectedCanvasTile = new Point(
                    mouse.X / (gridWidth + spacing)
                    , mouse.Y / (gridHeight + spacing));

                    level.RemoveTileAt(SelectedCanvasTile.X + (SelectedCanvasTile.Y) * levelRows);

                    DrawTiles();
                }

                
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

  
        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxWidth.Text, out gridWidth) == true)
            {
                drawGrid();
            }

            textBoxWidth.Text = gridWidth.ToString();
            //Spritesheet.GridWidth = gridWidth;
            level.GridWidth = gridWidth;
        }

        private void textBoxHeight_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxHeight.Text, out gridHeight) == true)
            {
                drawGrid();
            }

            textBoxHeight.Text = gridHeight.ToString();
            //Spritesheet.GridHeight = gridHeight;
            level.GridHeight = gridHeight;
        }

        private void textBoxSpacing_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxSpacing.Text, out spacing) == true)
            {
                drawGrid();
            }

            textBoxSpacing.Text = spacing.ToString();
            //Spritesheet.GridSpacing = spacing;
            level.GridSpacing = spacing;
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
            ////spritesheetPBox.DrawToBitmap(spritesheetArea, spritesheetPBox.Bounds);
            //Graphics g = Graphics.FromImage(spritesheetArea);
            //g.Clear(Color.White);

            //if (Spritesheet == null)
            //    return;

            //// draw the spritesheet (regardless of size mine you) to the
            //g.DrawImage(Spritesheet.Image, 0, 0);

            //Pen pen = new Pen(Brushes.LightGray);

            //int height = spritesheetPBox.Height;
            //int width = spritesheetPBox.Width;
            //for (int y = 0; y < height; y += gridHeight + spacing)
            //{
            //    g.DrawLine(pen, 0, y, width, y);
            //}

            //for (int x = 0; x < width; x += gridWidth + spacing)
            //{
            //    g.DrawLine(pen, x, 0, x, height);
            //}

            //Pen highlight = new Pen(Brushes.Red);
            //g.DrawRectangle(highlight,
            //    SelectedSpritesheetTile.X * (gridWidth + spacing),
            //    SelectedSpritesheetTile.Y * (gridHeight + spacing),
            //    gridWidth + spacing,
            //    gridHeight + spacing);


            //g.Dispose();

            //spritesheetPBox.Image = spritesheetArea;

            Graphics g = Graphics.FromImage(spritesheetArea);
            g.FillRectangle(Brushes.White, 0, 0, spritesheetArea.Width, spritesheetArea.Height);

            int tile_columns = 6;
            int tile_rows = 9;

            // paint the tiles to the picturebox
            for (int i = 0; i < tile_columns * tile_rows; i++)
            {
                int row, col;

                // determine the grid position based
                // hardcoded 15 columns
                row = i / 6;
                col = i % 6;

                // set the destination rect
                Rectangle dest = new Rectangle((level.GridWidth + level.GridSpacing) * col
                    , (level.GridHeight + level.GridSpacing) * row
                    , level.GridWidth, level.GridHeight);

                Rectangle source = new Rectangle(
                    col * (level.GridWidth +
                        level.GridSpacing),
                    row * (level.GridHeight +
                        level.GridSpacing),
                    level.GridWidth,
                    level.GridHeight);

                g.DrawImage(Spritesheet.Image, dest, source, GraphicsUnit.Pixel);


            }
            //g.DrawImage(Spritesheet.Image, 0, 0);
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
            for (int i = 0; i < level.GetMapSize(); i++)
            {
                //if (map[i] != null)
                if (level.GetTileAt(i) != null)
                {
                    // get the tile at that map location
                    TileInfo tile = level.GetTileAt(i);

                    int row, col;

                    // determine the grid position based
                    row = i / levelRows;
                    col = i % levelRows;

                    // set the destination rect
                    Rectangle dest = new Rectangle((level.GridWidth + level.GridSpacing) * col
                        , (level.GridHeight + level.GridSpacing) * row
                        , level.GridWidth, level.GridHeight);

                    Rectangle source = new Rectangle(
                      tile.Index.X * (level.GridWidth +
                           level.GridSpacing),
                       tile.Index.Y * (level.GridHeight +
                           level.GridSpacing),
                       level.GridWidth,
                       level.GridHeight);

                    g.DrawImage(Spritesheet.Image, dest, source, GraphicsUnit.Pixel);
                }

            }
            g.Dispose();

            CanvasPBox.Image = canvasArea;
        }

        public void SaveToFile(string filename) 
        {
            var relative_path = Path.GetDirectoryName(filename);
            // copying file

            // first check if the spritesheet doesn't already exist at that location
            if(!File.Exists(relative_path + "\\" + Path.GetFileName(Spritesheet.Path)))
            {
                File.Copy(Spritesheet.Path, relative_path + "\\" + Path.GetFileName(Spritesheet.Path), true);
            }
           

            Spritesheet.Path = Path.GetFileName(Spritesheet.Path);

            level.SaveToFile(filename);
        }

        public void LoadFromFile(string path)
        {
            // load the level
            level = Level.LoadFromFile(path);

            // we need to first set the spritesheet canvas area and for now, just file the first tile
            // and use the spritesheet path. The assumption is we can only save a file if there is
            // at last one tile drawn.
            // load the spritesheet into spritesheet picture box
            //Spritesheet = new Spritesheet(level.GetSpritesheet().Path);
            Spritesheet = new Spritesheet(Path.GetDirectoryName(path) + "\\" + level.GetSpritesheet().Path);

            spritesheetArea = new Bitmap(Spritesheet.Width, Spritesheet.Height);
            drawGrid();

            // draw the canvas
            DrawTiles();

            // populate the grid details
            textBoxWidth.Text = level.GridWidth.ToString();
            textBoxHeight.Text = level.GridHeight.ToString();
            textBoxSpacing.Text = level.GridSpacing.ToString();

        }
    }

}
