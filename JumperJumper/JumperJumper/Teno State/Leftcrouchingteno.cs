using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    class LeftCrouchingTeno:ITenoState
    {
        Teno teno;
        public IAnimatedSprite Sprite { get; set; }
        Game1 game;
        public LeftCrouchingTeno(Teno teno, Game1 game)
        {
            this.game = game;
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.leftSlidingTeno);
            this.teno = teno;
        
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            teno.state = new DeadTeno(teno, game);
        }

        public void Up()
        {
            teno.state = new LeftIdleTeno(teno, game);
        }
        public void Down()
        {
        }
        public void GoLeft()
        {
        }
        public void GoRight()
        {
            teno.state = new RightCrouchingTeno(teno, game);
        }
        public void Idle()
        {
            teno.state = new LeftIdleTeno(teno, game);
        }
        public void Land()
        {
        }
        public void Fall()
        {
        }
        public void MakeTeno()
        {
            // null
        }
        public void MakeDeadTeno()
        {
            teno.state = new DeadTeno(teno, game);
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
