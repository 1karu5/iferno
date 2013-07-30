using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public abstract class Block:Entity
    {
        public int mapPositionX;
        public int mapPositionY;
        public Map map;
        public bool isDestroying = false;
        public int dmg=0;

        public Block(Map map,int x, int y, Color color,Texture2D t):base(x*64,y*64,color,t)
        {
            this.map = map; 
            
            this.mapPositionX = x;
            this.mapPositionY = y;
        }

        public bool isVisible()
        {
            if (this.mapPositionX >= map.firstVisibleBlock && this.mapPositionX < map.firstVisibleBlock+map.visibleWidth)
            {
                return true;    //TODO
            }
            return true;
        }

        public void move(float px)
        {
            this.position.X += (int)px;
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
