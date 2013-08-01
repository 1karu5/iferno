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
    public class GameoverScreen : Screen
    {
        KeyboardState oldKeyboardState = Keyboard.GetState();

        public GameoverScreen(Game1 game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            
        }

        public override void activate()
        {
            oldKeyboardState = Keyboard.GetState();
            Settings.SoundEffects["death"].Play();
        }

        public override void LoadContent()
        {
            Settings.Textures.Add("gameover", Content.Load<Texture2D>("gameover"));
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
            spriteBatch.Draw(Settings.Textures["gameover"], new Vector2(0, 0), Color.White);
        }
    }
}
