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

        public override void activate()
        {
           
        }

        public override void LoadContent()
        {
            //Spielfiguer laden
            Settings.Textures.Add("iferno", Content.Load<Texture2D>("playersprite"));
            //healthbar laden
            Settings.Textures.Add("healthbar", Content.Load<Texture2D>("healthbar"));

            map = new Map(this);
            player = new Player(250, 400, Color.White, map);
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
            map.Update(dt);
            player.Update(dt);
        }

        public override void Draw(GameTime gameTime)
        {
            map.Draw(spriteBatch); 
            player.Draw(spriteBatch);           
        }
    }
}

