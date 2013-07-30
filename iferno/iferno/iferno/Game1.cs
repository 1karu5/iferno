using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace iferno
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player;
        
        List<Entity> map;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //Initialize game
            graphics.PreferredBackBufferWidth = Settings.Width;
            graphics.PreferredBackBufferHeight = Settings.Height;
            graphics.ApplyChanges();

            spriteBatch = new SpriteBatch(GraphicsDevice);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Load assets
            Settings.Textures.Add("blockgruen", Content.Load<Texture2D>("blockgruen"));
            Settings.Textures.Add("blockrot", Content.Load<Texture2D>("blockrot"));

            //Initialize world
            
           
            map = new List<Entity>();
            player = new Player(50, 400, Color.White,map);

            for (int i = 0; i < 16; i++)
            {
                map.Add(new Entity(i * 64, 11 * 64, Color.White, Settings.Textures["blockgruen"]));
            }
            map.Add(new Entity(6 * 64, 10 * 64, Color.White, Settings.Textures["blockgruen"]));
            map.Add(new Entity(6 * 64, 9 * 64, Color.White, Settings.Textures["blockgruen"]));
            map.Add(new Entity(6 * 64, 8 * 64, Color.White, Settings.Textures["blockgruen"]));

            map.Add(new Entity(11 * 64, 10 * 64, Color.White, Settings.Textures["blockgruen"]));
            map.Add(new Entity(11 * 64, 9 * 64, Color.White, Settings.Textures["blockgruen"]));
            map.Add(new Entity(11 * 64, 8 * 64, Color.White, Settings.Textures["blockgruen"]));
        }

        protected override void Update(GameTime gameTime)
        {
            //Calculate deltatime
            float dt = gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

            //Get keystate
            KeyboardState keyState = Keyboard.GetState();

            //Check input
            if (keyState.IsKeyDown(Keys.Right))
            {
                player.DirectionX = 1;
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                player.DirectionX = -1;
            }
            else
            {
                player.DirectionX = 0; 
            }

            if (keyState.IsKeyDown(Keys.Space))
            {
                player.jump();
            }

            //Update world
            player.Update(dt);

            foreach (Entity e in map)
            {
                e.Update(dt);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Clear background
            GraphicsDevice.Clear(Color.Cyan);

            //Draw world
            spriteBatch.Begin();

            player.Draw(spriteBatch);
            //player2.Draw(spriteBatch);

            foreach (Entity e in map)
            {
               e.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
