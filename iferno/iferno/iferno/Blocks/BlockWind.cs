using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockWind:Block
    {
        public BlockWind(Map map,int x, int y):base(map,x,y,Color.White,Settings.Textures["block-transparent"])
        {
            dmg = -5;
            collideWithPlayer = false;
        }

        public override void OnCollisionWithPlayer(Player p)
        {
            p.changeHP(dmg);
        }
    }
}
