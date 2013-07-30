using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class HealthBar
    {
        public Texture2D texture;
        public Vector2 position;

        public float health;
        
        public HealthBar(float x, float y)
        {
            this.health = 1.0f;
            //Get texture
            this.texture = Settings.Textures["healthbar"];

            //Set starting position
            this.position = new Vector2(x, y);
        }

        public void changeTo(int hp)
        {
            health = hp / 100.0f;
            //position.Y += 2;
        }

        public virtual void Update(float dt)
        {
              
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position,
                   null, Color.White, 0, new Vector2(0,200), new Vector2(1f,health), SpriteEffects.None, 0.0f); 
        }
    }
}
