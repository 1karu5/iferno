using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class HelpText
    {
        public Texture2D texture;
        public Vector2 position;

        public float timeout;
        public bool isDestroying=false;

        public HelpText(float x, float y, Texture2D t,float timeout)
        {
            //Get texture
            this.texture = t;
            //timeout to despawn
            this.timeout = timeout;
            //Set starting position
            this.position = new Vector2(x, y);
        }

        public virtual void Update(float dt)
        {
            timeout -= dt;
            if (timeout < 0)
            {
                isDestroying = true;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
