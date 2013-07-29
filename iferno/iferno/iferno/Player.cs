using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class Player : Entity
    {

        public int Directiony { get; set; }

        public Player(float x, float y, Color color)
            : base(x, y, color, Settings.Textures["blockrot"])
        {
            this.Directiony = 0;
            
        }


        public void Update(float dt)
        {
            base.Update(dt);   
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
