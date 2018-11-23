using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GameLevelEditor
{
    class Level
    {
        private string m_name;

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        private bool isEmpty = true;

        private int m_rows = 0;

        public int Rows
        {
            get { return m_rows; }
            set { m_rows = value; }
        }

        private int m_columns = 0;

        public int Columns
        {
            get { return m_columns; }
            set { m_columns = value; }
        }

        // stores the tiles painted

        private TileInfo[] map;


        // set the size of the array
        public void SetMapSize(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
                return;

            Rows = rows;
            Columns = columns;
            map = new TileInfo[rows * columns];
        }

        public int GetMapSize ()
        {
            return Rows * Columns;
        }

        // returns the tile in the map at a specified location
        public TileInfo GetTileAt(int index)
        {
            return map[index];
        }

        // stores a tile at a particular location
        public void SetTileAt(int index, TileInfo tile)
        {
            // check the index is valid
            if (index >= 0 && index < Rows * Columns && tile != null)
            {
                map[index] = tile;
                isEmpty = false;
            }
        }

        // checks if the map is empty
        public bool Empty()
        {
            return isEmpty;
        }



    }
}
