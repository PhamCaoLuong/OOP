using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class FallingState : ITenoPhysicsState
    {
        private Teno teno;
        private Vector2 fallingVelocityDecayRate = new Vector2(.76f, 1);
        private Vector2 fallingVelocity = new Vector2(0, .65f);
        private float positionDtAdjust = 40;
        int fallAnimTimer = 5;
        bool isFallingSprite = false;
        Game1 game;

        public FallingState(Teno teno, Game1 game)
        {
            this.game = game;
            this.teno = teno;
            teno.isFalling = true;
            teno.isJumping = false;
        }
      
        public void Update(GameTime gameTime)
        {
            fallAnimTimer--;
            if (fallAnimTimer < 0 && !isFallingSprite)
            {
                teno.state.Fall();
                isFallingSprite = true;
            }
            if (teno.velocity.Y < teno.maxVelocity.Y)
            {
                teno.velocity += fallingVelocity;
            }
            teno.position += teno.velocity * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);
            teno.velocity *= fallingVelocityDecayRate;
            if(Game1.GetInstance().level.collision.standingBlock.Count > 0 ||
                Game1.GetInstance().level.collision.standingHouse.Count > 0)
            {
                teno.physState = new GroundState(teno, game);
            }
            if (teno.position.Y > ValueHolder.fallingMarioBoundary)
            {
                teno.state = new DeadTeno(teno,game);
                game.ach.AchievementAdjustment(AchievementsManager.AchievementType.Death);
            }       
        }
        public void Run() { }
        public void Flip() { }
    }
}
