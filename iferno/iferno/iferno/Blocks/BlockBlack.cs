using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockBlack:Block
    {
        public BlockBlack(Map map, int x, int y)
            : base(map, x, y, Color.White, Settings.Textures["block-black"])
        {
            dmg = 0;  
        }

        public override bool OnCollisionWithPlayer(Player p)
        {
            return true;
        }
    }
}
