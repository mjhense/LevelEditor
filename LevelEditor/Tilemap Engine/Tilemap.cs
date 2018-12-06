using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LevelEditor;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LevelEditor.Tilemap_Engine
{
    public class Tilemap
    {
        #region declarations
        private int tileWidth = 32;
        private int tileHeight = 32;
        private const int mapWidth = 128;
        private const int mapHeight = 128;
        private int mapLayers = 4;
        public const int grassTile = 342;
        public const int transparentTile = 1437;
        public Tile[,] tileMap;
        private GameHandler game;
        private bool followingPlayer;
        private float elasped = 0.0f;
        private Texture2D collidableSquare;
        private Sprite lavaAnimation;
        private Sprite waterAnimation;
        private Sprite tileDecoration;
        private Sprite grassAnimation;

        public bool editorMode = false;
        private SpriteFont font;
        public Texture2D palette;
        #endregion

        #region Properties
        public int Columns
        {
            get
            {
                return (palette.Width / tileWidth);
            }
        }

        public int Rows
        {
            get
            {
                return (palette.Height / tileHeight);
            }
        }

        public int TransparentTile
        {
            get { return transparentTile; }
        }

        public int MapLayers => mapLayers;
        public int TileWidth => tileWidth;
        public int TileHeight => tileHeight;
        public int MapWidth => mapWidth;
        public int MapHeight => mapHeight;
        public bool FollowingPlayer
        {
            get { return followingPlayer; }
            set { followingPlayer = value; }
        }
        #endregion

        #region Constructor and Load
        public Tilemap(Texture2D palette, SpriteFont font, GameHandler game)
        {
            this.font = font;
            this.palette = palette;
            this.game = game;
            this.editorMode = false;
            tileMap = new Tile[mapWidth, mapHeight];
            followingPlayer = true;
            lavaAnimation = new Sprite(ref game, game.tileAnimation, 32, 32, true, 3);
            lavaAnimation.Direction = 0;
            waterAnimation = new Sprite(ref game, game.tileAnimation, 32, 32, true, 3);
            waterAnimation.Direction = 1;
            grassAnimation = new Sprite(ref game, game.tileAnimation, 32, 32, true, 3);
            grassAnimation.Direction = 2;
            grassAnimation.Duration = (0.40f);
            tileDecoration = new Sprite(ref game, game.tileDecorations, 32, 32, false, 3);
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    tileMap[x, y] = new Tile(tileWidth, TileHeight);
                    tileMap[x, y].SetTileNum(0, grassTile);
                    for (int z = 0; z < mapLayers; z++)
                    {
                        tileMap[x, y].SetTileNum(z, transparentTile);
                    }
                }
            }
        }
        public Tilemap(Texture2D palette, Texture2D square, GameHandler game)
        {
            this.palette = palette;
            this.game = game;
            this.editorMode = true;
            this.collidableSquare = square;
            tileMap = new Tile[mapWidth, mapHeight];
            followingPlayer = true;
            lavaAnimation = new Sprite(ref game, game.tileAnimation, 32, 32, true, 3);
            lavaAnimation.Direction = 0;
            lavaAnimation.Duration = (0.16f);
            waterAnimation = new Sprite(ref game, game.tileAnimation, 32, 32, true, 3);
            waterAnimation.Direction = 1;
            grassAnimation = new Sprite(ref game, game.tileAnimation, 32, 32, true, 3);
            grassAnimation.Direction = 2;
            grassAnimation.Duration = (0.40f);
            tileDecoration = new Sprite(ref game, game.tileDecorations, 32, 32, false, 3);
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    tileMap[x, y] = new Tile(tileWidth, TileHeight);
                    tileMap[x, y].SetTileNum(0, grassTile);
                    for (int z = 0; z < mapLayers; z++)
                    {
                        tileMap[x, y].SetTileNum(z, transparentTile);
                    }
                }
            }
        }

        public void LoadTileMap(string filename)
        {
            try
            {
                System.IO.FileStream s = new System.IO.FileStream(filename, System.IO.FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                tileMap = (Tile[,])formatter.Deserialize(s);
                s.Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("File Load Error", "Filepath was not found.",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                ClearMap();
            }
        }
        public void SaveMap(string filename)
        {
            System.IO.FileStream s = System.IO.File.Open(filename, System.IO.FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(s, tileMap);
            s.Close();
        }
        #endregion

        #region Functions
        public int GetTileByPixelX(int x)
        {
            return (int)(x / tileWidth);
        }

        public int GetTileByPixelY(int y)
        {
            return (int)(y / TileWidth);
        }

        public Vector2 GetTileByPixel(Vector2 pixelLoc)
        {
            return new Vector2(GetTileByPixelX((int)pixelLoc.X), GetTileByPixelY((int)pixelLoc.Y));
        }

        public Vector2 GetTileCenter(int tileX, int tileY)
        {
            return new Vector2(Convert.ToSingle((tileX * tileWidth) + (tileWidth / 2)), Convert.ToSingle((tileY * TileHeight) + (TileHeight / 2)));
        }

        public Vector2 GetTileCenter(Vector2 tileLoc)
        {
            return GetTileCenter((int)tileLoc.X, (int)tileLoc.Y);
        }

        public Rectangle GetTileWorldRectangle(int tileX, int tileY)
        {
            return new Rectangle(tileX * tileWidth, tileY * TileHeight, tileWidth, TileHeight);
        }

        public Rectangle GetTileScreenRectangle(int tileX, int tileY)
        {
            return game.Camera.WorldToScreen(GetTileWorldRectangle(tileX, tileY));
        }

        public Rectangle GetTileScreenRectangle(Vector2 tileLoc)
        {
            return GetTileWorldRectangle((int)tileLoc.X, (int)tileLoc.Y);
        }

        public bool IsTileCollidable(int tileX, int tileY)
        {
            return tileMap[tileX, tileY].Collidable;
        }

        public bool IsTileCollidable(Vector2 tileLoc)
        {
            return IsTileCollidable((int)tileLoc.X, (int)tileLoc.Y);
        }

        public bool IsTileCollidableByPixel(Vector2 pixelLoc)
        {
            return IsTileCollidable(GetTileByPixelX((int)pixelLoc.X), GetTileByPixelY((int)pixelLoc.Y));
        }

        public String GetTileData(int tileX, int tileY)
        {
            return tileMap[tileX, tileY].Data;
        }

        public string GetTileData(Vector2 tileLoc)
        {
            return GetTileData((int)tileLoc.X, (int)tileLoc.Y);
        }
        
        public Rectangle getSrcRect(int tileX, int tileY, int tilenum)
        {
            return game.editor.TileRects[tilenum];
        }

        public int getTileNum(int tileX, int tileY)
        {
            return (tileY * Columns + tileX);
        }

        public Rectangle srcRect(int index)
        {
            int srcX = (index % Columns) * tileWidth;
            int srcy = (index / Columns) * tileHeight;
            return new Rectangle(srcX, srcy, tileWidth, tileHeight);
        }

        public void ClearMap()
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    tileMap[x, y] = new Tile(tileWidth, tileHeight);
                    //set tile to transparent
                    for (int z = 0; z < mapLayers; z++)
                    {
                        tileMap[x, y].SetTileNum(z, transparentTile);
                    }
                }
            }
        }

        public void SetTilenum(int tileX, int tileY, int layer, int tilenum)
        {
            if (tilenum == 414)
            {
                tilenum = game.Random(757, 759);
            }
            else if (tilenum == 416)
            {
                tilenum = game.Random(754, 756);
            }
            else if (tilenum == 412)
            {
                tilenum = game.Random(341, 343);
            }
            tileMap[tileX, tileY].SetTileNum(layer, tilenum);
        }
        #endregion

        #region Update and Draw
        public void Update(GameTime gameTime)
        {
            lavaAnimation.Update(gameTime);
            waterAnimation.Update(gameTime);
            grassAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int startX = GetTileByPixelX((int)game.Camera.Position.X);
            int endX = GetTileByPixelX((int)(game.Camera.Position.X + game.Camera.getViewPortWidth()));
            int startY = GetTileByPixelY((int)game.Camera.Position.Y);
            int endY = GetTileByPixelY((int)(game.Camera.Position.Y + game.Camera.getViewPortHeight()));

            int tilenum = 0;

            if (game.Camera.Position.X < 0)
                game.Camera.Position  = new Vector2(0, game.Camera.Position.Y);
            if (game.Camera.Position.Y < 0)
                game.Camera.Position = new Vector2(game.Camera.Position.X, 0);

            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    for (int z = 0; z < mapLayers; z++)
                    {
                        tilenum = tileMap[x, y].getTileNum(z);
                        Rectangle dest = GetTileScreenRectangle(x, y);
                        Rectangle src = srcRect(tilenum);
                        if (tilenum == 413)
                        {
                            lavaAnimation.DrawTile(spriteBatch, (x * tileWidth), (y * TileHeight));
                        }
                        else if (tilenum == 412)
                        {
                            //grassAnimation.DrawTile(spriteBatch, (x * tileWidth), (y * TileHeight));
                            spriteBatch.Draw(palette, dest, src, Color.White);
                        }
                        else if (tilenum == 415)
                        {
                            waterAnimation.DrawTile(spriteBatch, (x * tileWidth), (y * TileHeight));
                        }
                        else
                        {
                            spriteBatch.Draw(palette, dest, src, Color.White);
                        }
                        if (tileMap[x, y].Collidable == true && editorMode == true && z == (mapLayers - 1))
                        {
                            spriteBatch.Draw(collidableSquare, dest, new Color(Color.Red, 0.2f));
                        }
                    }
                }
            }
        }
        #endregion
    }
}