using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    class DeadTeno : ITenoState
    {
        Game1 game;
        Teno teno;
        public IAnimatedSprite Sprite { get; set; }

        public DeadTeno(Teno teno, Game1 game)
        {
            this.game = game;
            ISpriteFactory factory = new SpriteFactory();
            if(teno.state.GetType().Equals(new RightCrouchingTeno(teno, game).GetType()) || teno.state.GetType().Equals(new RightFallingTeno(teno, game).GetType())
                || teno.state.GetType().Equals(new RightIdleTeno(teno, game).GetType()) || teno.state.GetType().Equals(new RightJumpingTeno(teno, game).GetType())
                || teno.state.GetType().Equals(new RightMovingTeno(teno, game).GetType()))
                Sprite = factory.build(SpriteFactory.sprites.rightDeadTeno);
            else
                Sprite = factory.build(SpriteFactory.sprites.leftDeadTeno);
            this.teno = teno;
            game.gameState = new DeadGameState(teno, game);
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }
        public void TakeDamage()
        {
        }
        public void Up()
        {
        }
        public void Down()
        {
        }
        public void GoLeft()
        {
        }
        public void GoRight()
        {
        }
        public void Idle()
        {
        }
        public void Land()
        {
        }
        public void Fall()
        {
        }
        public void MakeTeno()
        {
        }

        public void MakeDeadTeno()
        {
        }
        public void Flip() { }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Sprite.Draw(spriteBatch, location, color);
        }
    }
}
