using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class VVVVVVGroundState : ITenoPhysicsState
    {
        private Teno teno;
        private float speedDecayRate = .73f;
        private float positionDtAdjust = 20;
        private int positionShift = 7;
        private int gravityStrength = 3;
        Game1 game;

        public VVVVVVGroundState(Teno teno, int sign, Game1 game)
        {
            this.game = game;
            this.teno = teno;
            gravityStrength*=sign;
        }

        public void Update(GameTime gameTime)
        {
            teno.position.X += teno.velocity.X * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);
            teno.velocity.X *= speedDecayRate;
            teno.position.Y += gravityStrength;
        }

        public void Run() 
        {
        }

        public void Flip() {
            //SoundManager.flip.Play();
            teno.state.Flip();
            teno.gravityDirection = -teno.gravityDirection;
            teno.position.Y += positionShift*teno.gravityDirection;
            teno.physState = new VVVVVVAirState(teno, teno.gravityDirection, game);
        }
    }
}
