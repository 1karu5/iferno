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
    public class IntroScreen : Screen
    {
        int i = 1;
        int max = 11;
        KeyboardState oldKeyboardState=Keyboard.GetState();

        public IntroScreen(Game1 game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {

        }

        public override void activate()
        {
            i = 1;
            oldKeyboardState = Keyboard.GetState();
        }

        public override void LoadContent()
        {
            Settings.Textures.Add("intro1", Content.Load<Texture2D>("intro/intro1"));
            Settings.Textures.Add("intro2", Content.Load<Texture2D>("intro/intro2"));
            Settings.Textures.Add("intro3", Content.Load<Texture2D>("intro/intro3"));
            Settings.Textures.Add("intro4", Content.Load<Texture2D>("intro/intro4"));
            Settings.Textures.Add("intro5", Content.Load<Texture2D>("intro/intro5"));
            Settings.Textures.Add("intro6", Content.Load<Texture2D>("intro/intro6"));
            Settings.Textures.Add("intro7", Content.Load<Texture2D>("intro/intro7"));
            Settings.Textures.Add("intro8", Content.Load<Texture2D>("intro/intro8"));
            Settings.Textures.Add("intro9", Content.Load<Texture2D>("intro/intro9"));
            Settings.Textures.Add("intro10", Content.Load<Texture2D>("intro/intro10"));
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState menuState = Keyboard.GetState();
            if (menuState.IsKeyDown(Keys.Enter) && oldKeyboardState.IsKeyUp(Keys.Enter))
            {
                if (i < max)
                {
                    i++;
                }
                else
                {
                    Settings.game.switchScreen("karte");  
                }   
            }
            oldKeyboardState = menuState;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(Settings.Textures["intro" + i], new Vector2(0, 0), Color.White);
        }
    }
}
