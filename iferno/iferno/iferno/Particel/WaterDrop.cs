using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class WaterDrop
    {
        public Texture2D texture;
        public Vector2 position;
        public Color color;
        public float speed;
        public bool isDestroying = false;
        public Map map;
        
        public WaterDrop(float x, float y,Color color,Map map)
        {
            this.map = map;
            this.color = color;
            //Get texture
            this.texture = Settings.Textures["waterdrop"];

            //Set starting position
            this.position = new Vector2(x, y);

            this.speed = 10.0f;
        }

        public virtual void move(float px)
        {
            this.position.X += (int)px;
        }

        public float Width()
        {
            return this.texture.Width;
        }

        public float Height()
        {
            return this.texture.Height;
        }

        public float X()
        {
            return this.position.X;
        }

        public float Y()
        {
            return this.position.Y;
        }

        public Rectangle Collision()
        {
            return new Rectangle((int)this.X(), (int)this.Y(), (int)this.Width(), (int)this.Height());
        }

        public virtual bool CheckCollisionWithPlayer(Rectangle r)
        {
            Rectangle rec = Rectangle.Intersect(this.Collision(), r);
            return !rec.IsEmpty;
        }

        private bool CheckCollisionWithMap()
        {
            foreach (Block b in map.getVisibleBlocks())
            {
                if (!(b is BlockWasserTropfenSpawner) && b.CheckCollisionWith(Collision()))
                {
                    return true;
                }
            }
            return false;
        }

        public void Update(float dt)
        {
            position.Y += speed;
            if (position.Y > Settings.Height || CheckCollisionWithMap())
            {
                isDestroying = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, this.color);
        }
    }
}
