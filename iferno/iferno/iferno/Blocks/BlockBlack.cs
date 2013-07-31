using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockBlack:Block
    {
        public BlockBlack(Map map, int x, int y)
            : base(map, x, y, Settings.levelBackground[Settings.mapNumber], Settings.Textures["block-white"])
        {
            dmg = 0;  
        }

        public override bool OnCollisionWithPlayer(Player p)
        {
            return true;
        }
    }
}
