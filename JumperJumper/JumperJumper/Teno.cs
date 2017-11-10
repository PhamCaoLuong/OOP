using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public class Teno
    {
        public ITenoState state;
        public ITenoPhysicsState physState;
        public bool isLeft = false, isFalling = false, isJumping = false,
            isDead = false, isCrouch = false;
        public int gravityDirection = -1;
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 maxVelocity = new Vector2(6, 15);
        public Vector2 minVelocity = new Vector2(-6, -3.5f);
        public int tenoHight = 0;
        private SpriteFactory factory;
        private int modVal = 5;
        Game1 game;

        public Teno(Vector2 position, Game1 game)
        {
            this.game = game;
            state = new RightIdleTeno(this, game);
            physState = new GroundState(this, game);
            this.position = position;
            factory = new SpriteFactory();
        }

        public void Jump()
        {
            if(velocity.Y > minVelocity.Y && !isFalling)
            {
                physState = new JumpingState(this, game);
                state = new RightJumpingTeno(game.level.teno, game);
                velocity.Y -= ValueHolder.jumpingVelocity;
                state.Up();
            }
        }

        public void Fall()
        {
            physState = new FallingState(this, game);
            state = new RightFallingTeno(game.level.teno, game);
            velocity.Y += ValueHolder.jumpingVelocity;
            state.Down();
        }

        public void Crouch()
        {
            state.Down();
            velocity.Y += .1f;
            isCrouch = true;
        }

        public void GoLeft()
        {
            if (!isCrouch)
            {
                state.GoLeft();
                if (velocity.X > minVelocity.X)
                {
                    velocity.X -= ValueHolder.walkingVelocity;
                }
            }
            isLeft = true;
        }

        public void Idle()
        {
            if ((velocity.X < ValueHolder.rightTenoIdlingRange.X && velocity.X > ValueHolder.leftTenoIdlingRange.X) &&
            (velocity.Y < ValueHolder.rightTenoIdlingRange.Y && velocity.Y > ValueHolder.leftTenoIdlingRange.Y) &&
            !isFalling)
            {
                state.Idle();
                isCrouch = false;
            }
        }
        public void GoRight()
        {
            if (!isCrouch)
            {
                state.GoRight();
                if (velocity.X < maxVelocity.X)
                {
                    velocity.X += ValueHolder.walkingVelocity;
                }
            }
            isLeft = false;
        }

        public void MakeVictoryTeno()
        {
            //state.Sprite = factory.build(SpriteFactory.sprites.victoryTeno);
        }


        public void Respawn()
        {
            state = new RightIdleTeno(this, game);
            physState = new VVVVVVGroundState(this, 1, game);
            gravityDirection = 1;
            position = game.level.checkpoint;
        }

        public void Update(GameTime gametime)
        {
            if(game.level.collision.standingBlock == null)
                physState = new FallingState(this, game);
            state.Update(gametime);
            physState.Update(gametime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch, position, Color.Gold);
        }

        public void MakeTeno()
        {
            state.MakeTeno();
        }
        public void MakeDeadTeno()
        {
            state = new DeadTeno(this, game);
        }
        public void TransitionState(ITenoState prevState, ITenoState newState)
        {
            game.gameState = new TrasitionGameState(this, prevState, newState, game);
        }

    }
}
