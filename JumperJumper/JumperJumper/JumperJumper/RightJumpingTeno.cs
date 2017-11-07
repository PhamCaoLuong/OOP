using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    class RightJumpingTeno:ITenoState
    {
        Teno teno;
        public IAnimatedSprite Sprite { get; set; }
        ISpriteFactory factory;
        public RightJumpingTeno(Teno teno)
        {
            factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.rightJumpingTeno);
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
            teno.state = new RightIdleTeno(teno);
        }
        public void GoLeft()
        {
            teno.state = new RightJumpingTeno(teno);
        }
        public void GoRight()
        {
           
        }
        public void Idle()
        {
            teno.state = new RightIdleTeno(teno);
        }
        public void Land()
        {
            teno.state = new RightMovingTeno(teno);
        }
        public void Fall()
        {
            teno.state = new RightFallingTeno(teno);
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
