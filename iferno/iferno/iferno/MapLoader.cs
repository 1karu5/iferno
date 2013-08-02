using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Reflection;


namespace iferno
{
    public class MapLoader
    {
        public List<Block> Load(Map map,string path)
        {
            List<Block> newMap = new List<Block>();
 
            StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("iferno.level."+path));
            string line;
            int y=0;
            while(!reader.EndOfStream){
                line=reader.ReadLine();

                for (int x = 0; x < line.Length; x++)
                {
                    if (line[x] == 'W')
                    {
                        newMap.Add(new BlockWasser(map, x, y));
                    }
                    if (line[x] == 'S')
                    {
                        newMap.Add(new BlockSand(map, x, y));
                    }
                    if (line[x] == 'F')
                    {
                        newMap.Add(new BlockFeuer(map, x, y));
                    }
                    if (line[x] == 'K')
                    {
                        newMap.Add(new BlockKiste(map, x, y));
                    }
                    if (line[x] == 'H')
                    {
                        newMap.Add(new BlockHolz(map, x, y));
                    }
                    if (line[x] == 'E')
                    {
                        newMap.Add(new BlockLevelEnde(map, x, y));
                    }
                    if (line[x] == 'I')
                    {
                        newMap.Add(new BlockWiese(map, x, y, Settings.Textures["block-grasoben"]));
                    }
                    if (line[x] == 'J')
                    {
                        newMap.Add(new BlockWiese(map, x, y, Settings.Textures["block-gras"]));
                    }
                    if (line[x] == 'G')
                    {
                        newMap.Add(new BlockStein(map, x, y));
                    }
                    if (line[x] == 'L')
                    {
                        newMap.Add(new BlockBlatt(map, x, y));
                    }
                    if (line[x] == 'R')
                    {
                        newMap.Add(new BlockWolke(map, x, y));
                    }
                    if (line[x] == 'C')
                    {
                        newMap.Add(new BlockWasserTropfenSpawner(map, x, y));
                    }
                    if (line[x] == 'Q')
                    {
                        newMap.Add(new BlockWasserTropfenSpawner(map, x, y, Settings.Textures["block-wolkegegner"], 20));
                    }
                    if (line[x] == 'N')
                    {
                        newMap.Add(new BlockWasserTropfenSpawner(map, x, y, Settings.Textures["block-stein" + Settings.Rnd.Next(0, 4)]));
                    }
                    if (line[x] == 'B')
                    {
                        newMap.Add(new BlockBlack(map, x, y));
                    }
                    if (line[x] == 'M')
                    {
                        newMap.Add(new BlockKaefer(map, x, y));
                    }
                    if (line[x] == 'A')
                    {
                        newMap.Add(new BlockKaefer(map, x, y, Settings.Textures["block-bubblegenger"]));
                    }
                    if (line[x] == 'O')
                    {
                        newMap.Add(new BlockDschungel(map, x, y));
                    }
                    if (line[x] == 'P')
                    {
                        newMap.Add(new BlockPlatform(map, x, y));
                    }
                    if (line[x] == 'D')
                    {
                        newMap.Add(new BlockWind(map, x, y, Settings.Textures["block-windrechts"]));
                    }
                    if (line[x] == '#')
                    {
                        newMap.Add(new BlockWind(map, x, y, Settings.Textures["block-windlinks"]));
                    }
                    if (line[x] == 'V')
                    {
                        newMap.Add(new BlockVentilator(map, x, y));
                    }
                    if (line[x] == 'Z')
                    {
                        newMap.Add(new BlockDorf(map, x, y));
                    }
                    if (line[x] == 'U')
                    {
                        newMap.Add(new BlockUnteresWasser(map, x, y));
                    }
                }
                y++;
            }
            return newMap;
        }
    }
}
