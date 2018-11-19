using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GameLevelEditor
{
    public class Spritesheet
    {


        public int GridWidth { get; set; } = 16;
        public int GridHeight { get; set; } = 16;
        public int Spacing { get; set; } = 1;

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

        //private string path;

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

        public Spritesheet(string path)
        {
            Path = path;
            image = Image.FromFile(path);
        }

        //public void Load()
        //{
        //    image = Image.FromFile(path);
        //}

        public override string ToString()
        {
            return Filename;
        }
    }
}
