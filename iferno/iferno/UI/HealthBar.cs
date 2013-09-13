using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class HealthBar
    {
        public Texture2D texture_innen;
        public Texture2D texture_ausen;
        public Vector2 position_innen;
        public Vector2 position_ausen;

        public float health;
        
        public HealthBar(float x, float y)
        {
            this.health = 1.0f;
            //Get texture
            this.texture_innen = Settings.Textures["healthbar_innen"];
            this.texture_ausen = Settings.Textures["healthbar_ausen"];

            //Set starting position
            this.position_ausen = new Vector2(x, y);
            this.position_innen = new Vector2(x+3, y+3);
        }

        public void changeTo(int hp)
        {
            health = hp / 100.0f;
            //position.Y += 2;
        }

        public void Update(float dt)
        {
              
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture_ausen, position_ausen,
                   null, Color.White, 0, new Vector2(0, 200), new Vector2(1f, 1f), SpriteEffects.None, 0.0f);
            spriteBatch.Draw(texture_innen, position_innen,
                   null, Color.White, 0, new Vector2(0,200), new Vector2(health,1f), SpriteEffects.None, 0.0f); 
        }
    }
}
