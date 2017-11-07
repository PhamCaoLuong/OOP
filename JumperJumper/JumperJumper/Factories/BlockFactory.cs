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
            used, question, exclamation, brick, ground, leftEdge, rightEdge, quesMush, quesNinja,
            quesCoin, ques1up, quesStar, quesFlower, undergroundRoof, undergroundFloor, undergroundLeftWall, undergroundRightWall,
            undergroundLeftTop, undergroundRightTop, undergroundRightBottom, undergroundLeftBottom, brokenPipe,
            gai, catus1, catus2, crate, stone1, stone2, stone3, stone4, stoneblock, mushroom1, mushroom2, sea,
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
            if (type == BlockType.used)
            {
                state = new GenericBlockState(SpriteFactory.sprites.usedBlock);
            }
            if (type == BlockType.question)
            {
                //state = new QuestionBlockState();
            }
            if (type == BlockType.exclamation)
            {
                //state = new ExclamationBlockState();
            }
            if (type == BlockType.brick)
            {
                //state = new BrickBlockState();
            }
            if (type == BlockType.ground)
            {
                state = new GenericBlockState(SpriteFactory.sprites.ground);
            }
            if (type == BlockType.leftEdge)
            {
               //state = new GenericBlockState(SpriteFactory.sprites.leftEdge);
            }
            if (type == BlockType.rightEdge)
            {
                //state = new GenericBlockState(SpriteFactory.sprites.rightEdge);
            }
            if (type == BlockType.quesMush)
            {
                //state = new QuestionBlockState();
                //prize = new SuperMushroom(location);
            }
            if (type == BlockType.quesStar)
            {
                //state = new QuestionBlockState();
                //prize = new Star(location);
            }
            if (type == BlockType.ques1up)
            {
                //state = new InvisibleBlockState();
                //prize = new OneUpMushroom(location);
            }
            if (type == BlockType.quesCoin)
            {
                //state = new QuestionBlockState();
                //prize = new Coin(location);
            }
            if (type == BlockType.quesFlower)
            {
                //state = new QuestionBlockState();
                //prize = new FireFlower(location);
            }
            if (type == BlockType.quesNinja)
            {
                //state = new QuestionBlockState();
                //prize = new Ninja(location);
            }
            if (type == BlockType.undergroundRoof)
            {
                state = new GenericBlockState(SpriteFactory.sprites.undergroundRoof);
            }
            if (type == BlockType.undergroundFloor)
            {
                state = new GenericBlockState(SpriteFactory.sprites.undergroundFloor);
            }
            if (type == BlockType.undergroundRightTop)
            {
                state = new GenericBlockState(SpriteFactory.sprites.undergroundRightTopCorner);
            }
            if (type == BlockType.undergroundLeftTop)
            {
                state = new GenericBlockState(SpriteFactory.sprites.undergroundLeftTopCorner);
            }
            if (type == BlockType.undergroundRightBottom)
            {
                state = new GenericBlockState(SpriteFactory.sprites.undergroundRightBottomCorner);
            }
            if (type == BlockType.undergroundLeftBottom)
            {
                state = new GenericBlockState(SpriteFactory.sprites.undergroundLeftBottomCorner);
            }
            if (type == BlockType.undergroundLeftWall)
            {
                //state = new GenericBlockState(SpriteFactory.sprites.undergroundLeftWall);
            }
            if (type == BlockType.undergroundRightWall)
            {
                //state = new GenericBlockState(SpriteFactory.sprites.undergroundRightWall);
            }
            if (type == BlockType.brokenPipe)
            {
                //state = new GenericBlockState(SpriteFactory.sprites.bluePipe);
            }
            if (type == BlockType.gai)
            {
                /// state = new DamageBlockState(SpriteFactory.sprites.Gai);
            }
            if (type == BlockType.catus1)
            {
                /// state = new DamegeBlockState(SpriteFactory.sprites.catus1);
            }
            if (type == BlockType.catus2)
            {
                /// state = new DamageBlockState(SpriteFactory.sprites.catus2);
            }
            if(type == BlockType.sea)
            {
                /// state = new DamageBlockState(SpriteFactory.sprites.sea);
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
                /// state = new TrampolineBlockState(SpriteFactory.sprites.mushroom1); 
            }
            if(type == BlockType.mushroom2)
            {
                /// state = new TranpolineBlockState(SpriteFactory.sprites.mushroom2);
            }

            Block product = new Block(location, prize, state);
            return product;
        }
    }
}
