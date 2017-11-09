using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class LeftJumpingTeno:ITenoState
    {
        Game1 game;
        Teno teno;
        public IAnimatedSprite Sprite { get; set; }
        ISpriteFactory factory;
        public LeftJumpingTeno(Teno teno, Game1 game)
        {
            this.game = game;
            factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.leftJumpUpTeno);
            this.teno = teno;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void Up()
        {
        }
        public void Down()
        {
            teno.state = new LeftIdleTeno(teno, game);
        }
        public void GoLeft()
        {
        }
        public void GoRight()
        {
            teno.state = new RightJumpingTeno(teno, game);
        }
        public void Idle()
        {
            teno.state = new LeftIdleTeno(teno, game);
        }
        public void Land()
        {
            teno.state = new LeftMovingTeno(teno, game);
        }
        public void Fall()
        {
            //teno.state = new LeftFallingTeno(teno);
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
