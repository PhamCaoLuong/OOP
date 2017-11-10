using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JumperJumper
{
    public class BlockFactory
    {
        public enum BlockType
        {
            gai, catus1, catus2, crate, stone1, stone2, stone3, stone4, stoneblock, mushroom1, mushroom2, sea, ground,
        }
        SpriteFactory factory;
        IBlockState state;
        ICollectable prize;

        public BlockFactory()
        {
        }

        public Block build(BlockType type, Vector2 location)
        {
            prize = null;
            factory = new SpriteFactory();


            if (type == BlockType.ground)
            {
                state = new GenericBlockState(SpriteFactory.sprites.ground);
            }

            if (type == BlockType.gai)
            {
                state = new DamageBlockState(SpriteFactory.sprites.gai);
            }
            if (type == BlockType.catus1)
            {
                 state = new DamageBlockState(SpriteFactory.sprites.catus1);
            }
            if (type == BlockType.catus2)
            {
                state = new DamageBlockState(SpriteFactory.sprites.catus2);
            }
            if(type == BlockType.sea)
            {
                state = new DamageBlockState(SpriteFactory.sprites.sea);
            }
            /* Node : GaiBlockState là class có những block gai gây damage */

            if (type == BlockType.stone1)
            {
                state = new GenericBlockState(SpriteFactory.sprites.stone1);
            }
            if (type == BlockType.stone2)
            {
                state = new GenericBlockState(SpriteFactory.sprites.stone2);
            }
            if (type == BlockType.stone3)
            {
                state = new GenericBlockState(SpriteFactory.sprites.stone3);
            }
            if (type == BlockType.stone4)
            {
                state = new GenericBlockState(SpriteFactory.sprites.stone4);
            }
            if (type == BlockType.stoneblock)
            {
                state = new GenericBlockState(SpriteFactory.sprites.stoneblock);
            }
            if (type == BlockType.crate)
            {
                state = new GenericBlockState(SpriteFactory.sprites.crate);
            }

            if (type == BlockType.mushroom1)
            {
                state = new TrampolineBlockState(SpriteFactory.sprites.mushroom1); 
            }
            if(type == BlockType.mushroom2)
            {
                state = new TrampolineBlockState(SpriteFactory.sprites.mushroom2);
            }
            Block product = new Block(location, prize, state);
            return product;
        }
    }
}
