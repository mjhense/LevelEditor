using LevelEditor.Tilemap_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelEditor
{
    public partial class Form1 : Form
    {
        #region Declarations
        public Game1 game;
        private Graphics gfx;
        private Bitmap surface;
        private Graphics gfxSelectedSquare;
        private Bitmap paletteSurface;
        private int selectedTileX = 0;
        private int selectedTileY = 0;
        private Bitmap paletteImage;
        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();
            surface = new Bitmap(pb_selected.Width, pb_selected.Height);
            pb_selected.Image = surface;
            gfx = Graphics.FromImage(surface);
            paletteImage = new Bitmap("palette.png");
            paletteSurface = new Bitmap(paletteImage.Width, paletteImage.Height);
            gfxSelectedSquare = Graphics.FromImage(paletteSurface);
        }
        #endregion

        #region Methods
        public void FixScrollBarScales()
        {
            game.game.Camera.setViewPortWidth(pnlSurface.Width);
            game.game.Camera.setViewPortHeight(pnlSurface.Height);

            game.game.Camera.Move(Vector2.Zero);
            
            vScrollBar1.Minimum = 0;
            vScrollBar1.Maximum =
                game.game.worldRectangle().Height -
                game.game.Camera.getViewPortHeight();

            hScrollBar1.Minimum = 0;
            hScrollBar1.Maximum =
                game.game.worldRectangle().Width -
                game.game.Camera.getViewPortWidth();
        }

        private System.Drawing.Point getMousePositionFromControl(Control control)
        { 
            return new System.Drawing.Point(MousePosition.X - this.Left - control.Left - 10,
                MousePosition.Y - this.Top - control.Top - 39);
        }

        private void pb_palette_MouseClick(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;
            int tileX = mouseX / game.game.tilemap.TileWidth;
            int tileY = mouseY / game.game.tilemap.TileHeight;
            game.game.editor.selectedTileNum = game.game.tilemap.getTileNum(tileX, tileY);
            lblSelected.Text = "Current Tile: " + game.game.editor.selectedTileNum.ToString();
            //draw selected tile
            gfx.Clear(System.Drawing.Color.Transparent);
            Microsoft.Xna.Framework.Rectangle tmp = 
                game.game.tilemap.getSrcRect(tileX, tileY, game.game.editor.selectedTileNum);
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(tmp.Top, tmp.Left, tmp.Width, tmp.Height);
            gfx.DrawImage(paletteImage, 
                new System.Drawing.Rectangle(0, 0, pb_selected.Width, pb_selected.Height),
                rect, GraphicsUnit.Pixel);
            pb_selected.Image = surface;
            //draw selected sqare
            Pen p = new Pen(System.Drawing.Color.Purple, 2.0f);
            gfxSelectedSquare.Clear(System.Drawing.Color.Black);
            gfxSelectedSquare.DrawImage(paletteImage,
                new System.Drawing.Rectangle(0, 0, paletteImage.Width, paletteImage.Height));
            gfxSelectedSquare.DrawRectangle(p, rect);
            pb_palette.Image = paletteSurface;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.Exit();
            Application.Exit();
        }

        private void tmr_update_Tick(object sender, EventArgs e)
        {
            game.game.Camera.Position = new Vector2(hScrollBar1.Value, vScrollBar1.Value);
        }

        private void clearMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < game.game.tilemap.MapWidth; x++)
            {
                for (int y = 0; y < game.game.tilemap.MapHeight; y++)
                {
                    for (int z = 0; z < 3; z++)
                    {
                        game.game.tilemap.SetTilenum(x, y, z, game.game.tilemap.TransparentTile);
                    }
                }
            }
        }

        private void setToCurrentTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < game.game.tilemap.MapWidth; x++)
            {
                for (int y = 0; y < game.game.tilemap.MapHeight; y++)
                {
                    game.game.tilemap.SetTilenum(x, y, game.game.editor.selectedLayer
                        , game.game.editor.selectedTileNum);
                }
            }
        }

        private void clearTileDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < game.game.tilemap.MapWidth; x++)
            {
                for (int y = 0; y < game.game.tilemap.MapHeight; y++)
                {
                    Tile t = game.game.tilemap.tileMap[x, y];
                    t.Collidable = false;
                    t.Portal = false;
                    t.Data = "";
                    t.Filename = "";
                    for (int z = 0; z < 3; z++)
                    {
                        t.SetTileNum(z, game.game.tilemap.TransparentTile);
                    }
                    game.game.tilemap.tileMap[x, y] = t;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pb_palette.Image = paletteImage;
        }

        private void setTileInformation(Tile tile)
        {
            txtCodeValue.Text = tile.Data;
            txtFilename.Text = tile.Filename;
            chk_collidable.Checked = tile.Collidable;
            chk_portal.Checked = tile.Portal;
        }

        private void btnTileUpdate_Click(object sender, EventArgs e)
        {
            if (!rdo_edit.Checked)
                return;
            Tile tile;
            tile = new Tile(game.game.tilemap.TileWidth,
                game.game.tilemap.TileHeight);
            for (int z = 0; z < game.game.tilemap.MapLayers; z++)
            {
                tile.SetTileNum(z, game.game.tilemap.tileMap[selectedTileX, selectedTileY].getTileNum(z));
            }
            tile.Collidable = chk_collidable.Checked;
            tile.Portal = chk_portal.Checked;
            tile.Filename = txtFilename.Text;
            tile.Data = txtCodeValue.Text;
            game.game.tilemap.tileMap[selectedTileX, selectedTileY] = tile;
        }

        private void pnlSurface_MouseClick(object sender, MouseEventArgs e)
        {
            int tileWidth = game.game.tilemap.TileWidth;
            int tileHeight = game.game.tilemap.TileHeight;
            if (e.Button == MouseButtons.Left)
            {
                int mouseX = e.X + (int)game.game.Camera.Position.X;
                int mouseY = e.Y + (int)game.game.Camera.Position.Y;
                int tileX = (mouseX / game.game.tilemap.TileWidth);
                int tileY = (mouseY / game.game.tilemap.TileHeight);
                if (tileX >= game.game.tilemap.MapWidth)
                    tileX = game.game.tilemap.MapWidth - 1;
                if (tileY >= game.game.tilemap.MapHeight)
                    tileY = game.game.tilemap.MapHeight - 1;
                if (tileX < 0)
                    tileX = 0;
                if (tileY < 0)
                    tileY = 0;
                if (rad_draw.Checked)
                {
                    drawTile(tileX, tileY);
                }
                else if (rdo_edit.Checked)
                {
                    game.game.editor.selectedRectangle = new Microsoft.Xna.Framework.Rectangle(tileX
                        * tileWidth, tileY * tileHeight, tileWidth, tileHeight);
                    Tile tile = game.game.tilemap.tileMap[tileX, tileY];
                    setTileInformation(tile);
                    selectedTileX = tileX;
                    selectedTileY = tileY;
                }
            }
        }

        private void pnlSurface_MouseMove(object sender, MouseEventArgs e)
        {
            int tileWidth = game.game.tilemap.TileWidth;
            int tileHeight = game.game.tilemap.TileHeight;
            if (e.Button == MouseButtons.Left)
            {
                int mouseX = e.X + (int)game.game.Camera.Position.X;
                int mouseY = e.Y + (int)game.game.Camera.Position.Y;
                int tileX = (mouseX / game.game.tilemap.TileWidth);
                int tileY = (mouseY / game.game.tilemap.TileHeight);
                if (tileX >= game.game.tilemap.MapWidth)
                    tileX = game.game.tilemap.MapWidth - 1;
                if (tileY >= game.game.tilemap.MapHeight)
                    tileY = game.game.tilemap.MapHeight - 1;
                if (tileX < 0)
                    tileX = 0;
                if (tileY < 0)
                    tileY = 0;
                if (rad_draw.Checked)
                {
                    drawTile(tileX, tileY);
                }
                else if (rdo_edit.Checked)
                {
                    game.game.editor.selectedRectangle = new Microsoft.Xna.Framework.Rectangle(tileX
                        * tileWidth, tileY * tileHeight, tileWidth, tileHeight);
                    Tile tile = game.game.tilemap.tileMap[tileX, tileY];
                    setTileInformation(tile);
                    selectedTileX = tileX;
                    selectedTileY = tileY;
                }
            }
        }
        #endregion

        #region Load and Save Maps
        private void loadTilemapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Map File (*.MAP)|*.MAP";
            openFileDialog1.DefaultExt = "Map File";
            openFileDialog1.Title = "Open Map";
            openFileDialog1.ShowDialog();
            if (System.IO.File.Exists(openFileDialog1.FileName))
                game.game.tilemap.LoadTileMap(openFileDialog1.FileName);
            openFileDialog1.FileName = "";
        }

        private void saveTilemapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Map File (*.MAP)|*.MAP";
            saveFileDialog1.DefaultExt = "Map File";
            saveFileDialog1.Title = "Save Map";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
                game.game.tilemap.SaveMap(saveFileDialog1.FileName);
            saveFileDialog1.FileName = "";

        }
        #endregion

        #region layertabs
        private void foregroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.game.editor.selectedLayer = 3;
            groundToolStripMenuItem.Checked = false;
            backgroundToolStripMenuItem.Checked = false;
            foregroundToolStripMenuItem.Checked = true;
            groundToolStripMenuItem1.Checked = false;
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.game.editor.selectedLayer = 2;
            groundToolStripMenuItem.Checked = false;
            backgroundToolStripMenuItem.Checked = true;
            foregroundToolStripMenuItem.Checked = false;
            groundToolStripMenuItem1.Checked = false;
        }

        private void groundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.game.editor.selectedLayer = 1;
            groundToolStripMenuItem.Checked = true;
            backgroundToolStripMenuItem.Checked = false;
            foregroundToolStripMenuItem.Checked = false;
            groundToolStripMenuItem1.Checked = false;
        }

        private void groundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            game.game.editor.selectedLayer = 0;
            groundToolStripMenuItem.Checked = false;
            backgroundToolStripMenuItem.Checked = false;
            foregroundToolStripMenuItem.Checked = false;
            groundToolStripMenuItem1.Checked = true;
        }

        #endregion

        #region Tiling
        private void drawTile(int tileX, int tileY)
        {
            int tilenum = game.game.editor.selectedTileNum;
            int layer = game.game.editor.selectedLayer;
            if (!doTiling(tilenum))
            {
                game.game.tilemap.SetTilenum(tileX, tileY, layer, tilenum);
            }
            else
            {
                game.game.tilemap.SetTilenum(tileX, tileY, layer, tilenum);
                //autoTile(tileX, tileY, tilenum, layer);
            }
        }
        #region auto-tiling
        private void autoTile(int tileX, int tileY, int tilenum, int layer)
        {
            if (getTileType(tilenum) == "water")
            {
                tileWater(tileX, tileY, layer);
            }
        }
        private string getTileType(int tilenum)
        {
            if (tilenum == 68)
            {
                return "water";
            }
            else
            {
                return "error";
            }
        }
        private void tileWater(int tileX, int tileY, int layer)
        {
            string composition = string.Empty;
            int tilenum = 58;

            //get the type of surronding tiles
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (HasWater(tileX + x, tileY + y, layer))
                    {
                        composition += "W";
                    }
                    else
                    {
                        composition += "E";
                    }
                }
            }

            //set the tiles accordingly
            if (composition == "EEWEWEEEE" || composition == "EWWEWWEEE")
            {
                tilenum = 58;
            }
            else if (composition == "EEEEWWEWW")
            {

            }
            else if (composition == "EEEWWEWWE")
            {

            }
            else if (composition == "WWEWWEEEE")
            {

            }
            else if (composition == "WWEWWEWWE")
            {

            }
            else if (composition == "EEEWWWWWW")
            {

            }
            else if (composition == "WWWWWWEEE")
            {

            }
            else if (composition == "EWWEWWEWW")
            {

            }
            else if (composition == "WEEWWEWWE")
            {

            }
            else if (composition == "WWEWWEWWW")
            {

            }
            else if (composition == "WWWWWEWWE")
            {

            }
            else if (composition == "WWEWWEWEE")
            {

            }
            else if (composition == "EEEEWWWWW")
            {

            }
            else if (composition == "EEWWWWWWW")
            {

            }
            else if (composition == "EEEWWEWWW")
            {

            }
            else if (composition == "EWWEWWEEW")
            {

            }
            else if (composition == "WWWEWWEEE")
            {

            }
            else if (composition == "EEWEWWEWW")
            {

            }
            else if (composition == "WWWWWEEEE")
            {

            }
            else if (composition == "EWWWWWWWW")
            {

            }
            else if (composition == "WWWWWWWWE")
            {

            }
            else if (composition == "WWEWWWWWW")
            {

            }
            else if (composition == "WWWWWWEWW")
            {

            }
            else if (composition == "EWWEWWWWW")
            {

            }
            else if (composition == "EEWEWWWWW")
            {

            }
            else if (composition == "WEEWWEWWW")
            {

            }
            else if (composition == "WWWWWWWEE")
            {

            }
            else if (composition == "WWWWWEWEE")
            {

            }
            else if (composition == "WEEWWWWWW")
            {

            }
            else if (composition == "WWWWWWEEW")
            {

            }
            else if (composition == "WWWWWWWEW")
            {

            }
            else if (composition == "WEWWWWWWW")
            {

            }
            else if (composition == "WWWEWWEWW")
            {

            }
            else if (composition == "WWWWWEWWW")
            {

            }
            else if (composition == "WWWEWWWWW")
            {

            }
            else
            {
                tilenum = 58;
            }

            game.game.tilemap.SetTilenum(tileX, tileY, layer, tilenum);
        }
        private bool HasWater(int tileX, int tileY, int layer)
        {
            int tilenum = game.game.tilemap.tileMap[tileX, tileY].getTileNum(layer);
            switch (tilenum)
            {
                case 51:
                case 52:
                case 53:
                case 67:
                case 68:
                case 69:
                case 83:
                case 84:
                case 85:
                    return true;
                default:
                    return false;
            }
        }
        private bool doTiling(int tilenum)
        {
            bool result = false;
            switch (tilenum)
            {
                case 51:
                case 52:
                case 53:
                case 67:
                case 68:
                case 69:
                case 83:
                case 84:
                case 85:
                    result = true;
                    break;
                default:
                    result = false;
                    break;
            }
            return result;
        }
        #endregion

        #endregion
    }
}