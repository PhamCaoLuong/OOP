using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    class LeftJumpingTeno:ITenoState
    {
        Teno teno;
        public IAnimatedSprite Sprite { get; set; }
        ISpriteFactory factory;
        public LeftJumpingTeno(Teno teno)
        {
            factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.leftJumpingTeno);
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
            teno.state = new LeftIdleTeno(teno);
        }
        public void GoLeft()
        {
        }
        public void GoRight()
        {
            teno.state = new RightJumpingTeno(teno);
        }
        public void Idle()
        {
            teno.state = new LeftIdleTeno(teno);
        }
        public void Land()
        {
            teno.state = new LeftMovingTeno(teno);
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
            teno.state = new DeadTeno(teno);
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
