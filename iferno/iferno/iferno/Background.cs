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
    public class Background
    {
        Screen screen;

        public Background(Screen screen)
        {
            this.screen = screen;
        }

        public virtual void LoadContent()
        {
            Settings.Textures.Add("backgroundlevel1", screen.Content.Load<Texture2D>("backgroundlevel1"));
        }

        public void move(float px)
        {
           
        }

        public void Update(float dt)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
