using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace LevelEditor
{
    public class Game1 : Game
    {
        SpriteBatch spriteBatch;
        GraphicsDeviceManager graphics;
        ContentManager content;
        Panel drawSurface;
        public Form1 form;
        Texture2D square;
        float elapsed = 0.0f;
        public GameHandler game;
        private VScrollBar vscroll;
        private HScrollBar hscroll;

        //check for first frame
        private bool firstFrame = true;

        private void OnPreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs args)
        {
            args.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = drawSurface.Handle;
        }

        public Game1(System.IntPtr handle, ref Form1 form, Panel pb)
        {
            this.form = form;
            graphics = new GraphicsDeviceManager(this);
            graphics.PreparingDeviceSettings += OnPreparingDeviceSettings;
            content = new ContentManager(Services);
            this.IsMouseVisible = true;
            drawSurface = pb;

            vscroll = form.vScrollBar1;
            hscroll = form.hScrollBar1;
        }
        
        protected override void Initialize()
        {

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            square = content.Load<Texture2D>("Content/Sprite/square");
            Form.FromHandle(Window.Handle).Hide();
            game = new LevelEditor.GameHandler(ref graphics, Content);
            game.Camera.setViewPortHeight(drawSurface.Height);
            game.Camera.setViewPortWidth(drawSurface.Width);
            form.FixScrollBarScales();
            Form me = (Form)Control.FromHandle(Window.Handle);
            Window.Position = new Point(-1000, -1000);
            Window.Title = "Ignore This Window";
        }
        
        protected override void UnloadContent()
        {
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (firstFrame)
            {
                firstFrame = false;
                //set the default selection square of the palette
                form.pb_palette_MouseClick(this, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                MessageBox.Show(game.tilemap.getTileNum(4, 0).ToString());//Exit();
            elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsed > .016f)
            {
                elapsed = 0.0f;
                doInput();
            }

            game.tilemap.Update(gameTime);
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            game.tilemap.Draw(spriteBatch);
            if (form.rdo_edit.Checked)
            {
                spriteBatch.Draw(square, game.editor.selectedRectangle, Color.Purple);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void doInput()
        {
            bool left = false;
            bool right = false;
            bool up = false;
            bool down = false;
            float speed = 16.0f;
            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A))
                left = true;
            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D))
                right = true;
            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W))
                up = true;
            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S))
                down = true;
            Vector2 pos = Vector2.Zero;
            if (left)
            {
                pos = new Vector2(-speed, 0f);
            }
            else if (right)
            {
                pos = new Vector2(speed, 0f);
            }
            else if (up)
            {
                pos = new Vector2(0f, -speed);
            }
            else if (down)
            {
                pos = new Vector2(0f, speed);
            }
            game.Camera.Move(pos);
        }
    }
}
