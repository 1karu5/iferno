using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockWasser:Block
    {
        public BlockWasser(Map map,int x, int y):base(map,x,y,Color.White,Settings.Textures["block-wasser"])
        {
            dmg = -100;
        }

        public override bool OnCollisionWithPlayer(Player p)
        {
            p.changeHP(dmg);
            return true;
        }
    }
}
