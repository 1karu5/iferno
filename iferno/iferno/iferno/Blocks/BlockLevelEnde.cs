using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockLevelEnde:Block
    {

        public BlockLevelEnde(Map map, int x, int y)
            : base(map, x, y, Color.White, Settings.Textures["block-transparent"])
        {
            dmg = 0;
            collideWithPlayer = false;
        }

        public override void OnCollisionWithPlayer(Player p)
        {
            p.nextLevel();
        }
    }
}
