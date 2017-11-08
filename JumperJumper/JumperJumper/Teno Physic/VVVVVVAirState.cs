using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class VVVVVVAirState : ITenoPhysicsState
    {
        private Teno teno;
        private float speedDecayRate = .73f;
        private float positionDtAdjust = 20;
        private int gravityStrength = 4;

        public VVVVVVAirState(Teno teno, int sign)
        {
            this.teno = teno;
            gravityStrength *= sign;
        }

        public void Update(GameTime gameTime)
        {
            teno.position.X += teno.velocity.X * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);
            teno.velocity.X *= speedDecayRate;
            teno.position.Y += gravityStrength;
            if (Game1.GetInstance().level.collision.standingBlock.Count > 0)
            {
                teno.physState = new VVVVVVGroundState(teno, teno.gravityDirection);
            }
        }

        public void Run() {
        }

        public void Flip() {
        }
    }
}
