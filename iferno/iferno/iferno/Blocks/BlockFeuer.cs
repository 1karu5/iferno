using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockFeuer:Block
    {

        public BlockFeuer(Map map,int x, int y):base(map,x,y,Color.White,Settings.Textures["block-feuer"])
        {
            dmg = 10;

            frames = 8;
            delay = 0.2f;
            animate = true;
            collideWithPlayer = false;
        }

        public override Rectangle Collision()
        {
            Rectangle collision = base.Collision();
            collision.Y = collision.Y + (collision.Height * 2 / 3);
            collision.Height = collision.Height * 1 / 3;
            return collision;
        }

        public override void OnCollisionWithPlayer(Player p)
        {
            Settings.SoundEffects["pickup"].Play();
            isDestroying = true;
            p.changeHP(dmg);
        }
    }
}
