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
        KeyboardState oldKeyboardState=Keyboard.GetState();

        public IntroScreen(Game1 game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {

        }

        public override void activate()
        {
            oldKeyboardState = Keyboard.GetState();
        }

        public override void LoadContent()
        {
            Settings.Textures.Add("intro1", Content.Load<Texture2D>("intro1"));
            Settings.Textures.Add("intro2", Content.Load<Texture2D>("intro2"));
            Settings.Textures.Add("intro3", Content.Load<Texture2D>("intro3"));
            Settings.Textures.Add("intro4", Content.Load<Texture2D>("intro4"));
            Settings.Textures.Add("intro5", Content.Load<Texture2D>("intro5"));
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState menuState = Keyboard.GetState();
            if (menuState.IsKeyDown(Keys.Enter) && oldKeyboardState.IsKeyUp(Keys.Enter))
            {
                if (i < 5)
                {
                    i++;
                }
                else
                {
                    Settings.player.reset();
                    Settings.player.map.loadMap(Settings.mapNumber);
                    Settings.game.switchScreen("level");  
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
