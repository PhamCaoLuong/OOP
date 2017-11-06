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
            deadDino, flyingDino,
            leftDeadDino, rightDeadDino, walkingLeftDino, walkingRightDino,
            walkingRightSquishedDino, walkingLeftSquishedDino, deadShellessKoopa, leftWalkShellessKoopa, rightWalkShellessKoopa,
            banzaiBill, deadBanzaiBill, upSpike, downSpike,
            // Items
            coin, heathy, level, star, moon,
            // Blocks
            spikeBlock, brickBlock, questionBlock, usedBlock, exclamationBlock,
            // Background Items
            house1, house2, house3, house4, house5, exitSign,
            ground, overwoldnightBackground, exit, exitBroken, castle, explosion,
            // Teno
            leftCrouchingTeno, leftIdleTeno, leftJumpingTeno,
            leftMovingTeno, leftQuickturnTeno, leftShellKickTeno, leftSlidingTeno, rightCrouchingTeno,
            rightIdleTeno, rightJumpingTeno, rightMovingTeno,
            rightQuickturnTeno, rightShellKickTeno, victoryTeno, leftSprintTeno, rightSprintTeno,
            rightFallingTeno, leftFallingTeno, deadTeno,
            // Trampoline
            trampoline,
        }

        public SpriteFactory() { }

        public IAnimatedSprite build(SpriteFactory.sprites sprite)
        {
            IAnimatedSprite product = null;

            //Enemies
            if (sprite == sprites.banzaiBill)
            {
                Texture2D banzaiBill = Game1.gameContent.Load<Texture2D>("");
                return new StaticSprite(banzaiBill);
            }
            if (sprite == sprites.deadBanzaiBill)
            {
                Texture2D deadBanzaiBill = Game1.gameContent.Load<Texture2D>("");
                return new StaticSprite(deadBanzaiBill);
            }
            if (sprite == sprites.walkingLeftDino)
            {
                Texture2D leftTallDino = Game1.gameContent.Load<Texture2D>("");
                return new LeftTallDino(leftTallDino, 1, 2);
            }
            if (sprite == sprites.leftDeadDino)
            {
                Texture2D leftDeadDino = Game1.gameContent.Load<Texture2D>("");
                return new StaticSprite(leftDeadDino);
            }
            if (sprite == sprites.walkingLeftSquishedDino)
            {
                Texture2D leftSquishedDino = Game1.gameContent.Load<Texture2D>("");
                return new LeftSmashedDino(leftSquishedDino, 1, 2);
            }
            if (sprite == sprites.walkingRightDino)
            {
                Texture2D rightTallDino = Game1.gameContent.Load<Texture2D>("");
                return new RightTallDino(rightTallDino, 1, 2);
            }
            if (sprite == sprites.walkingRightSquishedDino)
            {
                Texture2D rightSquishedDino = Game1.gameContent.Load<Texture2D>("");
                return new RightSmashedDino(rightSquishedDino, 1, 2);
            }
            if (sprite == sprites.deadShellessKoopa)
            {
                Texture2D deadShellessKoopa = Game1.gameContent.Load<Texture2D>("");
                return new StaticSprite(deadShellessKoopa);
            }
            if (sprite == sprites.leftWalkShellessKoopa)
            {
                Texture2D leftShellessKoopa = Game1.gameContent.Load<Texture2D>("");
                return new LeftWalkingShellessKoopa(leftShellessKoopa, 1, 2);
            }
            if (sprite == sprites.rightWalkShellessKoopa)
            {
                Texture2D rightShellessKoopa = Game1.gameContent.Load<Texture2D>("");
                return new RightWalkingShellessKoopa(rightShellessKoopa, 1, 2);
            }


            ///......
            if (sprite == sprites.overwoldnightBackground)
            {
                Texture2D undergroundBackground = Game1.gameContent.Load<Texture2D>("undergroundBackground");
                return new OverwordNinghtBackgroundSprite(undergroundBackground, 1, 3);
            }


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
            return product;
        }
    }
}
