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
        public float time = 0;
        public float delay = 0.3f;
        public int frameCounter = 0;
        public bool markDestroy = false;
        public bool animate = false;

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

        public virtual void move(float px)
        {
            this.position.X += (int)px;
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            if (markDestroy || animate)
            {
                //Einzelne Frames abarbeiten
                time += dt;
                if (time > delay)
                {
                    time -= delay;
                    if (frameCounter < frames - 1)
                        frameCounter++;
                    else if (markDestroy)
                        isDestroying = true;
                    else
                        frameCounter = 0;
                }
            }
        }
        /**
         *  return: true -> collision
         *          false -> just dmg, player moves normaly
         * */
        public abstract bool OnCollisionWithPlayer(Player p);

        public virtual bool CheckCollisionWith(Rectangle r)
        {
            Rectangle rec = Rectangle.Intersect(this.Collision(), r);
            return !rec.IsEmpty;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.isVisible())
            {
                spriteBatch.Draw(this.texture, position,
                        new Rectangle((int)(frameCounter * (int)Width()), 0, (int)Width(), (int)Height()),
                        Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.0f);
            }
        }
    }
}
