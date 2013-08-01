using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockBlatt:Block
    {
        private bool collided = false;

        public BlockBlatt(Map map, int x, int y)
            : base(map, x, y, Color.White, Settings.Textures["block-blatt" + Settings.Rnd.Next(0, 8)])
        {
           
        }

        public override void OnCollisionWithPlayer(Player p)
        {
            if (!collided)
            {
                collided = true;
                Settings.SoundEffects["burn"].Play();
                markDestroy = true;
                burn = true;
            }
        }
    }
}
