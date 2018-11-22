using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GameLevelEditor
{
    class Level
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int rows;

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        private int columns;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        private TileInfo[] map;



    }
}
