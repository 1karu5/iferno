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
    public class MenuScreen : Screen
    {
        KeyboardState oldKeyboardState = Keyboard.GetState();

        public MenuScreen(Game1 game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {

        }

        public override void activate()
        {
            oldKeyboardState = Keyboard.GetState();
        }

        public override void LoadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime)
        {

        }
    }
}
