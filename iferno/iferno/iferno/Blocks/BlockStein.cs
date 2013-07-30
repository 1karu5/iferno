using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockStein:Block
    {
        public BlockStein(Map map,int x, int y):base(map,x,y,Color.White,Settings.Textures["blockgruen"])
        {
           
        }

        public override void collisionWithPlayer(Player p)
        {
          
        }
    }
}
