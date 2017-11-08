using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    class LeftMovingTeno:ITenoState
    {
        Teno teno;
        public IAnimatedSprite Sprite { get; set; }

        public LeftMovingTeno(Teno teno)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.leftMovingTeno);
            this.teno = teno;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void Up()
        {
            teno.state = new LeftJumpingTeno(teno);
        }
        public void Down()
        {
            teno.state = new LeftCrouchingTeno(teno);
        }
        public void GoLeft()
        {
        }
        public void GoRight()
        {
            teno.state = new RightMovingTeno(teno);
        }
        public void Idle()
        {
            teno.state = new LeftIdleTeno(teno);
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

