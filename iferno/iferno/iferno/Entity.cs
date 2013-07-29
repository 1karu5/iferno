using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class Entity
    {
        private Texture2D texture;
        private Vector2 position;
        private Color color;

        public int Directionx { get; set;}
        public int Directiony { get; set; }

        public Entity(float x, float y,Color color,Texture2D t)
        {
            this.color = color;
            //Get texture
            this.texture = t;

            //Set starting position
            this.position = new Vector2(x, y);

            //No initial movement
            this.Directionx = 0;
            this.Directionx = 0;
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
