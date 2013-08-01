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
       
        public BlockKaefer(Map map, int x, int y)
            : base(map, x, y, Color.White, Settings.Textures["blockgruen"])
        {
            dmg = 100;
            collideWithPlayer = false;
        }

        public override void OnCollisionWithPlayer(Player p)
        {
            p.changeHP(-1);
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
