using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor.Tilemap_Engine
{
   public class TilemapEditor
    {
        private List<Rectangle> tileRects;
        private int columns;
        private int rows;
        private GameHandler game;
        public Rectangle selectedRectangle;
        public int selectedTileNum;
        public int selectedLayer;

        public List<Rectangle> TileRects
        {
            get { return tileRects; }
        }


        public TilemapEditor(GameHandler game, int columns, int rows)
        {
            tileRects = new List<Rectangle>();
            this.columns = columns;
            this.rows = rows;
            this.game = game;
            selectedTileNum = 0;
            selectedRectangle = new Rectangle(0, 0, game.tilemap.TileWidth, game.tilemap.TileHeight);
            selectedLayer = 0;
            //create list of frames
            createRects();
        }

        private void createRects()
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    tileRects.Add(new Rectangle(x * game.tilemap.TileWidth, y * game.tilemap.TileHeight, game.tilemap.TileWidth, game.tilemap.TileHeight));
                }
            }
        }
    }
}