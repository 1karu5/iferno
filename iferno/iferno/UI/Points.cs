using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace iferno
{
    public class Points
    {
        public Texture2D texture;
        public Vector2 position;

        public SpriteFont font;

        public List<string> output;
        public string outputString;

        public int maxLines = 1;

        public int punkte = 0;

        public Points(float x, float y)
        {
            //Set starting position
            this.position = new Vector2(x, y);

            font = Settings.font;

            output = new List<string>();
            outputString = "";
        }

        public void reset()
        {
            punkte = 0;
        }

        public void changeTo(int p)
        {
            punkte += p;  
        }

        public virtual void Update(float dt)
        {
            outputString = "Punkte: " + punkte;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, outputString, position, Color.Black);
        }
    }
}
