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

        Map map;

        public LevelScreen(Game1 game, SpriteBatch spriteBatch) : base(game, spriteBatch)
        {
            
        }

        public override void LoadContent()
        {
            //Load assets
            Settings.Textures.Add("blockgruen", Content.Load<Texture2D>("blockgruen"));
            Settings.Textures.Add("blockrot", Content.Load<Texture2D>("blockrot"));

            //Initialize world


            map = new Map();
            player = new Player(50, 400, Color.White, map);

            
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

            foreach (Block e in map.getVisibleBlocks())
            {
                e.Update(dt);
            }

            
        }

        public override void Draw(GameTime gameTime)
        {
           

            player.Draw(spriteBatch);
            //player2.Draw(spriteBatch);

            foreach (Block e in map.getVisibleBlocks())
            {
                e.Draw(spriteBatch);
            }

           
        }
    }
}

