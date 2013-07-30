using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace iferno
{
    class LevelScreen : Screen
    {

        Player player;

        List<Entity> map;

        public LevelScreen(Game1 game, SpriteBatch spriteBatch) : base(game, spriteBatch)
        {
            
        }

        public override void LoadContent()
        {
            //Load assets
            Settings.Textures.Add("blockgruen", Content.Load<Texture2D>("blockgruen"));
            Settings.Textures.Add("blockrot", Content.Load<Texture2D>("blockrot"));

            //Initialize world


            map = new List<Entity>();
            player = new Player(50, 400, Color.White, map);

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

        public override void Update(GameTime gameTime)
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

            
        }

        public override void Draw(GameTime gameTime)
        {
           

            player.Draw(spriteBatch);
            //player2.Draw(spriteBatch);

            foreach (Entity e in map)
            {
                e.Draw(spriteBatch);
            }

           
        }
    }
}

