using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    class DeadTeno:ITenoState
    {
        Teno teno;
        public IAnimatedSprite Sprite { get; set; }

        public DeadTeno(Teno teno)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.deadTeno);
            this.teno = teno;
            Game1.GetInstance().gameState = new DeadGameState(teno);
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
