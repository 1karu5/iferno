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
            rndZahl = Settings.Rnd.Next(0, 2);

            if (rndZahl == 0)
            {
                //hier später Setting.mapNumber eintragen
                return Settings.Textures["level" + 1 + ".1"];
            }
                //hier später Setting.mapNumber eintragen
                return Settings.Textures["level" + 1 + ".2"];
        }

        public virtual void LoadContent()
        {
            //erstes Level
            Settings.Textures.Add("level1.1", screen.Content.Load<Texture2D>("level1.1"));
            Settings.Textures.Add("level1.2", screen.Content.Load<Texture2D>("level1.2"));
        /*    //zweites level
            Settings.Textures.Add("level2.1", screen.Content.Load<Texture2D>("level2.1"));
            Settings.Textures.Add("level2.2", screen.Content.Load<Texture2D>("level2.2"));
            //drittes level
            Settings.Textures.Add("level3.1", screen.Content.Load<Texture2D>("level3.1"));
            Settings.Textures.Add("level3.2", screen.Content.Load<Texture2D>("level3.2"));
            //viertes level
            Settings.Textures.Add("level4.1", screen.Content.Load<Texture2D>("level4.1"));
            Settings.Textures.Add("level4.2", screen.Content.Load<Texture2D>("level4.2"));
            //fünftes level
            Settings.Textures.Add("level5.1", screen.Content.Load<Texture2D>("level5.1"));
            Settings.Textures.Add("level5.2", screen.Content.Load<Texture2D>("level5.2"));  */
        }

        public void move(float px)
        {
            this.position.X += ((int)px) / Settings.BackgroundSpeed;
            this.position2.X += ((int)px) / Settings.BackgroundSpeed;
                ;

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
