using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    class RightCrouchingTeno:ITenoState
    {
        Teno teno;
        public IAnimatedSprite Sprite { get; set; }
        public RightCrouchingTeno(Teno teno)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.rightCrouchingTeno);
            this.teno = teno;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }
        public void Up()
        {
            teno.state = new RightIdleTeno(teno);
        }
        public void Down()
        {
        }
        public void GoLeft()
        {
            teno.state = new LeftCrouchingTeno(teno);
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
