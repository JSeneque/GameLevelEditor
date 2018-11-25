using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;


namespace GameLevelEditor
{
    public class Level
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

        public TileInfo[] map;


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

        // removes the tile at that particular location
        public void RemoveTileAt(int index)
        {
            map[index] = null;
                
            // hmmmm maybe I should track the number of painted tiles to
            // so I can determine if it is empty when I remove one
            
        }

        // checks if the map is empty
        public bool Empty()
        {
            return isEmpty;
        }

        public void SaveToFile(string fileName)
        {
            // save an existing file
            if (fileName != null)
            {
                // A serializer prepares the data to be saved or transmitted
                XmlSerializer serializer = new XmlSerializer(typeof(Level));                // A stream writer puts the data into a stream. In this case

                // we're saving it to the disk
                StreamWriter writer = new StreamWriter(fileName);

                // the serialize(...) method serializes the specified object and
                // sends the resulting data to the specified stream
                serializer.Serialize(writer, this);

                writer.Close();
            }

            

        }

        public static Level LoadFromFile(string path)
        {
            // we need a serializer with which to de-serialize our object
            XmlSerializer serializer = new XmlSerializer(typeof(Level));

            // we need to read the serialized data in using the stream
            StreamReader reader = new StreamReader(path);


            // the return object
            Level deserialized = serializer.Deserialize(reader) as Level;

            // close the stream
            reader.Close();

            return deserialized;
        }

        public Spritesheet GetSpritesheet()
        {
            Spritesheet spritesheet = new Spritesheet();

            // find the first tile details
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] != null)
                {
                    spritesheet = map[i].Spritesheet;
                    break;
                }
            }

            return spritesheet;
        }

        private int gridWidth;

        public int GridWidth
        {
            get { return gridWidth; }
            set { gridWidth = value; }
        }

        private int gridHeight;

        public int GridHeight
        {
            get {  return gridHeight;  }
            set { gridHeight = value; }
        }

        private int gridSpacing;

        public int GridSpacing
        {
            get { return gridSpacing; }
            set { gridSpacing = value; }
        }


    }
}
