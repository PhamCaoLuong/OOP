using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class GroundState :ITenoPhysicsState
    {
        Game1 game;
        private Teno teno;
        private Vector2 speedDecayRate = new Vector2(0.76f, 0.70f);
        private float positionDtAdjust = 40;
        private float runMultiplier = 1.4f;

        public GroundState(Teno teno, Game1 game)
        {
            this.game = game;
            teno.state.Land();
            teno.velocity.Y = 0;
            this.teno = teno;
            game.gameHUD.pointMultiplier = 1;

            teno.isJumping = false;
            teno.isFalling = false;
        }
        public void Update(GameTime gameTime)
        {
            teno.velocity.Y = 0;
            teno.position += teno.velocity * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);

            teno.velocity *= speedDecayRate;
            if (Game1.GetInstance().level.collision.standingBlock.Count == 0 &&
                Game1.GetInstance().level.collision.standingHouse.Count == 0)
            {
                teno.physState = new FallingState(teno, game);
            } 
        }
        public void Run()
        {
            if (teno.velocity.X > teno.minVelocity.X && teno.velocity.X < teno.maxVelocity.X)
            {
                teno.velocity.X *= runMultiplier;
                teno.state.Sprite.UpdateSpeed-=2;
            }
        }
        public void Flip() { }
    }
}
