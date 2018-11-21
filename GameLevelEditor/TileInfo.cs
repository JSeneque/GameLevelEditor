using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GameLevelEditor
{
    class TileInfo
    {

        //private int index;
        private Point index;

        //public int Index
        //{
        //    get { return index; }
        //    set { index = value; }
        //}

        public Point Index
        {
            get { return index; }
            set { index = value; }
        }

        public Spritesheet Spritesheet { get; set; } = null;

        public TileInfo()
        {
        }

        public TileInfo(Point index, Spritesheet spritesheet)
        {
            Index = index;
            Spritesheet = spritesheet;
        }
    }
}
