using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockWasserTropfenSpawner:Block
    {
        public int timer=0;
        public int anzahl;
        public List<WaterDrop> tropfen;

        public BlockWasserTropfenSpawner(Map map, int x, int y, Texture2D t,int anzahl)
            : base(map, x, y, Color.White, t)
        {
            dmg = -10;
            this.anzahl = anzahl;
            tropfen = new List<WaterDrop>();
            collideWithPlayer = false;
        }

        public BlockWasserTropfenSpawner(Map map, int x, int y,Texture2D t)
            : base(map, x, y, Color.White, t)
        {
            dmg = -10;
            anzahl = 100;
            tropfen = new List<WaterDrop>();
            collideWithPlayer = false;
        }

        public BlockWasserTropfenSpawner(Map map, int x, int y)
            : base(map, x, y, Color.White, Settings.Textures["block-wolke" + Settings.Rnd.Next(0, 2)])
        {
            dmg = -10;
            anzahl = 100;
            tropfen = new List<WaterDrop>();
            collideWithPlayer = false;
        }

        public void spawnDrop()
        {
            tropfen.Add(new WaterDrop(X()+(Width()/2)-8,Y()+Height(),Color.White,map,this));
        }

        public override void OnCollisionWithPlayer(Player p)
        {
            p.changeHP(dmg);
        }

        public override bool CheckCollisionWith(Rectangle r)
        {
            Rectangle rec = Rectangle.Intersect(this.Collision(), r);

            foreach (WaterDrop d in tropfen)
            {
                if (d.CheckCollisionWithPlayer(r))
                {
                    return true;
                }
            }

            return false;
        }

        public override void move(float px)
        {
            foreach (WaterDrop d in tropfen)
            {
                d.move(px);
            }
            base.move(px);
        }

        public override void Update(float dt)
        {
            timer++;

            if (timer % anzahl == 0)
            {
                timer = 0;
                //tropfen spawnen
                spawnDrop();
            }

            foreach (WaterDrop d in tropfen)
            {
                d.Update(dt);
            }

            for (int i = tropfen.Count - 1; i >= 0; i--)
            {
                if (tropfen[i].isDestroying)
                    tropfen.RemoveAt(i);
            }
            base.Update(dt);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (WaterDrop d in tropfen)
            {
                d.Draw(spriteBatch);
            }
            base.Draw(spriteBatch);  
        }
    }
}
