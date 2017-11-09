using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public class SpriteFactory : ISpriteFactory    // đã fix
    {
        public enum sprites
        {
            // Enemies
            /*deadDino, flyingDino, banzaiBill, leftDeadDino, walkingLeftSquishedDino, walkingLeftDino, walkingRightSquishedDino,
            walkingRightDino, deadShellessKoopa, leftWalkShellessKoopa, rightWalkShellessKoopa, deadBanzaiBill,*/
            leftGiaiTich, leftDeadGiaiTich, leftHoaDC, leftDeadHoaDC, leftLy2, OOP, leftPPT, leftDeadSXTK, leftSXTK,
            rightGiaiTich, rightDeadGiaiTich, rightHoaDC, rightDeadHoaDC, rightLy2, rightPPT, rightDeadSXTK, rightSXTK,
            // Items
            coin, star,
            // Blocks
            //spikeBlock, brickBlock, questionBlock, usedBlock, exclamationBlock, explosion, undergroundRoof, undergroundFloor,
            //undergroundRightTopCorner, undergroundLeftTopCorner, undergroundRightBottomCorner, undergroundLeftBottomCorner,

            gai, catus1, catus2, crate, stone1, stone2, stone3, stone4, stoneblock, sea, mushroom1,mushroom2, touchmushroom,
            // Background Items
            ground,  exit, exitBroken, castle, bush1, bush2, bush3 ,tree ,tree1, tree2, grass1, grass2, signArrow,
            exitSign, H1Background, H2Background, H3Background, H6Background, leftGround, centerGround, rightGround,
            // Teno
            /*leftCrouchingTeno, leftIdleTeno, leftJumpingTeno,
            leftMovingTeno, leftQuickturnTeno, leftShellKickTeno, leftSlidingTeno, rightCrouchingTeno,
            rightIdleTeno, rightJumpingTeno, rightMovingTeno,
            rightQuickturnTeno, rightShellKickTeno, victoryTeno, leftSprintTeno, rightSprintTeno,
            rightFallingTeno, leftFallingTeno, deadTeno,*/
            leftDeadTeno, leftIdleTeno, leftJumpFallTeno, leftJumpUpTeno, leftRunTeno, leftSlidingTeno, 
            rightDeadTeno, rightIdleTeno, rightJumpFallTeno, rightJumpUpTeno, rightRunTeno, rightSlidingTeno,
            // Trampoline
            trampoline,

            // title
            title,
        }

        public SpriteFactory() { }

        public IAnimatedSprite build(SpriteFactory.sprites sprite)
        {
            IAnimatedSprite product = null;

            //Enemies
            if (sprite == sprites.leftGiaiTich)
            {
                Texture2D leftGiaiTich = Game1.gameContent.Load<Texture2D>("Enemies/leftGiaiTich");
                return new MovingGiaiTich(leftGiaiTich, 1, 2);
            }
            if (sprite == sprites.leftDeadGiaiTich)
            {
                Texture2D deadGiaiTich = Game1.gameContent.Load<Texture2D>("Enemies/leftDeadGiaiTich");
                return new StaticSprite(deadGiaiTich);
            }
            if (sprite == sprites.rightGiaiTich)
            {
                Texture2D rightGiaiTich = Game1.gameContent.Load<Texture2D>("Enemies/rightGiaiTich");
                return new MovingGiaiTich(rightGiaiTich, 1, 2);
            }
            if (sprite == sprites.rightDeadGiaiTich)
            {
                Texture2D deadGiaiTich = Game1.gameContent.Load<Texture2D>("Enemies/rightDeadGiaiTich");
                return new StaticSprite(deadGiaiTich);
            }
            //
            if (sprite == sprites.leftHoaDC)
            {
                Texture2D leftHoaDC = Game1.gameContent.Load<Texture2D>("Enemies/leftHoaDC");
                return new MovingHoaDC(leftHoaDC, 1, 2);
            }
            if (sprite == sprites.leftDeadHoaDC)
            {
                Texture2D leftDeadHoaDC = Game1.gameContent.Load<Texture2D>("Enemies/leftDeadHoaDC");
                return new StaticSprite(leftDeadHoaDC);
            }
            if (sprite == sprites.rightHoaDC)
            {
                Texture2D rightHoaDC = Game1.gameContent.Load<Texture2D>("Enemies/rightHoaDC");
                return new MovingHoaDC(rightHoaDC, 1, 2);
            }
            if (sprite == sprites.rightDeadHoaDC)
            {
                Texture2D rightDeadHoaDC = Game1.gameContent.Load<Texture2D>("Enemies/rightDeadHoaDC");
                return new StaticSprite(rightDeadHoaDC);
            }
            //
            if (sprite == sprites.leftSXTK)
            {
                Texture2D leftSXTK = Game1.gameContent.Load<Texture2D>("Enemies/leftSXTK");
                return new MovingSXTK(leftSXTK, 1, 2);
            }
            if (sprite == sprites.leftDeadSXTK)
            {
                Texture2D deadSXTK = Game1.gameContent.Load<Texture2D>("Enemies/leftDeadSXTK");
                return new StaticSprite(deadSXTK);
            }
            if (sprite == sprites.rightSXTK)
            {
                Texture2D rightSXTK = Game1.gameContent.Load<Texture2D>("Enemies/rightSXTK");
                return new MovingSXTK(rightSXTK, 1, 2);
            }
            if (sprite == sprites.rightDeadSXTK)
            {
                Texture2D rightDeadSXTK = Game1.gameContent.Load<Texture2D>("Enemies/rightDeadSXTK");
                return new StaticSprite(rightDeadSXTK);
            }
            //
            if (sprite == sprites.leftLy2)
            {
                Texture2D leftLy2 = Game1.gameContent.Load<Texture2D>("Enemies/leftLy2");
                return new MovingLy2(leftLy2, 1, 2);
            }
            if (sprite == sprites.rightLy2)
            {
                Texture2D rightLy2 = Game1.gameContent.Load<Texture2D>("Enemies/rightLy2");
                return new MovingLy2(rightLy2, 1, 2);
            }
            //
            if (sprite == sprites.OOP)
            {
                Texture2D OOP = Game1.gameContent.Load<Texture2D>("Enemies/OOP");
                return new OOPChangning(OOP, 1, 8);
            }
            //
            if (sprite == sprites.leftPPT)
            {
                Texture2D ppt = Game1.gameContent.Load<Texture2D>("Enemies/leftPPT");
                return new MovingPPT(ppt, 1, 1);
            }
            if (sprite == sprites.rightPPT)
            {
                Texture2D ppt = Game1.gameContent.Load<Texture2D>("Enemies/rightPPT");
                return new MovingPPT(ppt, 1, 1);
            }


            /// Background 
            if (sprite == sprites.H1Background)
            {
                Texture2D H1Background = Game1.gameContent.Load<Texture2D>("background/H1background");
                return new OverwordNinghtBackgroundSprite(H1Background, 1, 3);
            }
            if (sprite == sprites.H2Background)
            {
                Texture2D H2Background = Game1.gameContent.Load<Texture2D>("background/H2background");
                return new OverwordNinghtBackgroundSprite(H2Background, 1, 3);
            }
            if (sprite == sprites.H3Background)
            {
                Texture2D H3Background = Game1.gameContent.Load<Texture2D>("background/H3background");
                return new OverwordNinghtBackgroundSprite(H3Background, 1, 3);
            }
            if (sprite == sprites.H6Background)
            {
                Texture2D H6Background = Game1.gameContent.Load<Texture2D>("background/H6background");
                return new OverwordNinghtBackgroundSprite(H6Background, 1, 3);
            }

            //***************************//
            // Teno
            if (sprite == sprites.leftRunTeno)
            {
                Texture2D leftRunTeno = Game1.gameContent.Load<Texture2D>("Teno/leftRunTeno");
                return new TenoMovingSprite(leftRunTeno, 1, 4);
            }
            if (sprite == sprites.leftIdleTeno)
            {
                Texture2D leftIdleTeno = Game1.gameContent.Load<Texture2D>("Teno/leftIdleTeno");
                return new TenoMovingSprite(leftIdleTeno, 1, 2);
            }
            if (sprite == sprites.leftJumpFallTeno)
            {
                Texture2D leftJumpFallTeno = Game1.gameContent.Load<Texture2D>("Teno/leftJumpFallTeno");
                return new StaticSprite(leftJumpFallTeno);
            }
            if (sprite == sprites.leftJumpUpTeno)
            {
                Texture2D leftJumpUpTeno = Game1.gameContent.Load<Texture2D>("Teno/leftJumpUpTeno");
                return new StaticSprite(leftJumpUpTeno);
            }
            if (sprite == sprites.leftSlidingTeno)
            {
                Texture2D leftSlidingTeno = Game1.gameContent.Load<Texture2D>("Teno/leftSlidingTeno");
                return new StaticSprite(leftSlidingTeno);
            }
            if(sprite == sprites.leftDeadTeno)
            {
                Texture2D leftDeadTeno = Game1.gameContent.Load<Texture2D>("Teno/leftDeadTeno");
                return new TenoMovingSprite(leftDeadTeno, 1, 3);
            }
            /// Right
            if (sprite == sprites.rightRunTeno)
            {
                Texture2D rightRunTeno = Game1.gameContent.Load<Texture2D>("Teno/rightRunTeno");
                return new TenoMovingSprite(rightRunTeno, 1, 4);
            }
            if (sprite == sprites.rightIdleTeno)
            {
                Texture2D rightIdleTeno = Game1.gameContent.Load<Texture2D>("Teno/rightIdleTeno");
                return new TenoMovingSprite(rightIdleTeno,1,2);
            }
            if (sprite == sprites.rightJumpFallTeno)
            {
                Texture2D rightJumpFallTeno = Game1.gameContent.Load<Texture2D>("Teno/rightJumpFallTeno");
                return new StaticSprite(rightJumpFallTeno);
            }
            if (sprite == sprites.rightJumpUpTeno)
            {
                Texture2D rightJumpUpTeno = Game1.gameContent.Load<Texture2D>("Teno/rightJumpUpTeno");
                return new StaticSprite(rightJumpUpTeno);
            }
            if (sprite == sprites.rightSlidingTeno)
            {
                Texture2D rightSlidingTeno = Game1.gameContent.Load<Texture2D>("Teno/rightSlidingTeno");
                return new StaticSprite(rightSlidingTeno);
            }
            if (sprite == sprites.rightDeadTeno)
            {
                Texture2D rightDeadTeno = Game1.gameContent.Load<Texture2D>("Teno/rightDeadTeno");
                return new TenoMovingSprite(rightDeadTeno, 1, 3);
            }



            // ITEMS
            if (sprite == sprites.star)
            {
                Texture2D star = Game1.gameContent.Load<Texture2D>("Item/star");
                return new CoinSprite(star, 1, 5);
            }

            if (sprite == sprites.bush1)
            {
                Texture2D bush1 = Game1.gameContent.Load<Texture2D>("Item/bush1");
                return new StaticSprite(bush1);
            }
            if (sprite == sprites.bush2)
            {
                Texture2D bush2 = Game1.gameContent.Load<Texture2D>("Item/bush2");
                return new StaticSprite(bush2);
            }
            if (sprite == sprites.bush3)
            {
                Texture2D bush3 = Game1.gameContent.Load<Texture2D>("Item/bush3");
                return new StaticSprite(bush3);
            }
            if(sprite == sprites.catus1)
            {
                Texture2D catus = Game1.gameContent.Load<Texture2D>("Item/cactus1");
                return new StaticSprite(catus);
            }
            if (sprite == sprites.catus2)
            {
                Texture2D catus = Game1.gameContent.Load<Texture2D>("Item/cactus2");
                return new StaticSprite(catus);
            }

            if(sprite == sprites.gai)
            {
                Texture2D gai = Game1.gameContent.Load<Texture2D>("Item/Gai");
                return new StaticSprite(gai);
            }

            // Blocks
            if (sprite == sprites.stoneblock)
            {
                Texture2D stoneblock = Game1.gameContent.Load<Texture2D>("Item/stoneblock");
                return new StaticSprite(stoneblock);
            }
            if (sprite == sprites.stone1)
            {
                Texture2D stone1 = Game1.gameContent.Load<Texture2D>("Item/stone1");
                return new StaticSprite(stone1);
            }
            if (sprite == sprites.stone2)
            {
                Texture2D stone2 = Game1.gameContent.Load<Texture2D>("Item/stone2");
                return new StaticSprite(stone2);
            }
            if (sprite == sprites.stone3)
            {
                Texture2D stone3 = Game1.gameContent.Load<Texture2D>("Item/stone3");
                return new StaticSprite(stone3);
            }
            if (sprite == sprites.stone4)
            {
                Texture2D stone4 = Game1.gameContent.Load<Texture2D>("Item/stone4");
                return new StaticSprite(stone4);
            }

            // tree
            if(sprite == sprites.tree)
            {
                Texture2D tree = Game1.gameContent.Load<Texture2D>("Item/Tree");
                return new StaticSprite(tree);
            }
            if (sprite == sprites.tree1)
            {
                Texture2D tree1 = Game1.gameContent.Load<Texture2D>("Item/Tree1");
                return new StaticSprite(tree1);
            }
            if (sprite == sprites.tree2)
            {
                Texture2D tree2 = Game1.gameContent.Load<Texture2D>("Item/Tree2");
                return new StaticSprite(tree2);
            }

            if(sprite == sprites.grass1)
            {
                Texture2D grass = Game1.gameContent.Load<Texture2D>("Item/Grass1");
                return new StaticSprite(grass);
            }
            if (sprite == sprites.grass2)
            {
                Texture2D grass = Game1.gameContent.Load<Texture2D>("Item/Grass2");
                return new StaticSprite(grass);
            }
            if(sprite == sprites.crate)
            {
                Texture2D crate = Game1.gameContent.Load<Texture2D>("Item/crate");
                return new StaticSprite(crate);
            }

            if(sprite == sprites.leftGround)
            {
                Texture2D ground = Game1.gameContent.Load<Texture2D>("Item/leftGround");
                return new StaticSprite(ground);
            }
            if (sprite == sprites.centerGround)
            {
                Texture2D ground = Game1.gameContent.Load<Texture2D>("Item/centerGround");
                return new StaticSprite(ground);
            }
            if (sprite == sprites.rightGround)
            {
                Texture2D ground = Game1.gameContent.Load<Texture2D>("Item/rightGround");
                return new StaticSprite(ground);
            }

            if(sprite == sprites.mushroom1)
            {
                Texture2D mushroom = Game1.gameContent.Load<Texture2D>("Item/Mushroom_1");
                return new StaticSprite(mushroom);
            }
            if (sprite == sprites.mushroom2)
            {
                Texture2D mushroom = Game1.gameContent.Load<Texture2D>("Item/Mushroom_2");
                return new StaticSprite(mushroom);
            }

            if(sprite == sprites.exit)
            {
                Texture2D exit = Game1.gameContent.Load<Texture2D>("Item/exit");
                return new StaticSprite(exit);
            }
            

            return product;
        }
    }
}
