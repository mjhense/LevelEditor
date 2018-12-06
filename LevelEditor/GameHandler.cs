using LevelEditor.Tilemap_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    public class GameHandler
    {
        public Editor_Camera Camera { get; set; }
        public Tilemap tilemap;
        public LevelEditor.Tilemap_Engine.TilemapEditor editor;
        public Texture2D palette;
        public Texture2D tileAnimation;
        public Texture2D tileDecorations;

        private Random rand;

        public Rectangle worldRectangle()
        {
            return new Rectangle(0, 0, tilemap.TileWidth * tilemap.MapWidth, tilemap.TileHeight * tilemap.MapHeight);
        }

        public GameHandler(ref GraphicsDeviceManager graphics, ContentManager content)
        {
            Camera = new Editor_Camera(ref graphics);
            palette = content.Load<Texture2D>("Content/wood_tileset");
            tileAnimation = content.Load<Texture2D>("Content/Animations/animations");
            tileDecorations = content.Load<Texture2D>("Content/Animations/decorations");
            tilemap = new Tilemap(palette, content.Load<Texture2D>
                ("Content/Sprite/collidablesquare"), this);
            editor = new Tilemap_Engine.TilemapEditor(this, tilemap.Columns, tilemap.Rows);
            rand = new Random();
            rand = new Random(rand.Next());
        }

        /// <summary>
        /// gets a random number between 2 values
        /// </summary>
        /// <param name="minValue">the minimum number to generate</param>
        /// <param name="maxValue">the maximum number to generate</param>
        /// <returns>the random result</returns>
        public int Random(int minValue, int maxValue)
        {
            return rand.Next(minValue, maxValue + 1);
        }
        /// <summary>
        /// gets a random number between 0 and max value
        /// </summary>
        /// <param name="maxValue">the maximum number to generate</param>
        /// <returns>the random result</returns>
        public int Random(int maxValue)
        {
            return Random(0, maxValue);
        }
        /// <summary>
        /// gets a random float between 0.0 and 1.0
        /// </summary>
        /// <returns>the random result</returns>
        public float RandomFloat()
        {
            return (float)rand.NextDouble();
        }
    }
}