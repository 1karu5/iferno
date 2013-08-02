using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockKaefer:Block
    {
        public int timer=0;
        public bool direction = false;
        public int speed = 300;

        public BlockKaefer(Map map, int x, int y,Texture2D t)
            : base(map, x, y, Color.White, t)
        {
            frames = 4;
            delay = 0.3f;
            animate = true;

            dmg = 100;
            collideWithPlayer = false;
        }

        public BlockKaefer(Map map, int x, int y)
            : base(map, x, y, Color.White, Settings.Textures["block-krabbegenger"])
        {
            dmg = 100;
            collideWithPlayer = false;
        }

        public override void OnCollisionWithPlayer(Player p)
        {
            p.changeHP(-1);
        }

        public override Rectangle Collision()
        {
            Rectangle collision = base.Collision();
            collision.Y = collision.Y + (collision.Height * 2 / 3);
            collision.Height = collision.Height * 1 / 3; 
            return collision;
        }

        public override void Update(float dt)
        {
            
            
                float newX = X();
                Rectangle collsionMesh = Collision();
                
                if (direction)
                {
                    newX+=speed *dt;   
                }
                else
                {
                    newX-=speed*dt;
                }
                collsionMesh.X = (int)newX;
                foreach (Block b in map.blocks)
                {
                    if (!(b is BlockKaefer) && b.CheckCollisionWith(collsionMesh))
                    {
                        newX = X();
                        direction = !direction; //umdrehen
                    }
                }
                this.position.X = newX;
            }
        
    }
}
