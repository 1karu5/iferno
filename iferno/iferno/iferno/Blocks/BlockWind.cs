using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockWind:Block
    {
        public BlockWind(Map map,int x, int y):base(map,x,y,Color.White,Settings.Textures["block-transparent"])
        {
            dmg = -10;
        }

        public override bool OnCollisionWithPlayer(Player p)
        {
            p.changeHP(dmg);
            return false;
        }
    }
}
