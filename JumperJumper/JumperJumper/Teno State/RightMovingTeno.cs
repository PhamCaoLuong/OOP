using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    class RightMovingTeno : ITenoState
    {
        Game1 game;
        Teno teno;
        public IAnimatedSprite Sprite { get; set; }

        public RightMovingTeno(Teno teno, Game1 game)
        {
            this.game = game;
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.rightRunTeno);
            this.teno = teno;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }
        public void TakeDamage()
        {
            MakeDeadTeno();
        }
        public void Up()
        {
            teno.state = new RightJumpingTeno(teno, game);
        }
        public void Down()
        {
            teno.state = new RightCrouchingTeno(teno,game);
        }
        public void GoLeft()
        {
            teno.state = new LeftMovingTeno(teno, game);
        }
        public void GoRight()
        {
            
        }
        public void Idle()
        {
            teno.state = new RightIdleTeno(teno, game);
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

