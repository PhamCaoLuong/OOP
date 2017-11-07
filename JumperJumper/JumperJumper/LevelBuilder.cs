using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
namespace JumperJumper
{
    class LevelBuilder
    {
        public Dictionary<string, CollectableFactory.CollectableType> itemDictionary = new Dictionary<string, CollectableFactory.CollectableType>();
        public Dictionary<string, BlockFactory.BlockType> blockDictionary = new Dictionary<string, BlockFactory.BlockType>();
        public Dictionary<string, EnemyFactory.EnemyType> enemyDictionary = new Dictionary<string, EnemyFactory.EnemyType>();
        public Dictionary<string, SpriteFactory.sprites> backgroundDictonary = new Dictionary<string, SpriteFactory.sprites>();
        ISpriteFactory factory;
        BlockFactory blockFactory;
        EnemyFactory enemyFactory;
        CollectableFactory collectableFactory;

        Teno teno;
        int spacingIncrement = 16; // khoảng các pixel
        Level level;
        public LevelBuilder(Level level)
        {
            this.level = level;
            factory = new SpriteFactory();
            blockFactory = new BlockFactory();
            enemyFactory = new EnemyFactory();
            collectableFactory = new CollectableFactory();
            // item là những gì thu lượm được
            itemDictionary.Add("C", CollectableFactory.CollectableType.coin);

            // background là nhừng gì không ảnh hưởng tới cái khác
            backgroundDictonary.Add("b1", SpriteFactory.sprites.bush1);
            backgroundDictonary.Add("G1", SpriteFactory.sprites.grass1);
            backgroundDictonary.Add("G2", SpriteFactory.sprites.grass2);
            backgroundDictonary.Add("T", SpriteFactory.sprites.tree);
            backgroundDictonary.Add("ex", SpriteFactory.sprites.exit);

            // enemy

            // blockDictionary là những khối trong game như đá, cây, hộp
            blockDictionary.Add("G", BlockFactory.BlockType.gai);
            blockDictionary.Add("c1", BlockFactory.BlockType.catus1);
            blockDictionary.Add("c2", BlockFactory.BlockType.catus2);
            blockDictionary.Add("M1", BlockFactory.BlockType.mushroom1);
            blockDictionary.Add("M2", BlockFactory.BlockType.mushroom2);
            blockDictionary.Add("S1", BlockFactory.BlockType.stone1);
            blockDictionary.Add("S2", BlockFactory.BlockType.stone2);
            blockDictionary.Add("S3", BlockFactory.BlockType.stone3);
            blockDictionary.Add("S4", BlockFactory.BlockType.stone4);
            blockDictionary.Add("SB", BlockFactory.BlockType.stoneblock);
            blockDictionary.Add("cr", BlockFactory.BlockType.crate);
            blockDictionary.Add("se", BlockFactory.BlockType.sea);
            blockDictionary.Add("g", BlockFactory.BlockType.ground);
            blockDictionary.Add("ulb", BlockFactory.BlockType.undergroundLeftBottom);
            blockDictionary.Add("urb", BlockFactory.BlockType.undergroundRightBottom);
        }
        public Teno Build(string fileName)
        {
            float xCoord = 0, yCoord = 0;
            StreamReader sr;
            sr = File.OpenText(Game1.GetInstance().Content.RootDirectory + fileName);
            string line;
            while((line = sr.ReadLine())!=null)
            {
                yCoord += spacingIncrement;
                xCoord = 0;
                string[] words = line.Split(',');
                for (int i = 0; i < words.Length; i++)
                {
                    int events = 1;
                    if(words[i] == "T")
                    {
                        teno = new Teno(new Vector2(xCoord, yCoord));
                    }
                    if(itemDictionary.ContainsKey(words[i]))
                    {
                        ICollectable item = collectableFactory.build(itemDictionary[words[i]], new Vector2(xCoord,yCoord));
                        level.levelItems.Add(item);
                    }
                    if(backgroundDictonary.ContainsKey(words[i]))
                    {
                        if(words[i] == "ex")
                        {
                            level.exitPosition = new Vector2(xCoord, yCoord);
                        }
                        else
                        {
                            KeyValuePair<IAnimatedSprite, Vector2> item = new KeyValuePair<IAnimatedSprite, Vector2>
                                (factory.build(backgroundDictonary[words[i]]), new Vector2(xCoord, yCoord));
                            level.levelBackgroundObjects.Add(item);
                        }
                    }
                    if(blockDictionary.ContainsKey(words[i]))
                    {
                        Block block = blockFactory.build(blockDictionary[words[i]], new Vector2(xCoord, yCoord));
                        level.levelBlock.Add(block);
                    }
                    if(enemyDictionary.ContainsKey(words[i]))
                    {
                        Enemy enemy = enemyFactory.build(enemyDictionary[words[i]], new Vector2(xCoord, yCoord));
                        level.levelEnemies.Add(enemy);
                    }

                    if(words[i] == "Ch")
                    {
                        level.checkpoint = new Vector2(xCoord, yCoord);
                    }
                    xCoord += spacingIncrement*events;
                }
            }
            return teno;
        }

    }
}
