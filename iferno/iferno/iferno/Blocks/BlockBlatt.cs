﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockBlatt:Block
    {
        public BlockBlatt(Map map,int x, int y):base(map,x,y,Color.White,Settings.Textures["blockgruen"])
        {
           
        }

        public override bool OnCollisionWithPlayer(Player p)
        {
            return true;
        }
    }
}