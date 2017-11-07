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

            // title
            title,
        }

        public SpriteFactory() { }

        public IAnimatedSprite build(SpriteFactory.sprites sprite)
        {
            IAnimatedSprite product = null;

            //Enemies
            if(sprite == sprites.deadDino)
            {
                Texture2D deadDino = Game1.gameContent.Load<Texture2D>("deadDino");
                return new StaticSprite(deadDino);
            }
            ///......
            if (sprite == sprites.overwoldnightBackground)
            {
                Texture2D undergroundBackground = Game1.gameContent.Load<Texture2D>("undergroundBackground");
                return new OverwordNinghtBackgroundSprite(undergroundBackground, 1, 3);
            }
            if (sprite == sprites.leftMovingTeno)
            {
                Texture2D leftMovingTeno = Game1.gameContent.Load<Texture2D>("leftMovingTeno");
                return new TenoMovingSprite(leftMovingTeno, 1, 2);
            }
            return product;
        }
    }
}
