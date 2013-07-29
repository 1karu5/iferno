using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class Entity
    {
        public Texture2D texture;
        public Vector2 position;
        public Color color;

        
        public Entity(float x, float y,Color color,Texture2D t)
        {
            this.color = color;
            //Get texture
            this.texture = t;

            //Set starting position
            this.position = new Vector2(x, y);
        }

        public Rectangle Collision()
        {
            return new Rectangle((int)this.position.X,(int)this.position.Y,this.texture.Width,this.texture.Height);
        }

        public void Update(float dt)
        {
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, this.color);
        }
    }
}
