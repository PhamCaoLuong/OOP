using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class GroundState :ITenoPhysicsState
    {
        private Teno teno;
        private Vector2 speedDecayRate = new Vector2(0.76f, 0.70f);
        private float positionDtAdjust = 40;
        private float runMultiplier = 1.4f;

        public GroundState(Teno teno)
        {
            teno.state.Land();
            teno.velocity.Y = 0;
            this.teno = teno;
            //Game1.GetInstance().gameHUD.pointMultiplier = 1;

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
                teno.physState = new FallingState(teno);
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
