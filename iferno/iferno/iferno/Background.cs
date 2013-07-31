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
        Texture2D texture;
        Texture2D texture2;
        Vector2 position;
        Vector2 position2;
        int rndZahl;

        public Background(Screen screen)
        {
            this.screen = screen;
            LoadContent();
            position = new Vector2(0,0);
            position2 = new Vector2(2048,0);

            texture = getRandomBackground();
            texture2 = getRandomBackground();
        }

        public Texture2D getRandomBackground()
        {
            Random rnd = new Random();
            rndZahl = rnd.Next(0, 2);

            if (rndZahl == 0)
            {
                return Settings.Textures["level1.1"];
            }
           
                return Settings.Textures["level1.2"];
        }

        public virtual void LoadContent()
        {
            Settings.Textures.Add("level1.1", screen.Content.Load<Texture2D>("level1.1"));
            Settings.Textures.Add("level1.2", screen.Content.Load<Texture2D>("level1.2"));
        }

        public void move(float px)
        {
            this.position.X += ((int)px) / 2;
            this.position2.X += ((int)px) / 2;

            if (position.X < position2.X)
            {
                if (position.X <= -2048)
                {
                     position.X = 2048+position2.X;
                    texture = getRandomBackground();
                }
            }
            else
                {
                    if(position2.X <= -2048)
                    {
                    position2.X = 2048+position.X;
                    texture2 = getRandomBackground();
                    }
                }
        }

        public void Update(float dt)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {   

            spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.Draw(texture2, position2, Color.White);
        }
    }
}
