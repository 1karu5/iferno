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
    public class EndScreen : Screen
    {
        KeyboardState oldKeyboardState = Keyboard.GetState();

        public EndScreen(Game1 game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            
        }

        public override void activate()
        {
            oldKeyboardState = Keyboard.GetState();
        }

        public override void LoadContent()
        {
            Settings.Textures.Add("ende", Content.Load<Texture2D>("ende"));
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState menuState = Keyboard.GetState();
            if (menuState.IsKeyDown(Keys.Enter) && oldKeyboardState.IsKeyUp(Keys.Enter)) 
            {
                Settings.game.switchScreen("start");  
            }
            oldKeyboardState = menuState;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(Settings.Textures["ende"], new Vector2(0, 0), Color.White);
        }
    }
}
