using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockKiste : Block
    {
        public BlockKiste(Map map, int x, int y)
            : base(map, x, y, Color.White, Settings.Textures["block-kiste" + Settings.Rnd.Next(0, 4)])
        {
            frames = 4;
            delay = 0.1f;
        }

        public override void OnCollisionWithPlayer(Player p)
        {
            markDestroy = true;
        }

        public override void Update(float dt)
        {
            base.Update(dt);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

        }
    }
}
