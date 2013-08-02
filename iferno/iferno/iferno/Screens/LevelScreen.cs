using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace iferno
{
    class LevelScreen : Screen
    {

        Player player;

        Map map;

        Background background;

        public LevelScreen(Game1 game, SpriteBatch spriteBatch) : base(game, spriteBatch)
        {

        }

        public override void activate()
        {
            MediaPlayer.Stop();
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(Settings.Songs["level"+Settings.mapNumber]);
            Settings.player.reset();
            Settings.player.map.loadMap(Settings.mapNumber);
        }

        public override void LoadContent()
        {
            //Spielfiguer laden
            Settings.Textures.Add("iferno", Content.Load<Texture2D>("player/playersprite"));
            Settings.Textures.Add("ifernowait", Content.Load<Texture2D>("player/playerwaitsprite"));
            Settings.Textures.Add("ifernoback", Content.Load<Texture2D>("player/playerbacksprite"));
            Settings.Textures.Add("ifernodmg", Content.Load<Texture2D>("player/playerdmgsprite"));
            Settings.Textures.Add("ifernodmgback", Content.Load<Texture2D>("player/playerdmgspriteback"));
            //ui laden
            Settings.Textures.Add("healthbar", Content.Load<Texture2D>("ui/healthbar"));
            //instruktion texte 
            Settings.Textures.Add("jumpLaufen", Content.Load<Texture2D>("ui/jumpLaufen"));
            Settings.Textures.Add("VorsichtWasser", Content.Load<Texture2D>("ui/VorsichtWasser"));
            Settings.Textures.Add("HolzIstBrennbar", Content.Load<Texture2D>("ui/HolzIstBrennbar"));
            Settings.Textures.Add("VorsichtWind", Content.Load<Texture2D>("ui/VorsichtWind"));
            Settings.Textures.Add("VorsichtKäfer", Content.Load<Texture2D>("ui/VorsichtKäfer"));

            //##########sound
            Settings.SoundEffects.Add("dmg", Content.Load<SoundEffect>("sound/damage"));
            Settings.SoundEffects.Add("death", Content.Load<SoundEffect>("sound/death"));
            Settings.SoundEffects.Add("jump", Content.Load<SoundEffect>("sound/jump"));
            Settings.SoundEffects.Add("burn", Content.Load<SoundEffect>("sound/burn"));
            Settings.SoundEffects.Add("pickup", Content.Load<SoundEffect>("sound/pickup"));
            //tropfen
            Settings.SoundEffects.Add("tropfen0", Content.Load<SoundEffect>("sound/tropfen/tropfen0"));
            Settings.SoundEffects.Add("tropfen1", Content.Load<SoundEffect>("sound/tropfen/tropfen1"));
            Settings.SoundEffects.Add("tropfen2", Content.Load<SoundEffect>("sound/tropfen/tropfen2"));
            Settings.SoundEffects.Add("tropfen3", Content.Load<SoundEffect>("sound/tropfen/tropfen3"));
            Settings.SoundEffects.Add("tropfen4", Content.Load<SoundEffect>("sound/tropfen/tropfen4"));
            Settings.SoundEffects.Add("tropfen5", Content.Load<SoundEffect>("sound/tropfen/tropfen5"));
            Settings.SoundEffects.Add("tropfen6", Content.Load<SoundEffect>("sound/tropfen/tropfen6"));
            Settings.SoundEffects.Add("tropfen7", Content.Load<SoundEffect>("sound/tropfen/tropfen7"));
            //musik
            Settings.Songs.Add("level0", Content.Load<Song>("sound/songs/strand"));
            Settings.Songs.Add("level1", Content.Load<Song>("sound/songs/wiese"));
            Settings.Songs.Add("level2", Content.Load<Song>("sound/songs/dorf"));
            Settings.Songs.Add("level3", Content.Load<Song>("sound/songs/dschungel"));
            Settings.Songs.Add("level4", Content.Load<Song>("sound/songs/hoehle"));


            Settings.font = Content.Load<SpriteFont>("ui/font");

            background = new Background(this);
            map = new Map(this, background);
            player = new Player(Color.White, map, background);
        }

        public override void Update(GameTime gameTime)
        {
            //Calculate deltatime
            float dt = gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

            //Get keystate
            KeyboardState keyState = Keyboard.GetState();

            //Check input
            if (keyState.IsKeyDown(Keys.Right))
            {
                player.DirectionX = 1;
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                player.DirectionX = -1;
            }
            else
            {
                player.DirectionX = 0;
            }

            if (keyState.IsKeyDown(Keys.Space))
            {
                player.jump();
            }
            if(keyState.IsKeyDown(Keys.Escape))
            {
                game.switchScreen("menu");
            }

            //cheat mode :D
            if (keyState.IsKeyDown(Keys.LeftAlt))
            {
                player.immortal = true;
            }
            else
            {
                player.immortal = false;
            }

            //Update world
            background.Update(dt);
            map.Update(dt);
            player.Update(dt);
        }

        public override void Draw(GameTime gameTime)
        {
            background.Draw(spriteBatch);
            map.Draw(spriteBatch); 
            player.Draw(spriteBatch);           
        }
    }
}

