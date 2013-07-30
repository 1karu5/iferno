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
        public int speed = 250;
       
        public BlockKaefer(Map map, int x, int y)
            : base(map, x, y, Color.White, Settings.Textures["blockgruen"])
        {
            dmg = 100;
        }

        public override bool OnCollisionWithPlayer(Player p)
        {
            p.changeHP(-1);
            return false;    //true, blockieren aber buggy
        }

        public override void Update(float dt)
        {
            if (isVisible())
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
                foreach (Block b in map.getVisibleBlocks())
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
}
