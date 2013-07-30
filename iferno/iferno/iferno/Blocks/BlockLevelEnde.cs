using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockLevelEnde:Block
    {

        public BlockLevelEnde(Map map, int x, int y)
            : base(map, x, y, Color.White, Settings.Textures["blockgruen"])
        {
            dmg = 0;
        }

        public override bool OnCollisionWithPlayer(Player p)
        {
            p.nextLevel();

            return true;
        }
    }
}
