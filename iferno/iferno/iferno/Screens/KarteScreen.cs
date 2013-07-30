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
    public class KarteScreen : Screen
    {

        public KarteScreen(Game1 game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {

        }

        public override void LoadContent()
        {
            Settings.Textures.Add("karte1", Content.Load<Texture2D>("karte1"));
            Settings.Textures.Add("karte2", Content.Load<Texture2D>("karte2"));
            Settings.Textures.Add("karte3", Content.Load<Texture2D>("karte3"));
            Settings.Textures.Add("karte4", Content.Load<Texture2D>("karte4"));
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState menuState = Keyboard.GetState();
            if (menuState.IsKeyDown(Keys.Enter))
            {
                Settings.game.switchScreen("level");  
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(Settings.Textures["karte" + Settings.mapNumber], new Vector2(0, 0), Color.White);
        }
    }
}
