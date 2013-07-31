using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace iferno
{
    public class Console
    {
        public Texture2D texture;
        public Vector2 position;

        public SpriteFont font;

        public List<string> output;
        public string outputString;

        public int maxLines = 3;

        public Console(float x, float y)
        {
            //Set starting position
            this.position = new Vector2(x, y);

            font = Settings.font;

            output = new List<string>();
            outputString = "";
        }

        public void write(string s)
        {
            output.Add(s);    
        }

        public virtual void Update(float dt)
        {
            outputString = "";

            for (int i = output.Count - 1 - maxLines; i >= 0; i--)
            {
                output.RemoveAt(i);
            }
            foreach (string o in output)
            {
                outputString += o + "\n";
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, outputString, position, Color.Black);
        }
    }
}
