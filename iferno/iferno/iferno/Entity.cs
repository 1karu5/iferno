using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public abstract class Entity
    {
        public Texture2D texture;
        public Vector2 position;
        public Color color;
        public int frames=1;
        
        public Entity(float x, float y,Color color,Texture2D t)
        {
            this.color = color;
            //Get texture
            this.texture = t;

            //Set starting position
            this.position = new Vector2(x, y);
        }

       

        public virtual float Width()
        {
            return this.texture.Width/frames;
        }

        public virtual float Height()
        {
            return this.texture.Height;
        }

        public virtual float X()
        {
            return this.position.X;
        }

        public virtual float Y()
        {
            return this.position.Y;
        }

        public virtual Rectangle Collision()
        {
            return new Rectangle((int)this.X(),(int)this.Y(),(int)this.Width(),(int)this.Height());
        }

        public virtual void Update(float dt)
        {
           
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, this.color);
        }
    }
}
