using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class Block:Entity
    {

        public int mapPositionX;
        public int mapPositionY;
        public Map map;

        public Block(Map map,int x, int y, Color color,Texture2D t):base(x*64,y*64,color,t)
        {
            this.map = map; 
            
            this.mapPositionX = x;
            this.mapPositionY = y;

        }

        public bool isVisible()
        {
            return true;
        }

        public void Update(float dt)
        {
            base.Update(dt);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.isVisible())
            {
                base.Draw(spriteBatch);
            }
        }
    }
}
