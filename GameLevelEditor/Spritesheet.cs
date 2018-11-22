using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GameLevelEditor
{
    public class Spritesheet
    {


        //public int GridWidth { get; set; } = 16;
        //public int GridHeight { get; set; } = 16;
        //public int Spacing { get; set; } = 1;
        private int gridWidth;
        private int gridHeight;
        private int gridSpacing;

        public string Filename
        {
            get { return Path.Substring(Path.LastIndexOf('\\')); }
        }

        private Image image = null;

        public Image Image
        {
            get
            {
                return image;
            }
        }

        public string Path { get; private set; }

        public int Width
        {
            get
            {
                return (image != null) ? image.Width : 0;
            }
        }

        public int Height
        {
            get
            {
                return (image != null) ? image.Height : 0;
            }
        }

        public int GridWidth
        {
            get
            {
                return (image != null) ? gridWidth : 0;
            }
            set { gridWidth = value; }
        }

        public int GridHeight
        {
            get
            {
                return (image != null) ? gridHeight : 0;
            }
            set { gridHeight = value; }
        }

        public int GridSpacing
        {
            get
            {
                return (image != null) ? gridSpacing : 0;
            }
            set { gridSpacing = value; }
        }

        public Spritesheet(string path)
        {
            Path = path;
            image = Image.FromFile(path);
        }

        public override string ToString()
        {
            return Filename;
        }
    }
}
