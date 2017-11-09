using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public class SpriteFactory : ISpriteFactory
    {
        public enum sprites
        {
            // Enemies
            /*deadDino, flyingDino, banzaiBill, leftDeadDino, walkingLeftSquishedDino, walkingLeftDino, walkingRightSquishedDino,
            walkingRightDino, deadShellessKoopa, leftWalkShellessKoopa, rightWalkShellessKoopa, deadBanzaiBill,*/
            leftGiaiTich, deadGiaiTich, leftHoaDC, deadHoaDC, leftLy2, OOP, PPT, rightSXTK, deadSXTK,
            // Items
            coin,// heathy, level, star, moon,
            // Blocks
            //spikeBlock, brickBlock, questionBlock, usedBlock, exclamationBlock, explosion, undergroundRoof, undergroundFloor,
            //undergroundRightTopCorner, undergroundLeftTopCorner, undergroundRightBottomCorner, undergroundLeftBottomCorner,

            catus1, catus2, crate, stone1, stone2, stone3, stone4, stoneblock, sea, mushroom1,mushroom2, touchmushroom,
            // Background Items
            ground,  exit, exitBroken, castle, bush1, tree ,tree1, tree2, grass1, grass2, signArrow,
            exitSign, H1Background, H2Background, H3Background, H6Background,
            // Teno
            leftCrouchingTeno, leftIdleTeno, leftJumpingTeno,
            leftMovingTeno, leftQuickturnTeno, leftShellKickTeno, leftSlidingTeno, rightCrouchingTeno,
            rightIdleTeno, rightJumpingTeno, rightMovingTeno,
            rightQuickturnTeno, rightShellKickTeno, victoryTeno, leftSprintTeno, rightSprintTeno,
            rightFallingTeno, leftFallingTeno, deadTeno,
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
                return new StaticSprite(banzaiBill);
            }
            if (sprite == sprites.deadGiaiTich)
            {
                Texture2D deadGiaiTich = Game1.gameContent.Load<Texture2D>("Enemies/deadGiaiTich");
                return new StaticSprite(deadBanzaiBill);
            }
            if (sprite == sprites.leftHoaDC)
            {
                Texture2D leftHoaDC = Game1.gameContent.Load<Texture2D>("Enemies/leftHoaDC");
                return new LeftTallDino(leftTallDino, 1, 2);
            }
            if (sprite == sprites.deadHoaDC)
            {
                Texture2D deadHoaDC = Game1.gameContent.Load<Texture2D>("Enemies/deadHoaDC");
                return new StaticSprite(leftDeadDino);
            }
            if (sprite == sprites.leftLy2)
            {
                Texture2D leftLy2 = Game1.gameContent.Load<Texture2D>("Enemies/leftLy2");
                return new LeftSmashedDino(leftSquishedDino, 1, 2);
            }
            if (sprite == sprites.OOP)
            {
                Texture2D OOP = Game1.gameContent.Load<Texture2D>("Enemies/OOP");
                return new RightTallDino(rightTallDino, 1, 2);
            }
            if (sprite == sprites.rightSXTK)
            {
                Texture2D rightSXTK = Game1.gameContent.Load<Texture2D>("Enemies/rightSXTK");
                return new RightSmashedDino(rightSquishedDino, 1, 2);
            }
            if (sprite == sprites.deadSXTK)
            {
                Texture2D deadSXTK = Game1.gameContent.Load<Texture2D>("Enemies/deadSXTK");
                return new StaticSprite(deadShellessKoopa);
            }


            /// Background 
            if (sprite == sprites.H1Background)
            {
                Texture2D H1Background = Game1.gameContent.Load<Texture2D>("background/H1Background");
                return new OverwordNinghtBackgroundSprite(undergroundBackground, 1, 3);
            }
            if (sprite == sprites.H2Background)
            {
                Texture2D H1Background = Game1.gameContent.Load<Texture2D>("background/H2Background");
                return new OverwordNinghtBackgroundSprite(undergroundBackground, 1, 3);
            }
            if (sprite == sprites.H3Background)
            {
                Texture2D H1Background = Game1.gameContent.Load<Texture2D>("background/H3Background");
                return new OverwordNinghtBackgroundSprite(undergroundBackground, 1, 3);
            }
            if (sprite == sprites.H6Background)
            {
                Texture2D H1Background = Game1.gameContent.Load<Texture2D>("background/H6Background");
                return new OverwordNinghtBackgroundSprite(undergroundBackground, 1, 3);
            }

            //***************************//
            // Teno
            if (sprite == sprites.leftMovingTeno)
            {
                Texture2D leftMovingTeno = Game1.gameContent.Load<Texture2D>("leftMovingTeno");
                return new TenoMovingSprite(leftMovingTeno, 1, 2);
            }



            if (sprite == sprites.leftCrouchingTeno)
            {
                Texture2D leftCrouchingTeno = Game1.gameContent.Load<Texture2D>("");
                return new StaticSprite(leftCrouchingTeno);
            }
            if (sprite == sprites.leftIdleTeno)
            {
                Texture2D leftIdleTeno = Game1.gameContent.Load<Texture2D>("");
                return new StaticSprite(leftIdleTeno);
            }
            if (sprite == sprites.leftJumpingTeno)
            {
                Texture2D leftJumpingTeno = Game1.gameContent.Load<Texture2D>("");
                return new StaticSprite(leftJumpingTeno);
            }
            if (sprite == sprites.leftMovingTeno)
            {
                Texture2D leftMovingTeno = Game1.gameContent.Load<Texture2D>("");
                return new TenoMovingSprite(leftMovingTeno, 1, 3);
            }
            if (sprite == sprites.rightCrouchingTeno)
            {
                Texture2D rightCrouchingTeno = Game1.gameContent.Load<Texture2D>("");
                return new StaticSprite(rightCrouchingTeno);
            }
            if (sprite == sprites.rightIdleTeno)
            {
                Texture2D rightIdleTeno = Game1.gameContent.Load<Texture2D>("");
                return new StaticSprite(rightIdleTeno);
            }
            if (sprite == sprites.rightJumpingTeno)
            {
                Texture2D rightJumpingTeno = Game1.gameContent.Load<Texture2D>("");
                return new StaticSprite(rightJumpingTeno);
            }
            if (sprite == sprites.rightMovingTeno)
            {
                Texture2D rightMovingTeno = Game1.gameContent.Load<Texture2D>("");
                return new TenoMovingSprite(rightMovingTeno, 1, 3);
            }
            if (sprite == sprites.rightSprintTeno)
            {
                Texture2D rightSprintTeno = Game1.gameContent.Load<Texture2D>("");
                return new TenoMovingSprite(rightSprintTeno, 1, 3);
            }
            if (sprite == sprites.leftSprintTeno)
            {
                Texture2D leftSprintTeno = Game1.gameContent.Load<Texture2D>("");
                return new TenoMovingSprite(leftSprintTeno, 1, 3);
            }
            if (sprite == sprites.victoryTeno)
            {
                Texture2D victoryTeno = Game1.gameContent.Load<Texture2D>("");
                return new StaticSprite(victoryTeno);
            }
            if (sprite == sprites.rightFallingTeno)
            {
                Texture2D rightFallingTeno = Game1.gameContent.Load<Texture2D>("");
                return new StaticSprite(rightFallingTeno);
            }
            if (sprite == sprites.leftFallingTeno)
            {
                Texture2D leftFallingTeno = Game1.gameContent.Load<Texture2D>("");
                return new StaticSprite(leftFallingTeno);
            }

            // Blocks
            if(sprite == sprites.stoneblock)
            {
                Texture2D stoneblock = Game1.gameContent.Load<Texture2D>("Item/stoneblock");
            }

            return product;
        }
    }
}
