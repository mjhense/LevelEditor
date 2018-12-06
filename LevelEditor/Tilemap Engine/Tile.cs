using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LevelEditor.Tilemap_Engine
{
    [Serializable]
    public class Tile
    {
        private int tileWidth;
        private int tileHeight;
        private bool portal;
        private string filename;
        private bool collidable;
        private int[] tilenum = new int[4];
        private string data;

        public int TileWidth
        {
            get { return tileWidth; }
            set { tileWidth = value; }
        }
        public int TileHeight
        {
            get { return tileHeight; }
            set { tileHeight = value; }
        }
        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }
        public bool Portal
        {
            get { return portal; }
            set { portal = value; }
        }
        public bool Collidable
        {
            get { return collidable; }
            set { collidable = value; }
        }
        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        public int[] TileNum => tilenum;

        public void SetTileNum(int layerIndex, int tileNumber)
        {
            tilenum[layerIndex] = tileNumber;
        }

        public int getTileNum(int layerIndex)
        {
            return tilenum[layerIndex];
        }

        public Tile(int tileWidth, int tileHeight)
        {
            this.tileHeight = tileHeight;
            this.tileWidth = tileWidth;
            portal = false;
            filename = "";
            collidable = false;
            data = "";

            for (int x = 0; x < tilenum.Length; x++)
            {
                tilenum[x] = 0;
            }
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}