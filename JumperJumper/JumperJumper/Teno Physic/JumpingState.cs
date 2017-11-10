using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class JumpingState : ITenoPhysicsState
    {
        private Teno teno;
        private Vector2 speedDecayRate = new Vector2(.76f, .5f);
        private static int maxJumpHeight = 150;
        private static int heightIncrement = 7;
        private double minJumpingVelocity = -.005;
        private double maxJumpVelocity = -1;
        private float positionXDtAdjust = 40;
        private float positionYDtAdjust = 17;
        Game1 game;
        public JumpingState(Teno teno, Game1 game)
        {
            this.game = game;
            this.teno = teno;
            teno.isJumping = true;
            game.level.collision.standingBlock.Clear();
        }

        public void Update(GameTime gameTime)
        {
            teno.position.Y += teno.velocity.Y * ((float)gameTime.ElapsedGameTime.Milliseconds / positionYDtAdjust);
            teno.position.X += teno.velocity.X * ((float)gameTime.ElapsedGameTime.Milliseconds / positionXDtAdjust);
            teno.velocity *= speedDecayRate;
            teno.tenoHight += heightIncrement;
            if (teno.velocity.Y > maxJumpVelocity) { 
                teno.velocity.Y =0; 
            }
            if (teno.velocity.Y > minJumpingVelocity || teno.tenoHight > maxJumpHeight)
            {
                teno.physState = new FallingState(teno, game);
                teno.tenoHight = 0;
            }
        }
        public void Run() { }
        public void Flip() { }
    }
}
